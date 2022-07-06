using NFTWallet.Models;
using NFTWallet.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(UserModel user)
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel(Navigation, user);
        }
    }
}