using System;
using System.IO;
using TranslationsAgainstHumanity.BulkTranslator.Models.API;
using Newtonsoft.Json;

namespace TranslationsAgainstHumanity.BulkTranslator.Serialization
{
	/// <summary>
	/// Extension class containing methods for JAH model serialization
	/// </summary>
	public static class JAHSerialization
	{
		#region Methods

		/// <summary>
		/// Deserialize card deck in JAH format from file
		/// </summary>
		/// <param name="filePath">Path to the file containg card deck in JAH format</param>
		/// <returns>CardDeck model in JAH format</returns>
		public static CardDeck DeserializeCardDeck(string filePath)
		{
			string content = string.Empty;
			try
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					string line = string.Empty;
					while ((line = reader.ReadLine()) != null)
					{
						content += line;
					}
				}
				CardDeck deck = JsonConvert.DeserializeObject<CardDeck>(content);
				return deck;
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR !!!");
				Console.WriteLine(ex.Message);
				Console.ReadKey();
				Environment.Exit(0);
				return null;
			}

		}

		/// <summary>
		/// Serializes card deck in JAH format to .json file
		/// </summary>
		/// <param name="cardDeck">card deck to serialize</param>
		/// <param name="filePath">path to new file for the deck</param>
		/// <returns>true, if serialization was succesfull, otherwise false</returns>
		public static bool SerializeCardDeck(CardDeck cardDeck, string filePath)
		{
			try
			{
				string content = JsonConvert.SerializeObject(cardDeck);
				using (StreamWriter writer = new StreamWriter(filePath))
				{
					writer.WriteLine(content);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR !!!");
				Console.WriteLine(ex.Message);
				Console.ReadKey();
				Environment.Exit(0);
				return false;
			}
		}

		#endregion
	}
}
