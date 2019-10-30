using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationsAgainstHumanity.BulkTranslator.Models;
using TranslationsAgainstHumanity.BulkTranslator.Translator;
namespace TranslationsAgainstHumanity.BulkTranslator.Converters
{
	public static class CardDeckConverter
	{
		public static async Task<Models.CardDeck> ConvertDeckToTAHFormat(Models.API.CardDeck oldDeck)
		{
			Console.Write("Enter API key for Yandex translation service: ");
			string apiKey = Console.ReadLine();

			Translator.Translator translator = new Translator.Translator(apiKey);

			Console.WriteLine("List of avaiable languages: ");
			translator.DisplayAvaiableLanguages();

			Console.Write("Enter language code: ");
			string language = Console.ReadLine();

			Models.CardDeck newDeck = new CardDeck();

			Console.Write("Enter deck name: ");
			newDeck.DeckName = Console.ReadLine();

			int totalTicks = oldDeck.BlackCards.Length;
			var options = new ProgressBarOptions
			{
				ProgressCharacter = '#',
				ProgressBarOnBottom = true
			};
			using (var pbar = new ProgressBar(totalTicks, "Converting black cards", options))
			{
				foreach (var card in oldDeck.BlackCards)
				{
					Models.BlackCard newCard = new Models.BlackCard(card.Text, card.Pick);
					newCard.TranslatedText = await translator.GetTranslation(newCard.OriginalText, language);
					newDeck.AddCardToList(newCard);
					pbar.Tick();
				}
			}
			totalTicks = oldDeck.WhiteCards.Length;
			using (var pbar = new ProgressBar(totalTicks, "Converting white cards", options))
			{
				foreach (var card in oldDeck.WhiteCards)
				{
					Models.WhiteCard newCard = new Models.WhiteCard(card);
					newCard.TranslatedText = await translator.GetTranslation(newCard.OriginalText, language);
					newDeck.AddCardToList(newCard);
					pbar.Tick();
				}
			}

			return newDeck;
		}
	}
}
