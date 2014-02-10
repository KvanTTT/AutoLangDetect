using NppPluginNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoLangDetect
{
	public class Utils
	{
		public static string GetExtensionWithoutDot(string filename)
		{
			return RemoveDot(Path.GetExtension(filename));
		}

		public static string RemoveDot(string extension)
		{
			if (string.IsNullOrEmpty(extension))
				return "";
			else
				return extension[0] == '.' ? extension.Substring(1) : extension;
		}

		public static string AppendDotToExtension(string extension)
		{
			if (string.IsNullOrEmpty(extension))
				return "";
			else
				return extension[0] == '.' ? extension : "." + extension;
		}

		public static bool IsFileNew(string fileName)
		{
			return fileName.StartsWith("new");
		}
	}
}
