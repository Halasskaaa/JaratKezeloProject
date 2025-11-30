using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject.Tests
{
    [TestFixture]
    internal class JaratKezeloTest
    {
        [Test]
        public void UjJarat_HozzaadodikASikeresenLetrehozottJarat()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("ABC123", "BUD", "LAX", new DateTime(2025, 1, 1, 8, 0, 0));

            var jaratok = jk.Jaratok();

            Assert.That(jaratok.Count, Is.EqualTo(1));
        }

        [Test]
        public void Keses_NoveliAzIndulasiIdot()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("ABC123", "BUD", "LAX", new DateTime(2025, 1, 1, 8, 0, 0));

            jk.Keses("ABC123", 30);

            var indulasiIdo = jk.IndulasiIdo("ABC123");

            Assert.That(indulasiIdo, Is.EqualTo(new DateTime(2025, 1, 1, 8, 30, 0)));
        }

        [Test]
        public void Keses_LevonasEsebenNemCsokkenhetNullaAlatt()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("ABC123", "BUD", "LAX", new DateTime(2025, 1, 1, 8, 0, 0));

            jk.Keses("ABC123", 20);
            jk.Keses("ABC123", -50);

            var indulasiIdo = jk.IndulasiIdo("ABC123");

            Assert.That(indulasiIdo, Is.EqualTo(new DateTime(2025, 1, 1, 8, 0, 0)));
        }

        [Test]
        public void UjJarat_HibasHaMarLetezikIlyenJarat()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("ABC123", "BUD", "LAX", DateTime.Now);

            Assert.Throws<ArgumentException>(() =>
            {
                jk.UjJarat("ABC123", "BUD", "LAX", DateTime.Now);
            });
        }

        [Test]
        public void IndulasiIdo_HelyesIdotAdVissza()
        {
            JaratKezelo jk = new JaratKezelo();
            var idopont = new DateTime(2025, 1, 1, 8, 0, 0);

            jk.UjJarat("DEF456", "BUD", "NYC", idopont);

            Assert.That(jk.IndulasiIdo("DEF456"), Is.EqualTo(idopont));
        }
    }
}