using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class ProfileViewModel : BaseViewModel, IInitializeAsync
    {
        private readonly IProfileService _profileService;
        private ProfileModel _profile;

        public Task Initialization { get; }

        public ProfileModel Profile 
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }

        public ProfileViewModel(INavigation navigation, IProfileService profileService)
            : base(navigation)
        {
            _profileService = profileService;
            Profile = new ProfileModel();

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

                var profile = await _profileService.GetProfileAsync();

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
    }
}
