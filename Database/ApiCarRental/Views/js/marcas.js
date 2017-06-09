$(document).ready(function () {

    function getMarcas() {
        var urlAPI = 'http://localhost:52673/api/Marcas';


        $.get(urlAPI, function (respuesta, estado) {

            $('#resultados').html('');

            if (estado === 'success') {
                var relleno = '';

                relleno += '<table>';
                relleno += '<tr>';
                relleno += '    <th>Id</th>';
                relleno += '    <th>Denominación</th>';
                relleno += '    <th colspan="2">Acciones</th>';
                relleno += '</tr>';

                $.each(respuesta.data, function (indice, elemento) {
                    relleno += '  <tr>';
                    relleno += '      <td>' + elemento.id + '</td>';
                    relleno += '      <td>' + elemento.denominacion + '</td>';
                    relleno += '      <td><button id="btnEliminar" data-id="' + elemento.id + '">X</button></td>';
                    relleno += '      <td><button id="btnUpdateMarca" data-id="' + elemento.id + '">Editar</button></td>';
                    relleno += '  </tr>';
                });
                relleno += '</table>';
                $('#resultados').append(relleno);
            }
        });
    }

    $('#resultados').on('click', '#btnEliminar', function () {
        var urlAPI = 'http://localhost:52673/api/Marcas';
        var idMarca = $(this).attr('data-id');

        $.ajax({
            url: urlAPI + '/' + idMarca,
            type: "DELETE",
            success: function (respuesta) {
                getMarcas();
            },
            error: function (respuesta) {
                //debugger;
                console.log(respuesta);
            }
        });

    });
    
    $('#btnAddMarca').click(function () {
        //debugger;
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        var urlAPI = 'http://localhost:52673/api/Marcas';
        var dataNuevaMarca = {
            id: 0,
            denominacion: nuevaMarca
        };
        //debugger;

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                //debugger;
                getMarcas();
                console.log(respuesta);
            },
            error: function (respuesta) {
                //debugger;
                console.log(respuesta);
            }
        });
        //equivalente a la llamada $.post siguiente:

        //$.post(urlAPI, dataNuevaMarca, function (respuesta) {
        //    console.log(respuesta);
        //}, 'json');
    });

    $('#resultados').on('click', '#btnUpdateMarca', function () {

        var urlAPI = 'http://localhost:52673/api/Marcas';
        var idMarca = $(this).attr('data-id');
        var nuevaMarca = $('#txtNuevaMarca').val();

        var dataMarcaAModificar = {
            denominacion: nuevaMarca
        };

        $.ajax({
            url: urlAPI + '/' + idMarca,
            type: "PUT",
            dataType: 'json',
            data: dataMarcaAModificar,
            success: function (respuesta) {
                getMarcas();
                console.log(respuesta);
            },
            error: function (respuesta) {
                //debugger;
                console.log(respuesta);
            }
        });
    });

    
    getMarcas();

});

