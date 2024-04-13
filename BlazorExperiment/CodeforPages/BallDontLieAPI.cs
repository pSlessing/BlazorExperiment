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
        private string APIKEY = "19cad8bd-dd85-4925-8e97-f66f8e48a1d8";
        private HttpClient client = new HttpClient();
        private string accessPointUrl = "";
        public BallDontLieAPI() 
        {
            client.DefaultRequestHeaders.Add("Authorization", APIKEY);
        }

        public async Task<NbaPlayer> getNbaPlayer(string input) 
        {
            accessPointUrl = "/players/" + input;
            client.BaseAddress = new Uri(baseURL + accessPointUrl);
            
        }

        public async Task<NbaPlayer> getNbaTeam(string input) 
        {
            accessPointUrl = "/teams/" + input;
            client.BaseAddress = new Uri(baseURL + accessPointUrl);
        }

        public async Task<NbaMatch> getNbaMatch(string input)
        {
            accessPointUrl = "/games/" + input;
            client.BaseAddress = new Uri(baseURL + accessPointUrl);
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
