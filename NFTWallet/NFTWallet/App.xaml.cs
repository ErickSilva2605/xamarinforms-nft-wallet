using NFTWallet.Helpers;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace NFTWallet
{
    public partial class App : Application
    {
        public App()
        {
            TranslateManagerHelper.Instance.InitCulture();
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
