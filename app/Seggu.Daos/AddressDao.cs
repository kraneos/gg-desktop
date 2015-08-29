using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Daos
{
    public class AddressDao : IdEntityDao<Address>, IAddressDao
    {
    }
}
