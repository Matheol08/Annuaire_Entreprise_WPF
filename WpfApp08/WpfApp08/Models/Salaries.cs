using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp08.Models3;
using WpfApp08.Models2;
using Newtonsoft.Json;

namespace WPF_Salaries
{
    public class Salaries
    {

        [Required]
        [Key]

        public int IDSalaries { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone_fixe { get; set; } 
        public string Telephone_portable { get; set; }
        public string Email { get; set; }    
        [ForeignKey("Service")]
        
        public int IDservice { get; set; }

        public virtual Service Service { get; set; }

        public string Nom_Service
        {
            get { return Service?.Nom_Service; }
        }

        [ForeignKey("Sites")]
        public int IDSite { get; set; }
       
        public virtual Sites Sites { get; set; }

        public string Ville
        {
            get { return Sites?.Ville; }
        }
    }
}


