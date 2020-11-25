using RealPromo.Classe;
using RealPromo.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealPromo
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Promocao> lista = new ObservableCollection<Promocao>();
        public MainPage()
        {
            InitializeComponent();

            new RealPromoSI(lista); 

            ListViewPromo.ItemsSource = lista;
        }
        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var promocao = e.SelectedItem as Promocao;

            Task.Run(async () => { await Browser.OpenAsync( new Uri(promocao.Url), BrowserLaunchMode.SystemPreferred); });
        }

        async Task Redirencionar(Uri uri)
        {
            try
            {
           
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // Não foi possivel acessar a uri
                await DisplayAlert("Erro : ", ex.Message, "Ok");
            }
        }




    }
}
