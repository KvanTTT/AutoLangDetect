using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoLangDetect
{
	public class LangParser
	{
		public NppLanguage[] Languages
		{
			get;
			set;
		}

		public LangParser()
		{
		}

		public void Parse(string langs)
		{
			var serializer = new XmlSerializer(typeof(NotepadPlus));

			NotepadPlus notepadPlus;
			using (TextReader reader = new StringReader(langs))
				notepadPlus = (NotepadPlus)serializer.Deserialize(reader);

			Languages = XmlToNppLangs(notepadPlus);
		}

		public static NppLanguage[] XmlToNppLangs(NotepadPlus xmlRoot)
		{
			var result = new List<NppLanguage>(xmlRoot.Languages.Language.Length);
			foreach (var xmlLang in xmlRoot.Languages.Language)
			{
				var lang = new NppLanguage
				{
					Name = xmlLang.Name ?? "",
					Extensions = xmlLang.Extension.Split(' '),
					CommentLine = xmlLang.CommentLine ?? "",
					CommentStart = xmlLang.CommentStart ?? "",
					CommentEnd = xmlLang.CommentEnd ?? "",
				};

				lang.Keywords = new Dictionary<string, string[]>();
				if (xmlLang.Keywords != null)
					foreach (var keyword in xmlLang.Keywords)
						lang.Keywords.Add(keyword.Name, keyword.Value == null ? new string[0] : keyword.Value.Split(' '));

				result.Add(lang);
			}

			return result.ToArray();
		}
	}
}
