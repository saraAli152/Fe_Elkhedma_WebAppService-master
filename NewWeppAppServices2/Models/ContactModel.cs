﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWeppAppServices2.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [AllowHtml]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }


    }
}