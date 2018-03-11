using Fiap.ioT.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fiap.ioT.UI.Controllers
{
    public class HomeController : Controller
    {
        //Localhost
        //string Baseurl = "http://localhost:32138/";

        //WEB
        string Baseurl = "http://fiapiotapi.azurewebsites.net/";
        public async Task<ActionResult> Index()
        {
            List<Medida> EmpInfo = new List<Medida>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/medidas");

                if (Res.IsSuccessStatusCode)
                { 
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result; 
                    EmpInfo = JsonConvert.DeserializeObject<List<Medida>>(EmpResponse);

                }
                return View(EmpInfo);
            }
        }
    }
}