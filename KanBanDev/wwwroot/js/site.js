function ExibirSucessoComConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        icon: 'success',
        title: Titulo,
        text: Mensagem,
    })
}

function ExibirSucessoSemConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        icon: 'success',
        title: Titulo,
        text: Mensagem,
        showConfirmButton: false,
        timer: 1200
    })
}

function ExibirErro(Titulo, Erros) {
    Swal.fire({
        icon: 'error',
        title: Titulo,
        html: PreencherListaDeErros(Erros),
    })
}

function PreencherListaDeErros(Erros) {
    var ErrosEmHtmlParaRenderizar = "";
    for (var i = 0; i < Erros.length; i++) {
        ErrosEmHtmlParaRenderizar += Erros[i].errorMessage + "<br/>";
    }
    return ErrosEmHtmlParaRenderizar;
}

function ExibirAlertaComConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        icon: 'warning',
        title: Titulo,
        text: Mensagem,
    })
}

function ExibirAlertaSemConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        icon: 'warning',
        title: Titulo,
        text: Mensagem,
        showConfirmButton: false,
        timer: 1200
    })
}

function ExibirConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        icon: 'question',
        title: Titulo,
        text: Mensagem,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirmar',
        cancelButtonText: 'Cancelar',
    })
}

function ExibirInformacao(Titulo, Mensagem) {
    Swal.fire({
        icon: 'info',
        title: Titulo,
        text: Mensagem,
    })
}

function SerializarFormulario(Formulario) {
    if (Formulario != undefined && Formulario != null && Formulario != "") {
        Formulario = $(Formulario).serialize();
    }
    return Formulario;
}

function IniciarLoading() {
    Swal.fire({
        title: 'Aguarde Carregando...',
        allowEscapeKey: false,
        allowOutsideClick: false,
        onOpen: () => {
            swal.showLoading();
        }
    })
}

function FinalizarLoading() {
    Swal.close();
}