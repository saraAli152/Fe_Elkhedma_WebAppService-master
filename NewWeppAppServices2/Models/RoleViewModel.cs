﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewWeppAppServices2.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [DisplayName( "نوع المستخدم")]
        public string Name { get; set; }
    }
}