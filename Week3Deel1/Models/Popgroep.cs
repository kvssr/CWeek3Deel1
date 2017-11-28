using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Deel1.Models
{
    class Popgroep
    {
        public int PopgroepId { get; set; }
        public string Naam { get; set; }

        public List<Artiest> Artiesten { get; set; }

    }
}
