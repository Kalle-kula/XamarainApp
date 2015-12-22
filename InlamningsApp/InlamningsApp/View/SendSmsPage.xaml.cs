using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using Xamarin.Forms;

namespace InlamningsApp.View
{
    public partial class SendSmsPage : ContentPage
    {
        public SendSmsPage()
        {
            InitializeComponent();
        }

        private void SspContactBtn_OnClicked(object sender, EventArgs e)
        {
            
        }

        private void SmsSendBtn_OnClicked(object sender, EventArgs e)
        {
            var smsSender = DependencyService.Get<ISms>();
            smsSender?.SendSms(SspNumberEntry.Text);
        }

        private void BtnJoke_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
