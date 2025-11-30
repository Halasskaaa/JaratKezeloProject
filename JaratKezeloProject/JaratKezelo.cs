namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.Any(j => j.JaratSzam == jaratSzam))
                throw new ArgumentException("A járat már létezik!");
            jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
        }

        public void Keses(string jaratSzam, int keses)
        {
            var jarat = jaratok.FirstOrDefault(j => j.JaratSzam == jaratSzam);
            if (jarat == null)
                throw new ArgumentException("Nincs ilyen járat!");
            jarat.ModositIndulasiIdo(keses);
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            var jarat = jaratok.FirstOrDefault(j => j.JaratSzam == jaratSzam);
            if (jarat == null)
                throw new ArgumentException("Nincs ilyen járat!");
            return jarat.IndulasiIdo;
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            return jaratok
                .Where(j => j.RepterHonnan == repter)
                .Select(j => j.JaratSzam)
                .ToList();
        }

        public List<Jarat> Jaratok()
        {
            return jaratok.ToList();
        }

        public DateTime IndulasiIdo(string jaratSzam)
        {
            return MikorIndul(jaratSzam);
        }
    }
}