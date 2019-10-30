using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationsAgainstHumanity.BulkTranslator.Models;

namespace TranslationsAgainstHumanity.BulkTranslator.Serialization
{
	public static class TAHSerialization
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
