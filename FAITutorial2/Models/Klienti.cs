using System;
using System.Collections.Generic;

namespace FAITutorial2.Models
{
    public partial class Klienti
    {
        public int KlientiId { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public int NumriTelefonit { get; set; }
        public string Email { get; set; }
    }
}
