using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAH_Translator.BulkTranslator.Models.API
{
	public partial class CardDeck
	{
		[JsonProperty("blackCards")]
		public BlackCard[] BlackCards { get; set; }

		[JsonProperty("whiteCards")]
		public string[] WhiteCards { get; set; }
	}
}
