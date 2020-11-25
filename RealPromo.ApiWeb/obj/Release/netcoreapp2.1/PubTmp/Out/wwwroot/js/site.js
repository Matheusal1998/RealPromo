
var connection = new signalR.HubConnectionBuilder().withUrl("/PromoHub").build();

connection.start().then(function () {
    console.info("Connected!")
}).catch(function (err) {
    console.error(err.toString());

})

connection.on("CadastradoSucesso", function () {
    var mensagem = document.getElementById("sucesso");
    mensagem.innerHTML = "Cadastrado com sucesso";
})
connection.on("receberPromocao", function (promocao) {

    //<div class="container-promo">
    //    <div class="container-chamada">
    //        <h1>Carrefour</h1>
    //        <p>TV LG 40" - R$ 999,99</p>
    //        <p>Somente 20 unidades</p>
    //    </div>
    //    <div class="container-botao">
    //        Pegar
    //    </div>
    //</div>
    var container = document.getElementById("containerlogin");

    var containerPromo = document.createElement("div");
    containerPromo.setAttribute("class", "container-promo");


    var containerChamada = document.createElement("div");
    containerChamada.setAttribute("class", "container-chamada");
    var titulo = document.createElement("h1");

    titulo.innerText = promocao.empresa;
    var p1 = document.createElement("p");
    var p2 = document.createElement("p");
    p1.innerText = promocao.chamada;
    p2.innerText = promocao.regras;
    var containerBtn = document.createElement("div");
    containerBtn.setAttribute("class", "container-botao");
    var  link= document.createElement("a");
    link.setAttribute("href", promocao.url);
    link.innerText = "Pegar";


    containerChamada.appendChild(titulo);
    containerChamada.appendChild(p1);
    containerChamada.appendChild(p2);

    containerBtn.appendChild(link);

    containerPromo.appendChild(containerChamada);
    containerPromo.appendChild(containerBtn);

    container.appendChild(containerPromo);

    console.log(promocao)
})

var BtnCadastrar = document.getElementById("BtnCadastrar")
if (BtnCadastrar != null) {
    BtnCadastrar.addEventListener("click", function () {
        var empresa = document.getElementById("EmpresaId").value;
        
        var chamada = document.getElementById("ChamadaId").value;
        var regras = document.getElementById("RegrasId").value;
        var url = document.getElementById("UrlId").value;

        var promocao = { Empresa : empresa, Chamada : chamada, Regras : regras, Url : url }

        connection.invoke("CadastrarPromocao", promocao).then(function () {
            console.info("Connected!")
        }).catch(function (err) {
            console.error(err.toString());
        })

    });
}