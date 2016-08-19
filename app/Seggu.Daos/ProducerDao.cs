using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public class ProducerDao : IdParseEntityDao<Producer>, IProducerDao
    {
        public List<Producer> GetCollectors()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return (
                    from p in context.Producers
                    where p.IsCollector
                    select p).ToList();
            }
        }

        public bool GetByRegistrationNumberId(string registrationNumber, long id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var prod = context.Producers.FirstOrDefault(p => p.RegistrationNumber == registrationNumber);
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

        public bool GetByRegistrationNumber(string registrationNumber)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var prod = context.Producers.FirstOrDefault(p => p.RegistrationNumber == registrationNumber);
                if (prod == null)
                {
                    return false;
                }
                return true;
            }
        }

        public List<ProducerCode> GetByCompanyId(int id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return (context
                    .ProducerCodes
                    .Include("Producer")
                    .Where(pc => pc.CompanyId == id)).ToList();
            }
        }

        public override void Update(Producer obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Producers.Find(obj.Id);
                Mapper.Map(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
