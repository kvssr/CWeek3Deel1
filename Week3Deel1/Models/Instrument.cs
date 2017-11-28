using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Deel1.Models
{
    class Instrument
    {
        public int InstrumentId { get; set; }
        public string Naam { get; set; }

        public List<Artiest> Artiesten { get; set; }
    }
}
