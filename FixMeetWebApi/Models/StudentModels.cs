using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class StudentModels
    {
        [Key]
        public int StudId { get; set; }

        public string Name { get; set; }
    }
}