using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;
namespace Seggu.Daos
{
    public sealed class BankDao : IdParseEntityDao<Bank>, IBankDao
    {
        public BankDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public bool GetByName(string name)
         {
            return this.Set.Any(c => c.Name == name);
        }
        
        public bool GetByNumber(string number)
        {
            return this.Set.Any(c => c.Number == number);
        }
        public override void Update(Bank obj)
        {
            var orig = context.Banks.Find(obj.Id);
            Mapper.Map<Bank, Bank>(obj, orig);
            context.SaveChanges();
        }
    }
}