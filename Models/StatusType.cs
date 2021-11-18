using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinFIRSystem.Models
{
    public class StatusType
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        [Display(Name ="Type of Status")]
        public string TypeofStatus { get; set; }
        public string Status { get; set; }
    }
}