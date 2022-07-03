using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NFTWallet.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private NftModel _nft;

        public NftModel Nft 
        {
            get => _nft; 
            set => SetProperty(ref _nft, value);
        }

        public DetailViewModel(INavigation navigation, NftModel nft)
            : base(navigation)
        {
            Nft = nft;
        }

    }
}
