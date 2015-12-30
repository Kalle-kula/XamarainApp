using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using Xamarin.Forms;
using InlamningsApp.Services;

namespace InlamningsApp.View
{
    public partial class CallPage : ContentPage
    {
        public DelayDB _delayDb;
        public Delay delay;

        private WebAPI wa = new WebAPI();
        string joke = string.Empty;

        
        public CallPage()
        {
            InitializeComponent();
        }

        async void BtnCall_OnClicked(object sender, EventArgs e)
        {

            var dialer = DependencyService.Get<IPhoneService>();
            if (dialer != null)
            {
                delay = new Delay();
                _delayDb = new DelayDB();
                double DBlatestDelay = _delayDb.GetDelays(delay.TimeDelay);
                int latestDelay = Convert.ToInt32(DBlatestDelay);
                await Task.Delay(latestDelay);
                

                dialer.Call(PhoneNo.Text);
            }
        }

        private void BtnJoke_OnClicked(object sender, EventArgs e)
        {
            JokeLabel.Text = wa.GetJokeFromApi(joke);
        }
    }
}
