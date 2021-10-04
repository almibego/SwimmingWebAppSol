using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Rank { get; set; }

        public List<Training> Trainings { get; set; }
        public List<Result> Results { get; set; }
    }
}