// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var btnPaginaBack = document.getElementById("btnPaginaBack");
var btnPaginaNext = document.getElementById("btnPaginaNext");
var inputPaginaAtiva = document.getElementById("indexPaginaAtiva");


inputPaginaAtiva.addEventListener('change', function () {
    var indexPaginaAtiva = parseInt(document.getElementById("indexPaginaAtiva").text);
    if (indexPaginaAtiva == 0) { return; }
    var itensPagina = document.querySelectorAll("#listaProdutos [data-pagina]");
    
    for (let i = 0; i < itensPagina.length; i++) {
        if (itensPagina[i].getAttribute("data-pagina") == (indexPaginaAtiva)) {
            itensPagina[i].classList.remove("hide");
        } else {
            itensPagina[i].classList.add("hide");
        }
    }
    if ((indexPaginaAtiva + 1) != 0) {
        document.getElementById("btnPaginaBack").removeAttribute("disabled");
    }    
})
btnPaginaNext.addEventListener('click', function () {
    var indexPaginaAtiva = parseInt(document.getElementById("indexPaginaAtiva").text);
    if (indexPaginaAtiva+1 == 0) { return; }
    var itensPagina = document.querySelectorAll("#listaProdutos [data-pagina]");
    for (let i = 0; i < itensPagina.length; i++) {
        if (itensPagina[i].getAttribute("data-pagina") == (indexPaginaAtiva + 1)) {
            itensPagina[i].classList.remove("hide");
        } else {            
            itensPagina[i].classList.add("hide");
        }
    }    
    if((indexPaginaAtiva + 1) != 0) {
        document.getElementById("btnPaginaBack").removeAttribute("disabled");
    }
    document.getElementById("indexPaginaAtiva").text = indexPaginaAtiva + 1;
});

btnPaginaBack.addEventListener('click', function () {
    var itensPagina = document.querySelectorAll("#listaProdutos [data-pagina]");
    var indexPaginaAtiva = parseInt(document.getElementById("indexPaginaAtiva").text);
    if (indexPaginaAtiva - 1 == 0) { return; }
    for (let i = 0; i < itensPagina.length; i++) {
        if (itensPagina[i].getAttribute("data-pagina") == (indexPaginaAtiva - 1)) {
            itensPagina[i].classList.remove("hide");
        } else {
            itensPagina[i].classList.add("hide");
        }
    }
    document.getElementById("indexPaginaAtiva").text = indexPaginaAtiva - 1;
});