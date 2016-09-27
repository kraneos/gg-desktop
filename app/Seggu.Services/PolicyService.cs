using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class PolicyService : IPolicyService
    {
        private readonly IPolicyDao policyDao;
        private IVehicleDao vehicleDao;
        private IFeeDao feeDao;
        private IAddressDao addressDao;
        private IAttachedFileDao attachedFilesDao;

        public PolicyService(IPolicyDao policyDao, IVehicleDao vehicleDao, IFeeDao feeDao, IAddressDao addressDao, IAttachedFileDao attachedFilesDao)
        {
            this.policyDao = policyDao;
            this.vehicleDao = vehicleDao;
            this.feeDao = feeDao;
            this.addressDao = addressDao;
            this.attachedFilesDao = attachedFilesDao;
        }
        public PolicyFullDto GetById(long policyId)
        {
            var id = policyId;
            var policy = policyDao.Get(id);
            return PolicyDtoMapper.GetFullDto(policy);
        }

        public IEnumerable<PolicyGridItemDto> GetValidsByClient(long clientId)
        {
            var id = clientId;
            var policies = policyDao.GetValidsByClient(id);
            return policies.Select(p => new PolicyGridItemDto { Id = (int)p.Id, Name = p.Number, EndDate = p.EndDate });
        }
        public IEnumerable<PolicyGridItemDto> GetNotValidsByClient(long clientId)
        {
            var id = clientId;
            var policies = policyDao.GetNotValidsByClient(id).OrderByDescending(x => x.EndDate);
            return policies.Select(p => new PolicyGridItemDto { Id = (int)p.Id, Name = p.Number, EndDate = p.EndDate });//dto mapper???
        }
        public IEnumerable<PolicyGridItemDto> GetByPlate(string plate)
        {
            return policyDao.GetByVehiclePlate(plate).OrderByDescending(x => x.EndDate)
                .Select(p => new PolicyGridItemDto { Id = (int)p.Id, Name = p.Number, EndDate = p.EndDate });
        }
        public IEnumerable<PolicyGridItemDto> GetByPolicyNumber(string polNum)
        {
            return policyDao.GetByPolicyNumber(polNum).OrderByDescending(x => x.EndDate)
                .Select(p => new PolicyGridItemDto { Id = (int)p.Id, Name = p.Number, EndDate = p.EndDate });
        }

        public void SavePolicy(PolicyFullDto pol)
        {
            if (pol.Vehicles != null)
                foreach (var vehicle in pol.Vehicles)
                {
                    if (vehicle.Accessories == null) continue;
                    foreach (var accessory in vehicle.Accessories)
                    {
                        accessory.VehicleId = vehicle.Id;
                    }
                }

            var policy = PolicyDtoMapper.GetObjectWithCover(pol);
            var isNew = pol.Id == default(int);
            if (isNew)
            {
                if (policy.Vehicles != null)
                    AddCoveragesToVehicles(policy);
                else if (policy.Employees != null)
                    AddCoveragesToEmployees(policy);
                else if (policy.Integrals != null)
                    AddCoveragesToIntegral(policy);
                policyDao.Save(policy);
            }
            else
            {
                var existingAttachedFiles = attachedFilesDao.GetByPolicyId(pol.Id);
                var attachedFilesToRemove = existingAttachedFiles.Where(x => !policy.AttachedFiles.Any(y => y.FilePath == x.FilePath));
                attachedFilesDao.DeleteMany(attachedFilesToRemove);
                if (policy.Vehicles != null)
                    foreach (var vehicle in policy.Vehicles)
                        vehicle.PolicyId = policy.Id;
                else if (policy.Employees != null)
                    foreach (var employee in policy.Employees)
                        employee.PolicyId = policy.Id;
                else if (policy.Integrals != null)
                    foreach (var integral in policy.Integrals)
                        integral.PolicyId = policy.Id;
                policyDao.Edit(policy);
            }
        }
        private void AddCoveragesToIntegral(Policy policy)
        {
            foreach (var integral in policy.Integrals)
            {
                var coverages = integral.Coverages.Select(coverage => this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id)).ToList();
                integral.Coverages = coverages;
            }
        }
        private void AddCoveragesToVehicles(Policy policy)
        {
            foreach (var vehicle in policy.Vehicles)
            {
                var coverages = vehicle.Coverages.Select(coverage => this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id)).ToList();
                vehicle.Coverages = coverages;
            }
        }
        private void AddCoveragesToEmployees(Policy policy)
        {
            foreach (var employee in policy.Employees)
            {
                var coverages = employee.Coverages.Select(coverage => this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id)).ToList();
                employee.Coverages = coverages;
            }
        }
        public IEnumerable<PolicyRosViewDto> GetRosView(DateTime from, DateTime to)
        {
            var policies = policyDao.GetRosView(from, to);
            return policies.Select(PolicyDtoMapper.GetRosView);
        }
    }
}
