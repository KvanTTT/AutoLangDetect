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

	[XmlRoot("NotepadPlus")]
	public class NotepadPlusSession
	{
		[XmlElement("Session")]
		public Session Session { get; set; }
	}

	public class Session
	{
		[XmlAttribute("activeView")]
		public int ActiveView { get; set; }

		[XmlElement("mainView")]
		public MainView MainView { get; set; }

		[XmlElement("subView")]
		public SubView SubView { get; set; }
	}

	public class MainView
	{
		[XmlAttribute("activeIndex")]
		public int ActiveIndex { get; set; }

		[XmlElement("File")]
		public List<NppFile> Files { get; set; }
	}

	public class SubView
	{
		[XmlAttribute("activeIndex")]
		public int ActiveIndex { get; set; }

		[XmlElement("File")]
		public List<NppFile> Files { get; set; }
	}

	[XmlType("File")]
	public class NppFile
	{
		[XmlAttribute("firstVisibleLine")]
		public int FirstVisibleLine { get; set; }

		[XmlAttribute("xOffset")]
		public int XOffset { get; set; }

		[XmlAttribute("scrollWidth")]
		public int ScrollWidth { get; set; }

		[XmlAttribute("startPos")]
		public int StartPos { get; set; }

		[XmlAttribute("EndPos")]
		public int endPos { get; set; }

		[XmlAttribute("SelMode")]
		public int selMode { get; set; }

		[XmlAttribute("lang")]
		public string Language { get; set; }

		[XmlAttribute("encoding")]
		public int Encoding { get; set; }

		[XmlAttribute("filename")]
		public string Filename { get; set; }
	}
}
