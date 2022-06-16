using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class WalletViewModel : BaseViewModel, IInitializeAsync
    {
        private readonly IWalletService _walletService;

        private WalletModel _wallet;

        public WalletModel Wallet
        {
            get => _wallet;
            set => SetProperty(ref _wallet, value);
        }

        public Task Initialization { get; }

        public WalletViewModel(INavigation navigation, IWalletService walletService)
            : base(navigation)
        {
            _walletService = walletService;
            Wallet = new WalletModel();

            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await GetWalletAsync();
        }

        private async Task GetWalletAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var wallet = await _walletService.GetWalletAsync(TranslateManagerHelper.Instance.GetCurrentCulture());

                if (wallet != null)
                    Wallet = wallet;
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
