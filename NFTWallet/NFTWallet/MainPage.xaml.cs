using NFTWallet.Helpers;
using NFTWallet.Resources.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFTWallet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SetDeviceCulture(object sender, EventArgs e)
        {
            Preferences.Remove("cultureSelected");
            TranslateManagerHelper.Instance.InitCulture();
        }

        private void SetIngles(object sender, EventArgs e)
        {
            TranslateManagerHelper.Instance.SetCulture(new CultureInfo("en-US"));
        }

        private void SetPortugues(object sender, EventArgs e)
        {
            TranslateManagerHelper.Instance.SetCulture(new CultureInfo("pt-BR"));
        }
    }
}
