﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationsAgainstHumanity.BulkTranslator.Models.Workspace
{
	public class BlackCard : WhiteCard
	{
		public int BlankCount { get; set; }

		public BlackCard() : base()
		{
			BlankCount = 0;
		}
	}
}
