using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AutoLangDetect
{
	public class NotepadPlus
	{
		[XmlElement]
		public Languages Languages { get; set; }
	}

	public class Languages
	{
		[XmlElement("Language")]
		public Language[] Language { get; set; }
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
}
