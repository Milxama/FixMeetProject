using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixMeetWebApi.Models
{
    public class NegotiationChatModels
    {
        [Key]
        public int ChatId { get; set; }

        [Required]
        public DateTime ChatDate { get; set; }

        [Required]
        public string ChatText { get; set; }

        [Required]
        public int OfferID { get; set; }

        public string CustId { get; set; }

        public string SuppId { get; set; }

        public string MessageOwnerId { get; set; }
    }
}