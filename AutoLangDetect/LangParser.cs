using NppPluginNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AutoLangDetect
{
	public class LangParser
	{
		const string UserDefined = "user defined";
		static LangType[] _langTypes;

		static LangParser()
		{
			_langTypes = (LangType[])Enum.GetValues(typeof(LangType));
		}

		public static Dictionary<string, NppLanguage> Deserialize(string langsData, out string encoding)
		{
			var serializer = new XmlSerializer(typeof(NotepadPlus));

			string s = langsData.Remove(langsData.IndexOf("?>"));
			int encStart = s.IndexOf("encoding=\"") + "encoding=\"".Length;
			if (encStart != -1)
			{
				int encEnd = s.IndexOf('"', encStart);
				encoding = s.Substring(encStart, encEnd - encStart);
			}
			else
				encoding = "";

			NotepadPlus notepadPlus;
			using (TextReader reader = new StringReader(langsData))
				notepadPlus = (NotepadPlus)serializer.Deserialize(reader);
			
			var result = XmlToNppLangs(notepadPlus);
			return result;
		}

		public static string Serialize(Dictionary<string, NppLanguage> langs, string encoding)
		{
			var xmlType = NppLangsToXml(langs);

			var serializer = new XmlSerializer(typeof(NotepadPlus));
			StringBuilder result = new StringBuilder();
			using (XmlWriter writer = XmlWriter.Create(result, new XmlWriterSettings { Indent = true } ))
			{
				var namespaces = new XmlSerializerNamespaces();
				namespaces.Add(string.Empty, string.Empty);
				serializer.Serialize(writer, xmlType, namespaces);
			}

			var str = result.ToString();
			int ind = str.IndexOf("?>");
			string s = str.Remove(ind);
			s = s.Replace("utf-16", encoding);

			return s + str.Substring(ind);
		}

		private static Dictionary<string, NppLanguage> XmlToNppLangs(NotepadPlus xmlRoot)
		{
			var result = new Dictionary<string, NppLanguage>(xmlRoot.Languages.Language.Length);
			foreach (var xmlLang in xmlRoot.Languages.Language)
			{
				var lang = new NppLanguage
				{
					Name = xmlLang.Name,
					Extensions = xmlLang.Extension.Split(' ').ToList(),
					CommentLine = xmlLang.CommentLine,
					CommentStart = xmlLang.CommentStart,
					CommentEnd = xmlLang.CommentEnd
				};

				LangType langType;
				if (Enum.TryParse("L_" + lang.Name.ToUpperInvariant(), out langType))
					lang.LangType = langType;
				else
				{
					switch (lang.Name)
					{
						case "actionscript":
							lang.LangType = LangType.L_FLASH;
							break;
						case "autoit":
							lang.LangType = LangType.L_AU3;
							break;
						case "coffeescript":
							lang.LangType = LangType.L_EXTERNAL;
							break;
						case "javascript":
							lang.LangType = LangType.L_JS;
							break;
						case "nfo":
							lang.LangType = LangType.L_ASCII;
							break;
						case "normal":
							lang.LangType = LangType.L_TEXT;
							break;
						case "postscript":
							lang.LangType = LangType.L_PS;
							break;
					}
				}

				lang.Keywords = new Dictionary<string, List<string>>();
				if (xmlLang.Keywords != null)
					foreach (var keyword in xmlLang.Keywords)
						lang.Keywords.Add(keyword.Name, keyword.Value == null ?
							new List<string>() : keyword.Value.Split(' ').ToList());

				result.Add(lang.Name, lang);
			}

			result.Add(UserDefined, new NppLanguage
			{
				Name = UserDefined,
				LangType = LangType.L_USER,
				Extensions = new List<string>(),
				Keywords = new Dictionary<string,List<string>>()
			});

			return result;
		}

		private static NotepadPlus NppLangsToXml(Dictionary<string, NppLanguage> langs)
		{
			NotepadPlus xmlType = new NotepadPlus
			{
				Languages = new Languages()
			};

			var xmlLangs = new List<Language>(langs.Count);
			foreach (var lang in langs)
			{
				if (lang.Key == UserDefined)
					continue;

				var value = lang.Value;
				var xmlLang = new Language
				{
					Name = value.Name,
					Extension = string.Join(" ", value.Extensions),
					CommentLine = value.CommentLine,
					CommentStart = value.CommentStart,
					CommentEnd = value.CommentEnd,
				};

				if (value.Keywords.Count != 0)
				{
					var xmlKeywords = new List<Keywords>(value.Keywords.Count);
					foreach (var keywords in value.Keywords)
					{
						xmlKeywords.Add(new Keywords
						{
							Name = keywords.Key,
							Value = string.Join(" ", keywords.Value)
						});
					}
					xmlLang.Keywords = xmlKeywords.ToArray();
				}

				xmlLangs.Add(xmlLang);
			}

			xmlType.Languages.Language = xmlLangs.ToArray();
			return xmlType;
		}
	}
}
