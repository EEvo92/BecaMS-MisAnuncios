using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Anuncios.Models
{
    public class Advertiser
    {
        [Key]
        public int AdvertiserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public City AdvCity { get; set; }
        public int[] CommercialsIds { get; set; }
    }
}
