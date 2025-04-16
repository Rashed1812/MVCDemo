using Demo.BLL.DTO.Department_DTO;
using Demo.BLL.DTO.Employee_DTO;
using Demo.BLL.Services.Employee_Services;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices , IWebHostEnvironment _environment, 
        ILogger<EmployeeController> _logger) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeServices.GetAllEmployees(false);
            return View(Employees);
        }

        #region Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid) //Server Side Validation
            {
                try
                {
                    //First step Add Department in db and check Row Effictive Result
                    var result = _employeeServices.AddEmployee(employeeDto);
                    //result > 0 means the department is created successfully
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create Employee");
                    }
                }
                catch (Exception ex)
                {
                    //Log Exception
                    if (_environment.IsDevelopment())
                    {
                        //1.Handle erro In Environment Case
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //1.Handle erro In Deployment Case
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(employeeDto);
        }
        #endregion

        #region Details Employee
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        #endregion

        #region Edit Employee

        [HttpGet]
        public IActionResult Edit (int? id)
        {   
            if (!id.HasValue)
                return BadRequest();

            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();
            var employeeDto = new UpdateEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender =Enum.Parse<Gender>( employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            };
            return View(employeeDto);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdateEmployeeDto employeeDto)
        {
            if (!id.HasValue || id != employeeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid) return View(employeeDto);

            try
            {
                var result = _employeeServices.UpdateEmployee(employeeDto);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update Employee");
                    return View(employeeDto);
                }
            }
            catch (Exception ex)
            {
                //Log Exception
                if (_environment.IsDevelopment())
                {
                    //1.Handle erro In Environment Case
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeDto);

                }
                else
                {
                    //1.Handle erro In Deployment Case
                    _logger.LogError(ex.Message);
                    return View("Error View");
                }
            }
        }

        #endregion

        #region Delet Employee

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                var result = _employeeServices.DeleteEmployee(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to delete Employee");
                    return View();
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View();
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Error View");
                }
            }
        }
        #endregion

    }
}
