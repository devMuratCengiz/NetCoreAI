using NetCoreAI.Project03_RapidAPI.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
var client = new HttpClient();
List<ApiSeriesViewModel> list = new List<ApiSeriesViewModel>();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", "1678b341acmsh9cf54c10397041cp1400b9jsn73fdb90bb65d" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    list = JsonConvert.DeserializeObject<List<ApiSeriesViewModel>>(body);
    foreach (var item in list)
    {
        Console.WriteLine("Rank: " + item.rank);
        Console.WriteLine("Title: " + item.title);
        Console.WriteLine("Rating: "+ item.rating);
        Console.WriteLine("Year: " + item.year);
        Console.WriteLine();
    }
}