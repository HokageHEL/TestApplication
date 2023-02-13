using System;

using TestApplication.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace TestApplication.Views
{
    public sealed partial class CoinsMarketPage : Page
    {
        public CoinsMarketViewModel ViewModel { get; } = new CoinsMarketViewModel();

        
        public CoinsMarketPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadCoinsAsync();
        }

      

       
    }
}
