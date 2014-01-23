using NppPluginNET;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoLangDetect.Tests
{
	[TestFixture]
	public class LandDetectorTests
	{
		[Test]
		public void InitLanguages()
		{
			string encoding;
			var langs = LangParser.Deserialize(File.ReadAllText(@"..\..\langs.xml"), out encoding);
			var langDetector = new LangDetector();
			langDetector.InitLanguages(langs, encoding);
		}
	}
}
