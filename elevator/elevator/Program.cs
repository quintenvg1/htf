using System.Net.Http.Headers;
using System.Net.Http.Json;

//lift setup
int steps = 0; //defines hou many levels the elevator will skip upon it's next movement
int level = 0;
List<int> getavailablemoves() {
	List<int> i = new List<int> { 0, (level - steps), (level + steps)};
	return i;
};
List<int> GetAnswer(int _verdieping){
	int verdieping = _verdieping;
	return new List<int> { 0};
};

#region setup
// Swagger
// https://involved-htf-challenge.azurewebsites.net/swagger/index.html

// De httpclient die we gebruiken om http calls te maken
var client = new HttpClient();
// De base url die voor alle calls hetzelfde is
client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");

// De token die je gebruikt om je team te authenticeren, deze kan je via de swagger ophalen met je teamname + password
var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNDEiLCJuYmYiOjE2Mzg0Mzc3NTksImV4cCI6MTYzODUyNDE1OSwiaWF0IjoxNjM4NDM3NzU5fQ.yPfhm_tn9_CIfr6Le0DV68QIf5Zi0SQy8HfSefW7iN1znYnP9J8Yoz4yElLkc207e4Mv96eFFzm9uCzioRW5zw";
// We stellen de token in zodat die wordt meegestuurd bij alle calls, anders krijgen we een 401 Unauthorized response op onze calls
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

// De url om de challenge te starten
var startUrl = "api/path/1/medium/Start";
// We voeren de call uit en wachten op de response
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await
// De start endpoint moet je 1 keer oproepen voordat je aan een challenge kan beginnen
// Krijg je een 403 Forbidden response op je Sample of Puzzle calls? Dat betekent dat de challenge niet gestart is
var startResponse = await client.GetAsync(startUrl);

// De url om de sample challenge data op te halen
var sampleUrl = "api/path/1/medium/Sample";
// We doen de GET request en wachten op de het antwoord
// De response die we verwachten is een lijst van getallen dus gebruiken we List<int>
var sampleGetResponse = await client.GetFromJsonAsync<int>(sampleUrl);

// Je zoekt het antwoord
#endregion
var sampleAnswer = GetAnswer(sampleGetResponse);
#region setup2
// We sturen het antwoord met een POST request
// Het antwoord dat we moeten versturen is een getal dus gebruiken we int
// De response die we krijgen zal ons zeggen of ons antwoord juist was
var samplePostResponse = await client.PostAsJsonAsync<List<int>>(sampleUrl, sampleAnswer);
// Om te zien of ons antwoord juist was moeten we de response uitlezen
// Een 200 status code betekent dus niet dat je antwoord juist was!
var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();

// De url om de puzzle challenge data op te halen
var puzzleUrl = "api/path/1/easy/Puzzle";
// We doen de GET request en wachten op de het antwoord
// De response die we verwachten is een lijst van getallen dus gebruiken we List<int>
var puzzleGetResponse = await client.GetFromJsonAsync<int>(puzzleUrl);

// Je zoekt het antwoord
#endregion
var puzzleAnswer = GetAnswer(puzzleGetResponse);

// We sturen het antwoord met een POST request
// Het antwoord dat we moeten versturen is een getal dus gebruiken we int
// De response die we krijgen zal ons zeggen of ons antwoord juist was
var puzzlePostResponse = await client.PostAsJsonAsync<List<int>>(sampleUrl, puzzleAnswer); //replace by puzzleUrl
// Om te zien of ons antwoord juist was moeten we de response uitlezen
// Een 200 status code betekent dus niet dat je antwoord juist was!
var puzzlePostResponseValue = await puzzlePostResponse.Content.ReadAsStringAsync();