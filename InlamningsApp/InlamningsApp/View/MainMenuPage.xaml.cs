using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using Xamarin.Forms;


namespace InlamningsApp.View
{
    public partial class MainMenuPage : ContentPage
    {

        public DelayDB _delayDb;
        public Delay delay;

        public MainMenuPage()
        {
            InitializeComponent();
        }

        //private void ButtonTime_OnClicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new SetTimePage());
        //}

        private void StepperDelay_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            StepperLabel.Text = (StepperDelay.Value).ToString();
        }

        private void SaveDelayButton_OnClicked(object sender, EventArgs e)
        {
            
            delay = new Delay();
            _delayDb = new DelayDB();

            if (StepperDelay.Value >= 1)
            {
                delay.TimeDelay = StepperDelay.Value;

                _delayDb.AddDelay(delay);
                double lateDelay = _delayDb.GetDelays(delay.TimeDelay);
                

                //var setDelay = _delayDb.GetDelay(delay.Id);
                DelayLabelMain.Text = "Din fördröjning är satt till " + lateDelay + " minut(er)";
            }
            else DelayLabelMain.Text = "Du måste sätta en fördröjning";

        }

        private void ButtonSms_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SendSmsPage());
        }
    }
}
