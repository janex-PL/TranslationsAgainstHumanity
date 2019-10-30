using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationsAgainstHumanity.BulkTranslator.Models
{
	public class BlackCard : WhiteCard
	{
		public int BlankCount { get; set; }

		public BlackCard() : base()
		{
			BlankCount = 0;
		}
		public BlackCard(string originalText, int blankCount) : base(originalText)
		{
			BlankCount = blankCount;
		}

		
	}
}
