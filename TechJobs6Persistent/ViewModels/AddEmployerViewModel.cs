using System;
using System.ComponentModel.DataAnnotations;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.Models
{
	public class AddEmployerViewModel
	{
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Employer name is required")]
        public string Name { get; set; }

        public string? Location { get; set; }
    }
}