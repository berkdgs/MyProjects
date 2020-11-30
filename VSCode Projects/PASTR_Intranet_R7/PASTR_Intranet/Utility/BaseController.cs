using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PASTR.Intranet.Models;

// ReSharper disable once CheckNamespace
namespace PASTR.Intranet.Utility
{
    public class BaseController : Controller
    {
        // GET: Base
        public void ShowMessage(MessageType type, String messageText, Int32? time = 3, Boolean closeable = true)
        {
            Message msg = new Message();
            msg.Type = type;
            if (type == MessageType.Success)
                msg.Text = messageText;
            else
                msg.Text = messageText;
            msg.Duration = time;
            msg.Closeable = closeable;

            List<Message> messages = null;

            if (TempData[Message.MessageName] != null)
                messages = (List<Message>)TempData[Message.MessageName];
            else
                messages = new List<Message>();
            messages.Add(msg);
            TempData[Message.MessageName] = messages;
        }
        public IEnumerable<YemekMenu> Yemek(Boolean gunluk)
        {

            String pathExcel = @"C:\inetpub\wwwroot\App_Data\Yemek_Menu.xlsm";
            OleDbConnection connectionExcel = new OleDbConnection($"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {pathExcel};Extended Properties = 'Excel 12.0 Macro;HDR=YES'");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT dt.Tarih, dt.Yemek1, k1.Kalori, dt.Yemek2, k2.Kalori, dt.Yemek3, k3.Kalori, dt.Yemek4, k4.Kalori, dt.Yemek5, k5.Kalori FROM [Data$] dt, [Kaloriler$] k1, [Kaloriler$] k2, [Kaloriler$] k3, [Kaloriler$] k4, [Kaloriler$] k5 WHERE dt.Yemek1 = k1.Yemek AND dt.Yemek2 = k2.Yemek AND dt.Yemek3 = k3.Yemek AND dt.Yemek4 = k4.Yemek AND dt.Yemek5 = k5.Yemek", connectionExcel);
            DataSet ds = new DataSet();
            da.Fill(ds, "YemekTablosu");
            DataTable dt = ds.Tables["YemekTablosu"];

            var data = ds.Tables["YemekTablosu"].AsEnumerable();
            IEnumerable<YemekMenu> query;
            if (gunluk)
            {
                query = data.Where(x => x.Field<DateTime>("Tarih").Date == DateTime.Today)
                    .Select(x => new YemekMenu
                    {
                        Tarih = x.Field<DateTime>("Tarih"),
                        Yemekler = new List<string>
                        {
                            x.Field<string>("Yemek1"),
                            x.Field<string>("Yemek2"),
                            x.Field<string>("Yemek3"),
                            x.Field<string>("Yemek4"),
                            x.Field<string>("Yemek5")
                        },
                        Kaloriler = new List<double>
                        {
                            x.Field<double>("k1.Kalori"),
                            x.Field<double>("k2.Kalori"),
                            x.Field<double>("k3.Kalori"),
                            x.Field<double>("k4.Kalori"),
                            x.Field<double>("k5.Kalori")
                        }
                    });
            }
            else
            {

                query = data.Where(x => x.Field<DateTime>("Tarih").Month == DateTime.Today.Month).OrderBy(x => x.Field<DateTime>("Tarih"))
                    .Select(x => new YemekMenu
                    {
                        Tarih = x.Field<DateTime>("Tarih"),
                        Yemekler = new List<string>
                        {
                            x.Field<string>("Yemek1"),
                            x.Field<string>("Yemek2"),
                            x.Field<string>("Yemek3"),
                            x.Field<string>("Yemek4"),
                            x.Field<string>("Yemek5")
                        },
                        Kaloriler = new List<double>
                        {
                            x.Field<double>("k1.Kalori"),
                            x.Field<double>("k2.Kalori"),
                            x.Field<double>("k3.Kalori"),
                            x.Field<double>("k4.Kalori"),
                            x.Field<double>("k5.Kalori")
                        }
                    });
            }

            return query;
        }
    }
}