﻿using AutoMapper;
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
            Mapper.Map<Address, Address>(obj, orig);
            context.SaveChanges();
        }
    }
}
