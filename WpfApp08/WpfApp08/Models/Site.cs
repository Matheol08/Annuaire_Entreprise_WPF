using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp08.Models
{
    public class Site
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string Ville { get; set; }
        public string Statut_Site { get; set; }
    }
}
