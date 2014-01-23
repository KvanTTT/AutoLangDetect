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
		public void SerialzieDeserialize()
		{
			string encoding;
			var langs = LangParser.Deserialize(File.ReadAllText(@"..\..\langs.xml"), File.ReadAllText(@"..\..\stylers.xml"), out encoding);
			var xml = LangParser.Serialize(langs, encoding);
			var langs2 = LangParser.Deserialize(xml, File.ReadAllText(@"..\..\stylers.xml"), out encoding);

			Assert.AreEqual(1, langs.Count(lang => lang.Value.LangType == NppPluginNET.LangType.L_USER));
			Assert.AreEqual(0, langs.Count(l => string.IsNullOrEmpty(l.Value.Description)));

			foreach (var lang in langs)
			{
				var lang2 = langs2.FirstOrDefault(l => l.Value.Name == lang.Value.Name);
				Assert.AreEqual(lang.Value.Extensions, lang2.Value.Extensions);
				Assert.AreEqual(lang.Value.CommentLine, lang2.Value.CommentLine);
				Assert.AreEqual(lang.Value.CommentStart, lang2.Value.CommentStart);
				Assert.AreEqual(lang.Value.CommentEnd, lang2.Value.CommentEnd);
				foreach (var keywords in lang.Value.Keywords)
				{
					var keywords2 = lang2.Value.Keywords.FirstOrDefault(k => k.Key == keywords.Key);
					CollectionAssert.AreEqual(keywords.Value, keywords2.Value);
				}
			}
		}
	}
}
