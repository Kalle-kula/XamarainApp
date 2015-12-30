using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTimer.Forms.Plugin.Abstractions;
using InlamningsApp.Interface;
using InlamningsApp.Services;
using Xamarin.Forms;


namespace InlamningsApp.View
{
    public partial class SendSmsPage : ContentPage
    {
        public DelayDB _delayDb;
        public Delay delay;

        private WebAPI wa = new WebAPI();
        string joke = String.Empty;

        public SendSmsPage()
        {
            InitializeComponent();
        }
        
        async void SmsSendBtn_OnClicked(object sender, EventArgs e)
        {
            var smsSender = DependencyService.Get<ISms>();
            
            if (smsSender != null)
            {

                //Instansierar db:n
                delay = new Delay();
                _delayDb = new DelayDB();

                //Hämtar senaste inknappade delayen i db:n
                double DBlatestDelay = _delayDb.GetDelays(delay.TimeDelay);

                //Gör om från double till int
                int latestDelay = Convert.ToInt32(DBlatestDelay);
                
                                
                //Sätter den senaste inknappade delayen som nu är en int och väntar antal inknappade minuter
                await Task.Delay(latestDelay);

                //TimerLabel.Text = timer.ToString();
                smsSender.SendSms(SspNumberEntry.Text);
                smsSender.SendSmsMsg(MsgEntry.Text);
            }

        }
        
        private void BtnJoke_OnClicked(object sender, EventArgs e)
        {
            JokeLabel.Text = wa.GetJokeFromApi(joke);
        }
    }
}
