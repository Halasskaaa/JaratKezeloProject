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
			jaratKezelo.UjJarat();
		}
	}
}
