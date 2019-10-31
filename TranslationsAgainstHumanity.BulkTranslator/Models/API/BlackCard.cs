using Newtonsoft.Json;

namespace TranslationsAgainstHumanity.BulkTranslator.Models.API
{
	/// <summary>
	/// JAH model for black cards
	/// </summary>
	public class BlackCard
	{
		#region Fields

		/// <summary>
		/// Text from the card
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Number of blanks in text
		/// </summary>
		[JsonProperty("pick")]
		public int Pick { get; set; }

		#endregion 
	}
}
