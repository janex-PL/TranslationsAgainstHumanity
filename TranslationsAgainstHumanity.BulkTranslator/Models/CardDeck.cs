using System.Collections.Generic;
using System.Linq;

namespace TranslationsAgainstHumanity.BulkTranslator.Models
{
	/// <summary>
	/// TAH model of card deck
	/// </summary>
	public class CardDeck
	{
		#region Fields

		/// <summary>
		/// Collection of black cards
		/// </summary>
		public List<BlackCard> BlackCards { get; set; }

		/// <summary>
		/// Collection of white cards
		/// </summary>
		public List<WhiteCard> WhiteCards { get; set; }

		/// <summary>
		/// Name of the deck
		/// </summary>
		public string DeckName { get; set; }

		#endregion

		#region Constructors 

		/// <summary>
		/// Default constructor
		/// </summary>
		public CardDeck()
		{
			DeckName = string.Empty;
			BlackCards = new List<BlackCard>();
			WhiteCards = new List<WhiteCard>();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Adds card to the coresponding base if it's not empty or already in deck
		/// </summary>
		/// <param name="card">White/Black card to be added</param>
		public void AddCardToList(dynamic card)
		{
			switch (card)
			{
				case BlackCard blackCard:
					if (!(IsCardAlreadyInDeck(blackCard) || string.IsNullOrEmpty(blackCard.OriginalText)))
						BlackCards.Add(blackCard);
					break;
				case WhiteCard whiteCard:
					if (!(IsCardAlreadyInDeck(whiteCard) || string.IsNullOrEmpty(whiteCard.OriginalText)))
						WhiteCards.Add(whiteCard);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Checks if card is already in the coresponding deck
		/// </summary>
		/// <param name="card">Black/White card</param>
		/// <returns>True if card is in the deck, otherwise false</returns>
		public bool IsCardAlreadyInDeck(dynamic card)
		{
			switch (card)
			{
				case BlackCard blackCard:
					return BlackCards.Any(x => x.OriginalText == blackCard.OriginalText);
				case WhiteCard whiteCard:
					return WhiteCards.Any(x => x.OriginalText == whiteCard.OriginalText);
				default:
					return false;
			}
		}

		#endregion
	}
}
