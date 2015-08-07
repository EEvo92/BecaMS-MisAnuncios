using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Anuncios.Models
{
    public class Commercial
    {
        [Key]
        public int CommercialId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public City ComCity { get; set; }
        public Category ComCategory { get; set; }
        public int AdvertiserId { get; set; }
    }
}
