

var JsAccesRegistroCotizacion = function () {

    function GetListaTypeServices() {
        $.ajax({
            method: "POST",
            url: "/Home/ListarTypeServices/"

        }).done(function (response) {
            $.each(response.Data, function (i, item) {
                $('<option value="' + item.TypeServicesId + '">' + item.Name_TypeServices + '</option>').appendTo('#cboTipoServices');
            });
        })
    };
     
    function GetListServices(TypeServicesId) {

        var modelView = {
            TypeServicesId: TypeServicesId

        };

        $.ajax({
            method: "POST",
            url: "/Home/ListarServicesbyType/",
            data: modelView
        }).done(function (response) {
            $.each(response.Data, function (i, item) {
                $('<option value="' + item.TypeServicesId + '">' + item.Name_TypeServices + '</option>').appendTo('#cboTipoServices');
            });
        })
    };
    GetListaTypeServices();
    GetListServices(1);
    return {
        init: function (parametros) {

        }
    };
}();