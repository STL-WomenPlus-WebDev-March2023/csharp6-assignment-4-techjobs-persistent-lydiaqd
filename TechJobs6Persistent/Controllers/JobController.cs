using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        public IActionResult Add()
        {
            {
                List<SelectListItem> ListItems = new List<SelectListItem> ();
                foreach(Employer employer in context.Employers)
                {
                    ListItems.Add(new SelectListItem { Text = employer.Name, Value = employer.Id.ToString()});
                }

                AddJobViewModel addJobViewModel = new AddJobViewModel
                {
                    EmployerList = ListItems,
                    Name = "Steve"
                };

                return View(addJobViewModel);
            }

         // This method needs to contain a list of Employer objects which it pulls from the Employers dbContext.
         // This method needs to create an instance of the AddJobViewModel which is passed the list of employer objects.
         // Pass an instance of AddJobViewModel to the view.
        }

        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            Console.WriteLine(addJobViewModel);
            int EmployerId;
            if (ModelState.IsValid && Int32.TryParse(addJobViewModel.SelectedEmployer, out EmployerId))
            {
                Job newJob = new Job(addJobViewModel.Name)
                {
                    EmployerId = EmployerId,
                    Employer = context.Employers.Find(EmployerId)
                };

                context.Add(newJob);

                context.SaveChanges();

                return Redirect("/Job");
            }

            return View(addJobViewModel);
        }

        //Back in the JobController, rename ProcessAddJobForm() to Add() and add the [HttpPost] attribute to designate this as your post handler.
        //This post handler needs to take in an instance of AddJobViewModel and make sure that any validation conditions you want to add are met before creating a new Job object and saving it to the database.
        //If model is valid, redirect to the “/Jobs”.

        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}

