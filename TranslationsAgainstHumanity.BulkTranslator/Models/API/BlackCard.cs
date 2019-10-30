using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationsAgainstHumanity.BulkTranslator.Models.API
{
	public class BlackCard
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("pick")]
		public long Pick { get; set; }
	}
}
