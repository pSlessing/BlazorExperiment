using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace BlazorExperiment
{
    public class BallDontLieAPI
    {
        private const string baseURL = "https://api.balldontlie.io/v1/";
        private HttpClient client = new HttpClient();
        private string accessPointUrl = "";
        public BallDontLieAPI(string APIKEY) 
        {
            client.DefaultRequestHeaders.Add("Authorization", APIKEY);
            client.BaseAddress = new Uri(baseURL);
        }

        public async Task<NbaPlayer> getNbaPlayer(int input) 
        {
            accessPointUrl = "players/";
            System.Diagnostics.Debug.WriteLine(accessPointUrl);
            var response = await client.GetAsync(accessPointUrl + input.ToString());
            var responseBody = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(responseBody);
            NbaPlayer returnPlayer = new NbaPlayer();



            return returnPlayer;
            
        }

        public async Task<NbaTeam> getNbaTeam(int input) 
        {
            accessPointUrl = "/teams/";
            var response = await client.GetAsync(accessPointUrl + input.ToString());
            System.Diagnostics.Debug.WriteLine(response.Content);
            NbaTeam returnTeam = new NbaTeam();


            return returnTeam;
        }

        public async Task<NbaMatch> getNbaMatch(int input)
        {
            accessPointUrl = "/games/";
            var response = await client.GetAsync(accessPointUrl + input.ToString());
            System.Diagnostics.Debug.WriteLine(response.Content);
            NbaMatch match = new NbaMatch();

            return match;
        }

    }

    public class NbaPlayer 
    {
    }

    public class NbaTeam 
    { 
    }

    public class NbaMatch 
    {
    }
}
