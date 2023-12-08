using System;
namespace TechJobs6Persistent.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Job> Jobs { get; set; }

        public Employer(string name, string location)
        {
            Name = name;
            Location = location;
        }

    }
}

//We need to create a List of Job objects named Jobs in the Employer model.
//Make sure it has both a getter and a setter.