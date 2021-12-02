// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
DateTime Date = DateTime.Now;
DateTime Datum1 = DateTime.Now;
DateTime Datum2 = DateTime.Now;

var client = new HttpClient();
client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");
var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNDEiLCJuYmYiOjE2Mzg0Mzc3NTksImV4cCI6MTYzODUyNDE1OSwiaWF0IjoxNjM4NDM3NzU5fQ.yPfhm_tn9_CIfr6Le0DV68QIf5Zi0SQy8HfSefW7iN1znYnP9J8Yoz4yElLkc207e4Mv96eFFzm9uCzioRW5zw";
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var startUrl = "/api/path/2/easy/Start";
var startResponse = await client.GetAsync(startUrl);
var sampleUrl = "/api/path/2/easy/Sample";
var sampleGetResponse = await client.GetStringAsync(sampleUrl);
var puzzleUrl = "api/path/2/easy/Puzzle";
var puzzleGetResponse = await client.GetStringAsync(puzzleUrl);

Console.WriteLine(sampleGetResponse);
Datum(1, sampleGetResponse);
Datum1 = Date;
Datum(1, sampleGetResponse);
Datum2 = Date;

var dateinseconds = (Datum2 - Datum1).TotalSeconds *-1;
Console.WriteLine(dateinseconds);

var samplePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, Convert.ToInt32(dateinseconds));
var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
var puzzlePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, Convert.ToInt32(dateinseconds));
var puzzlePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();

//var puzzlePostResponse = await client.PostAsJsonAsync<int>(puzzleUrl, Convert.ToInt32(dateinseconds));
//var puzzlePostResponseValue = await puzzlePostResponse.Content.ReadAsStringAsync();
void Datum(int teller, string datum)
{
    string date = Convert.ToString(datum);
    Console.Write(datum);
    var Day = "";
    var Month = "";
    var Year = "";

    for (int i = 0; i < 4; i++)
    {
        string datedeel = date.Substring(1, 4);
        string dateCheck = date.Substring(teller + 2, 2);
        teller += 4;

        if (dateCheck == "DD")
        {
            Day = datedeel;
            Day = Day.Substring(0, 2);
        }
        else if (dateCheck == "MM")
        {
            Month = datedeel;
            Month = Month.Substring(0, 2);
        }
        else if (dateCheck == "YY")
        {
            var Trash = datedeel;
        }
        else
        {
            Year = datedeel;
        }

    }

    Console.WriteLine(Day + " " + Month + " " + Year);
    var fulldatum = Day + "/" + Month + "/" + Year;
    var dateTime = DateTime.Parse(fulldatum);
    Console.WriteLine(dateTime);
    Date = dateTime;

}


//api url /api/path/1/easy/Puzzle

//code to get data from the api
