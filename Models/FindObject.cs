using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amsterdam.Models
{
    [Serializable]
    public class FindObject
    {
        public long No { get; set; }
        public string Bul { get; set; }
        public string Kod { get; set; }
        public int ExNo { get; set; }
        public int ExNo1 { get; set; }
        public int ExNo2 { get; set; }
        public int ExNo3 { get; set; }
        public int ExNo4 { get; set; }
        public int ExNo5 { get; set; }
        public int ExNo6 { get; set; }
        public string Tarih1 { get; set; }
        public string Tarih2 { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Title { get; set; }
        public int UygulamaNo { get; set; }
        public long SayfaNo { get; set; }
    }

    public class ResponseObject
    {
        public int? No { get; set; }
        public bool Result { get; set; }
        public string Mess { get; set; }

    }
}