using GenericsAndDI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericsAndDI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IMockDatabase _mockDatabase;
        public BaseRepository(IMockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public IEnumerable<T> GetAll()
        {
            return _mockDatabase.GetAll<T>();
        }

        public T GetById(string id)
        {
            return _mockDatabase.GetById<T>(id);
        }
    }
}