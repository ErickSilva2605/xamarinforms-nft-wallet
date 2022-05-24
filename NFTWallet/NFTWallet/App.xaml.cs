using NFTWallet.Helpers;
using Xamarin.Forms;

namespace NFTWallet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ThemeHelper.InitTheme();

            MainPage = new MainPage();
        }
            
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
