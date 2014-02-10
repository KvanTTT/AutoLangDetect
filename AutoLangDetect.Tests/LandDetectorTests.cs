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

		[Test]
		public void CheckAutodetection()
		{
			string encoding;
			var langs = Parser.DeserializeLangs(File.ReadAllText(@"..\..\langs.xml"), File.ReadAllText(@"..\..\stylers.xml"), out encoding);
			var langDetector = new LangDetector();
			langDetector.InitLanguages(langs, encoding);

			var langFilePaths = Directory.GetFiles(@"..\..\Data");
			var detectedLangs = new Dictionary<string, NppLanguage>();
			int matchedItems = 0;
			foreach (var langFile in langFilePaths)
			{
				var langData = File.ReadAllText(langFile);
				var detectedLang = langDetector.DetectLanguage(langData);
				detectedLangs.Add(Path.GetFileName(langFile), detectedLang);
				if (langDetector.ExtensionLangs[Utils.GetExtensionWithoutDot(langFile)] == detectedLang)
					matchedItems++;
			}
		}
	}
}
