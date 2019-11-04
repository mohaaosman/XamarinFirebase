using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFirebase.Services;

namespace XamarinFirebase
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetUser(object sender, EventArgs e)
        {
            string uid = await DependencyService.Get<FirebaseAuthShared>().GetCurrentUser();
            if(uid != "")
            {
                await DisplayAlert("Login", uid, "OK");

            }
            else
            {
                await DisplayAlert("Login", "No user found", "OK");

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<FirebaseAuthShared>().SignOut();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());

        }
    }
}
