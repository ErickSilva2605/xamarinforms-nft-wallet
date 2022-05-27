using NFTWallet.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class GetStartedViewModel : BaseViewModel
    {
        public ICommand NavigateToLoginCommand { get; }
        public GetStartedViewModel(INavigation navigation) 
            : base(navigation)
        {
            NavigateToLoginCommand = new Command(async () => await ExecuteNavigateToLoginCommand());
        }

        private async Task ExecuteNavigateToLoginCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await Navigation.PushAsync(new LoginPage());
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
 