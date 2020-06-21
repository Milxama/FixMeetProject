using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //[Required]
        //public string Description { get; set; }

        [Required]
        public int OfferID { get; set; }

        [Required]
        public int RequestID { get; set; }

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

        // virtual public ApplicationUser Customer { get; set; }

        //[Required]
        //public int CustomerId { get; set; }

        //[Required]
        //public int SupplierId { get; set; }


    }
}