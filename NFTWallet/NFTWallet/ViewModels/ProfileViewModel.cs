﻿using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using NFTWallet.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class ProfileViewModel : BaseViewModel, IInitializeAsync
    {
        private readonly IProfileService _profileService;
        private ProfileModel _profile;
        private string _exibitionMode;

        public Task Initialization { get; }

        public ProfileModel Profile 
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }

        public string ExibitionMode 
        {
            get => _exibitionMode;
            set => SetProperty(ref _exibitionMode, value);
        }

        public ICommand NavigateToDetailCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand ChangeExibitionModeCommand { get; }

        public ProfileViewModel(INavigation navigation, IProfileService profileService)
            : base(navigation)
        {
            _profileService = profileService;
            Profile = new ProfileModel();
            ExibitionMode = "2";
            NavigateToDetailCommand = new Command<NftModel>(async (nftSelected) => await ExecuteNavigateToDetailCommand(nftSelected));
            NavigateToSettingsCommand = new Command(async () => await ExecuteNavigateToSettingsCommand());
            ChangeExibitionModeCommand = new Command<string>((mode) => ExecuteChangeExibitionModeCommand(mode));

            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await GetProfileAsync();
        }

        private async Task GetProfileAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var profile = await _profileService.GetProfileAsync(TranslateManagerHelper.Instance.GetCurrentCulture());

                if (profile != null)
                    Profile = profile;
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

        private async Task ExecuteNavigateToDetailCommand(NftModel nftSelected)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await Navigation.PushAsync(new DetailPage(nftSelected));
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

        private async Task ExecuteNavigateToSettingsCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                await Navigation.PushAsync(new SettingsPage(Profile.User));
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

        private void ExecuteChangeExibitionModeCommand(string mode)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                ExibitionMode = mode;
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
    }
}
