using Microsoft.AspNetCore.Mvc;
using Northwind_API.Entities;
using Northwind_API.Models;
using Northwind_API.Repositories;

namespace Northwind_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _dbcontext;
        private readonly IUnitOfWorkNorthwind _unitOfWorkNorthwind;


        // public EmployeesController(IRepository<Employee> employeesRepository)
        // add service ? unitofwork
        public EmployeesController()
        {
            _dbcontext = new NorthwindContext();
            _unitOfWorkNorthwind = new UnitOfWorkNorthwindSQL(_dbcontext);
        }


        // GET /api/Employees

        [HttpGet]
        public async Task<IList<EmployeeDTO>> GetEmployeesAsync()
        {
            IList<Employee> lst = await _unitOfWorkNorthwind.EmployeesRepository.GetAllAsync();
            return lst.Select(e => EmployeeToDTO(e)).ToList();
        }

        //POST /api/Employees 

        [HttpPost]
        public async Task InsertEmployeesAsync(EmployeeDTO employeeDTO)
        {
            // assure that id is not set to avoid error with autoincrement in database
            employeeDTO.EmployeeId = 0;
            Employee e = DTOToEmployee(employeeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.InsertAsync(e);
        }

        // PUT /api/Employees/id

        [HttpPut]

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee e = DTOToEmployee(employeeDTO);
            await _unitOfWorkNorthwind.EmployeesRepository.SaveAsync(e);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            Employee? emp = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(EmployeeToDTO(emp));
            }

        }

        // Delete only Employee with no orders    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            Employee? emp = await _unitOfWorkNorthwind.EmployeesRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWorkNorthwind.EmployeesRepository.DeleteAsync(emp);
                return Ok();
            }

        }


        private static EmployeeDTO EmployeeToDTO(Employee emp) =>
            new EmployeeDTO
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy

            };

        private static Employee DTOToEmployee(EmployeeDTO emp) =>
            new Employee
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };
    }
}