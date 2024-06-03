using Amsterdam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Amsterdam.Controllers
{
    public class AmsterdamController : Controller
    {
        // GET: Amsterdam


        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult GenelPartial()
        {
            int No = 0;
            int ExNo = 0;
            int ExNo1 = 0;
            int ExNo2 = 0;
            int ExNo3 = 0;
            int SayfaNo = 0;
            string Bul = "";
            string Tarih1 = "";
            string Tarih2 = "";
            string Kod = "";
            string Title = "";
            if (RouteData.Values["id"] != null)
            {

                Bul = RouteData.Values["id"].ToString();
                try
                {
                    No = Convert.ToInt32(RouteData.Values["id"].ToString());
                }
                catch (Exception)
                {


                }
            }
            if (Request.QueryString["ExNo"] != null && Request.QueryString["ExNo"] != "")
            {
                try
                {
                    ExNo = Convert.ToInt32(Request.QueryString["ExNo"]);
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["SayfaNo"] != null && Request.QueryString["SayfaNo"] != "")
            {
                try
                {
                    SayfaNo = Convert.ToInt32(Request.QueryString["SayfaNo"]);
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["Tarih1"] != null && Request.QueryString["Tarih1"] != "")
            {
                try
                {
                    Tarih1 = Request.QueryString["Tarih1"].ToString();
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["Tarih2"] != null && Request.QueryString["Tarih2"] != "")
            {
                try
                {
                    Tarih2 = Request.QueryString["Tarih2"].ToString();
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["ExNo1"] != null && Request.QueryString["ExNo1"] != "")
            {
                try
                {
                    ExNo1 = Convert.ToInt32(Request.QueryString["ExNo1"]);
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["ExNo2"] != null && Request.QueryString["ExNo2"] != "")
            {
                try
                {
                    ExNo2 = Convert.ToInt32(Request.QueryString["ExNo2"]);
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["ExNo3"] != null && Request.QueryString["ExNo3"] != "")
            {
                try
                {
                    ExNo3 = Convert.ToInt32(Request.QueryString["ExNo3"]);
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["Kod"] != null && Request.QueryString["Kod"] != "")
            {
                try
                {
                    Kod = Request.QueryString["Kod"].ToString();
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["Title"] != null && Request.QueryString["Title"] != "")
            {
                try
                {
                    Title = Request.QueryString["Title"].ToString();
                }
                catch (Exception)
                {


                }

            }
            if (Request.QueryString["Bul"] != null && Request.QueryString["Bul"] != "")
            {
                try
                {
                    Bul = Request.QueryString["Bul"].ToString();
                }
                catch (Exception)
                {


                }

            }

            FindObject po = new FindObject()
            {
                No = No,
                Bul = Bul,
                ExNo = ExNo,
                ExNo1 = ExNo1,
                ExNo2 = ExNo2,
                ExNo3 = ExNo3,
                Tarih1 = Tarih1,
                Tarih2 = Tarih2,
                SayfaNo = SayfaNo,
                Kod = Kod,
                Title = Title,
            };

            return PartialView("partial/" + Request.QueryString["partial"], po);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SendMail(string subject, string name, string email, string message)
        {
            ResponseObject ro = new Models.ResponseObject();
            try
            {
                DataModel dm = new DataModel();
                var mails = dm.tblMail.FirstOrDefault();
                if (mails != null) { 
                    var credentials = new NetworkCredential(mails.Mail, mails.Pass);
                string body = @"
                                <table>   
                                  <tr>
                                    <td>Konu:</td>
                                    <td>" + (subject != null ? subject : "") + @"</td>
                                  </tr>
                                  <tr>
                                    <td>Gonderen</td>
                                    <td>" + (name != null ? name : "") + @"</td>
                                  </tr>
                                    <tr>
                                    <td>Mail:</td>
                                    <td>" + (email != null ? email : "") + @"</td>
                                  </tr>
                                    <tr>
                                    <td>Mesaj:</td>
                                    <td>" + (message != null ? message : "") + @"</td>
                                  </tr>
                                </table>
                         ";

                var mail = new System.Net.Mail.MailMessage()
                {
                    From = new System.Net.Mail.MailAddress(mails.Mail, "WEB_Iletisim"),
                    Subject = subject,
                    Body = body
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new System.Net.Mail.MailAddress(email));
                var client = new System.Net.Mail.SmtpClient()
                {
                    Port = Convert.ToInt32(mails.Port),
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = mails.Host,
                    EnableSsl = false,
                    Credentials = credentials
                };
                client.Send(mail);
            }
                ro.Result = true;
            ro.Mess = "Kayıt Edildi.";
        }
            catch (Exception ex)
            {
                ro.Result = false;
                ro.Mess = "HATA->" + ex.ToString();

            }
            return Json(ro);
}
    }
}