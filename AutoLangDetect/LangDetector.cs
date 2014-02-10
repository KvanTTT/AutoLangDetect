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

		public Dictionary<string, List<NppLanguage>> KeywordsLangs
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
			UpdateKeywordsLangs();
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

		public NppLanguage DetectLanguage(string data)
		{
			var words = data.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
			Dictionary<NppLanguage, int> mathcedLangs = new Dictionary<NppLanguage,int>();
			foreach (var lang in Languages)
				mathcedLangs.Add(lang.Value, 0);
			foreach (var word in words)
			{
				List<NppLanguage> langs;
				if (KeywordsLangs.TryGetValue(word, out langs))
					foreach (var lang in langs)
						mathcedLangs[lang]++;
			}

			int maxCount = 0;
			NppLanguage maxElement = null;
			foreach (var lang in mathcedLangs)
			{
				if (lang.Value > maxCount)
				{
					maxElement = lang.Key;
					maxCount = lang.Value;
				}
			}
			return maxElement;
		}

		#region Utils
		
		void UpdateExtensionLangs()
		{
			ExtensionLangs = new Dictionary<string, NppLanguage>();
			foreach (var lang in Languages)
				foreach (var ext in lang.Value.Extensions)
					if (!ExtensionLangs.ContainsKey(ext))
						ExtensionLangs.Add(ext, lang.Value);
		}

		void UpdateKeywordsLangs()
		{
			KeywordsLangs = new Dictionary<string, List<NppLanguage>>();
			foreach (var lang in Languages)
			{
				foreach (var keywords in lang.Value.Keywords)
				{
					foreach (var keyword in keywords.Value)
					{
						List<NppLanguage> keywordLanguages;
						if (KeywordsLangs.TryGetValue(keyword, out keywordLanguages))
							KeywordsLangs[keyword].Add(lang.Value);
						else
							KeywordsLangs.Add(keyword, new List<NppLanguage>() { lang.Value });
					}
				}
			}
		}

		#endregion
	}
}
