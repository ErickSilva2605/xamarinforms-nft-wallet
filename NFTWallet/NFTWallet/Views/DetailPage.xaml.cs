using NFTWallet.Models;
using NFTWallet.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(NftModel nft)
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(Navigation, nft);
        }
    }
}