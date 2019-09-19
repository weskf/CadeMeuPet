

function ClickImg(obj) {
    var AnimalId = obj.id;

    bootbox.confirm({
        message: "Deseja 'Excluir' ou 'Editar' o cadastro do Pet ? ",
        buttons: {
            confirm: {
                label: 'Editar',
                className: 'btn btn-outline-warning'
            },
            cancel: {
                label: 'Excluir',
                className: 'btn btn-outline-danger'
            }
        },
        callback: function (result) {
            if (result) {
                EditarCadastroPet(AnimalId);
            } else {
                ExcluirCadastroPet(AnimalId);
            }
        }
    });
};


function EditarCadastroPet(_AnimalId) {

    window.location.href = "/EncontreiPet/Editar?AnimalId="+_AnimalId;
    //$.ajax({
    //    url: "/EncontreiPet/Editar",
    //    type: 'GET',
    //    data: { AnimalId: _AnimalId }
    //});
}

$(document).ready(function () {

    $("#btn-cadastrar").click(function () {
        window.location.href = "/EncontreiPet/Cadastrar";
    });
});