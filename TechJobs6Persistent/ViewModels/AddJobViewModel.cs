using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.Models
{
    public class AddJobViewModel
	{
        public List<SelectListItem>? EmployerList { get; set; }
        public string? SelectedEmployer;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Job name is required")]
        public string? Name { get; set; }

        public int? Id { get; set; }
    }
}