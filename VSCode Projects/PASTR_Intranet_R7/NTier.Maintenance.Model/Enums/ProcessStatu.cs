using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Maintenance.Model.Enums
{
    public enum ProcessStatu
    {
        [Display(Name ="Sürüyor")] Suruyor = 0,
        [Display(Name ="Parça Bekliyor")] ParcaBekliyor = 5,
        [Display(Name ="Onay Bekliyor")] OnayBekliyor = 8,
        [Display(Name ="Tamamlandı")] Tamamlandi = 9
    }
}
