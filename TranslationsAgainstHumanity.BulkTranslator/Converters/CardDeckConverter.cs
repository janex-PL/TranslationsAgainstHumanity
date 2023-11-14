using ShellProgressBar;
using System;
using System.Threading.Tasks;
using TranslationsAgainstHumanity.BulkTranslator.Models;
namespace TranslationsAgainstHumanity.BulkTranslator.Converters
{
	/// <summary>
	/// Extension class for converting card decks
	/// </summary>
	public static class CardDeckConverter
	{
		#region Methods

		/// <summary>
		/// Converts the deck from JAH to TAH format
		/// </summary>
		/// <param name="oldDeck">Card deck in JAH format</param>
		/// <returns>Translated card deck in TAH format</returns>
		public static async Task<Models.CardDeck> ConvertDeckToTAHFormat(Models.API.CardDeck oldDeck)
		{
			Console.Write("Enter API key for Yandex translation service: ", ConsoleColor.Cyan);
			string apiKey = Console.ReadLine();

			Translator.Translator translator = new Translator.Translator(apiKey);

			Console.WriteLine("List of avaiable languages: ", ConsoleColor.Cyan);
			translator.DisplayAvaiableLanguages();

			Console.Write("Enter language code: ", ConsoleColor.Cyan);
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
			Console.WriteLine("Translation finished succesfully!", ConsoleColor.Green);

			return newDeck;
		}

		#endregion
	}
}
