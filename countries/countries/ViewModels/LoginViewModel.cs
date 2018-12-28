namespace countries.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;    

    public class LoginViewModel : BaseViewModel
    {
        //Aqui se deben declarar las propiedades que se bindaron en
        //la LoginPage "Deben ser del mismo tipo string, booleano etc."
        
        #region Attributes
            private string email;
            private string password;
            private bool isRunning;
            private bool isEnable;
        #endregion

        #region Properties
            public string Email
            {
                get { return email; }
                set { SetValue(ref email, value); }
            }

        public string Password
            {
                get { return password; }
                set { SetValue(ref password, value); }
            }

        public bool IsRunning
            {
                get { return this.isRunning; }
                set { SetValue(ref isRunning, value); }
            }

        public bool IsRemmembered
            {
                get;
                set;
            }

        public bool IsEnable
            {
                get { return this.isEnable; }
                set { SetValue(ref isEnable, value); }
            }
        #endregion

        #region Constructors
            public LoginViewModel()
            {
                this.IsRemmembered = true;
                this.IsEnable = true;
            }
        #endregion

        #region Commands
            public ICommand LoginCommand
            {
                get
                {
                    return new RelayCommand(Login);
                }
            }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email....",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Password....",
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = true;
            this.IsEnable = false;

            if (this.Email != "druizbermud@uniminuto.edu.co" ||
                this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnable = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password wrong....",
                    "Accept");
                return;
            }

            this.IsRunning = false;
            this.IsEnable = true;
            await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You are in!!you're on fire!!",
                    "Accept");
        }
        #endregion

    }
}
