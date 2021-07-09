using Microsoft.AspNet.Identity;
using NewWeppAppServices2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NewWeppAppServices2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }
        public ActionResult IndexOfIndex()
        {
            
            return View();
        }
        public ActionResult Details(int serviceId)
        {
            var service = db.Serves.Find(serviceId);
            if (service == null)
            {
                return HttpNotFound();
            }
            Session["ServiceId"] = serviceId;
            return View(service);
        }
        //[Authorize]
        //public ActionResult Accept(string id, int ServeId, int status)
        //{
        //   var UserId = User.Identity.GetUserId();
        //   var service = db.ApplyForServices.Where(a => a.user.Id == id && a.serveId == ServeId).FirstOrDefault();
        //    service.tmp = 1;

        //    db.ApplyForServices.Add(service);
        //    db.SaveChanges();
        //    return RedirectToAction("GetServesByPublisher");
        //}

        public ActionResult OurIndexTwo()
        {
            return View();
        }

    
        

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Apply(string Message, string tmp)
        {
            var UserId = User.Identity.GetUserId();
            var ServiceId = (int)Session["ServiceId"] ;

            var check = db.ApplyForServices.Where(a => a.serveId == ServiceId && a.UserId == UserId).ToList();
            // هنا هيجيب الاشخاص اللي عملو ابلاي
            if (check.Count <1)
            {
                var service = new ApplyForService();
                service.UserId = UserId;
                service.serveId = ServiceId;
                service.Message = Message;
                service.tmp = tmp; 
                service.ApplyDate = DateTime.Now;
               

                db.ApplyForServices.Add(service);
                db.SaveChanges();
                ViewBag.Result_Success = "تم إيصال طلبك بنجاح";

            }
            else// معناها ان اليوزر ده طلب الخدمه دي قبل كدا
            {
                ViewBag.Result_Error = "المعذرة لقد سبق وطلبت هذه الخدمة، رجاء إنتظر الرد";
            }


            return View();
        }
        [Authorize]
        public ActionResult DetailsOfService(int id)
        {
            var service = db.ApplyForServices.Find(id);

            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetServiceByUser()
        {
            var UserId = User.Identity.GetUserId();// دي هتجيب اليوزر الحالي اللي داخل
            var Services = db.ApplyForServices.Where(a => a.UserId == UserId);

            return View(Services.ToList()) ;
        }

        [Authorize]
        public ActionResult GetServesByPublisher()
        {
            var UserID = User.Identity.GetUserId();

            var Serves = from app in db.ApplyForServices
                         join servee in db.Serves
                         on app.serveId equals servee.Id
                         where servee.User.Id == UserID 
                         select app;

            var grouped = from j in Serves
                          group j by j.serve.ServeName
                          into gr
                          select new ServeViewModel
                          {
                              ServeTitle = gr.Key,
                              Items = gr
                          };

            return View(grouped.ToList());

            

        }


            public ActionResult Edit(int id)
        {
            var job = db.ApplyForServices.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        public ActionResult Edit(ApplyForService s)
        {
            if (ModelState.IsValid)
            {
                s.ApplyDate = DateTime.Now;
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("GetServiceByUser");
            }
            return View(s);
        }

        public ActionResult Delete(int id)
        {

            var service = db.ApplyForServices.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForService service)
        {
            // TODO: Add delete logic here
            var myService = db.ApplyForServices.Find(service.Id);
            db.ApplyForServices.Remove(myService);
            db.SaveChanges();
            return RedirectToAction("GetServiceByUser");

        }

        [HttpGet]
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("felkhema@gmail.com", "2468F2468");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("felkhema@gmail.com"));
            mail.Subject = contact.Subject;
            mail.IsBodyHtml = true;
            string body = "اسم المرسل: " + contact.Name + "<br>" +
                            "بريد المرسل: " + contact.Email + "<br>" +
                            "عنوان الرسالة: " + contact.Subject + "<br>" +
                            "نص الرسالة: <b>" + contact.Message + "</b>";
            mail.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);
            return RedirectToAction("Index");
        }


        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Serves.Where(a => a.ServeName.Contains(searchName)
            || a.ServeContent.Contains(searchName)
            || a.Category.CategoryName.Contains(searchName)
            || a.Category.CategoryDescription.Contains(searchName)).ToList();

            return View(result);
        }




    }
}