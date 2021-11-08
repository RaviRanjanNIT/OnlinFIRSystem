using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinFIRSystem.Models
{
    public class FIR
    {
        public int Id { get; set; }
        public string FIRNUMBER { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateTimeFIR { get; set; }
        public string Location { get; set; }
        public int PoliceStationId { get; set; }
        public string FIRAgainst { get; set; }
        public string Witnesses { get; set; }
        public string EmailId { get; set; }
        public int FIRSTATUS { get; set; }
        public string PoliceStationName { get; set; }
        public string TypeofStatus { get; set; }
        public int PIN { get; set; }
    }
}