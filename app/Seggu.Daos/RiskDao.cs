﻿using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class RiskDao : IdParseEntityDao<Risk>, IRiskDao
    {
        public RiskDao()
            : base()
        {

        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Risks.Any(c => c.Name == name); 
            }
        }

        public List<Risk> GetByCompany(long idCompany)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return (
                    from r in context.Risks
                    where r.CompanyId == idCompany
                    orderby r.Name
                    select r).ToList();
            }
        }

        public List<Risk> GetByCompanyWithCoveragePacks(long idCompany)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return (
                    from r in context.Risks.Include("CoveragesPacks.Coverages")
                    where r.CompanyId == idCompany
                    orderby r.Name
                    select r).ToList();
            }
        }

        public bool GetByNameId(string name, long id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var prod = context.Risks.FirstOrDefault(p => p.Name == name);
                if (prod == null)
                {
                    return false;
                }
                else if (prod.Id == id)
                {
                    return false;
                }
                return true;
            }
        }

        public List<Risk> GetByCompanyAndRiskType(long id, RiskType riskType)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Risks.Where(r => r.CompanyId == id && r.RiskType == riskType).ToList();
            }
        }

        public override void Update(Risk obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Risks.Find(obj.Id);
                Mapper.Map<Risk, Risk>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
