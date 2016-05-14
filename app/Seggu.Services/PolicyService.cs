﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Seggu.Services
{
    public sealed class PolicyService : IPolicyService
    {
        private IPolicyDao policyDao;
        private IVehicleDao vehicleDao;
        private IFeeDao feeDao;
        private IAddressDao addressDao;

        public PolicyService(IPolicyDao policyDao, IVehicleDao vehicleDao, IFeeDao feeDao, IAddressDao addressDao)
        {
            this.policyDao = policyDao;
            this.vehicleDao = vehicleDao;
            this.feeDao = feeDao;
            this.addressDao = addressDao;
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
            var policies = this.policyDao.GetValidsByClient(id);
            return policies.Select(p => new PolicyGridItemDto { Id = (int)p.Id, Name = p.Number, EndDate = p.EndDate });
        }
        public IEnumerable<PolicyGridItemDto> GetNotValidsByClient(long clientId)
        {
            var id = clientId;
            var policies = this.policyDao.GetNotValidsByClient(id).OrderByDescending(x => x.EndDate);
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
                //.Select(x => PolicyDtoMapper.GetFullDto(x));
        }

        public void SavePolicy(PolicyFullDto pol)
        {
            if (pol.Fees != null)
                if (pol.Fees.Count() > 0)
                    foreach (var fee in pol.Fees) { }
            //fee.Id = fee.Id== default(int) ? Guid.NewGuid().ToString() : fee.Id;

            if (pol.Vehicles != null)
                foreach (var vehicle in pol.Vehicles)
                {
                    //vehicle.Id = string.IsNullOrEmpty(vehicle.Id) ? Guid.NewGuid().ToString() : vehicle.Id;
                    if (vehicle.Accessories != null)
                        foreach (var accessory in vehicle.Accessories)
                        {
                            //accessory.Id = string.IsNullOrEmpty(accessory.Id) ? Guid.NewGuid().ToString() : accessory.Id;
                            accessory.VehicleId = vehicle.Id;
                        }
                }
            else if (pol.Employees != null)
                foreach (var employee in pol.Employees) { }
            //employee.Id = string.IsNullOrEmpty(employee.Id) ? Guid.NewGuid().ToString() : employee.Id;
            else if (pol.Integrals != null)
                foreach (var integral in pol.Integrals)
                {
                    //integral.Id = string.IsNullOrEmpty(integral.Id) ? Guid.NewGuid().ToString() : integral.Id;
                    //integral.Address.Id = string.IsNullOrEmpty(integral.Address.Id) ?
                    //Guid.NewGuid().ToString() : integral.Address.Id;
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
                    this.AddCoveragesToIntegral(policy);
                policyDao.Save(policy);
            }
            else
            {
                if (policy.Vehicles != null)
                    foreach (var vehicle in policy.Vehicles)
                        vehicle.PolicyId = policy.Id;
                else if (policy.Employees != null)
                    foreach (var employee in policy.Employees)
                        employee.PolicyId = policy.Id;
                else if (policy.Integrals != null)
                {
                    foreach (var integral in policy.Integrals)
                    {
                        integral.PolicyId = policy.Id;
                    }
                }
                policyDao.Edit(policy);
            }
        }
        private void AddCoveragesToIntegral(Policy policy)
        {
            foreach (var integral in policy.Integrals)
            {
                var coverages = new List<Coverage>();
                foreach (var coverage in integral.Coverages)
                    coverages.Add(this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id));
                integral.Coverages = coverages;
            }
        }
        private void AddCoveragesToVehicles(Policy policy)
        {
            foreach (var vehicle in policy.Vehicles)
            {
                var coverages = new List<Coverage>();
                foreach (var coverage in vehicle.Coverages)
                    coverages.Add(this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id));
                vehicle.Coverages = coverages;
            }
        }
        private void AddCoveragesToEmployees(Policy policy)
        {
            foreach (var employee in policy.Employees)
            {
                var coverages = new List<Coverage>();
                foreach (var coverage in employee.Coverages)
                    coverages.Add(this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id));
                employee.Coverages = coverages;
            }
        }
        public IEnumerable<PolicyRosViewDto> GetRosView(DateTime from, DateTime to)
        {
            var policies = this.policyDao.GetRosView(from, to);
            return policies.Select(obj => PolicyDtoMapper.GetRosView(obj));
        }
    }
}
