using System;
using System.Collections.Generic;

namespace FAITutorial2.Models
{
    public partial class Vendori
    {
        public int VendoriId { get; set; }
        public string Emri { get; set; }
        public string Lokacioni { get; set; }
        public int NrKontaktues { get; set; }
        public int BankAccount { get; set; }
    }
}
