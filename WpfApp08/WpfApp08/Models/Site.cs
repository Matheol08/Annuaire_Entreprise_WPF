using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp08.Models3
{
    public class Sites
    {
        [Required]
        [Key]
        public int IDSite { get; set; }
        public string Ville { get; set; }
        public string Statut_Site { get; set; }
    }
}
