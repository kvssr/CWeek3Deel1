using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Deel1.Models
{
    class Artiest
    {
        public int ArtiestId { get; set; }
        public string Naam { get; set; }

        public int PopgroepId { get; set; }
        public Popgroep Popgroep { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}
