using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    public class Jarat
    {
        public string JaratSzam { get; }
        public string RepterHonnan { get; }
        public string RepterHova { get; }
        public DateTime IndulasiIdo { get; private set; }

        public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulasiIdo)
        {
            JaratSzam = jaratSzam;
            RepterHonnan = repterHonnan;
            RepterHova = repterHova;
            IndulasiIdo = indulasiIdo;
        }

        public void ModositIndulasiIdo(int kesesPerc)
        {
            var ujIdo = IndulasiIdo.AddMinutes(kesesPerc);

            if (ujIdo < IndulasiIdo)
                IndulasiIdo = IndulasiIdo;
            else
                IndulasiIdo = ujIdo;
        }
    }

    public class JaratKezelo
    {
        private Dictionary<string, Jarat> jaratok = new Dictionary<string, Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.ContainsKey(jaratSzam))
                throw new ArgumentException("A járat már létezik!");

            var j = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
            jaratok.Add(jaratSzam, j);
        }

        public void Keses(string jaratSzam, int keses)
        {
            if (!jaratok.ContainsKey(jaratSzam))
                throw new ArgumentException("Nincs ilyen járat!");

            var j = jaratok[jaratSzam];

            j.ModositIndulasiIdo(keses);
        }

        public List<Jarat> Jaratok()
        {
            return jaratok.Values.ToList();
        }

        public DateTime IndulasiIdo(string jaratSzam)
        {
            if (!jaratok.ContainsKey(jaratSzam))
                throw new ArgumentException("Nincs ilyen járat!");

            return jaratok[jaratSzam].IndulasiIdo;
        }
    }
}