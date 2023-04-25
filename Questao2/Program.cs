using Newtonsoft.Json;
using System.Net;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        string url = "https://jsonmock.hackerrank.com/api/football_matches?year=" + year.ToString() + "&team1=" + team + "&team2=" + team;

        using (var client = new WebClient())
        {
            string json = client.DownloadString(url);
            dynamic data = JsonConvert.DeserializeObject(json);

            int totalGoals = 0;
            foreach (var match in data.data)
            {
                if (match.team1 == team)
                    totalGoals += match.team1goals;
                else if (match.team2 == team)
                    totalGoals += match.team2goals;
            }

            return totalGoals;
        }
    }
}