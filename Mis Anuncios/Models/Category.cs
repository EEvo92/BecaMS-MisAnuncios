using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mis_Anuncios.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryType { get; set; }
    }
}
