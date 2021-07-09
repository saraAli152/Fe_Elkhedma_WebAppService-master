using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWeppAppServices2.Models
{
    public class ServeViewModel
    {
        public string ServeTitle { get; set; }
        
        public IEnumerable<ApplyForService> Items { get; set; }
    }
}