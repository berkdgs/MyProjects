using PASTR.Intranet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace PAS.Intranet.Controllers
{
    public class ProductionController : Controller
    {
        oeeEntities db = new oeeEntities();
        DateTime uretimTarihi;
        //GET: Uretim
        public ActionResult UretimOzet(String tarih)
        {
            List<sp_OzetUretim_Result> ozetUretim = OzetUretim(tarih);
            ViewBag.UretimTarihi = uretimTarihi.ToString("dd/MM/yyyy");
            return View(ozetUretim);
        }
        public List<sp_OzetUretim_Result> OzetUretim(DateTime tarih)
        {
            if (tarih.Year != 1)
                uretimTarihi = tarih;
            else
                uretimTarihi = DateTime.Today.Date.AddDays(-1);

            return db.sp_OzetUretim(uretimTarihi).ToList();
        }
        public List<sp_OzetUretim_Result> OzetUretim(String tarih)
        {
            if (tarih != String.Empty)
                uretimTarihi = Convert.ToDateTime(tarih);
            else
                uretimTarihi = DateTime.Today.Date.AddDays(-1);

            return db.sp_OzetUretim(uretimTarihi).ToList();
        }
        public ActionResult DurusDetay(String department, String tarih)
        {
            uretimTarihi = Convert.ToDateTime(tarih);
            List<sp_ProductSteps_Result> duruslar = db.sp_ProductSteps(uretimTarihi, department).ToList();
            ViewBag.Departman = department;
            ViewBag.UretimTarihi = uretimTarihi.ToString("dd/MM/yyyy");
            return View(duruslar);
        }
        public ActionResult UretimDetay(String department, String tarih)
        {
            uretimTarihi = Convert.ToDateTime(tarih);
            List<View_UretimTR> uretimler = db.View_UretimTR
                .Where(x => x.Department == department && x.ProductionDate == uretimTarihi).OrderBy(x => x.Shift).ThenBy(x => x.Material).ToList();
            ViewBag.UretimTarihi = uretimTarihi.ToString("dd/MM/yyyy");
            ViewBag.Departman = department;
            return View(uretimler);
        }
        public ActionResult CreateChart(String tarih)
        {
            var data = db.sp_OzetUretim(Convert.ToDateTime(tarih)).ToList();

            Legend lg = new Legend("Departmanlar")
            {
                BackColor = Color.Transparent,
                LegendStyle = LegendStyle.Row,
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Arial", 8f, FontStyle.Bold),
                Title = "Departmanlar",
                TitleFont = new Font("Arial", 11f, FontStyle.Bold)
            };

            Series urt = new Series("Üretimler (Ad.)");
            urt.ChartType = SeriesChartType.Column;
            urt["DrawingStyle"] = "Cylinder";

            Series drs = new Series("Duruşlar (dk.)");
            drs.ChartType = SeriesChartType.Column;
            drs["DrawingStyle"] = "Cylinder";

            Chart chart = new Chart()
            {
                Width = Unit.Pixel(900),
                Height = Unit.Pixel(600),
                BackColor = ColorTranslator.FromHtml("#C9DC87"),
                BackGradientStyle = GradientStyle.TopBottom,
                BackSecondaryColor = Color.White,
                BorderSkin = new BorderSkin
                {
                    SkinStyle = BorderSkinStyle.Emboss,
                    BorderColor = Color.FromArgb(64, 64, 64, 64),
                    BorderDashStyle = ChartDashStyle.Solid
                }
            };
            
            chart.ChartAreas.Add(new ChartArea() { BackColor = Color.Transparent });
            chart.Legends.Add(lg);
            chart.Series.Add(urt);
            chart.Series.Add(drs);

            DataPoint pt;

            for (int x = 0; x < data.Count; x++)
            {
                int ptIdx = urt.Points.AddXY(data[x].Department, data[x].tpUretim);
                pt = urt.Points[ptIdx];
                pt.Label = "#VALY{#,###}";
                pt.LabelBackColor = Color.White;
                pt.LabelBorderDashStyle = ChartDashStyle.Solid;
                pt.LabelBorderColor = Color.Black;
                pt.Font = new Font("Arial", 8f, FontStyle.Bold);
                pt.LabelForeColor = Color.Green;

            }

            for (int x = 0; x < data.Count; x++)
            {
                int ptIdx = drs.Points.AddXY(data[x].Department, data[x].tpDurus);
                pt = drs.Points[ptIdx];
                pt.Label = "#VALY{#,###}";
                pt.LabelBackColor = Color.White;
                pt.LabelBorderDashStyle = ChartDashStyle.Solid;
                pt.LabelBorderColor = Color.Black;
                pt.Font = new Font("Arial", 8f, FontStyle.Bold);
                pt.LabelForeColor = Color.Green;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                return File(ms.ToArray(), "image/png");
            }
        }
        public ActionResult Malzemeler()
        {
            List<BasicMaterial> malzemeler = db.BasicMaterial.Where(x => x.Plant == "3000").OrderBy(x => x.Material).ToList() ;
            return View(malzemeler);
        }

        
    }
}