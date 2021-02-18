using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WinnerGoalsApp
{
    public class Result
    {


        public static int getWinnerTotalGoals(string competition, int year)
        {
            int totalGoals = 0;
            IList<string> articles = new List<string>();

            try
            {
                var competitionUrl = $"https://jsonmock.hackerrank.com/api/football_competitions?name={competition}&year={year}";

                var response = getHttpResponse(competitionUrl);
                var data = JsonConvert.DeserializeObject<CompetitionData>(response);
                var competitionName = data.Data[0].Name;
                var winnerName = data.Data[0].Winner;

                var url = $"https://jsonmock.hackerrank.com/api/football_matches?competition={competition}&year={year}&team1={winnerName}&page1";
                var pagesResponse = getHttpResponse(url);
                var pageData = JsonConvert.DeserializeObject<MatchesData>(response);

                int pages = pageData.Total;

                for(int i = 1; i <= pages; i++)
                {
                    var homeMatchesUrl = $"https://jsonmock.hackerrank.com/api/football_matches?competition={competitionName}&year={year}&team1={winnerName}&page{i}";
                    var visitingMatchesUrl = $"https://jsonmock.hackerrank.com/api/football_matches?competition={competitionName}&year={year}&team2={winnerName}&page{i}";

                    var homeMatchesResponse = getHttpResponse(homeMatchesUrl);
                    var visitingMatchesResponse = getHttpResponse(visitingMatchesUrl);

                    var homeMatchData = JsonConvert.DeserializeObject<MatchesData>(homeMatchesResponse);
                    var visitingMatchData = JsonConvert.DeserializeObject<MatchesData>(visitingMatchesResponse);

                    foreach (var match in homeMatchData.Data)
                    {
                        totalGoals += Int32.Parse(match.Team1goals);
                    }

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

            }
            
            return responseString;
        }

        public static List<string> getArticleTitles(string author)
        {
            List<string> articles = new List<string>();
            try
            {
                var page = 1;
                var url = $"https://jsonmock.hackerrank.com/api/articles?author={author}&page={page}";
                var response = getHttpResponse(url);
                var data = JsonConvert.DeserializeObject<BaseData>(response);

                int pages = data.Total_Pages;

                for (int i = 1; i <= pages; i++)
                {
                    var articleUrl = $"https://jsonmock.hackerrank.com/api/articles?author={author}&page={i}";
                    var articleResponse = getHttpResponse(articleUrl);
                    var articleData = JsonConvert.DeserializeObject<BaseData>(articleResponse);
                    string title;

                    foreach (var article in articleData.Data)
                    {
                        if (article.Title != null)
                        {
                            title = article.Title;
                            articles.Add(title);
                        }
                        else if (article.Title == null && article.Story_Title != null)
                        {
                            title = article.Story_Title;
                            articles.Add(title);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return articles;

        }

        public static long getTime(string s)
        {
            long res = 0;

            char[] lettersArr = s.ToCharArray();

            for (int i = 0; i <= lettersArr.Length; i++)
            {
                char firstLetter = lettersArr[i];
                var secondLetter = lettersArr[i + 1];

                int k = (int)Char.GetNumericValue(firstLetter);
                int j = (int)Char.GetNumericValue(secondLetter);

                var result = j - k;
                res += result;



            }


            return res;
        }
    }
}
