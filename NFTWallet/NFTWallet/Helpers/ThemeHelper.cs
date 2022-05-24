using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFTWallet.Helpers
{
    public static class ThemeHelper
    {
        public static void InitTheme()
        {
            if (Preferences.ContainsKey("themeSelected"))
            {
                int themeSelected = Preferences.Get("themeSelected", 0);

                if (themeSelected != 0)
                    SetTheme((OSAppTheme)themeSelected);
            }
            else if (!DeviceHasDarkMode())
                SetTheme(OSAppTheme.Light);
        }

        public static void ChangeTheme(OSAppTheme theme)
        {
            int themeSelected = Preferences.Get("themeSelected", 0);
            if (themeSelected == (int)theme)
                return;

            Preferences.Set("themeSelected", (int)theme);
            SetTheme(theme);
        }

        public static bool DeviceHasDarkMode()
        {
            bool hasDarkMode = false;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                hasDarkMode = DeviceInfo.Version.Major >= 10;
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                hasDarkMode = DeviceInfo.Version.Major >= 13;

            return hasDarkMode;
        }

        private static OSAppTheme GetTheme() =>
            Application.Current.RequestedTheme;

        private static void SetTheme(OSAppTheme theme) =>
            Application.Current.UserAppTheme = theme;
    }
}
