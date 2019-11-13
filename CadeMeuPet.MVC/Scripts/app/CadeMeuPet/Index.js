$(document).ready(function () {

    $("#Estado").change(function () {
        CarregaComboCidade();
    });

    $("#Especie").change(function () {
        CarregaComboRaca();
    });

});

function CarregaComboCidade() {

    var _EstadoId = $("#Estado").val();

    if (_EstadoId == "") {
        $("#Cidade").empty();
        $("#Cidade").append('<option value="">Cidade</option>');
    }

    $.ajax({
        url: "/CadeMeuPet/RetornaCidadePorEstado",
        type: 'POST',
        dataType: "json",
        data: { EstadoId: _EstadoId },
        success: function (response) {
            $("#Cidade").empty();
            for (var i = 0; i < response.length; i++) {
                $("#Cidade").append('<option value="' + response[i].CidadeId + '">' + response[i].NomeCidade + '</option>');
            };
        }
    });
};

function CarregaComboRaca() {

    var _EspecieId = $("#Especie").val();

    if (_EspecieId == "") {
        $("#Raca").empty();
        $("#Raca").append('<option value="">Raça</option>');
    }
        

    $.ajax({
        url: "/CadeMeuPet/RetornaRacaPorEspecie",
        type: 'POST',
        dataType: "json",
        data: { EspecieId: _EspecieId },
        success: function (response) {
            $("#Raca").empty();
            for (var i = 0; i < response.length; i++) {
                $("#Raca").append('<option value="' + response[i].RacaAnimalId + '">' + response[i].Raca + '</option>');
            };
        }
    });
}