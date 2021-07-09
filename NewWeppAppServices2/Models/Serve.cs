using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewWeppAppServices2.Models
{
    public class Serve
    {
        public int Id { get; set; }

        [DisplayName("إسم الخدمة")]
        public string ServeName { get; set; }

        [DisplayName("وصف الخدمة")]

        public string ServeContent { get; set; }

        [DisplayName("صورة الخدمة")]

        public string ServeImage { get; set; }

        [DisplayName("نوع الخدمة")]
        public int CategoryId { get; set; }


        public string UserID { get; set; }


        public virtual Category Category { get; set; }


        public virtual ApplicationUser User { get; set; }

    }
}