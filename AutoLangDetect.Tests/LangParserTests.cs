using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoLangDetect.Tests
{
	[TestFixture]
	public class LangParserTests
	{
		[Test]
		public void Parse()
		{
			var parser = new LangParser();
			parser.Parse(File.ReadAllText(@"..\..\langs.xml"));
			Assert.AreEqual(56, parser.Languages.Length);
		}
	}
}
