using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class RequestsModels
    {
        [Key]
        public int RequestID { get; set; }

        public DateTime RequestDate { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string Description { get; set; }

        // public ICollection<Offer> OffersFromSuppliers { get; set; }

        //public Booking? Booking { get; set; } //refernce to booking if exists, else will be NULL

        //FK
        public int UserID { get; set; }

        // public Customer Customer { get; set; }
    }
}