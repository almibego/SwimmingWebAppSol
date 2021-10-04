using System;
using System.ComponentModel.DataAnnotations;

namespace SwimmingWebApp.DAL.Entities
{
    public class Training
    {
        public int TrainingId { get; set; }
        [DataType(DataType.Date)]
        public DateTime TrainingDate { get; set; }
        public int TrainingVolume { get; set; }
        public string KeyAssignment { get; set; }
        public string KeyAssignmentBestTime { get; set; }
        public string Feeling { get; set; }

        public int SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }   
    }
}
