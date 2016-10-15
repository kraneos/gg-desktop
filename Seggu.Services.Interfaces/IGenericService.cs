using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IGenericService<T>
    {
        IEnumerable<T> GetAll();
    }
}
