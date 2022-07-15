using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private NftModel _nft;

        public NftModel Nft 
        {
            get => _nft; 
            set => SetProperty(ref _nft, value);
        }

        public ICommand NavigateBackCommand { get; }

        public DetailViewModel(INavigation navigation, NftModel nft)
            : base(navigation)
        {
            Nft = nft;
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
