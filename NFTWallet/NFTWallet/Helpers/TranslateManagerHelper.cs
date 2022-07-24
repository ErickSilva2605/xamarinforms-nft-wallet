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
            string language = Preferences.Get(Constants.PREFERENCES_KEY_CULTURE_SELECTED, string.Empty);
            if (!string.IsNullOrEmpty(language))
                SetCulture(new CultureInfo(language));
            else
                SetCulture(GetDeviceCulture());
        }

        public string GetCurrentCulture()
        {
            string language = Preferences.Get(Constants.PREFERENCES_KEY_CULTURE_SELECTED, string.Empty);
            if (!string.IsNullOrEmpty(language))
                return language;
            else
                return "system";
        }

        public void ChangeCulture(string language)
        {
            if (GetCurrentCulture() == language)
                return;

            if(language == "system")
            {
                Preferences.Set(Constants.PREFERENCES_KEY_CULTURE_SELECTED, string.Empty);
                SetCulture(GetDeviceCulture());
            }
            else
            {
                Preferences.Set(Constants.PREFERENCES_KEY_CULTURE_SELECTED, language);
                SetCulture(new CultureInfo(language));
            }
        }

        public CultureInfo GetDeviceCulture() =>
            CultureInfo.InstalledUICulture;

        public CultureInfo GetCulture() =>
            AppResources.Culture;

        private void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;

            Invalidate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
