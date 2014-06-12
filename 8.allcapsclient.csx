#r "System.Net.Http"
using System.Net.Http;
using System.Net.Http.Headers;

var client = new HttpClient();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("ApPLICATION/JSON"));
var request = client.GetStreamAsync("http://localhost:8090/");
request.Result.CopyTo(Console.OpenStandardOutput());
