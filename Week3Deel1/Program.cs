using System;
using Week3Deel1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Week3Deel1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PopgroepContext pc = new PopgroepContext();

            //Instrumenten aanmaken
            Instrument i1 = new Instrument { Naam = "Gitaar" };
            Instrument i2 = new Instrument { Naam = "Bass" };
            Instrument i3 = new Instrument { Naam = "Drum" };

            //Groepen aanmaken
            Popgroep p1 = new Popgroep { Naam = "Groep1" };
            Popgroep p2 = new Popgroep { Naam = "Groep2" };
            Popgroep p3 = new Popgroep { Naam = "Groep3" };

            //Artiesten aanmaken en de groep en instrument toevoegen
            Artiest a1 = new Artiest { Naam = "Arie", Popgroep = p1, Instrument = i1 };
            Artiest a2 = new Artiest { Naam = "Bert", Popgroep = p1, Instrument = i2 };
            Artiest a3 = new Artiest { Naam = "Cornelis", Popgroep = p1, Instrument = i3 };
            Artiest a4 = new Artiest { Naam = "Dirk", Popgroep = p2, Instrument = i1 };
            Artiest a5 = new Artiest { Naam = "Eva", Popgroep = p2, Instrument = i2 };
            Artiest a6 = new Artiest { Naam = "Ferdi", Popgroep = p2, Instrument = i3 };
            Artiest a7 = new Artiest { Naam = "Gerda", Popgroep = p3, Instrument = i1 };
            Artiest a8 = new Artiest { Naam = "Henk", Popgroep = p3, Instrument = i3 };

            //Alles aan de dcContext toevoegen
            pc.Artiesten.Add(a1);
            pc.Artiesten.Add(a2);
            pc.Artiesten.Add(a3);
            pc.Artiesten.Add(a4);
            pc.Artiesten.Add(a5);
            pc.Artiesten.Add(a6);
            pc.Artiesten.Add(a7);
            pc.Artiesten.Add(a8);

            //Opslaan naar de database
            pc.SaveChanges();

            //Haalt alle popgroepen en artiesten in een groep op. Eager.
            foreach (Popgroep p in pc.Popgroepen.Include(p => p.Artiesten))
            {
                Console.WriteLine(p.Naam);
                foreach(Artiest a in p.Artiesten)
                {
                    Console.WriteLine("-{0}", a.Naam);
                }
            }

            //Haalt alle popgroepen op die meer dan 2 bandleden hebben.
            Console.WriteLine("\nDeze groepen hebben meer dan 2 bandleden.");
            foreach (Popgroep p in pc.Popgroepen.Include(p => p.Artiesten))
            {
                if(p.Artiesten.Count > 2)
                {
                    Console.WriteLine("-{0}", p.Naam);
                }
            }

            //Haalt de groepen, artiesten en instrumenten op.
            foreach(Popgroep p in pc.Popgroepen.Include(p => p.Artiesten).ThenInclude(a => a.Instrument))
            {
                Console.WriteLine(p.Naam);
                foreach (Artiest a in p.Artiesten)
                {
                    Console.WriteLine("-{0} - {1}", a.Naam, a.Instrument.Naam);
                }
            }

            //Haalt de artiesten van groep2 op d.m.v. Explicit loading.
            Popgroep pgroep = pc.Popgroepen.Where(p => p.Naam.Equals("Groep2")).First();
            pc.Entry(pgroep).Collection(p => p.Artiesten).Load();
            Console.WriteLine("Groep2");
            foreach(Artiest a in pgroep.Artiesten)
            {
                Console.WriteLine("-{0}", a.Naam);
            }
            Console.ReadKey();
        }
    }
}
