using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TranslationsAgainstHumanity.BulkTranslator.Models.API;
using Newtonsoft.Json;

namespace TranslationsAgainstHumanity.BulkTranslator.Serialization
{
	public static class JAHSerialization
	{
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
	}
}
