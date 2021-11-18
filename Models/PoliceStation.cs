using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinFIRSystem.Models
{
    public class PoliceStation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "PIN Code of Police Station")]
        public int PIN { get; set; }

        [Required]
        [Display(Name = "Name of Police Station")]
        public string PoliceStationName { get; set; }

        [Required]
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }

    //public enum FillStatus
    //{
    //    Active,
    //    Inactive
    //}
}