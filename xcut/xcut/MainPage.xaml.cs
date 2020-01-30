using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xcut {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        IAuth auth;
        public MainPage() {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void LoginClicked(object sender, EventArgs e) {
            string Token = await auth.LoginWithEmailPassword(EmailInput.Text, PasswordInput.Text);
            if (Token != "") {
                await Navigation.PushAsync(new HomePage());
            } else {
                ShowError();
            }
        }

        async private void ShowError() {
            await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
        }
    }
}
