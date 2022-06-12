using NFTWallet.Helpers;
using NFTWallet.Views;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public string Email 
        {
            get => _email; 
            set => SetProperty(ref _email, value);
        }

        public string Password 
        { 
            get => _password; 
            set => SetProperty(ref _password, value); }

        public ICommand LoginCommand { get; }

        public LoginViewModel(INavigation navigation) : 
            base(navigation)
        {
            LoginCommand = new Command(() => ExecuteLoginCommand());
        }

        private void ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if(Authenticated())
                {
                    Preferences.Set(Constants.PREFERENCES_KEY_AUTHENTICATED, true);
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool Authenticated()
        {
            // TODO 
            // NAO AUTENTICADO - EXIBIR MENSAGEM DE ERRO

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                return false;

            if (!Email.Equals(Constants.EMAIL_DEFAULT) || !Password.Equals(Constants.PASSWORD_DEFAULT))
                return false;

            return true;
        }
    }
}
