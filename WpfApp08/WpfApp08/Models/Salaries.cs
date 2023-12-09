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
using System.Windows.Navigation;

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
        [ForeignKey("Service_Employe")]

        public int IDService { get; set; }

        public virtual Service Service_Employe { get; set; }

       
        [ForeignKey("Sites")]
        public int IDSite { get; set; }

        public virtual Sites Sites { get; set; }

        
    }
    public class Ajout_Salaries
    {

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone_fixe { get; set; }
        public string Telephone_portable { get; set; }
        public string Email { get; set; }
        [ForeignKey("Service_Employe")]
        public int IDService { get; set; }


        [ForeignKey("Sites")]
        public int IDSite { get; set; }

    }
}

