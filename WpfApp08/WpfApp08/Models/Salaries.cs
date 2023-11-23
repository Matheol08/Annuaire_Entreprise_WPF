using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Salaries
{
    public class Salaries
    { 

        [Required]
        [Key]
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone_fixe { get; set; }
        public string Telephone_portable { get; set; }
        public string Email { get; set; }
        [ForeignKey("Service")]
        public int IDservice { get; set; }
        [ForeignKey("Site")]

        public int IDsite { get; set; }

    }
}
