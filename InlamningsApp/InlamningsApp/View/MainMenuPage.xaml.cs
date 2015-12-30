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
                //Sätter delayn till minuter istället för millisekunder
                delay.TimeDelay = (StepperDelay.Value) * 60000;

                // Sparar delayn i DB:n
                _delayDb.AddDelay(delay);

                //double lateDelay = _delayDb.GetDelays(delay.TimeDelay);

                DelayLabelMain.Text = "Din fördröjning är satt till " + StepperDelay.Value + " minut(er)";
            }
            else DelayLabelMain.Text = "Du måste sätta en fördröjning";

        }

        private void ButtonSms_OnClicked(object sender, EventArgs e)
        {
            if (StepperDelay.Value >= 1)
            {
                Navigation.PushAsync(new SendSmsPage());
            }
            else DelayLabelMain.Text = "Du måste sätta en fördröjning";
        }

        private void ButtonCall_OnClicked(object sender, EventArgs e)
        {
            if (StepperDelay.Value >= 1)
            {
                Navigation.PushAsync(new CallPage());
            }
            else DelayLabelMain.Text = "Du måste sätta en fördröjning";
        }
    }
}
