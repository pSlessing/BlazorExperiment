using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace BlazorExperiment
{
    public class BallDontLieAPI
    {
        private const string baseURL = "https://api.balldontlie.io/v1";
        private HttpClient client = new HttpClient();
        private string accessPointUrl = "";
        public BallDontLieAPI(string APIKEY) 
        {
            client.DefaultRequestHeaders.Add("Authorization", APIKEY);
        }

        public async Task<NbaPlayer> getNbaPlayer(int input) 
        {
            accessPointUrl = "/players/";
            client.BaseAddress = new Uri(baseURL + accessPointUrl);
            var response = await client.GetAsync(input.ToString());
            
        }

        public async Task<NbaPlayer> getNbaTeam(int input) 
        {
            accessPointUrl = "/teams/";
            client.BaseAddress = new Uri(baseURL + accessPointUrl);
            var response = await client.GetAsync(input.ToString());
        }

        public async Task<NbaMatch> getNbaMatch(int input)
        {
            accessPointUrl = "/games/";
            client.BaseAddress = new Uri(baseURL + accessPointUrl);
            var response = await client.GetAsync(input.ToString());
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
