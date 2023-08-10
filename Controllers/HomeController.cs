using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using CsvHelper.Configuration;
using CsvReadWebExample.Models;

namespace CsvReadWebExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = "|",
            };
            var filepath = Server.MapPath("~/App_Data/Order.txt");
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, configPersons))
            {
                var records = csv.GetRecords<OrderRecord>();
                var order = new Order
                {
                    OrderLines = new List<Line>(),
                };
                foreach (var record in records)
                {
                    var line = new Line
                    {
                        Sku = record.Sku,
                        Quantity = record.Quantity,
                    };
                    order.Po = record.Po;
                    order.Address = record.Address;
                    order.OrderLines.Add(line);
                }

                ViewBag.Order = order;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}