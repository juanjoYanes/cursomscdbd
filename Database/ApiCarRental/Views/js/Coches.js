$(document).ready(
    function getMarcas() {
        var urlAPI = 'http://localhost:52673/api/Coches';

        $.get(urlAPI, function (respuesta, estado) {
            if (estado === 'success') {
                var listaCoches = '<ul class="listadoCoches">';
                $.each(respuesta.data, function (indice, elemento) {
                    listaCoches += '<li>(' + elemento.marca.denominacion;
                    listaCoches += ') ' + elemento.matricula + '</li>';
                });
                listaCoches += '</ul>';
                $('#listaCoches').append(listaCoches);
            }
        })
    }
);