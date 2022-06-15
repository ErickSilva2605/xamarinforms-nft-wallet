using NFTWallet.Services;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private HomeViewModel _homeViewModel;
        private TrendViewModel _trendViewModel;

        public HomeViewModel HomeViewModel
        {
            get => _homeViewModel;
            set => SetProperty(ref _homeViewModel, value);
        }

        public TrendViewModel TrendViewModel
        {
            get => _trendViewModel;
            set => SetProperty(ref _trendViewModel, value);
        }

        public MainViewModel(INavigation navigation)
            : base(navigation)
        {
            HomeViewModel = new HomeViewModel(navigation, new FilterService(), new SaleService());
            TrendViewModel = new TrendViewModel(navigation, new TrendService());
        }
    }
}
