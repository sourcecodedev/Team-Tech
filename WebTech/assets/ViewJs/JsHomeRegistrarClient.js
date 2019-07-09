var usuarioValido = false;
var empresavalida = false;
var JsHomeRegistrarClient = function () {

    $('#btnPersonaNaturalSeach').on('click', function () {


        var dni = $('#txtdni_PersonaNatural').val();

        if (dni != null && dni != '') {

            GetDataValidPersonaNatural(dni);
        }
        else {
            new PNotify({
                title: 'Validación de datos!',
                text: 'Campo Dni vacío.',
                icon: 'icofont icofont-info-circle',
                type: 'error'
            });
        }

    });

    $('#btnGuardarEmpresa').on('click', function () {

        var ruc = $('#txtRuc_empresa').val();
        var nombre_emprea = $('#txtNombreEmpresa_Empresa').val();
        var dirrecion = $('#txtDireccion_Empresa').val();
        var distrito_empresa = $('#cboDistrito_Empresa option:selected').val();
        var representante_empresa = $('#txtRepresentante_Empresa').val();
        var dniRepresentante_empresa = $('#txtdnirepsentante_Empresa').val();
        var celular_empresa = $('#txtcelular_Empresa').val();
        var correo_empresa = $('#email_Empresa').val();
        var canal_atencion_empresa = $('#cboAtencion_Empresa option:selected').val();
        var asesor_comercial = $('#cboAsesor_Empresa option:selected').val();

        if (empresavalida) {
            if (ruc != '' && nombre_emprea != '' && dirrecion != '' && distrito_empresa != '' && representante_empresa != '' && dniRepresentante_empresa != '' && celular_empresa != '' && correo_empresa != '' && canal_atencion_empresa != '' && asesor_comercial != '') {

                SaveClienteData_Empresa(ruc, nombre_emprea, dirrecion, distrito_empresa, representante_empresa, dniRepresentante_empresa, celular_empresa, correo_empresa, canal_atencion_empresa, asesor_comercial);
                GetInfoEmpleadoByIdQuequeMessage(asesor_comercial, nombre_emprea, ruc, "Empresa");
            }
            else {
                new PNotify({
                    title: 'Validación de datos!',
                    text: 'Todos los datos son obligatorios',
                    icon: 'icofont icofont-info-circle',
                    type: 'error'
                });
            }
        }
        else {
            new PNotify({
                title: 'Validación de datos!',
                text: 'El RUC esta vacío o cliente \n no encontrado',
                icon: 'icofont icofont-info-circle',
                type: 'error'
            });
        }


    });
    $('#btnPersonaEmpresaSearch').on('click', function () {

        var ruc = $('#txtRuc_empresa').val();
        if (ruc != null && ruc != '') {

            GetDataValidEmpresa(ruc);
        }
        else {
            new PNotify({
                title: 'Validación de datos!',
                text: 'Campo Ruc Vacío',
                icon: 'icofont icofont-info-circle',
                type: 'error'
            });
        }

    });
    $('#btnGrabarClientePrsonaNatural').on('click', function () {

        debugger;
        if (usuarioValido) {

            var dni = $("#txtdni_PersonaNatural").val();
            var NombresCompletos = $('#txtNombreCompletos_PersonaNatural').val();
            var direccion = $('#txtDireccion_PersonaNatural').val();
            var distrito = $('#cboDistrito_PersonaNatural option:selected').val();
            var celular = $('#txtCelular_PersonaNatural').val();
            var mail = $('#txtemail_PersonaNatural').val();
            var canal_Atencion = $('#cboCanalAtencion_PersonaNatural option:selected').val();
            var asesorComercial = $('#cboAsesorComercial_PersonaNatural option:selected').val();


            if (dni != '' && NombresCompletos != '' && direccion != '' && celular != '' && canal_Atencion != '' && asesorComercial != '' && mail != '' && distrito != '') {
                SaveClienteData_PersonaNatural(dni, NombresCompletos, direccion, distrito, celular, canal_Atencion, asesorComercial, mail, distrito);

                GetInfoEmpleadoByIdQuequeMessage(asesorComercial, NombresCompletos, dni, "Persona Natural");

            }
            else {
                new PNotify({
                    title: 'Validación de datos!',
                    text: 'Todos los datos son obligatorios',
                    icon: 'icofont icofont-info-circle',
                    type: 'error'
                });
            }
        }
        else {
            new PNotify({
                title: 'Validación de datos!',
                text: 'El DNI o Carnet esta vacío o cliente \n no encontrado',
                icon: 'icofont icofont-info-circle',
                type: 'error'
            });
        }

    });

    function SaveClienteData_Empresa(ruc, nombre_emprea, dirrecion, distrito_empresa, representante_empresa, dniRepresentante_empresa, celular_empresa, correo_empresa, canal_atencion_empresa, asesor_comercial) {
        var modelView = {
            ruc: ruc,
            nombre_emprea: nombre_emprea,
            dirrecion: dirrecion,
            distrito_empresa: distrito_empresa,
            representante_empresa: representante_empresa,
            dniRepresentante_empresa: dniRepresentante_empresa,
            celular_empresa: celular_empresa,
            correo_empresa: correo_empresa,
            canal_atencion_empresa: canal_atencion_empresa,
            asesor_comercial: asesor_comercial,
            tipoclient: 'Empresa'
        };

        $.ajax({
            method: "POST",
            url: "/Home/SaveClienteData_Empresa/",
            data: modelView
        }).done(function (response) {

            new PNotify({
                title: 'Operación Completada',
                text: 'Cliente registrado Exitosamente',
                icon: 'icofont icofont-info-circle',
                type: 'info'
            });
            if (response.Success) {

                debugger;


                if (response.Data == "1") {
                    new PNotify({
                        title: 'Operación Completada',
                        text: 'Cliente registrado Exitosamente',
                        icon: 'icofont icofont-info-circle',
                        type: 'info'
                    });

                    $('#txtRuc_empresa').val('');
                    $('#txtNombreEmpresa_Empresa').val('');
                    $('#txtDireccion_Empresa').val('');
                    $('#txtRepresentante_Empresa').val('');
                    $('#txtdnirepsentante_Empresa').val('');
                    $('#txtcelular_Empresa').val('');
                    $('#email_Empresa').val('');

                }
                else if (response.Data == "-2") {
                    new PNotify({
                        title: 'Error al guardar Cliente!',
                        text: 'Cliente ya se encuentra registrado',
                        icon: 'icofont icofont-info-circle',
                        type: 'error'
                    });
                }
                else {

                    new PNotify({
                        title: 'Error al guardar Cliente',
                        text: 'Hubo un error, inténtelo más tarde',
                        icon: 'icofont icofont-info-circle',
                        type: 'error'
                    });
                }
            }
            else {
                new PNotify({
                    title: 'Error al guardar Cliente',
                    text: response.Message,
                    icon: 'icofont icofont-info-circle',
                    type: 'error'
                });
            }
        });
    }

    function SaveClienteData_PersonaNatural(dni, NombresCompletos, direccion, distrito, celular, canal_Atencion, asesorComercial, mail) {

        var modelView = {
            dni: dni,
            NombresCompletos: NombresCompletos,
            direccion: direccion,
            distrito: distrito,
            celular: celular,
            canal_Atencion: canal_Atencion,
            asesorComercial: asesorComercial,
            tipoclient: 'Natural',
            mail: mail
        };

        $.ajax({
            method: "POST",
            url: "/Home/SaveClienteData_PersonaNatural/",
            data: modelView
        }).done(function (response) {
            debugger;
            if (response.Success) {




                if (response.Data == "1") {
                    new PNotify({
                        title: 'Operación Completada',
                        text: 'Cliete registrado Exitosamente',
                        icon: 'icofont icofont-info-circle',
                        type: 'info'
                    });

                    $("#txtdni_PersonaNatural").val('');
                    $('#txtNombreCompletos_PersonaNatural').val('');
                    $('#txtDireccion_PersonaNatural').val('');
                    $('#txtCelular_PersonaNatural').val('');
                    $('#txtemail_PersonaNatural').val('');


                }
                else if (response.Data == "-2") {
                    new PNotify({
                        title: 'Error al guardar Cliente!',
                        text: 'Cliente ya se encuentra registrado',
                        icon: 'icofont icofont-info-circle',
                        type: 'error'
                    });
                }
                else {

                    new PNotify({
                        title: 'Error al guardar Cliente',
                        text: 'Hubo un error, inténtelo más tarde',
                        icon: 'icofont icofont-info-circle',
                        type: 'error'
                    });
                }
            }
            else {
                new PNotify({
                    title: 'Error al guardar Cliente',
                    text: response.Message,
                    icon: 'icofont icofont-info-circle',
                    type: 'error'
                });
            }
        });
    }
    function GetDataValidPersonaNatural(dni) {
        var modelView = {
            dni: dni
        };

        $.ajax({
            method: "POST",
            url: "/Home/GetDataConsultDatosPersonal/",
            data: modelView
        })
            .done(function (response) {

                if (response.Success) {
                    var nombre_completo = response.Data.apellido_paterno + ' ' + response.Data.apellido_materno + ',' + response.Data.nombres;
                    $('#txtNombreCompletos_PersonaNatural').val(nombre_completo)

                    usuarioValido = true;
                    new PNotify({
                        title: 'Validación de datos!',
                        text: 'El DNI o Carnet es correcto.',
                        icon: 'icofont icofont-info-circle',
                        type: 'info'
                    });
                }
                else {

                    new PNotify({
                        title: 'Validación de datos!',
                        text: response.Message,
                        icon: 'icofont icofont-info-circle',
                        type: 'error'
                    });
                }
            });
    }

    function GetDataValidEmpresa(ruc) {
        var modelView = {
            ruc: ruc
        };

        $.ajax({
            method: "POST",
            url: "/Home/GetDataConsultDatosCompany/",
            data: modelView
        })
            .done(function (response) {

                if (response.Success) {
                    $('#txtNombreEmpresa_Empresa').val(response.Data.razon_social)
                    $('#txtDireccion_Empresa').val(response.Data.direccion)
                    empresavalida = true;
                    new PNotify({
                        title: 'Validación de datos!',
                        text: 'Ruc Correcto',
                        icon: 'icofont icofont-info-circle',
                        type: 'info'
                    });
                }
                else {

                    new PNotify({
                        title: 'Validación de datos!',
                        text: response.Message,
                        icon: 'icofont icofont-info-circle',
                        type: 'error'
                    });
                }
            });
    }

    function GetListEmpleadoAsesores() {

        $.ajax({
            method: "POST",
            url: "/Home/GetListEmpleadoAsesores/"

        }).done(function (response) {

            console.log(response.Data);

            $.each(response.Data, function (i, item) {

                //console.log(item);
                $('<option value="' + item.EmployeeeId + '">' + item.FullName + '</option>').appendTo('#cboAsesorComercial_PersonaNatural');
                $('<option value="' + item.EmployeeeId + '">' + item.FullName + '</option>').appendTo('#cboAsesor_Empresa');

            });
            //cboAsesorComercial_PersonaNatural
        })

    }

    function GetInfoEmpleadoByIdQuequeMessage(EmployeeeId, nombre, dni, tipoCliente) {

        var modelView = {
            EmployeeeId: EmployeeeId,
            nombre: nombre,
            dni: dni,
            tipoCliente: tipoCliente
        };

        $.ajax({
            method: "POST",
            url: "/Home/GetInfoEmpleadoByIdQuequeMessage/",
            data: modelView
        }).done(function (response) {

        })
    }

    GetListEmpleadoAsesores();
    return {
        init: function (parametros) {

        }
    };
}();