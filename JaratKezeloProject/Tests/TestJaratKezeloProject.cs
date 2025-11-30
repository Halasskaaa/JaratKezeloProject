using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject.Tests
{
	internal class TestJaratKezeloProject
	{
		JaratKezelo jaratKezelo;

		[SetUp]
		public void SetUp()
		{
			jaratKezelo = new JaratKezelo();
		}
		[Test]
        public void UjJarat()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("XY123", "BUD", "NYC", new DateTime(2025, 1, 1, 12, 00, 00));

            var indul = jk.MikorIndul("XY123");

            Assert.That(indul, Is.EqualTo(new DateTime(2025, 1, 1, 12, 00, 00)));
        }

    }
}
