namespace TranslationsAgainstHumanity.BulkTranslator.Models
{
	/// <summary>
	/// TAH model of white card
	/// </summary>
	public class WhiteCard
	{
		#region Fields

		/// <summary>
		/// Contains original card text
		/// </summary>
		public string OriginalText { get; set; }

		/// <summary>
		/// Contains translated card text
		/// </summary>
		public string TranslatedText { get; set; }

		/// <summary>
		/// Describes completion status of translation
		/// 
		/// 0 = Translation not ready to be published
		/// 1 = Translation ready to publish
		/// -1 = Discard card
		/// </summary>
		public int TranslationStatus { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public WhiteCard()
		{ 
			OriginalText = string.Empty;
			TranslatedText = string.Empty;
			TranslationStatus = 0;
		}

		/// <summary>
		/// Constructor with original text
		/// </summary>
		/// <param name="originalText">Original text from card</param>
		public WhiteCard(string originalText)
		{
			OriginalText = originalText;
			TranslatedText = string.Empty;
			TranslationStatus = 0;
		}

		#endregion
	}
}

