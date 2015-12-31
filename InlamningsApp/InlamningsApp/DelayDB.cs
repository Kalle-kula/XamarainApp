using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using SQLite;
using Xamarin;
using Xamarin.Forms;

namespace InlamningsApp
{
    public class DelayDB
    {
        private SQLiteConnection _sqlconnection;
        //double lastDelay;
        public DelayDB()
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Delay>();
        }

        public void AddDelay(Delay delay)
        {
            //Kollar så att fördröjningen är sparad som den ska
            string addedDelay = "delay: " + delay.TimeDelay + " millisekunder";
            Insights.Track("Delay added", new Dictionary<string, string>
            {
                {"Saved delay", addedDelay}
            });
            _sqlconnection.Insert(delay);
        }

        public double GetDelays(double TimeDelay) 
        {
            //Hämtar den senaste delayen som är sparad i DB:n (alltså den vi satte)
           return _sqlconnection.Table<Delay>().LastOrDefault(t => t.TimeDelay == TimeDelay).TimeDelay;
        }

    }
}
