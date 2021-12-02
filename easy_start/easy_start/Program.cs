﻿// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;



int GetAnswer(List<int> cijfer) {
	int resultaat = 0;
	foreach (int item in cijfer){
		Console.WriteLine(item);
	resultaat += item;
	};
	//splits resultaat todat je 1 beduidend cijfer krijgt
	string strresultaat = resultaat.ToString();
	while(strresultaat.Length != 1){ 
		for(int x = 0; x < strresultaat.Length; x++)
		{
			resultaat += Convert.ToInt32(strresultaat[x]);
			Console.WriteLine("resultaat " + resultaat);
		}
		strresultaat = resultaat.ToString();
	//done
	}
	Console.WriteLine(resultaat);
	return resultaat;
};





var client = new HttpClient();
client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");
var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNDEiLCJuYmYiOjE2Mzg0Mzc3NTksImV4cCI6MTYzODUyNDE1OSwiaWF0IjoxNjM4NDM3NzU5fQ.yPfhm_tn9_CIfr6Le0DV68QIf5Zi0SQy8HfSefW7iN1znYnP9J8Yoz4yElLkc207e4Mv96eFFzm9uCzioRW5zw";
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var startUrl = "api/path/1/easy/Start";
var startResponse = await client.GetAsync(startUrl);

var sampleUrl = "api/path/1/easy/Sample";
var sampleGetResponse = await client.GetFromJsonAsync<List<int>>(sampleUrl);
var sampleAnswer = GetAnswer(sampleGetResponse);
var samplePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, sampleAnswer);
var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
var puzzleUrl = "api/path/1/easy/Puzzle";
var puzzleGetResponse = await client.GetFromJsonAsync<List<int>>(puzzleUrl);
var puzzleAnswer = GetAnswer(puzzleGetResponse);
var puzzlePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, puzzleAnswer);
var puzzlePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
Console.WriteLine(sampleAnswer);
Console.ReadLine();
//api url /api/path/1/easy/Puzzle
//code to get data from the api
