using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using unirest_net.http;
using Newtonsoft.Json;

namespace InlamningsApp.Services
{
    public class WebAPI
    {
        
        public string GetJokeFromApi(string joke)
        {
            //try
            //    {
            string errorMessage = string.Empty;
            
            HttpResponse<string> jsonResponse = Unirest.get("https://webknox-jokes.p.mashape.com/jokes/oneLiner")
            .header("X-Mashape-Key", "UMJJhgaBWumshuvL0Yrr8EhR6CfNp1bpx1Xjsnt2Gzhihdd7FF")
            .asJson<string>();

            if (jsonResponse.Code == 200)
            {
                string jokeRaw = jsonResponse.Body;
                jokeRaw = jokeRaw.Replace("text", "Joke");
                jokeRaw = jokeRaw.Replace("{", "");
                jokeRaw = jokeRaw.Replace("}", "");
                return jokeRaw;
            }

            //!= 200
            errorMessage = "Nått gick fel, inget skämt =(";
            return errorMessage;
            //    }

            //catch (Exception ex)
            //{
            //    ////Log exception to insight
            //    //Insights.Report(ex);
            //    //errorMessage = "Wrong something went.  Connected to the interwebz are you, hmm?";
            //    //return errorMessage;
            //}
        }
    }
}
