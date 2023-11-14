namespace TranslationsAgainstHumanity.BulkTranslator.Models
{
	/// <summary>
	/// Black card, containing additionaly number of blanks in text
	/// </summary>
	public class BlackCard : WhiteCard
	{
		#region Fields

		/// <summary>
		/// Specifies number of blanks in text
		/// </summary>
		public int BlankCount { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public BlackCard() : base()
		{
			BlankCount = 0;
		}

		/// <summary>
		/// Constructor with specified text and blank count
		/// </summary>
		/// <param name="originalText">Original text from card</param>
		/// <param name="blankCount">Number of blanks in the text</param>
		public BlackCard(string originalText, int blankCount) : base(originalText)
		{
			BlankCount = blankCount;
		}

		#endregion
	}
}
