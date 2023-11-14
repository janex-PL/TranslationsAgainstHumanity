using Newtonsoft.Json;
using System;
using System.IO;
using TranslationsAgainstHumanity.BulkTranslator.Models;

namespace TranslationsAgainstHumanity.BulkTranslator.Serialization
{
	/// <summary>
	/// Extension class containing methods for TAH formatted card deck serialization
	/// </summary>
	public static class TAHSerialization
	{
		#region Methods

		/// <summary>
		/// Deserialize TAH formatted card deck from file
		/// </summary>
		/// <param name="filePath">Path to the file containing TAH card deck</param>
		/// <returns>CardDeck in TAH format</returns>
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
		/// Serializes TAH formatted card deck to file
		/// </summary>
		/// <param name="cardDeck">CardDeck in TAH format to serialize</param>
		/// <param name="filePath">Path to the new file</param>
		/// <returns>True if file saved successfully, otherwise false</returns>
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
