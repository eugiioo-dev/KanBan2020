function Login() {

    if ($("#UsuarioEmail").val() == null || $("#UsuarioEmail").val() == "") {
        ExibirErro("", "É obrigatório informar o e-mail");
        return;
    }

    if ($("#UsuarioSenha").val() == null || $("#UsuarioSenha").val() == "") {
        ExibirErro("", "É obrigatório informar a senha");
        return;
    }

    $.ajax({
        url: "/Usuario/Login",
        type: 'POST',
        data: $('#form-login').serialize(),
    }).done(function (data) {
        if (data.status == 0)
        {
            window.location.href = "/Home/Index/";
        }
        else
        {
            ExibirErro("Ops...", data.erros);
        }
    })
};