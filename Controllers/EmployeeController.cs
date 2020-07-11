using System.Collections.Generic;
using GenericsAndDI.Entities;
using GenericsAndDI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericsAndDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        public EmployeeController(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Employee Get(string id)
        {
            return _employeeRepository.GetById(id);
        }
    }
}