
function getTiposCombustible() {
    var urlAPI = 'http://localhost:52673/api/TipoCombustibles';

    $.get(urlAPI, function (respuesta, estado) {
        if (estado === 'success') {
            var listaTiposCombustibles = '<ul class="listadoTiposCombustibles">';
            $.each(respuesta.data, function (indice, elemento) {
                listaTiposCombustibles += '<li>' + elemento.denominacion + '</li>';
            });
            listaTiposCombustibles += '</ul>';
            $('#listaTiposCombustible').append(listaTiposCombustibles);
        }
    })
}

$("#btnAddTipoCombustible").click(function () {
    debugger
    var nuevoTipoCombustible = $('#btnAddTipoCombustible').val();
    var urlAPI = 'http://localhost:52673/api/TipoCombustibles';
    var dataNuevoTipoCombustible = {
        id: 0,
        denominacion: nuevoTipoCombustible
    }

    $.ajax({
        url: urlAPI,
        type: 'POST',
        dataType: 'json',
        data: dataNuevoTipoCombustible,
        success: function (respuesta) {
            console.log(respuesta);
        },
        error: function (respuesta) {
            console.log(respuesta);
        }
    });

});