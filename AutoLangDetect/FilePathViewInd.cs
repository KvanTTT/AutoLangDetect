using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoLangDetect
{
	public class FilePathViewIndex
	{
		public string Path
		{
			get;
			set;
		}

		public int View
		{
			get;
			set;
		}

		public int Index
		{
			get;
			set;
		}

		public FilePathViewIndex(string path, int view, int index)
		{
			Path = path;
			View = view;
			Index = index;
		}

		public override string ToString()
		{
			return string.Format("{0};{1};{2}", Path, View, Index);
		}
	}
}
