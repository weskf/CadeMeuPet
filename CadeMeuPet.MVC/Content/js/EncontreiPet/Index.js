//function ClickImg(obj) {
//    var AnimalId = obj.id;

//    bootbox.confirm({
//        message: "Deseja 'Excluir' ou 'Editar' o cadastro do Pet ? ",
//        buttons: {
//            confirm: {
//                label: 'Editar',
//                className: 'btn btn-outline-warning'
//            },
//            cancel: {
//                label: 'Excluir',
//                className: 'btn btn-outline-danger'
//            }
//        },
//        callback: function (result) {
//            if (result) {
//                EditarCadastroPet(AnimalId);
//            } else {
//                ExcluirCadastroPet(AnimalId);
//            }
//        }
//    });
//};

function EditarCadastroPet(btn) {
    var AnimalId = RetornaPetId(btn);

    window.location.href = "/EncontreiPet/Editar?AnimalId=" + AnimalId;
}

function ExcluirCadastroPet(btn) {
    var _AnimalId = RetornaPetId(btn);

    $.ajax({
        url: "/EncontreiPet/Excluir",
        type: 'POST',
        dataType: "json",
        async: false,
        data: { AnimalId: _AnimalId },
        success: function (resultado) {
            if (resultado.retorno == "sucesso") {
                bootbox.alert(resultado.msgRetorno);
                window.location.href = "/EncontreiPet/Index";
            }
            else {
                bootbox.alert(resultado.msgRetorno);
            }
        }
    });
}

function RetornaPetId(btn) {
    var _AnimalId = btn.id;
    var posInicio = _AnimalId.indexOf("_") + 1;
    var posFim = _AnimalId.length;
    return AnimalId = _AnimalId.substring(posInicio, posFim);
}

$(document).ready(function () {

    $("#btn-cadastrar").click(function () {
        window.location.href = "/EncontreiPet/Cadastrar";
    });
});