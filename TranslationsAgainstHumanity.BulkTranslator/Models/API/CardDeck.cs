using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationsAgainstHumanity.BulkTranslator.Models.API
{
	public partial class CardDeck
	{
		[JsonProperty("blackCards")]
		public BlackCard[] BlackCards { get; set; }

		[JsonProperty("whiteCards")]
		public string[] WhiteCards { get; set; }
	}
}
