
var urlHomeIndex = 'Home/index/'

var JsAccessLoginForm = function () {


    $('#btn-Ingresar_login').on('click', function () {

        debugger;
        var valor_usuario = $('#txtusuarioForm').val();
        var valor_password = $('#txtpasswordForm').val();

        if (valor_usuario != "" && valor_password != "") {


            ValidateAcessLogin(valor_usuario, valor_password)


        }
        else {
            $('#txtusuarioForm').val('');
            $('#txtpasswordForm').val('');
            new PNotify({
                title: 'Danger notice',
                text: 'datos faltantes',
                icon: 'icofont icofont-info-circle',
                type: 'error'
            });
        }
    });

    function ValidateAcessLogin(usu, pass) {

        var modelView = {
            usu: usu,
            pass: pass,
        };
        $.ajax({
            method: "POST",
            url: "/Account/ValidateSessionPortalWeb/",
            data: modelView
        })
            .done(function () {

                location.href = '/' + urlHomeIndex;

            });


    }

    return {
        init: function (parametros) {

        }
    };
}();

