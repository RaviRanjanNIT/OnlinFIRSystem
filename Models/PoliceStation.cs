using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinFIRSystem.Models
{
    public class PoliceStation
    {
        public int Id { get; set; }

        public int PIN { get; set; }

        public string PoliceStationName { get; set; }

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