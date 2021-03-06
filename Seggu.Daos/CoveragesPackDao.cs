﻿using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CoveragesPackDao : IdParseEntityDao<CoveragesPack>, ICoveragesPackDao
    {
        public CoveragesPackDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<CoveragesPack> GetByRiskId(long riskId)
        {
            return this.context.Set<CoveragesPack>().Include("Coverages").Where(x => x.RiskId == riskId);
        }

        public void UpdateCoveragesPack(CoveragesPack coveragesPack)
        {
            var coverages = new List<Coverage>(coveragesPack.Coverages).ToList();
            var newCoveragesPack = context.CoveragesPacks
                                    .Include("Coverages")
                                    .FirstOrDefault(c => c.Id == coveragesPack.Id) ?? coveragesPack;

            newCoveragesPack.Coverages.Clear();
            context.Entry(newCoveragesPack).State = EntityState.Modified;

            coveragesPack.Id = newCoveragesPack.Id;
            context.Entry(newCoveragesPack).CurrentValues.SetValues(coveragesPack);

            foreach (var c in context.Coverages)
            {
                if (coverages.Any(cpack => cpack.Id == c.Id))
                {
                    context.Coverages.Attach(c);
                    newCoveragesPack.Coverages.Add(c);
                }
                else
                    newCoveragesPack.Coverages.Remove(c);
            }
            context.SaveChanges();
        }

        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public bool HasRiskPackege(long idRisk)
        {
            return this.Set.Any(c => c.RiskId == idRisk);
        }

        public bool GetByNameRisk(string name, long idRisk)
        {
            return this.Set.Any(p => p.Name == name && p.RiskId == idRisk);
        }

        public bool GetByNameId(string name, long id, long riskId)
        {
            var prod = this.Set.FirstOrDefault(p => p.Name == name && p.RiskId == riskId);
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

        public override void Update(CoveragesPack obj)
        {
            var orig = context.CoveragesPacks.Find(obj.Id);
            Mapper.Map<CoveragesPack, CoveragesPack>(obj, orig);
            context.SaveChanges();
        }
    }
}
