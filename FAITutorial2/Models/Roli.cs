using System;
using System.Collections.Generic;

namespace FAITutorial2.Models
{
    public partial class Roli
    {
        public Roli()
        {
            Punetori = new HashSet<Punetori>();
        }

        public int RoliId { get; set; }
        public string Roli1 { get; set; }

        public ICollection<Punetori> Punetori { get; set; }
    }
}
