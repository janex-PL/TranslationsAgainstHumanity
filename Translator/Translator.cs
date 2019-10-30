using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CAH_Translator.BulkTranslator.Translator
{
	public class Translator
	{
		private readonly string APICall_Translate = @"https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang=en-{2}";
		private readonly string APICall_GetLanguages = @"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui=en";
		public string APIKey { get; set; }
		public Dictionary<string, string> AvailableLanguages { get; set; }

		private readonly HttpClient Client = new HttpClient();


		public Translator(string apiKey)
		{
			APIKey = apiKey;
			AvailableLanguages = GetAvailableLanguages().Result;
		}
		public async Task<Dictionary<string, string>> GetAvailableLanguages()
		{
			string apiCall = String.Format(APICall_GetLanguages, APIKey);
			string responseBody = string.Empty;

			try
			{
				using (HttpResponseMessage response = await Client.GetAsync(apiCall))
				{
					if (!response.IsSuccessStatusCode)
						throw new Exception($"HTTP request returned {response.StatusCode.ToString()}");
					responseBody = await response.Content.ReadAsStringAsync();
				}
				return JsonConvert.DeserializeObject<Languages>(responseBody).Langs;
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR !!!");
				Console.WriteLine("An error occured while trying to get avaiable languages.");
				Console.WriteLine(ex.Message);
				Console.ReadKey();
				Environment.Exit(0);
				return null;
			}
		}

		public async Task<string> GetTranslation(string text, string lang)
		{
			if (!AvailableLanguages.ContainsKey(lang))
				throw new Exception("Wrong language code!");

			string apiCall = String.Format(APICall_Translate, APIKey, text, lang);
			string responseBody = string.Empty;

			try
			{
				using (HttpResponseMessage response = await Client.GetAsync(apiCall))
				{
					if (!response.IsSuccessStatusCode)
						throw new Exception($"API call returned status code {response.StatusCode}");
					responseBody = await response.Content.ReadAsStringAsync();
				}
				return JsonConvert.DeserializeObject<Translation>(responseBody).Text.First();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR !!!");
				Console.WriteLine("An error occured while trying to get translation.");
				Console.WriteLine(ex.Message);
				Console.ReadKey();
				Environment.Exit(0);
				return null;
			}
		}
	}
	public class Translation
	{
		[JsonProperty("code")]
		public HttpStatusCode Code { get; set; }

		[JsonProperty("lang")]
		public string Lang { get; set; }

		[JsonProperty("text")]
		public string[] Text { get; set; }
	}
	public class Languages
	{
		[JsonProperty("dirs")]
		public string[] Dirs { get; set; }

		[JsonProperty("langs")]
		public Dictionary<string, string> Langs { get; set; }
	}
}
