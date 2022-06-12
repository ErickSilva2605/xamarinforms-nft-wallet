using NFTWallet.Services;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private HomeViewModel _homeViewModel;

        public HomeViewModel HomeViewModel
        {
            get => _homeViewModel;
            set => SetProperty(ref _homeViewModel, value);
        }

        public MainViewModel(INavigation navigation) 
            : base(navigation)
        {
            HomeViewModel = new HomeViewModel(navigation, new FilterService(), new SaleService());
        }
    }
}
