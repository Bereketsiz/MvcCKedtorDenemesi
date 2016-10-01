using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace MvcCKedtorDenemesi.Models
{
    public class Urun
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }

        [DisplayName("Ürün Fiyatı")]
        public decimal Fiyat { get; set; }

        [DisplayName("Ürün Resmi")]
        public string UrunResim { get; set; }

        [DisplayName("Ürün Detayı")]
        public string Detay { get; set; }

    }
}