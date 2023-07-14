using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class Zamowienia
    {
        [Key]
        public int ID { get; set; }

        public int KlientID { get; set; }

        public System.DateTime DataZamowienia { get; set; }

        // Define the navigation property for the related Klient
        public Klienci Klient { get; set; }
    }
}
