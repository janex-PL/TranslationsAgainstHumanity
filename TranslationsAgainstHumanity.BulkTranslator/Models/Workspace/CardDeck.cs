using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TranslationsAgainstHumanity.BulkTranslator.Models.Workspace
{
	public class CardDeck
	{
		public List<BlackCard> BlackCards { get; set; }
		public List<WhiteCard> WhiteCards { get; set; }
		public string DeckName { get; set; }

		public CardDeck()
		{
			DeckName = string.Empty;
			BlackCards = new List<BlackCard>();
			WhiteCards = new List<WhiteCard>();
		}
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
	}
}
