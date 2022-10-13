using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Repositories;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompayRepository _companyRepository;
        private readonly IDataAccessADO _dataAccessADO;
        public EmployeeController(IEmployeeRepository employeeRepository, ICompayRepository compayRepository, IDataAccessADO dataAccessADO)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = compayRepository;
            _dataAccessADO = dataAccessADO;
        }

        public IActionResult Index()
        {
            EmployeeIndexViewModel viewModel = new EmployeeIndexViewModel()
            {
                Employees = _employeeRepository.GetAll()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            EmployeeCreateViewModel viewModel = new EmployeeCreateViewModel()
            {
                Companies = _companyRepository.GetAll().ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    StartDateOfWork = employee.StartDateOfWork,
                    Position = employee.Position,
                    Company = employee.Company,
                };
                _employeeRepository.Create(newEmployee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                EmployeeEditViewModel viewModel = new EmployeeEditViewModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    StartDateOfWork = employee.StartDateOfWork,
                    Position = employee.Position,
                    Company = employee.Company,
                    Companies = _companyRepository.GetAll().ToList()
                };
                return View(viewModel);
            }
            else
            {
                return NotFoundView(id);
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel employee)
        {
            if (ModelState.IsValid)
            {
                Employee existingEmployee = _employeeRepository.Get(employee.Id);
                existingEmployee.Id = employee.Id;
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.StartDateOfWork = employee.StartDateOfWork;
                existingEmployee.Position = employee.Position;
                existingEmployee.Company = employee.Company;
                _employeeRepository.Update(existingEmployee);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if(employee != null)
            {
                _employeeRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFoundView(id);
            }
        }

        [HttpGet]
        public IActionResult EmployeesRecordADO()
        {
            EmployeesRecordADOViewModel viewModel = new EmployeesRecordADOViewModel
            {
                employees = _dataAccessADO.GetEmployeesRecord().ToList()
            };
            return View(viewModel);
        }

        private ViewResult NotFoundView(int id)
        {
            Response.StatusCode = 404;
            return View("EmployeeNotFound", id);
        }
    }
}
