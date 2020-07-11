using GenericsAndDI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericsAndDI
{
    public class MockDatabase : IMockDatabase
    {
        private readonly List<Department> departments;
        private readonly List<Employee> employees;

        public MockDatabase()
        {
            departments = new List<Department>
            {
                new Department {Code = "D01", Name = "IT"},
                new Department {Code="D02", Name = "Finance"}
            };
            
            employees = new List<Employee>
            {
                new Employee {Id = 1, Name = "James Bond", DepartmentCode = "D01"},
                new Employee {Id = 2, Name = "Jason Bourne", DepartmentCode = "D02"}
            };
        }

        public IEnumerable<T> GetAll<T>()
        {
            if (typeof(T) == typeof(Department))
            {
                return (List<T>)Convert.ChangeType(departments, typeof(List<T>));
            }
            else if (typeof(T) == typeof(Employee))
            {
                return (List<T>)Convert.ChangeType(employees, typeof(List<T>));
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public T GetById<T>(string id)
        {
            object result = null;
            if (typeof(T) == typeof(Department))
            {
                result = departments.FirstOrDefault(d => d.Code == id);
            }
            else if (typeof(T) == typeof(Employee))
            {
                result = employees.FirstOrDefault(e => e.Id == Convert.ToInt32(id));
            }
            else
            {
                throw new NotSupportedException();
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}