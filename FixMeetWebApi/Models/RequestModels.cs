using System;
using System.Collections.Generic;
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
        //FK
        public string UserID { get; set; }

        // public Customer Customer { get; set; }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }

        public virtual IList<OfferModels> Offers { get; set; }
    }
}