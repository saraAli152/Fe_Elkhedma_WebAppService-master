using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewWeppAppServices2.Models
{
    public class ApplyForService
    {
        public int Id { get; set; }
        [DisplayName("طريقة التواصل")]
        public string tmp { get; set; }
        [DisplayName("الرسالة")]
        public string Message { get; set; }
        [DisplayName("تاريخ الرسالة")]
        public DateTime ApplyDate { get; set; }
        public int serveId { get; set; }
        public string UserId { get; set; }

        public virtual Serve serve { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}