using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class SzczegolyZamowienia
    {
        [Key]
        public int ID { get; set; }

        public int ZamowienieID { get; set; }

        public int ProduktID { get; set; }

        public int Ilosc { get; set; }

        public Zamowienia Zamowienie { get; set; }

        public Produkty Produkt { get; set; }
    }
}
