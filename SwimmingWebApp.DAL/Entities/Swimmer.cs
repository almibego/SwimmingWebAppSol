using System;
using System.Collections.Generic;

namespace SwimmingWebApp.DAL.Entities
{
    public class Swimmer
    {
        public Swimmer()
        {
            Trainings = new List<Training>();
        }

        public int SwimmerId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Rank { get; set; }

        public List<Training> Trainings { get; set; }
    }
}
