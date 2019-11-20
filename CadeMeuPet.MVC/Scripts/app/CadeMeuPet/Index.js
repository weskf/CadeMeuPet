$(document).ready(function () {

    $("#Estado").change(function () {
        CarregaComboCidade();
    });

    $("#Especie").change(function () {
        CarregaComboRaca();
    });

    $("#btn-help").on('click', function () {
        $("#div-help").removeAttr('hidden');
    })

});

function CarregaComboCidade() {

    var _EstadoId = $("#Estado").val();

    if (_EstadoId == "") {
        $("#Cidade").empty();
        $("#Cidade").append('<option value="">Cidade</option>');
    }
    else {
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
    }


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

function CriarObjetoPet() {

    var objLocalizacao = {
        EstadoId: $("#Estado").val(),
        CidadeId: $("#Cidade").val(),
        Bairro: $("#bairro").val(),
        Logradouro: $("#logradouro").val(),
    }

    var obj = {
        EspecieAnimalId: $("#Especie").val(),
        RacaAnimalId: $("#Raca").val(),
        CorAnimalId: $("#Cor").val(),
        PorteAnimalId: $("#Porte").val(),
        Caracteristica: $("#inp-pesquisar").val(),
        Localizacao: objLocalizacao,
    }

    return obj;
}

function Filtro() {

    var obj = CriarObjetoPet();

    $.ajax({
        url: "/CadeMeuPet/Filtro",
        type: "POST",
        async: false,
        data: { filter: obj },
        success: function (data) {
            $('#GridCadeMeuPet').html(data);
        },
        error: function (error) {
            $("#dv-error").removeAttr('hidden');
            console.log(error);
        }
    });
}