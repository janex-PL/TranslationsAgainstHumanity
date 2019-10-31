using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationsAgainstHumanity.BulkTranslator.Serialization;

namespace TranslationsAgainstHumanity.BulkTranslator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("#########################################################");
			Console.WriteLine("##   Bulk translator                                   ##");
			Console.WriteLine("##                               Author: Jan Kliszcz   ##");
			Console.WriteLine("#########################################################");
			Console.WriteLine("## Powered by Yandex.Translate                         ##");
			Console.WriteLine("#########################################################");
			Console.Write("Enter path to JSON file: ", ConsoleColor.Cyan);
			string filepath = Console.ReadLine();

			Models.API.CardDeck oldDeck = JAHSerialization.DeserializeCardDeck(filepath);

			Models.CardDeck newDeck = Converters.CardDeckConverter.ConvertDeckToTAHFormat(oldDeck).Result;

			Console.Write("Enter path to new JSON file: ", ConsoleColor.Cyan);
			filepath = Console.ReadLine();
			TAHSerialization.SerializeCardDeck(newDeck, filepath);
		}
	}
}
