using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using catotestapp.Models;
using System.Net.Http;

namespace catotestapp.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("https://networkingdemo-api.azurewebsites.net/api/values");

            string[] list = new string[1];

            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<string[]>();
            }
            else
            {
                list[0] = response.ReasonPhrase;
            }

            ViewBag.List = list;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}