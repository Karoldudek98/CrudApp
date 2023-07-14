﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class Produkty
    {
        [Key]
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public decimal Cena { get; set; }

        public string Opis { get; set; }
    }
}
