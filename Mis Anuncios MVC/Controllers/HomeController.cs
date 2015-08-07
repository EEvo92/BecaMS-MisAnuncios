using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Mis_Anuncios.Models;
using Mis_Anuncios_MVC.Models;

namespace Mis_Anuncios_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Bienvenido a Mis Anuncios";

            return View();
        }

        public async Task<ActionResult> MainPage()
        {
            ViewBag.Title = "Mis Anuncios";

            Container container = new Container();
           
            var httpClient = new HttpClient();
            
            var json = await httpClient.GetStringAsync("http://apimisanunciosms.azurewebsites.net/api/Commercials");
            container.CommercialsList = JsonConvert.DeserializeObject<List<Commercial>>(json);
            ViewBag.commercials = json;

            json = await httpClient.GetStringAsync("http://apimisanunciosms.azurewebsites.net/api/Categories");
            container.CategoriesList = JsonConvert.DeserializeObject<List<Category>>(json);
            ViewBag.categories = json;

            json = await httpClient.GetStringAsync("http://apimisanunciosms.azurewebsites.net/api/Cities");
            container.CitiesList = JsonConvert.DeserializeObject<List<City>>(json);
            ViewBag.cities = json;

            ViewBag.container = container;

            return View(container);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca de Mis anuncios";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto";

            return View();
        }
    }
}