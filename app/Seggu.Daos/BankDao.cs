using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;
namespace Seggu.Daos
{
    public sealed class BankDao : IdParseEntityDao<Bank>, IBankDao
    {
        public BankDao()
            : base()
        {
        }

        public bool GetByName(string name)
         {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Banks.Any(c => c.Name == name); 
            }
        }
        
        public bool GetByNumber(string number)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Banks.Any(c => c.Number == number); 
            }
        }
        public override void Update(Bank obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Banks.Find(obj.Id);
                Mapper.Map<Bank, Bank>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}