using NFTWallet.Helpers;
using NFTWallet.Models;
using NFTWallet.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private UserModel _user;
        private int _themeSelected;
        private double[] _lockStates = new double[] { };
        private bool _drawerIsOpen;
        private bool _changeThemeVisible;
        private bool _changeLanguageVisible;
        private bool _logoutVisible;

        public UserModel User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public int ThemeSelected
        {
            get => _themeSelected;
            set => SetProperty(ref _themeSelected, value);
        }

        public double[] LockStates
        {
            get => _lockStates;
            set => SetProperty(ref _lockStates, value);
        }

        public bool DrawerIsOpen
        {
            get { return _drawerIsOpen; }
            set { SetProperty(ref _drawerIsOpen, value); }
        }

        public bool ChangeThemeVisible
        {
            get => _changeThemeVisible;
            set => SetProperty(ref _changeThemeVisible, value);
        }

        public bool ChangeLanguageVisible
        {
            get => _changeLanguageVisible;
            set => SetProperty(ref _changeLanguageVisible, value);
        }

        public bool LogoutVisible
        {
            get => _logoutVisible;
            set => SetProperty(ref _logoutVisible, value);
        }

        public bool DeviceHasDarkMode
        {
            get => ThemeHelper.DeviceHasDarkMode();
        }

        public ICommand NavigateBackCommand { get; }
        public ICommand OpenModalChangeLanguageCommand { get; }
        public ICommand OpenModalChangeThemeCommand { get; }
        public ICommand OpenModalLogoutCommand { get; }
        public ICommand CloseModalCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ChangeThemeCommand { get; }

        public SettingsViewModel(INavigation navigation, UserModel user)
            : base(navigation)
        {
            User = user;
            NavigateBackCommand = new Command(async () => await ExecuteNavigateBackCommand());
            OpenModalChangeLanguageCommand = new Command(async () => await ExecuteOpenModalChangeLanguageCommand());
            OpenModalChangeThemeCommand = new Command(async () => await ExecuteOpenModalChangeThemeCommand());
            OpenModalLogoutCommand = new Command(async () => await ExecuteOpenModalLogoutCommand());
            CloseModalCommand = new Command(async () => await ExecuteCloseModalCommand());
            ChangeThemeCommand = new Command(async () => await ExecuteChangeThemeCommand());
            LogoutCommand = new Command(async () => await ExecuteLogoutCommand());

            SelectCurrentTheme();
        }

        private void SelectCurrentTheme()
            => ThemeSelected = (int)ThemeHelper.GetCurrentTheme();

        private async Task ExecuteNavigateBackCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteOpenModalChangeThemeCommand()
        {
            if (IsBusy)
                return;

            try
            {
                await Task.Run(() =>
                {
                    IsBusy = true;
                    LockStates = new double[] { 0, 0.33 };
                    LogoutVisible = false;
                    ChangeLanguageVisible = false;
                    ChangeThemeVisible = true;
                    DrawerIsOpen = true;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteOpenModalChangeLanguageCommand()
        {
            if (IsBusy)
                return;

            try
            {
                await Task.Run(() =>
                {
                    IsBusy = true;
                    LockStates = new double[] { 0, 0.33 };
                    LogoutVisible = false;
                    ChangeThemeVisible = false;
                    ChangeLanguageVisible = true;
                    DrawerIsOpen = true;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteOpenModalLogoutCommand()
        {
            if (IsBusy)
                return;

            try
            {
                await Task.Run(() =>
                {
                    IsBusy = true;
                    LockStates = new double[] { 0, 0.28 };
                    ChangeLanguageVisible = false;
                    ChangeThemeVisible = false;
                    LogoutVisible = true;
                    DrawerIsOpen = true;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteChangeThemeCommand()
        {
            if (IsBusy || ThemeSelected == (int)ThemeHelper.GetCurrentTheme())
                return;

            try
            {
                IsBusy = true;
                DrawerIsOpen = false;
                await Task.Delay(50);
                ThemeHelper.ChangeTheme((OSAppTheme)ThemeSelected);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteCloseModalCommand()
        {
            if (IsBusy)
                return;

            try
            {
                await Task.Run(() =>
                {
                    IsBusy = true;
                    DrawerIsOpen = false;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteLogoutCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                DrawerIsOpen = false;

                await Task.Delay(100);

                Preferences.Set(Constants.PREFERENCES_KEY_AUTHENTICATED, false);
                Application.Current.MainPage = new NavigationPage(new GetStartedPage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
