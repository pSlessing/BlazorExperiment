namespace BlazorExperiment;

using System.Collections.Generic;
using PuppeteerSharp;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc.Rendering;

static class HLTVScraper
{
    public static async Task<Player> GetTwistzzStats()
    {
        Player result;
        List<string> playerStats = new List<string>();
        await new BrowserFetcher().DownloadAsync();

        var launchOptions = new LaunchOptions
        {
            Headless = false, // = false for testing

        };

        using (var browser = await Puppeteer.LaunchAsync(launchOptions))
        //var browser = await Puppeteer.ConnectAsync(new ConnectOptions { BrowserWSEndpoint = "wss://chrome.browsercloud.io?token=pEteddJOUfqsH0lx&--window-size=1200,900" });
        using (var page = await browser.NewPageAsync())
        {

            await page.GoToAsync("https://www.hltv.org/player/10394/twistzz");

            var html = await page.GetContentAsync();

            System.Diagnostics.Debug.WriteLine(html);
            var currentPlayerNameObject = await page.QuerySelectorAsync(".playerRealname");
            string currentPlayerName = (await currentPlayerNameObject.GetPropertyAsync("innerText")).RemoteObject.Value.ToString();
            System.Diagnostics.Debug.WriteLine(currentPlayerName);

            var currentImgSourceObject = await page.QuerySelectorAsync(".bodyshot-img");
            string currentImgSource = (await currentImgSourceObject.GetPropertyAsync("src")).RemoteObject.Value.ToString();
            System.Diagnostics.Debug.WriteLine(currentImgSource);

            var currentPlayerTagObject = await page.QuerySelectorAsync(".playerNickname");
            string currentPlayerTag = (await currentPlayerTagObject.GetPropertyAsync("innerText")).RemoteObject.Value.ToString();
            System.Diagnostics.Debug.WriteLine(currentPlayerTag);

            var currentPlayerStatValueObjects = (await page.QuerySelectorAllAsync(".statsVal"));
            foreach (var item in currentPlayerStatValueObjects)
            {
                var itemChild = await item.QuerySelectorAsync("p");
                playerStats.Add((await itemChild.GetPropertyAsync("innerText")).RemoteObject.Value.ToString());
                System.Diagnostics.Debug.WriteLine((await itemChild.GetPropertyAsync("innerText")).RemoteObject.Value.ToString());
            }

            result = new Player(currentPlayerName, currentPlayerTag, currentImgSource,
                                           playerStats[0], playerStats[1],
                                           playerStats[2], playerStats[3],
                               playerStats[4], playerStats[5]);

            System.Diagnostics.Debug.WriteLine(result.playerName);

            await page.CloseAsync();
            await browser.CloseAsync();
        }

        return result;
    }
}

class Player
{
    public string playerName { get; set; }
    public string playerTag { get; set; }
    public string imgSource { get; set; }
    public string rating { get; set; }
    public string killsPerRound { get; set; }
    public string headshotPercentage { get; set; }
    public string mapsPlayed { get; set; }
    public string deathsPerRound { get; set; }
    public string roundsContributed { get; set; }

    public Player(string playerName, string playerTag, string imgSource, string rating, string killsPerRound, string headshotPercentage, string mapsPlayed, string deathsPerRound, string roundsContributed) 
    {
        this.playerName = playerName;
        this.playerTag = playerTag;
        this.imgSource = imgSource;
        this.rating = rating;
        this.killsPerRound = killsPerRound;
        this.headshotPercentage = headshotPercentage;
        this.mapsPlayed = mapsPlayed;
        this.deathsPerRound = deathsPerRound;
        this.roundsContributed = roundsContributed;
    }

    public Player() 
    {
        this.playerName = "";
        this.playerTag = "";
        this.imgSource = "";
        this.rating = "";
        this.killsPerRound = "";
        this.headshotPercentage = "";
        this.mapsPlayed = "";
        this.deathsPerRound = "";
        this.roundsContributed = "";
    }
}