using System;

namespace SwimmingWebApp.DAL.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public DateTime Date { get; set; }
        public int Place { get; set; }
        public string Distance { get; set; }
        public string Time { get; set; }
        
        public int SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }
    }
}