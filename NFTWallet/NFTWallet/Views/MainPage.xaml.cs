﻿using NFTWallet.Services;
using NFTWallet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation, new FilterService(), new SaleService());
        }
    }
}