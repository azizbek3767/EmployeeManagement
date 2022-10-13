using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models.Repositories;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompayRepository _compayRepository;

        public CompanyController(ICompayRepository compayRepository)
        {
            _compayRepository = compayRepository;
        }

        public IActionResult Index()
        {
            CompanyIndexViewModel viewModel = new CompanyIndexViewModel()
            {
                Companies = _compayRepository.GetAll()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyCreateViewModel company)
        {
            if (ModelState.IsValid)
            {
                Company newCompany = new Company
                {
                    Name = company.Name,
                    TypeOfBusinessEntity = company.TypeOfBusinessEntity,
                };
                _compayRepository.Create(newCompany);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Company company = _compayRepository.Get(id);
            if(company != null)
            {
                CompanyEditViewModel viewModel = new CompanyEditViewModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    TypeOfBusinessEntity = company.TypeOfBusinessEntity
                };
                return View(viewModel);
            }
            else
            {
                return NotFoundView(id);
            }
        }

        [HttpPost]
        public IActionResult Edit(CompanyEditViewModel company)
        {
            if (ModelState.IsValid)
            {
                Company existingCompany = _compayRepository.Get(company.Id);
                existingCompany.Id = company.Id;
                existingCompany.Name = company.Name;
                existingCompany.TypeOfBusinessEntity = company.TypeOfBusinessEntity;
                _compayRepository.Update(existingCompany);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Company company = _compayRepository.Get(id);
            if(company != null)
            {
                _compayRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFoundView(id);
            }
        }

        private ViewResult NotFoundView(int id)
        {
            Response.StatusCode = 404;
            return View("CompanyNotFound", id);
        }
    }
}
