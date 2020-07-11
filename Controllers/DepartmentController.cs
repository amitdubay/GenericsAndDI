using System.Collections.Generic;
using GenericsAndDI.Entities;
using GenericsAndDI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericsAndDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IBaseRepository<Department> _departmentRepository;
        public DepartmentController(IBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _departmentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Department Get(string id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}
