using NFTWallet.Resources.Language;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using Xamarin.Essentials;

namespace NFTWallet.Helpers
{
    public class TranslateManagerHelper : INotifyPropertyChanged
    {
        public static TranslateManagerHelper Instance { get; } = new TranslateManagerHelper();

        public string this[string text]
        {
            get
            {
                return AppResources.ResourceManager.GetString(text, AppResources.Culture);
            }
        }

        public void InitCulture() 
        {
            string language = Preferences.Get("cultureSelected", string.Empty);
            if (!string.IsNullOrEmpty(language))
                SetCulture(new CultureInfo(language));
            else
                SetCulture(CultureInfo.InstalledUICulture);
        }

        public void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;

            Preferences.Set("cultureSelected", language.Name);

            Invalidate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
