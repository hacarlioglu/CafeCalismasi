
using Amsterdam.Helper;
using Amsterdam.Models;
using System;

using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amsterdam.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult User()
        {
            return View();
        }

        public ActionResult Log()
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
        public JsonResult EditCategory(tblCategory po, HttpPostedFileBase Images, string customCheck)
        {
            ResponseObject ro = new Models.ResponseObject();
            DataModel dm = new DataModel();
            tblCategory cat = new tblCategory();
            try
            {
                if (po.No > 0)
                {
                    cat = dm.tblCategory.Where(w => w.No == po.No).FirstOrDefault();
                }
                cat.Name = po.Name;
                cat.Description = po.Description;
                cat.Number = po.Number==null?0: po.Number;
                cat.IsActive = customCheck == "true" || customCheck == "on" ? true : false;

                /*
                   string pic = System.IO.Path.GetFileName(Images.FileName);
                   string path = System.IO.Path.Combine(
                                          Server.MapPath("~/Asset/Category/"), pic);

                   Images.SaveAs(path);
                   */
                if (Images != null)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Images.InputStream.CopyTo(ms);
                        cat.Image = ms.GetBuffer();
                    }
                if (po.No > 0)
                {
                    LogSave("tblCategory", po.No, "Düzenleme-" + cat.Name);
                    dm.SaveChanges();
                }
                else
                {
                    dm.tblCategory.Add(cat);
                    dm.SaveChanges();
                    LogSave("tblCategory", cat.No, "Kaydetme-" + cat.Name);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RemoveCategory(int No)
        {
            ResponseObject ro = new Models.ResponseObject();
            DataModel dm = new DataModel();
            tblCategory cat = new tblCategory();
            try
            {
                if (No > 0)
                {
                    cat = dm.tblCategory.Where(w => w.No == No).FirstOrDefault();
                }
                foreach (var item in cat.tblProducts.ToList())
                {
                    item.CategoryNo = null;
                    dm.SaveChanges();
                }

                LogSave("tblCategory", cat.No, "Silme-" + cat.Name);
                dm.tblCategory.Remove(cat);
                dm.SaveChanges();
                ro.Result = true;
                ro.Mess = "Silme İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                ro.Result = false;
                ro.Mess = "Hata->" + ex.ToString();
            }


            return Json(ro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditProduct(int No, string Description, string VAT, string CategoryNo, string Price, string Name, HttpPostedFileBase Images, string customCheck, string IsVAT)
        {
            ResponseObject ro = new Models.ResponseObject();
            DataModel dm = new DataModel();
            tblProduct pro = new tblProduct();
            try
            {
                if (No > 0)
                {
                    pro = dm.tblProduct.Where(w => w.No == No).FirstOrDefault();
                }
                pro.CategoryNo = Convert.ToInt32(CategoryNo);
                pro.Name = Name;
                pro.Price = Convert.ToDecimal(Price, CultureInfo.InvariantCulture);
                pro.VAT = Convert.ToDecimal(VAT, CultureInfo.InvariantCulture);
                pro.IsVAT = IsVAT == "true" || IsVAT == "on" ? true : false;
                pro.IsActive = customCheck == "true" || customCheck == "on" ? true : false;
                pro.Description = Description;
                /*
                   string pic = System.IO.Path.GetFileName(Images.FileName);
                   string path = System.IO.Path.Combine(
                                          Server.MapPath("~/Asset/Category/"), pic);

                   Images.SaveAs(path);
                   */
                if (Images != null)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Images.InputStream.CopyTo(ms);
                        pro.Image = ms.GetBuffer();
                    }
                if (No > 0)
                {
                    LogSave("tblProduct", pro.No, "Düzenleme-" + pro.Name);
                    dm.SaveChanges();
                }
                else
                {
                    pro.Code = "0000" + ((dm.tblProduct.OrderByDescending(o => o.No).First().No) + 1).ToString();
                    dm.tblProduct.Add(pro);
                    dm.SaveChanges();
                    LogSave("tblProduct", pro.No, "Kaydetme-" + pro.Name);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RemoveProduct(int No)
        {
            ResponseObject ro = new Models.ResponseObject();
            DataModel dm = new DataModel();
            tblProduct pro = new tblProduct();
            try
            {
                if (No > 0)
                {
                    pro = dm.tblProduct.Where(w => w.No == No).FirstOrDefault();
                }
                LogSave("tblProduct", pro.No, "Silme-" + pro.Name);
                dm.tblProduct.Remove(pro);
                dm.SaveChanges();
                ro.Result = true;
                ro.Mess = "Silme İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                ro.Result = false;
                ro.Mess = "Hata->" + ex.ToString();
            }


            return Json(ro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(string userName, string password)
        {
            ResponseObject ro = new Models.ResponseObject();
            DataModel dm = new DataModel();
            string pass = Cryption.Encrypt(password);
            var kul = dm.tblUser.Where(w => w.UserName == userName && w.Password == pass && w.IsActive == true).FirstOrDefault();
            try
            {
                if (kul != null)
                {
                    Sessions.Bilgi = new MySession();
                    Sessions.Bilgi.No = kul.No;
                    Sessions.Bilgi.Name = kul.Name;
                    Sessions.Bilgi.UserName = kul.UserName;
                    ro.Result = true;
                    ro.Mess = "Giriş Başarılı";
                }
                else
                {
                    ro.Result = false;
                    ro.Mess = "Bilgilerinizi Kontrol Ediniz";
                }

            }
            catch (Exception ex)
            {
                ro.Result = false;
                ro.Mess = "Hata->" + ex.ToString();
            }
            return Json(ro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditUser(tblUser user, string customCheck)
        {
            ResponseObject ro = new Models.ResponseObject();
            DataModel dm = new DataModel();
            tblUser us = new tblUser();
            try
            {
                if (user.No > 0)
                {
                    us = dm.tblUser.Where(w => w.No == user.No).FirstOrDefault();
                }
                us.Name = user.Name;
                us.UserName = user.UserName;
                us.Password = Cryption.Encrypt(user.Password);
                us.IsActive = customCheck == "true" || customCheck == "on" ? true : false;
                if (user.No > 0)
                {
                    LogSave("tblUser", us.No, "Düzenleme-" + us.Name);
                    dm.SaveChanges();

                }
                else
                {
                    dm.tblUser.Add(us);
                    dm.SaveChanges();
                    LogSave("tblUser", us.No, "Kaydetme-" + us.Name);
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

        public void LogSave(string TableName, int No, string Description)
        {
            try
            {
                DataModel dm = new DataModel();
                tblLog log = new tblLog();
                log.UserNo = Sessions.Bilgi.No;
                log.TableName = TableName;
                log.Date = DateTime.Now;
                log.TableNo = No;
                log.Description = Description;
                dm.tblLog.Add(log);
                dm.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public JsonResult EditInfo(tblInfo i)
        {
            ResponseObject ro = new Models.ResponseObject();
            try
            {
                DataModel dm = new DataModel();
                tblInfo log = new tblInfo();
                tblInfo info = new tblInfo();
                 if(dm.tblInfo.FirstOrDefault() != null)
                {
                    info = dm.tblInfo.FirstOrDefault();
                }

                info.Adress = i.Adress;
                info.City = i.City;
                info.Ilce = i.Ilce;
                info.Phone = i.Phone;
                if (dm.tblInfo.FirstOrDefault() != null)
                {
                    dm.SaveChanges();
                }
                else
                {
                    dm.tblInfo.Add(info);
                    dm.SaveChanges();
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
