using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranslationsAgainstHumanity.BulkTranslator.Translator
{
	/// <summary>
	/// Yandex Translator class
	/// </summary>
	public class Translator
	{
		#region Fields

		/// <summary>
		/// API Call for translation
		/// </summary>
		private readonly string _apiCall_Translate = @"https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang=en-{2}";

		/// <summary>
		/// API Call for available languages
		/// </summary>
		private readonly string _apiCall_GetLanguages = @"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui=en";

		/// <summary>
		/// Http client for sending requests
		/// </summary>
		private readonly HttpClient _client = new HttpClient();

		/// <summary>
		/// API key for Yandex.Translate API
		/// </summary>
		private string _apiKey { get; set; }

		/// <summary>
		/// Dictionary of languages, language code being key and language name being value
		/// </summary>
		private Dictionary<string, string> _availableLanguages { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="apiKey">Yandex.Translate API key</param>
		public Translator(string apiKey)
		{
			_apiKey = apiKey;
			_availableLanguages = GetAvailableLanguages().Result;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Displays _availableLanguages dictionary in table format
		/// </summary>
		public void DisplayAvaiableLanguages()
		{
			ConsoleTables.ConsoleTable ct = new ConsoleTables.ConsoleTable("Language code", "Language name");
			foreach (var item in _availableLanguages)
			{
				ct.AddRow(item.Key, item.Value);
			}
			ct.Write(ConsoleTables.Format.Alternative);
		}

		/// <summary>
		/// Gets dictionary of availabel languages from Yandex.Translate
		/// </summary>
		/// <returns>Dictionary of available langugae with names and codes</returns>
		public async Task<Dictionary<string, string>> GetAvailableLanguages()
		{
			string apiCall = String.Format(_apiCall_GetLanguages, _apiKey);
			string responseBody = string.Empty;

			try
			{
				using (HttpResponseMessage response = await _client.GetAsync(apiCall))
				{
					if (!response.IsSuccessStatusCode)
						throw new Exception($"HTTP request returned {response.StatusCode.ToString()} on call {apiCall}");
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

		/// <summary>
		/// Filters text from characters, that are forbidden in HTTP request
		/// </summary>
		/// <param name="text">Input text</param>
		/// <returns>Filtered string from #, &, and HTML markup</returns>
		public string FilterText(string text)
		{
			while (true)
			{
				switch (text)
				{
					case string txt when text.Contains("#"):
						text = text.Replace("#", "%23");
						break;
					case string txt when text.Contains("&"):
						text = text.Replace("&", "%26");
						break;
					case string txt when Regex.IsMatch(text, "<.*?>"):
						text = Regex.Replace(text, "<.*?>", "");
						break;
					default:
						return text;
				}
			}
		}

		/// <summary>
		/// Gets translation of the text for specified language
		/// </summary>
		/// <param name="text">Text to be translated</param>
		/// <param name="lang">Requested language</param>
		/// <returns>String containing translated text</returns>
		public async Task<string> GetTranslation(string text, string lang)
		{
			if (!_availableLanguages.ContainsKey(lang))
				throw new Exception("Wrong language code!");

			string apiCall = String.Format(_apiCall_Translate, _apiKey, FilterText(text), lang);
			string responseBody = string.Empty;

			try
			{
				using (HttpResponseMessage response = await _client.GetAsync(apiCall))
				{
					if (!response.IsSuccessStatusCode)
						throw new Exception($"API call returned status code {response.StatusCode} with text '{text}'");
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

		#endregion
	}

	/// <summary>
	///	Translation model for Yandex.Translate
	/// </summary>
	public class Translation
	{
		#region Fields

		/// <summary>
		/// HTTP response code
		/// </summary>
		[JsonProperty("code")]
		public HttpStatusCode Code { get; set; }

		/// <summary>
		/// language pair of translation
		/// </summary>
		[JsonProperty("lang")]
		public string Lang { get; set; }

		/// <summary>
		/// Translated text
		/// </summary>
		[JsonProperty("text")]
		public string[] Text { get; set; }

		#endregion
	}

	/// <summary>
	/// Language colllection model for Yandex.Translate 
	/// </summary>
	public class Languages
	{
		#region Fields

		/// <summary>
		/// Available dictionaries
		/// </summary>
		[JsonProperty("dirs")]
		public string[] Dirs { get; set; }

		/// <summary>
		/// Language code and name dictionary
		/// </summary>
		[JsonProperty("langs")]
		public Dictionary<string, string> Langs { get; set; }

		#endregion
	}
}
