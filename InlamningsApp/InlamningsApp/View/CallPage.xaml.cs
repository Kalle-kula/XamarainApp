using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using Xamarin.Forms;

namespace InlamningsApp.View
{
    public partial class CallPage : ContentPage
    {
        public DelayDB _delayDb;
        public Delay delay;
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
                double lateDelay = _delayDb.GetDelays(delay.TimeDelay);
                int latestDelay = Convert.ToInt32(lateDelay);

                //OnTimedEvent();
                await Task.Delay(latestDelay);
                dialer.Call(PhoneNo.Text);
            }
        }

        private void BtnJoke_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
