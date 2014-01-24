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
			var langs = Parser.DeserializeLangs(File.ReadAllText(@"..\..\langs.xml"), File.ReadAllText(@"..\..\stylers.xml"), out encoding);
			var langDetector = new LangDetector();
			langDetector.InitLanguages(langs, encoding);
		}
	}
}
