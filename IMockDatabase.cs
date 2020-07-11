using GenericsAndDI.Entities;
using System.Collections.Generic;

namespace GenericsAndDI
{
    public interface IMockDatabase
    {
        IEnumerable<T> GetAll<T>();
        T GetById<T>(string id);
    }
}