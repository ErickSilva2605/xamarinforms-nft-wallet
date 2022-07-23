using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFTWallet.Helpers
{
    public static class ThemeHelper
    {
        public static void InitTheme()
        {
            if (Preferences.ContainsKey(Constants.PREFERENCES_KEY_THEME_SELECTED))
            {
                int themeSelected = Preferences.Get(Constants.PREFERENCES_KEY_THEME_SELECTED, (int)OSAppTheme.Unspecified);

                if (themeSelected != (int)OSAppTheme.Unspecified)
                    SetTheme((OSAppTheme)themeSelected);
            }
            else if (!DeviceHasDarkMode())
                SetTheme(OSAppTheme.Light);
        }

        public static void ChangeTheme(OSAppTheme theme)
        {
            int themeSelected = Preferences.Get(Constants.PREFERENCES_KEY_THEME_SELECTED, (int)OSAppTheme.Unspecified);
            if (themeSelected == (int)theme)
                return;

            Preferences.Set(Constants.PREFERENCES_KEY_THEME_SELECTED, (int)theme);
            SetTheme(theme);
        }

        public static OSAppTheme GetCurrentTheme()
        {
            int themeSelected = Preferences.Get(Constants.PREFERENCES_KEY_THEME_SELECTED, (int)OSAppTheme.Unspecified);

            if (themeSelected != (int)OSAppTheme.Unspecified)
                return (OSAppTheme)themeSelected;

            if(!DeviceHasDarkMode())
                return OSAppTheme.Light;

            return OSAppTheme.Unspecified;
        }

        public static bool DeviceHasDarkMode()
        {
            bool hasDarkMode = false;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                hasDarkMode = DeviceInfo.Version.Major >= Constants.ANDROID_DARK_MODE_MINIMAL_VERSION;
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                hasDarkMode = DeviceInfo.Version.Major >= Constants.IOS_DARK_MODE_MINIMAL_VERSION;

            return hasDarkMode;
        }

        private static OSAppTheme GetTheme() =>
            Application.Current.RequestedTheme;

        private static void SetTheme(OSAppTheme theme) =>
            Application.Current.UserAppTheme = theme;
    }
}
