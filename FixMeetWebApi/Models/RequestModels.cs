using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class RequestModels
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
        [Required]
        public bool IsOpen { get; set; }

        public string Address { get; set; }
        //FK
        public string UserID { get; set; }

        // public Customer Customer { get; set; }
        [DisplayName("First Name")]
        public string CustomerFirstName { get; set; }
        [DisplayName("Last Name")]
        public string CustomerLastName { get; set; }


        public virtual IList<OfferModels> Offers { get; set; }
    }
}