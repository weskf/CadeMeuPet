function CarregaComboCidade() {

    var _EstadoId = $("#Estado").val();

    $.ajax({
        url: "/EncontreiPet/RetornaCidadePorEstado",
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

    $.ajax({
        url: "/EncontreiPet/RetornaRacaPorEspecie",
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

function UploadFiles() {

    var Countfiles = $(".file");
    var file;
    var imagensAnexadas = 0;


    var fileData = new FormData();
    for (var i = 0; i < Countfiles.length; i++) {
        file = Countfiles.get(i).files;

        if (file.length != 0) {
            fileData.append("fileInput", file[0]);
            imagensAnexadas++;
        }
    }

    if (imagensAnexadas == 0) {
        bootbox.alert({
            message: 'Favor anexar um arquivo para enviar.',
            title: 'Aviso',
            size: 'small',
            buttons: {
                ok: {
                    label: 'Ok',
                    className: 'btn-primary'
                }
            }
        });
    }
    else {

        $.ajax({
            type: "POST",
            url: "/EncontreiPet/UploadFile",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (result, status, xhr) {
                if (result.success = "s") {
                    bootbox.alert({
                        message: result.message,
                        title: 'Sucesso',
                        size: 'small',
                        buttons: {
                            ok: {
                                label: 'Ok',
                                className: 'btn-primary'
                            }
                        },
                        callback: function () {
                            window.location.href = "/EncontreiPet/Index";
                        }
                    });
                }
            },
            error: function (xhr, status, error) {
                alert(status);
            }
        });
    }
}

function AbrirModalUploadFotos() {
    $("#fileUpload").removeAttr('hidden');
}

function CriarObjetoAnimal() {

    var objLocalizacao = {
        EstadoId: $("#Estado").val(),
        CidadeId: $("#Cidade").val(),
        Bairro: $("#bairro").val(),
        Logradouro: $("#logradouro").val(),
        DataLocalizacao: $("#data-localizacao").val()
    }

    var obj = {
        EspecieAnimalId: $("#Especie").val(),
        RacaAnimalId: $("#Raca").val(),
        CorAnimalId: $("#Cor").val(),
        PorteAnimalId: $("#Porte").val(),
        Identificacao: $("#identificacao").val(),
        Caracteristica: $("#característica").val(),
        Localizacao: objLocalizacao,
        Ativo: true
    }

    return obj;
}

function SalvarCadastro() {

    var obj = CriarObjetoAnimal();

    $.ajax({
        url: "/EncontreiPet/Cadastrar",
        type: 'POST',
        dataType: "json",
        async: false,
        data: { animalViewModel: obj },
        success: function (resultado) {
            if (resultado.retorno == "sucesso") {
                $("#fileUpload").removeAttr('hidden', 'hidden');
            }
            else {
                bootbox.alert(resultado.msgRetorno);
            }
        }
    });
}

function SalvarEdicaoPet() {

    var obj = CriarObjetoAnimal();

    var Countfiles = $(".file");
    var file;
    var imagensAnexadas = 0;

    for (var i = 0; i < Countfiles.length; i++) {
        file = Countfiles.get(i).files;
        if (file.length != 0) {
            imagensAnexadas++;
        }
    }

    $.ajax({
        url: "/EncontreiPet/Editar",
        type: 'POST',
        dataType: "json",
        async: false,
        data: { animalViewModel: obj },
        success: function (resultado) {
            if (resultado.retorno == "sucesso") {
                if (imagensAnexadas > 0) {
                    UploadFiles();
                }
                else {

                    bootbox.confirm({
                        message: resultado.msgRetorno,
                        buttons: {
                            confirm: {
                                label: 'Ok',
                                className: 'btn btn-outline-success'
                            },
                        },
                        callback: function (result) {
                            if (result) {
                                window.location.href = "/EncontreiPet/Index";
                            }
                            
                        }
                    });
                }
            }
            else {
                bootbox.alert(resultado.msgRetorno);
            }
        }
    });
}

function ExcluirImagemPet(btn) {
    var _DescricaoPet = btn.id;

    $.ajax({
        url: "/EncontreiPet/RemoverImagemPet",
        type: 'POST',
        dataType: "json",
        async: false,
        data: { descricaoPet: _DescricaoPet },
        success: function (resultado) {
            if (resultado.retorno == "sucesso") {
                location.reload();
            }
            else {
                bootbox.alert(resultado.message);
            }
        }
    });
}

function PreencheNomeArquivoUpload() {

    var input01 = document.getElementById("file01");
    var inputGroupFile01 = document.getElementById("inputGroupFile01");
    input01.addEventListener("change", function () {
        if (input01.files.length > 0) nome01 = input01.files[0].name;
        inputGroupFile01.innerHTML = nome01;
    });

    var input02 = document.getElementById("file02");
    var inputGroupFile02 = document.getElementById("inputGroupFile02");
    input02.addEventListener("change", function () {
        if (input02.files.length > 0) nome02 = input02.files[0].name;
        inputGroupFile02.innerHTML = nome02;
    });

    var input03 = document.getElementById("file03");
    var inputGroupFile03 = document.getElementById("inputGroupFile03");
    input03.addEventListener("change", function () {
        if (input03.files.length > 0) nome03 = input03.files[0].name;
        inputGroupFile03.innerHTML = nome03;
    });

    var input04 = document.getElementById("file04");
    var inputGroupFile04 = document.getElementById("inputGroupFile04");
    input04.addEventListener("change", function () {
        if (input04.files.length > 0) nome04 = input04.files[0].name;
        inputGroupFile04.innerHTML = nome04;
    });

    var input05 = document.getElementById("file05");
    var inputGroupFile05 = document.getElementById("inputGroupFile05");
    input05.addEventListener("change", function () {
        if (input05.files.length > 0) nome05 = input05.files[0].name;
        inputGroupFile05.innerHTML = nome05;
    });
}

$(document).ready(function () {

    $("#Estado").change(function () {
        CarregaComboCidade();
    });

    $("#Especie").change(function () {
        CarregaComboRaca();
    });

    $("#inputFile").click(function () {
        UploadFiles();
    });

    $("#btn-salvar").click(function () {
        SalvarCadastro();
    });

    $("#btn-Editar").click(function () {
        SalvarEdicaoPet();
    });

    $("#btn-Voltar").click(function () {
        window.location.href = "/EncontreiPet/Index;
    });

    $("#btn-anexar").click(function () {
        $("#fileUpload").removeAttr('hidden', 'hidden');
    });

    $("#btn-excluir-img").click(function () {
        SalvarEdicaoPet();
    });

    PreencheNomeArquivoUpload();

});



