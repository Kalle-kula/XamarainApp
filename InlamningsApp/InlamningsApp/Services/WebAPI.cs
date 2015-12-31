using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using unirest_net.http;
using Newtonsoft.Json;
using Xamarin;

namespace InlamningsApp.Services
{
    public class WebAPI
    {
        //Hämtar one-liner skämt från mashape.com
        public string GetJokeFromApi(string joke)
        {
            try
            {

                string errorMessage = string.Empty;

                //Mäter hur lång tid det tar att anropa API:t
                var handle = Insights.TrackTime("Time to get api call");

                handle.Start();
            
            HttpResponse<string> jsonResponse = Unirest.get("https://webknox-jokes.p.mashape.com/jokes/oneLiner")
            .header("X-Mashape-Key", "UMJJhgaBWumshuvL0Yrr8EhR6CfNp1bpx1Xjsnt2Gzhihdd7FF")
            .asJson<string>();

                handle.Stop();

                //Om hämtningen av skämtet lyckas
                if (jsonResponse.Code == 200)
            {
                string jokeRaw = jsonResponse.Body;
                jokeRaw = jokeRaw.Replace("text", "Joke");
                jokeRaw = jokeRaw.Replace("{", "");
                jokeRaw = jokeRaw.Replace("}", "");
                //jokeRaw = jokeRaw.Replace("\u2019", "'");
                return jokeRaw;
            }

            //!= 200
            errorMessage = "Nått gick fel, inget skämt =(";
            return errorMessage;
            }

            catch (Exception ex)
            {
                ////Logga exception till insight om hämtning av skämtet inte lyckas
                Insights.Report(ex, new Dictionary<string, string>
                { 
                { "Methodname", "GetJokeFromApi()" },
                { "Where", "WebAPI.cs"}
                });
                string errorMessage = "Something went wrong, are you sure you have a connection?";
                return errorMessage;
            }
        }
    }
}
