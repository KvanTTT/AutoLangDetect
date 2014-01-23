using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoLangDetect
{
	public class LangDetector
	{
		public string Encoding
		{
			get;
			private set;
		}
		
		public Dictionary<string, NppLanguage> Languages
		{
			get;
			private set;
		}

		public Dictionary<string, NppLanguage> ExtensionLangs
		{
			get;
			private set;
		}

		public NppLanguage DefaultLang
		{
			get;
			private set;
		}

		public void InitLanguages(Dictionary<string, NppLanguage> languages, string encoding)
		{
			Encoding = encoding;
			Languages = languages;
			DefaultLang = languages.FirstOrDefault(lang => lang.Key == "normal").Value;
			UpdateExtensionLangs();
		}

		public bool ContainsExtension(string extension)
		{
			return ExtensionLangs.ContainsKey(extension);
		}

		public void AddOrUpdateExtension(string language, string extension)
		{
			foreach (var lang in Languages)
				lang.Value.Extensions.Remove(extension);
			Languages[language].Extensions.Add(extension);
			UpdateExtensionLangs();
		}

		void UpdateExtensionLangs()
		{
			ExtensionLangs = new Dictionary<string, NppLanguage>();
			foreach (var lang in Languages)
				foreach (var ext in lang.Value.Extensions)
					if (!ExtensionLangs.ContainsKey(ext))
						ExtensionLangs.Add(ext, lang.Value);
		}
	}
}
