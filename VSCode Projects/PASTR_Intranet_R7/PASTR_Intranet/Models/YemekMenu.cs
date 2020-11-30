using System;
using System.Collections.Generic;

namespace PASTR.Intranet.Models
{
    public class YemekMenu
    {
        public DateTime Tarih { get; set; }
        public List<String> Yemekler { get; set; }
        public List<Double> Kaloriler { get; set; }
        public Double ToplamKalori
        {
            get
            {
                Double toplam = 0;
                foreach (var item in Kaloriler)
                {
                    toplam += item;
                }
                return toplam;
            }
        }

    }
}