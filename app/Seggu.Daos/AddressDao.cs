using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public class AddressDao : IdParseEntityDao<Address>, IAddressDao
    {
        public AddressDao(SegguDataModelContext context)
            : base(context)
        {
        }
        public override void Update(Address obj)
        {
            var orig = context.Addresses.Find(obj.Id);
            if (orig == null) return;

            var props = orig.GetType().GetProperties();

            orig.Street = obj.Street;
            orig.Phone = obj.Phone;
            orig.Number = obj.Number;
            orig.Floor = obj.Floor;
            orig.Appartment = obj.Appartment;
            orig.LocalityId = obj.LocalityId;
            orig.PostalCode = obj.PostalCode;
            orig.AddressType = obj.AddressType;
            orig.       
        }
    }
}
