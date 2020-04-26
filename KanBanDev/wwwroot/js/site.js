function ExibirSucessoComConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        type: 'success',
        title: Titulo,
        text: Mensagem,
    })
}

function ExibirSucessoSemConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        type: 'success',
        title: Titulo,
        text: Mensagem,
        showConfirmButton: false,
        timer: 1200
    })
}

function ExibirErro(Titulo, Erros) {
    Swal.fire({
        type: 'error',
        title: Titulo,
        html: PreencherListaDeErros(Erros),
    })
}

function PreencherListaDeErros(Erros) {
    var ErrosEmHtmlParaRenderizar = "";
    if (Array.isArray(Erros) == false) {
        ErrosEmHtmlParaRenderizar = Erros;
    } else {
        for (var i = 0; i < Erros.length; i++) {
            ErrosEmHtmlParaRenderizar += Erros[i] + "<br/>";
        }
    }
    return ErrosEmHtmlParaRenderizar;
}

function ExibirAlertaComConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        type: 'warning',
        title: Titulo,
        text: Mensagem,
    })
}

function ExibirAlertaSemConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        type: 'warning',
        title: Titulo,
        text: Mensagem,
        showConfirmButton: false,
        timer: 1200
    })
}

function ExibirConfirmacao(Titulo, Mensagem) {
    Swal.fire({
        type: 'question',
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
        type: 'info',
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