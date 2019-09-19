function CriarObjetoUsuario() {

    var obj = {
        Nome: $("#nome").val(),
        Sobrenome: $("#sobrenome").val(),
        Telefone: $("#telefone").val(),
        Celular: $("#celular").val(),
        LinkRedeSocial: $("#linkRedeSocial").val(),
        Email: $("#email").val(),
        Senha: $("#senha").val(),
        ConfirmacaoSenha: $("#confirmacaoSenha").val()
    }

    return obj;
}

function CriarObjetoLogin() {

    var objLogin = {
        Email: $("#inputEmail").val(),
        Senha: $("#inputPassword").val()
    }

    return objLogin;
}

function ValidaPreenchimentoSenha(obj) {
    if (obj.Senha == obj.ConfirmacaoSenha)
        return true;
    else
        return false;
}

function SalvarCadastro() {

    var obj = CriarObjetoUsuario();

    if (ValidaPreenchimentoSenha(obj)) {
        $.ajax({
            url: "/Account/Cadastrar",
            type: 'POST',
            dataType: "json",
            data: { usuarioViewModel: obj },
            success: function (resultado) {
                if (resultado.retorno == "sucesso") {
                    bootbox.alert({
                        message: resultado.msgRetorno,
                        callback: function () {
                            window.location.href = "/Account/Login";
                        }
                    })
                }
                else {
                    bootbox.alert(resultado.msgRetorno);
                }
            }
        });
    }
    else {
        bootbox.alert({
            size: "small",
            title: "Atenção",
            message: "Senhas não coincidem.",
            callback: function () { /* your callback code */ }
        })
    }
}

function Limpar() {

    $("#nome").val("");
    $("#sobrenome").val("");
    $("#telefone").val("");
    $("#celular").val("");
    $("#linkRedeSocial").val("");
    $("#email").val("");
    $("#senha").val("");
    $("#confirmacaoSenha").val("");
}

function Login() {
    
    var _Email = $("#inputEmail").val();
    var _Senha= $("#inputPassword").val();

    $.ajax({
        url: "/Account/Login",
        type: 'POST',
        dataType: "json",
        data: { email: _Email, senha: _Senha },
        success: function (resultado) {
            if (resultado.retorno == "sucesso") {
                bootbox.alert(resultado.msgRetorno);
                window.location.href = "/EncontreiPet/Index";
            }
            else {
                bootbox.alert(resultado.msgRetorno);
                window.location.href = "/Account/Login";
            }
        }
    });

}

$(document).ready(function () {

    $("#btn-cadastrar").click(function () {
        window.location.href = "/Account/Cadastrar";
    });

    $("#btn-salvar").click(function () {
        SalvarCadastro();
    });

    $("#btn-limpar").click(function () {
        Limpar();
    });

    $("#btn-logar").click(function () {
        Login();
    });

    $("#celular").mask("(99) 99999-9999");
    $("#telefone").mask("(99) 9999-9999");
    
});