using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class BookingModels
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string Description { get; set; }

        //[Required]
        //public int OfferID { get; set; }

        [Required]
        public int RequestID { get; set; }

        //[Required]
        //public int CustomerId { get; set; }

        //[Required]
        //public int SupplierId { get; set; }
    }
}