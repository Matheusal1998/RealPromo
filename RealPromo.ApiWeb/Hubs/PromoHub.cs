using Microsoft.AspNetCore.SignalR;
using RealPromo.ApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealPromo.ApiWeb.Hubs
{
    // RPC
    public class PromoHub : Hub
    {
        //Cliente - JS/C#/JAVA
        //Cliente (JS) -> HUB (cadastrar promocao) c#
        //HUB -> Cliente (Receber promocao) c#

        public async Task CadastrarPromocao(Promocao promocao)
        {
            // 
            // Notificar o Usuario(SignaIr)
            await Clients.Caller.SendAsync("CadastradoSucesso"); //Cadastro com sucesso
            await Clients.Others.SendAsync("receberPromocao", promocao); // Promocao chegou
        }

    }
}
