using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext jobDbContext { get; set; }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employer = jobDbContext.Employers.ToList();
            return View(employer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        /// <summary>
        /// Hi
        /// </summary>
        /// <param name="addEmployerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            Employer employer = new Employer(addEmployerViewModel.Name, addEmployerViewModel.Location);

            jobDbContext.Employers.Add(employer);

            jobDbContext.SaveChanges();

            return RedirectToAction("Index", employer);
            //return View("Index", employer);
        }

       // About() takes an id as a parameter. It will create an Employer object by searching through the Employers table in DbContext until it finds the provided id.
       // It will pass the employer object to the view.
       // Consider using the .Find() method to search the database.
        public IActionResult About(int id)
        {
            List<Employer> employers = new List<Employer>(jobDbContext.Employers);
            Employer? employer = employers.Find(x => x.Id == id);
            return View(employer);
        }

        public EmployerController(JobDbContext jobContext)
        {
            jobDbContext = jobContext;
        }
    }
}

//ctrl + shift + space