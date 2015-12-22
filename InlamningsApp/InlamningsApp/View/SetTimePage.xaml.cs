using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InlamningsApp.Interface;
using Xamarin.Forms;

namespace InlamningsApp.View
{
    public partial class SetTimePage : ContentPage
    {
        public double delay;
        public SetTimePage()
        {
            InitializeComponent();
        }

        //private void StepperDelay_OnValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    StepperLabel.Text = (StepperDelay.Value).ToString();
        //}

        //private void SaveDelayButton_OnClicked(object sender, EventArgs e)
        //{
        //    //var delay = DependencyService.Get<IDelay>();
        //    //if (delay != null)
        //    //{
        //    //    delay.TimeDelay(StepperDelay.Value);
        //    //}
        //    delay = StepperDelay.Value;
        //    Navigation.PushAsync(new MainMenuPage());
        //}
    }
}
