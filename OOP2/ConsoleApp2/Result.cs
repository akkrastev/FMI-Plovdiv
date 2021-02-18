using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApp2
{
    public class Result
    {

        /*
         * Complete the 'getTotalGoals' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING team
         *  2. INTEGER year
         */

        public static int getTotalGoals(string team, int year)
        {
            int totalgoals = 0;
            int page = 1;
            WebClient http = new WebClient();
            string homeTeamUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";
            string visitingTeamUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={page}";

            try
            {
                var homeTemp = JsonConvert.DeserializeObject<Team>(http.DownloadString(homeTeamUrl));
                var visitingTeamTemp = JsonConvert.DeserializeObject<Team>(http.DownloadString(visitingTeamUrl));

                int homeTeamPages = homeTemp.Total_Pages;
                int visitingTeamPages = visitingTeamTemp.Total_Pages;

                for (int i = 1; i <= homeTeamPages; i++)
                {
                    homeTeamUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={i}";
                    homeTemp = JsonConvert.DeserializeObject<Team>(http.DownloadString(homeTeamUrl));

                    foreach (var match in homeTemp.Data) {
                        totalgoals += Int32.Parse(match.Team1goals);
                    }
                }

                for (int i = 1; i <= visitingTeamPages; i++)
                {
                    visitingTeamUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={i}";
                    visitingTeamTemp = JsonConvert.DeserializeObject<Team>(http.DownloadString(visitingTeamUrl));
                    
                    foreach (var match in visitingTeamTemp.Data) {
                        totalgoals += Int32.Parse(match.Team2goals);
                    }
                    
                }

            }
            catch (Exception ex)
            {

            }

            return totalgoals;

        }
        public static int getTotalGoals1(string team, int year)
        {
            int totalgoals = 0;
            int page = 1;

            using (var client = new HttpClient())
            {
                try
                {
                    var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        var responseString = responseContent.ReadAsStringAsync().Result;
                        var temp = JsonConvert.DeserializeObject<Team>(responseString);

                        int pages = temp.Total_Pages;

                        for (int i = 1; i <= pages; i++)
                        {
                            var homeTeamUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={i}";
                            var visitingTeamUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={i}";
                            
                            totalgoals += calculateTotalGoals(homeTeamUrl);
                            totalgoals += calculateTotalGoals(visitingTeamUrl);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                return totalgoals;
            }
        }

        private static int calculateTotalGoals(string url)
        {
            var totalGoals = 0;
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;

                    var content = response.Content;
                    var responseString = content.ReadAsStringAsync().Result;
                    var team = JsonConvert.DeserializeObject<Team>(responseString);

                    foreach (var match in team.Data)
                    {
                        if (url.Contains("team1"))
                        {
                            totalGoals += Int32.Parse(match.Team1goals);
                        }
                        else
                        {
                            totalGoals += Int32.Parse(match.Team2goals);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

            return totalGoals;
            
        }


        public static int getTotalGoals3(string team, int year)
        {
            int totalGoals = 0;
            int page = 1;
            try
            {
                var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";
                var pageResponse = getHttpResponse(url);
                var data = JsonConvert.DeserializeObject<Team>(pageResponse);

                int pages = data.Total_Pages;

                for (int i = 1; i <= pages; i++)
                {
                    var homeMatchUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={i}";
                    var homeMatchResponse = getHttpResponse(homeMatchUrl);
                    var homeMatchData = JsonConvert.DeserializeObject<Team>(homeMatchResponse);

                    foreach (var match in homeMatchData.Data)
                    {
                        totalGoals += Int32.Parse(match.Team1goals);
                    }

                    var visitingMatchUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={i}";
                    var visitingMatchResponse = getHttpResponse(visitingMatchUrl);
                    var visitingMatchData = JsonConvert.DeserializeObject<Team>(visitingMatchResponse);

                    foreach (var match in visitingMatchData.Data)
                    {
                        totalGoals += Int32.Parse(match.Team2goals);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalGoals;
        }

        private static string getHttpResponse(string url)
        {

            var responseString = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return responseString;
        }
    }
}
