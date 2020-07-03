using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class RatingModels
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        public DateTime RatingDate { get; set; }

        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        //[Required]
        //public int BookingId { get; set; }

        public string CustId { get; set; }

        public string SuppId { get; set; }

        [DisplayName("Customer First Name")]
        public string CustFirstName { get; set; }

        [DisplayName("Customer Last Name")]
        public string CustLastName { get; set; }

        [DisplayName("Supplier First Name")]
        public string SuppFirstName { get; set; }

        [DisplayName("Supplier Last Name")]
        public string SuppLastName { get; set; }


    }
}