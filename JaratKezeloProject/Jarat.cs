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
        public DateTime EredetiIndulasiIdo { get; }
        public DateTime IndulasiIdo { get; private set; }

        public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulasiIdo)
        {
            JaratSzam = jaratSzam;
            RepterHonnan = repterHonnan;
            RepterHova = repterHova;
            EredetiIndulasiIdo = indulasiIdo;
            IndulasiIdo = indulasiIdo;
        }

        public void ModositIndulasiIdo(int kesesPerc)
        {
            var ujIdo = IndulasiIdo.AddMinutes(kesesPerc);

            if (ujIdo < EredetiIndulasiIdo)
                throw new ArgumentException("A késés negatívba nem mehet az eredeti indulási idő alá!");

            IndulasiIdo = ujIdo;
        }
    }
}