using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amsterdam.Helper
{
    [Serializable]
    public class MySession
    {
        public short No { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }

    public class Sessions
    {
        public static MySession Bilgi
        {
            get { return HttpContext.Current.Session["rpr49vdhyd"] as MySession; }
            set { HttpContext.Current.Session["rpr49vdhyd"] = value; }
        }

    }
}