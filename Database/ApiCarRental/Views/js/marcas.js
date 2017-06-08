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
};


$('#btnAddMarca').click(function () {
    //debugger;
    var nuevaMarca = $('#txtMarcaDenominacion').val();
    var urlAPI = 'http://localhost:52673/api/Marcas';
    var dataNuevaMarca = {
        id: 0,
        denominacion: nuevaMarca
    };
    //debugger;

    //$.ajax({
    //    url: urlAPI,
    //    type: "POST",
    //    dataType: 'json',
    //    data: dataNuevaMarca,
    //    success: function (respuesta) {
    //        //debugger;
    //        console.log(respuesta);
    //    },
    //    error: function (respuesta) {
    //        //debugger;
    //        console.log(respuesta);
    //    }
    //});
    // equivalente a la llamada $.post siguiente:

    $.post(urlAPI, dataNuevaMarca, function (respuesta) {
        console.log(respuesta);
    }, 'json');
});

