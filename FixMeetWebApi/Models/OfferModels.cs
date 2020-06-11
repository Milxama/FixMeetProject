﻿using System;
using System.Collections.Generic;
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

     //   public Booking Booking { get; set; } //refernce to booking if exists, else will be NULL


        //FK
        public string UserID { get; set; }
        [Required]
        public int RequestID { get; set; }

    }
}