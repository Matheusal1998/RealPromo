using Microsoft.AspNetCore.SignalR.Client;
using RealPromo.Classe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RealPromo.Service
{
    public class RealPromoSI
    {
        public RealPromoSI(ObservableCollection<Promocao> lista)
        {
           Task.Run(async() => { await ConfigurarSI(lista); }) ;
        }

        private async Task ConfigurarSI(ObservableCollection<Promocao> lista)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://realpromo.azurewebsites.net/PromoHub").Build();

            connection.On<Promocao>("receberPromocao", (promocao) => {

                Xamarin.Forms.Device.InvokeOnMainThreadAsync(() => {

                    lista.Add(promocao);
                });
            });


            await connection.StartAsync();
        }
    }
}
