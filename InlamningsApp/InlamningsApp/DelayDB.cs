using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using SQLite;
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
            _sqlconnection.Insert(delay);
        }

        public double GetDelays(double TimeDelay) 
        {
           return _sqlconnection.Table<Delay>().LastOrDefault(t => t.TimeDelay == TimeDelay).TimeDelay;

            //return (from c in _sqlconnection.Table<Delay>() select c).ToList();
            //var latestDelay = _sqlconnection.Table<Delay>().LastOrDefault(d => d.Id == this.)
        }

    }
}
