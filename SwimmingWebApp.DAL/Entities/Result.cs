using System;
using System.ComponentModel.DataAnnotations;

namespace SwimmingWebApp.DAL.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }
        
        public int SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }
    }
}