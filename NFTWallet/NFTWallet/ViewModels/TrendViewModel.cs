using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class TrendViewModel : BaseViewModel, IInitializeAsync
    {
        private readonly ITrendService _trendService;

        private ObservableRangeCollection<TrendModel> _trends;

        public ObservableRangeCollection<TrendModel> Trends
        {
            get => _trends;
            set => SetProperty(ref _trends, value);
        }

        public Task Initialization { get; }

        public TrendViewModel(INavigation navigation, ITrendService trendService)
            : base(navigation)
        {
            _trendService = trendService;
            Trends = new ObservableRangeCollection<TrendModel>();

            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await GetTrendsAsync();
        }

        private async Task GetTrendsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var trends = await _trendService.GetTrendsAsync();

                if (trends.Any())
                    Trends = new ObservableRangeCollection<TrendModel>(trends);
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
