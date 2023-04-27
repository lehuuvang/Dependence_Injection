using Demo_DI.Models;
using Domain.Enities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Student;
using System.Collections.Generic;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Demo_DI.Controllers
{
    public class StudentController : Controller
    {
        private readonly MvcContext mvcContext;
        private readonly IStudentServices _stuService;
        private readonly INotyfService _otyfService;
        public StudentController(IStudentServices stuService,MvcContext mvcContext,INotyfService _otyfService)
        {
            _stuService = stuService;
            this.mvcContext = mvcContext;
            this._otyfService = _otyfService;
        }
        //page and search
        [HttpGet]
        public IActionResult Index(string keyword,int page = 1)
        {
                int pageSize = 4;

                var students = _stuService.getAllStudent();

                var pagedProducts = mvcContext.Students.OrderBy(p => p.Id)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();
                var totalCount = students.Count();
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
                var searchResults = _stuService.Search(keyword).OrderBy(p => p.Id)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();
                var viewModel = new StudentsViewModel
                {
                    //students = pagedProducts,
                    students = searchResults,
                    Keyword = keyword,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        //TotalItems = totalCount ,
                        TotalItems = searchResults.Count(),
                        ItemsPerPage = pageSize,
                        TotalPages = totalPages,
                    }
                };           
            return View(viewModel);
            //var list = _stuService.getAllStudent();
            //return View(list);
        }

        [HttpGet]
        public IActionResult SearchString(string keyword)
        {
            var searchResults = _stuService.Search(keyword);
            var viewModel = new SearchViewModel
            {
                Keyword = keyword,
                Results = searchResults
            };
            return View(viewModel);
            /*
             // Search student by List<> not IQueryable
            if (keyword != null)
            { 
                var listsearch = _stuService.Search(keyword);
                return View("Index", listsearch);
            }
            else
            {
                var list = _stuService.getAllStudent();
                TempData["NotString"] = "Input name student want to search,please!";
                return View("Index", list);
            }
            */
        }
        //Autocomplete
        [Produces("application/json")]
        [HttpGet("suggest")]
        public IActionResult suggest(string keyword)
        {
            try
            {
                keyword = HttpContext.Request.Query["term"].ToString();
                var studentsName = _stuService.FillDataInSearch(keyword);
                //return Json(new { data = studentsName });
                return Ok(studentsName);
            }
            catch
            {
                return BadRequest();
            }
        }     
        [HttpGet]
        public IActionResult Insert() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool CheckInputAge(Domain.Enities.Student model)
        {
           var age = DateTime.Now.Year - model.BirthDate.Year;
            if (age >= 18)
            {
                return true;
            }
            ViewBag.Message = "Age student must be >= 18";
            return false;          
        }
        public IActionResult Insert(Domain.Enities.Student model)
        {           
            if (ModelState.IsValid)
            {
                if (CheckInputAge(model)) {                 
                    _stuService.Insert(model);
                    //ViewBag.Message = "Student added successfully!";
                    _otyfService.Success("Student added successfully!"); 
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _stuService.get(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Domain.Enities.Student model)
        {
            if (ModelState.IsValid)
            {
                if (CheckInputAge(model))
                {
                    _stuService.Update(model);
                    //ViewBag.Message = "Student updated successfully!";
                    _otyfService.Success("Student updated successfully!");
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var model = _stuService.get(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = _stuService.get(id);
            _stuService.Delete(model);
            //TempData["Message"] = "Student Deleted successfully";
            _otyfService.Success("Student Deleted successfully!");
            return RedirectToAction("Index");
        }       
    }
}
