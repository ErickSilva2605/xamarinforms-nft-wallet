using NFTWallet.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartedPage : ContentPage
    {
        public GetStartedPage()
        {
            InitializeComponent();
            BindingContext = new GetStartedViewModel(Navigation);
        }
    }
}