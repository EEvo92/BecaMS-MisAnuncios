using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mis_Anuncios.Models;

namespace Mis_Anuncios_MVC.Models
{
    public class Container
    {
        public List<Commercial> CommercialsList { get; set; }
        public List<Advertiser> AdvertisersList { get; set; }
        public List<City> CitiesList { get; set; }
        public List<Category> CategoriesList { get; set; }
    }
}