using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using NFTWallet.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NFTWallet.ViewModels
{
    public class HomeViewModel : BaseViewModel, IInitializeAsync
    {
        private readonly IFilterService _filterService;
        private readonly ISaleService _saleService;

        private ObservableRangeCollection<FilterModel> _filter;
        private ObservableRangeCollection<NftModel> _forSale;

        public Task Initialization { get; }

        public ObservableRangeCollection<FilterModel> Filters 
        {
            get => _filter;
            set => SetProperty(ref _filter, value);
        }

        public ObservableRangeCollection<NftModel> ForSale
        {
            get => _forSale;
            set => SetProperty(ref _forSale, value);
        }

        public ICommand FilterCommand { get; }
        public ICommand NavigateToDetailCommand { get; }

        public HomeViewModel(INavigation navigation, IFilterService filterService, ISaleService saleService) :
            base(navigation)
        {
            _filterService = filterService;
            _saleService = saleService;
            Filters = new ObservableRangeCollection<FilterModel>();
            ForSale = new ObservableRangeCollection<NftModel>();
            FilterCommand = new Command<FilterModel>((filterSelected) => ExecuteFilterCommand(filterSelected));
            NavigateToDetailCommand = new Command<NftModel>(async (nftSelected) => await ExecuteNavigateToDetailCommand(nftSelected));

            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await GetFiltersAsync();
            await GetSalesAsync();
        }

        private async Task GetFiltersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var filters = await _filterService.GetFiltersAsync(TranslateManagerHelper.Instance.GetCurrentCulture());

                if (filters.Any())
                    Filters = new ObservableRangeCollection<FilterModel>(filters);
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

        private async Task GetSalesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var sales = await _saleService.GetSalesAsync(TranslateManagerHelper.Instance.GetCurrentCulture());

                if (sales.Any())
                    ForSale = new ObservableRangeCollection<NftModel>(sales);
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

        private void ExecuteFilterCommand(FilterModel filterSelected)
        {
            if (filterSelected.Selected)
                return;

            Filters.ForEach(filter => filter.Selected = false);

            filterSelected.Selected = true;
        }

        private async Task ExecuteNavigateToDetailCommand(NftModel nftSelected)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await Navigation.PushAsync(new DetailPage(nftSelected));
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
