using NppPluginNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoLangDetect
{
	public class NppLanguage
	{
		public string Name
		{
			get;
			set;
		}

		public List<string> Extensions
		{
			get;
			set;
		}

		public string CommentLine
		{
			get;
			set;
		}

		public string CommentStart
		{
			get;
			set;
		}

		public string CommentEnd
		{
			get;
			set;
		}

		public Dictionary<string, List<string>> Keywords
		{
			get;
			set;
		}

		public LangType LangType
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public override string ToString()
		{
			if (Extensions == null || Extensions.Count == 0)
				return Name;
			else
				return string.Format("{0} ({1})", Name, string.Join(", ", Extensions));
		}
	}
}
