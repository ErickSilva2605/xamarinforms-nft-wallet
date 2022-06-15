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
                SetCulture(CultureInfo.InstalledUICulture);
        }

        public string GetCurrentCulture()
        {
            string language = Preferences.Get(Constants.PREFERENCES_KEY_CULTURE_SELECTED, string.Empty);
            if (!string.IsNullOrEmpty(language))
                return language;
            else
                return GetCulture().Name;
        }

        public void ChangeCulture(CultureInfo language)
        {
            string languageName = Preferences.Get(Constants.PREFERENCES_KEY_CULTURE_SELECTED, string.Empty);
            if (!string.IsNullOrEmpty(languageName) || language.Name.Equals(languageName))
                return;

            Preferences.Set(Constants.PREFERENCES_KEY_CULTURE_SELECTED, language.Name);
            SetCulture(language);
        }

        private CultureInfo GetCulture() =>
            CultureInfo.InstalledUICulture;

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
