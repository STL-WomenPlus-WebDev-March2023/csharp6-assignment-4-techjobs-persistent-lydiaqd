using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.Models
{
    public class AddJobViewModel
    {
        public AddJobViewModel(List<Employer> employers)
        {
            Name = "";
            EmployerList = new List<SelectListItem>();
            foreach (Employer employer in employers)
            {
                EmployerList.Add(new SelectListItem
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString()
                });
            }
        }

        public AddJobViewModel()
        {

        }

        public List<SelectListItem>? EmployerList { get; set; }

        public string? SelectedEmployer;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Job name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Id is required")]
        public int EmployerId { get; set; }
    }
}