using iTextSharp.text;
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
    public sealed class EndorseService : IEndorseService
    {
        private IEndorseDao endorseDao;
        private IPolicyDao policyDao;
        public EndorseService(IEndorseDao endorseDao, IPolicyDao policyDao)
        {
            this.endorseDao = endorseDao;
            this.policyDao = policyDao;
        }

        public void Save(EndorseFullDto endorseFull)
        {
            var endorse = EndorseDtoMapper.GetObjectWithCover(endorseFull);
            SetChildrenToNull(endorse);
            bool isNew = endorseFull.Id == default(int);

            bool isAnnulated = endorse.EndorseType == Seggu.Domain.EndorseType.Anulación;
            if (isAnnulated)
                this.AnnulateEndorseChilds(endorse);

            if (isNew)
            {
                if (endorse.Vehicles != null)
                    AddCoveragesToVehicles(endorse);
                else if (endorse.Employees != null)
                    AddCoveragesToEmployees(endorse);
                else if (endorse.Integrals != null)
                    AddCoveragesToIntegrals(endorse);
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
                else if (endorse.Integrals != null)
                    foreach (var Integral in endorse.Integrals)
                        Integral.EndorseId = Integral.Id;
                endorseDao.Edit(endorse);
            }
        }

        private void SetChildrenToNull(Endorse endorse)
        {
            if (endorse.Vehicles != null)
            {
                foreach (var vehicle in endorse.Vehicles)
                {
                    vehicle.Id = 0;
                    foreach (var accessory in vehicle.Accessories)
                    {
                        accessory.Id = 0;
                    }
                }
            }
            if (endorse.Employees != null)
            {
                foreach (var vehicle in endorse.Employees)
                {
                    vehicle.Id = 0;
                }
            }
            if (endorse.Integrals != null)
            {
                foreach (var vehicle in endorse.Integrals)
                {
                    vehicle.Id = 0;
                    vehicle.Address.Id = 0;
                }
            }
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
        private void AddCoveragesToIntegrals(Endorse endorse)
        {
            foreach (var Integral in endorse.Integrals)
            {
                var coverages = new List<Coverage>();
                foreach (var coverage in Integral.Coverages)
                    coverages.Add(this.policyDao.GetContainer().Coverages.Single(c => c.Id == coverage.Id));
                Integral.Coverages = coverages;
            }
        }
        private void AnnulateEndorseChilds(Endorse endorse)
        {
            endorse.AnnulationDate = DateTime.Today;
            endorse.IsAnnulled = true;

            var policy = policyDao.Get(endorse.PolicyId);
            policy.AnnulationDate = DateTime.Today;
            policy.IsAnnulled = true;
            if (policy.Fees.Count > 0)
                foreach (var fee in policy.Fees)
                    fee.Annulated = true;
            policyDao.Update(policy);
        }
    }
}
