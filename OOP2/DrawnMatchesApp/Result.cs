using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DrawnMatchesApp
{
    public class Result
    {
        public static int getNumDraws(int year)
        {
            var totalDraws = 0;

            try
            {
                using (var client = new HttpClient())
                {
                    int page = 1;
                    var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&page={page}";

                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var temp = JsonConvert.DeserializeObject<Team>(responseString);

                    int pages = temp.Total_Pages;
                    int maxScore = 10;

                    /* for(int i = 1; i <= pages; i++)
                     {
                         for (int score = 0; score <= maxScore; score++)
                         {
                             url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1goals={score}&team2goals={score}&page={i}";
                             //url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&page={i}";
                             totalDraws += calculateTotalDraws(url);
                         }

                     }*/

                    for (int score = 0; score <= maxScore; score++)
                    {
                        for (int i = 1; i <= pages; i++)
                        {
                            url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1goals={score}&team2goals={score}&page={i}";
                            totalDraws += calculateTotalDraws(url);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalDraws;
        }

        private static int calculateTotalDraws(string url)
        {
            int totalDrawns = 0;
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var temp = JsonConvert.DeserializeObject<Team>(responseString);

                    totalDrawns = temp.Data.Count;

                   /* foreach (var match in temp.Data)
                    {
                        if (match.Team1goals == match.Team2goals)
                        {
                            totalDrawns++;
                        }
                    }*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalDrawns;
        }
    }
}
