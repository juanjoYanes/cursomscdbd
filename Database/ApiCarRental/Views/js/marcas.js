$(document).ready(
    function getMarcas() {
        var urlAPI = 'http://localhost:52673/api/Marcas';

        $.get(urlAPI, function (respuesta, estado) {
            if (estado === 'success') {
                var listaMarcas = '<ul class="listadoMarcas">';
                $.each(respuesta.data, function (indice, elemento) {
                    listaMarcas += '<li>' + elemento.denominacion + '</li>';
                });
                listaMarcas += '</ul>';
                $('#listaMarcas').append(listaMarcas);
            }
        })
    }
);