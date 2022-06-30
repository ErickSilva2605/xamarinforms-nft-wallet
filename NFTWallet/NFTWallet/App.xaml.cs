using NFTWallet.Helpers;
using NFTWallet.Views;
using Syncfusion.Licensing;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFTWallet
{
    public partial class App : Application
    {
        public App()
        {
            TranslateManagerHelper.Instance.InitCulture();
            SyncfusionLicenseProvider.RegisterLicense(Constants.SYNCFUSION_LICENSE_KEY);

            InitializeComponent();

            ThemeHelper.InitTheme();

            if(Preferences.Get(Constants.PREFERENCES_KEY_AUTHENTICATED, false))
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new GetStartedPage());
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
