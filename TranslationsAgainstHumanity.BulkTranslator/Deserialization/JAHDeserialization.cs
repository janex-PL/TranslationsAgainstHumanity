using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TranslationsAgainstHumanity.BulkTranslator.Models.API;
using Newtonsoft.Json;

namespace TranslationsAgainstHumanity.BulkTranslator.Deserialization
{
	public static class JAHDeserialization
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
