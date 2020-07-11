using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericsAndDI.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
}
