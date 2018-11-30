using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SqlToElasticSearchConverter {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View(new ConvertModel());
        }

        [HttpPost]
        public IActionResult Index(ConvertModel model) {

            try {
                var converter = new SqlToElasticSearchConversion(model.SQLQuery);
                model.ElasticQuery = converter.ElasticQuery;
            }
            catch (Exception ex) {
                model.ElasticQuery = $"Sorry, something went wrong. Error: {ex.Message}";
            }

            return View(model);
        }

        public IActionResult About() => View();
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
