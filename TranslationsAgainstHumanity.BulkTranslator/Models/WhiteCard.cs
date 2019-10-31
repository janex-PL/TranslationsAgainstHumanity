﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationsAgainstHumanity.BulkTranslator.Models
{
	public class WhiteCard
	{
		public string OriginalText { get; set; }
		public string TranslatedText { get; set; }

		public bool IsCardReady { get; set; }
		public WhiteCard()
		{
			OriginalText = string.Empty;
			TranslatedText = string.Empty;
			IsCardReady = false;
		}
		public WhiteCard(string originalText)
		{
			OriginalText = originalText;
			TranslatedText = string.Empty;
			IsCardReady = false;
		}
	}
}
