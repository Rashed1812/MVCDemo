using Demo.BLL.DTO.Department_DTO;
using Demo.BLL.Services;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentsServices,
        ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var departments = _departmentsServices.GetAllDepartments();

            return View(departments);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if(ModelState.IsValid) //Server Side Validation
            {
                try
                {
                    //First step Add Department in db and check Row Effictive Result
                    var result =  _departmentsServices.AddDepartment(departmentDto);
                    //result > 0 means the department is created successfully
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create department");
                    }
                }
                catch(Exception ex)
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
            return View(departmentDto);
        }
        #endregion

        #region Details Of Department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();//400

            var department = _departmentsServices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        #endregion

        #region Edit Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _departmentsServices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                //Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                DateOfCreation = department.CreatedOn,
                Description = department.Description
            };
            return View(departmentViewModel);
        }
        
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id,DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            try
            {
                var updateDepartment = new UpdateDepartmentDto()
                {
                    Id = id.Value,
                    Name = viewModel.Name,
                    Code = viewModel.Code,
                    DateOfCreation = viewModel.DateOfCreation,
                    Description = viewModel.Description
                };
                var result = _departmentsServices.UpdateDepartment(updateDepartment);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update department");
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
            return View(viewModel);
        }
        #endregion

        #region Delete Department
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest();
        //    var department = _departmentsServices.GetDepartmentById(id.Value);
        //    if (department is null)
        //        return NotFound();
        //    return View(department);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        //can be used for delete if int is not nullable
        public IActionResult Delete(int id)
        {
            if(id == 0)
                return BadRequest();
            try
            {
                var deleted = _departmentsServices.DeleteDepartment(id);
                if (deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed To Delete Department");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex) 
            {
                //Log Exception
                if (_environment.IsDevelopment())
                {
                    //1.Handle erro In Environment Case
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //2.Handle erro In Deployment Case
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
            
                 
            
        }
        #endregion
    }
}
