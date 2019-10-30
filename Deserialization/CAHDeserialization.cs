using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CAH_Translator.BulkTranslator.Models.API;
using Newtonsoft.Json;

namespace CAH_Translator.BulkTranslator.Deserialization
{
	public static class CAHDeserialization
	{
		public static CardDeck GetCardDeck(string filePath)
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
	}
}
