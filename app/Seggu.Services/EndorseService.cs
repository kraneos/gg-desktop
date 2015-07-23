using iTextSharp.text;
using iTextSharp.text.pdf;
using Seggu.Daos.Interfaces;
using Seggu.Data;
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
    public sealed class EndorseService : IEndorseService
    {
        private IEndorseDao endorseDao;
        private IPolicyDao policyDao;
        public EndorseService(IEndorseDao endorseDao, IPolicyDao policyDao)
        {
            this.endorseDao = endorseDao;
            this.policyDao = policyDao;
        }

        public IEnumerable<EndorseDto> GetByPolicyId(string Id)
        {
            var polId = new Guid(Id);
            var endorses = endorseDao.GetByPolicyId(polId);
            return endorses.Select(e => EndorseDtoMapper.GetDto(e));
        }

        public void Save(EndorseFullDto endorseFull)
        {
            if (endorseFull.Fees != null)
                SetFeesIds(endorseFull);

            if (endorseFull.Vehicles != null)
                SetVehiclesIds(endorseFull);
            else if (endorseFull.Employees != null)
                SetEmployeesIds(endorseFull);

            var endorse = EndorseDtoMapper.GetObjectWithCover(endorseFull);
            bool isNew = string.IsNullOrEmpty(endorseFull.Id);

            bool isAnnulated = endorse.EndorseType == Seggu.Data.EndorseType.Anulación;
            if (isAnnulated)
                this.AnnulateEndorseChilds(endorse);

            if (isNew)
            {
                if (endorse.Vehicles != null)
                    AddCoveragesToVehicles(endorse);
                else if (endorse.Employees != null)
                    AddCoveragesToEmployees(endorse);
                endorseDao.Save(endorse);
            }
            else
            {
                if (endorse.Vehicles != null)
                    foreach (var vehicle in endorse.Vehicles)
                        vehicle.EndorseId = endorse.Id;
                else if (endorse.Employees != null)
                    foreach (var employee in endorse.Employees)
                        employee.EndorseId = endorse.Id;
                endorseDao.Edit(endorse);
            }
        }
            private static void SetFeesIds(EndorseFullDto endorseFull)
            {
                foreach (var fee in endorseFull.Fees)
                    fee.Id = string.IsNullOrEmpty(fee.Id) ? Guid.NewGuid().ToString() : fee.Id;
            }
            private static void SetVehiclesIds(EndorseFullDto endorseFull)
            {
                foreach (var vehicle in endorseFull.Vehicles)
                    vehicle.Id = string.IsNullOrEmpty(vehicle.Id) ? Guid.NewGuid().ToString() : vehicle.Id;
            }
            private static void SetEmployeesIds(EndorseFullDto endorseFull)
            {
                foreach (var employee in endorseFull.Employees)
                    employee.Id = string.IsNullOrEmpty(employee.Id) ? Guid.NewGuid().ToString() : employee.Id;
            }
            private void AddCoveragesToVehicles(Endorse endorse)
            {
                foreach (var vehicle in endorse.Vehicles)
                {
                    var coverages = new List<Coverage>();
                    foreach (var coverage in vehicle.Coverages)
                        coverages.Add(this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id));
                    vehicle.Coverages = coverages;
                }
            }
            private void AddCoveragesToEmployees(Endorse endorse)
            {
                foreach (var employee in endorse.Employees)
                {
                    var coverages = new List<Coverage>();
                    foreach (var coverage in employee.Coverages)
                        coverages.Add(this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id));
                    employee.Coverages = coverages;
                }
            }


        private void AnnulateEndorseChilds(Seggu.Data.Endorse endorse)
        {
            endorse.AnnulationDate = DateTime.Today;
            endorse.IsAnnulled = true;

            var policy = policyDao.Get(endorse.PolicyId);
            policy.AnnulationDate = DateTime.Today;
            policy.IsAnnulled = true;
            if (policy.Fees.Count > 0)
                foreach(var fee in policy.Fees)
                    fee.Annulated = true;
            policyDao.Update(policy);
        }
    }
}
