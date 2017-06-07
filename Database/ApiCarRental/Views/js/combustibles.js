$(document).ready(
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
);