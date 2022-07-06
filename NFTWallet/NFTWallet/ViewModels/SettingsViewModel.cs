using NFTWallet.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private UserModel _user;

        public UserModel User 
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public ICommand NavigateBackCommand { get; }

        public SettingsViewModel(INavigation navigation, UserModel user) 
            : base(navigation)
        {
            User = user;
            NavigateBackCommand = new Command(async () => await ExecuteNavigateBackCommand());
        }

        private async Task ExecuteNavigateBackCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await Navigation.PopAsync();
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
    }
}
