using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsApp.Services
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string TimeElapsed { get; set; }

        //private DispatcherTimer timer;
        private Stopwatch stopWatch;

        public void StartTimer()
        {
            //timer = new DispatcherTimer();
            //timer.Tick += dispatcherTimerTick_;
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            stopWatch = new Stopwatch();
            stopWatch.Start();
            //timer.Start();
        }

        private void dispatcherTimerTick_(object sender, EventArgs e)
        {
            TimeElapsed = stopWatch.Elapsed.TotalMilliseconds.ToString(); // Format as you wish
            PropertyChanged(this, new PropertyChangedEventArgs("TimeElapsed"));
        }
    }
}
