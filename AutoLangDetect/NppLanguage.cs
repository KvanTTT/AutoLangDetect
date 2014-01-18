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

		public string[] Extensions
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

		public Dictionary<string, string[]> Keywords
		{
			get;
			set;
		}
	}
}
