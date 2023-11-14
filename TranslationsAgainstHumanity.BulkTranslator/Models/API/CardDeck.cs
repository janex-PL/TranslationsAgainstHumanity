using Newtonsoft.Json;

namespace TranslationsAgainstHumanity.BulkTranslator.Models.API
{
	/// <summary>
	/// JAH model for card deck
	/// </summary>
	public class CardDeck
	{
		#region Fields

		/// <summary>
		/// Collection of black cards
		/// </summary>
		[JsonProperty("blackCards")]
		public BlackCard[] BlackCards { get; set; }

		/// <summary>
		/// Collection of white cards
		/// </summary>
		[JsonProperty("whiteCards")]
		public string[] WhiteCards { get; set; }

		#endregion
	}
}
