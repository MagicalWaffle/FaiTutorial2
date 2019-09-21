using System;
using System.Collections.Generic;

namespace FAITutorial2.Models
{
    public partial class Punetori
    {
        public int PunetoriId { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Gjinia { get; set; }
        public int? RoliId { get; set; }
        public long? NumriPersonal { get; set; }

        public Roli Roli { get; set; }
    }
}
