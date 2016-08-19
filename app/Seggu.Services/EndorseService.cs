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
        private readonly IEndorseDao endorseDao;
        private readonly IPolicyDao policyDao;
        private readonly ICoverageDao coverageDao;
        public EndorseService(IEndorseDao endorseDao, IPolicyDao policyDao, ICoverageDao coverageDao)
        {
            this.endorseDao = endorseDao;
            this.policyDao = policyDao;
            this.coverageDao = coverageDao;
        }

        public void Save(EndorseFullDto endorseFull)
        {
            var endorse = EndorseDtoMapper.GetObjectWithCover(endorseFull);
            SetChildrenToNull(endorse);
            var isNew = endorseFull.Id == default(int);

            var isAnnulated = endorse.EndorseType == EndorseType.Anulación;
            if (isAnnulated)
                AnnulateEndorseChilds(endorse);

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
                    foreach (var integral in endorse.Integrals)
                        integral.EndorseId = integral.Id;
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
                var coverages = vehicle.Coverages.Select(coverage => this.coverageDao.Find(coverage.Id)).ToList();
                vehicle.Coverages = coverages;
            }
        }
        private void AddCoveragesToEmployees(Endorse endorse)
        {
            foreach (var employee in endorse.Employees)
            {
                var coverages = employee.Coverages.Select(coverage => this.coverageDao.Find(coverage.Id)).ToList();
                employee.Coverages = coverages;
            }
        }
        private void AddCoveragesToIntegrals(Endorse endorse)
        {
            foreach (var integral in endorse.Integrals)
            {
                var coverages = integral.Coverages.Select(coverage => this.coverageDao.Find(coverage.Id)).ToList();
                integral.Coverages = coverages;
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
