using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seggu.Domain;
namespace Seggu.Daos.Interfaces
{
    public interface IIntegralDao : IParseIdEntityDao<Integral>
    {
        void SaveIntegral(Integral newIntegral);
    }
}
