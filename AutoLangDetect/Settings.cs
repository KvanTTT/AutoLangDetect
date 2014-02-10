using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoLangDetect
{
	public class Settings
	{
		public bool DetectLanguageAutomatically { get; set; }
		public bool CheckEmptyExtensionFiles { get; set; }
		public bool ShowDetectLanguageDialog { get; set; }
		public bool PasteClipboardTextToNewlyCreatedFile { get; set; }
		public bool ShowPasteTextFromClipboardDialog { get; set; }
	}
}
