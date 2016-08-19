using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public class AddressDao : IdParseEntityDao<Address>, IAddressDao
    {
        public AddressDao()
            : base()
        {
        }
        public override void Update(Address obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Addresses.Find(obj.Id);
                Mapper.Map<Address, Address>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
