using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoLangDetect
{
	[XmlRoot("NotepadPlus")]
	public class NotepadPlusLanguages
	{
		[XmlArray("Languages")]
		[XmlArrayItem("Language")]
		public Language[] Languages { get; set; }
	}

	public class Language
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("ext")]
		public string Extension { get; set; }

		[XmlAttribute("commentLine")]
		public string CommentLine { get; set; }

		[XmlAttribute("commentStart")]
		public string CommentStart { get; set; }

		[XmlAttribute("commentEnd")]
		public string CommentEnd { get; set; }

		[XmlElement("Keywords")]
		public Keywords[] Keywords { get; set; }
	}

	public class Keywords
	{
		[XmlAttribute("name")]
		public string Name;

		[XmlText]
		public string Value;
	}

	[XmlRoot("NotepadPlus")]
	public class NotepadPlusStylers
	{
		[XmlArray("LexerStyles")]
		[XmlArrayItem("LexerType")]
		public List<LexerType> LexerStyles { get; set; }

		[XmlArray("GlobalStyles")]
		[XmlArrayItem("WidgetStyle")]
		public List<WidgetStyle> GlobalStyles { get; set; }
	}

	public class LexerType
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("desc")]
		public string Description { get; set; }

		[XmlAttribute("ext")]
		public string Extension { get; set; }

		[XmlElement("WordsStyle")]
		public WordsStyle[] WordsStyles { get; set; }
	}

	public class WordsStyle
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("styleID")]
		public int StyleID { get; set; }

		[XmlAttribute("fgColor")]
		public string ForegroundColor { get; set; }

		[XmlAttribute("bgColor")]
		public string BackgroundColor { get; set; }

		[XmlAttribute("fontName")]
		public string FontName { get; set; }

		[XmlAttribute("fontStyle")]
		public string FontStyle { get; set; }

		[XmlAttribute("fontSize")]
		public string FontSize { get; set; }

		[XmlAttribute("keywordClass")]
		public string KeywordClass { get; set; }
	}

	public class WidgetStyle
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("styleID")]
		public int StyleID { get; set; }

		[XmlAttribute("fgColor")]
		public string ForegroundColor { get; set; }

		[XmlAttribute("bgColor")]
		public string BackgroundColor { get; set; }

		[XmlAttribute("fontName")]
		public string FontName { get; set; }

		[XmlAttribute("fontStyle")]
		public string FontStyle { get; set; }

		[XmlAttribute("fontSize")]
		public string fontSize { get; set; }

		[XmlAttribute("keywordClass")]
		public string KeywordClass { get; set; }
	}
}
