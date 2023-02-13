using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestApplication.Core.Models;


namespace TestApplication.ViewModels
{
    public class CoinsMarketViewModel : INotifyPropertyChanged
    {
        

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CoinsMarket> _coins;
        public ObservableCollection<CoinsMarket> Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                OnPropertyChanged("Coins");
            }
        }

       

        public async Task<ObservableCollection<CoinsMarket>> LoadCoinsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var coins = JsonConvert.DeserializeObject<List<CoinsMarket>>(responseString);

                return Coins = new ObservableCollection<CoinsMarket>(coins.Take(100));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
