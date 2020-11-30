using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekListExcel.Entities
{
    class MaaliyetMerkezleri
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public List<Yemekler> Yemekler { get; set; }
    }
}