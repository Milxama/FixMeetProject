using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class OfferModels
    {
        [Key]
        public int OfferID { get; set; }

        [Required]
        public DateTime OfferDate { get; set; }

        [Required]
        public string Description { get; set; }

        public int Cost { get; set; }
        
        public string UserID { get; set; }
        [Required]
        public int RequestID { get; set; }


        [DisplayName("Supplier First Name")]
        public string SupplierFirstName { get; set; }
        [DisplayName("Supplier Last Name")]
        public string SupplierLastName { get; set; }

        [DisplayName("Customer First Name")]
        public string CustomerFirstName { get; set; }
        [DisplayName("Customer Last Name")]
        public string CustomerLastName { get; set; }


        public virtual RequestModels Request { get; set; }

    }
}