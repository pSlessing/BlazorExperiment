using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorExperiment
{
    public class BallDontLieAPI
    {
        private const string baseURL = "https://api.balldontlie.io/v1/";
        private HttpClient client = new HttpClient();
        private string? accessPointUrl;
        public BallDontLieAPI(string APIKEY) 
        {
            client.DefaultRequestHeaders.Add("Authorization", APIKEY);
            client.BaseAddress = new Uri(baseURL);
        }

        public async Task<NbaPlayer?> getNbaPlayerByID(int input) 
        {
            accessPointUrl = "players/";
            System.Diagnostics.Debug.WriteLine(accessPointUrl);
            var response = await client.GetAsync(accessPointUrl + input.ToString());
            var responseBody = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(responseBody);

            NbaPlayer? returnPlayer = JsonConvert.DeserializeObject<RootPlayer>(responseBody).data;

            return returnPlayer;
            
        }
        
        public async Task<NbaTeam> getNbaTeamByID(int input) 
        {
            accessPointUrl = "teams/";
            System.Diagnostics.Debug.WriteLine(accessPointUrl);
            var response = await client.GetAsync(accessPointUrl + input.ToString());
            var responseBody = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(responseBody);



            NbaTeam returnTeam = JsonConvert.DeserializeObject<RootTeam>(responseBody).data;

            return returnTeam;
        }

        public async Task<NbaMatch> getNbaMatch(int input)
        {
            accessPointUrl = "games/";
            System.Diagnostics.Debug.WriteLine(accessPointUrl);
            var response = await client.GetAsync(accessPointUrl + input.ToString());
            var responseBody = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(responseBody);
            NbaMatch returnMatch = JsonConvert.DeserializeObject<RootMatch>(responseBody).data;

            return returnMatch;
        }
    }


    public class RootPlayer
    {
        public NbaPlayer data { get; set; }
    }

    public class RootTeam
    {
        public NbaTeam data { get; set; }
    }

    public class RootMatch
    {
        public NbaMatch data { get; set; }
    }

    public class NbaPlayer 
    {
        public int? id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? position { get; set; }
        public string? height { get; set; }
        public string? weight { get; set; }
        public string? jersey_number { get; set; }
        public string? college { get; set; }
        public string? country { get; set; }
        public string? draft_year { get; set; }
        public string? draft_round { get; set; }
        public string? draft_number { get; set; }
        public NbaTeam? team { get; set; }
    }

    public class NbaTeam 
    {
        public int? id { get; set; }
        public string? conference { get; set; }
        public string? division { get; set; }
        public string? city { get; set; }
        public string? name { get; set; }
        public string? full_name { get; set; }
        public string? abbreviation { get; set; }
    }

    public class NbaMatch 
    {
        public int id { get; set; }
        public string? date { get; set; }
        public int season { get; set; }
        public string? status { get; set; }
        public int period { get; set; }
        public string time { get; set; }
        public bool postseason { get; set; }
        public int home_team_score { get; set; }
        public int visitor_team_score { get; set; }
        public NbaTeam home_team { get; set; }
        public NbaTeam visitor_team { get; set; }
    }
}
