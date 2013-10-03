//puede fallar
$(document).ready(function () {
    $('#chau').hide();
    $('#boton').click(invertirEstado);
});

var invertirEstado = function () {
    $('#hola').toggle();
    $('#chau').toggle();
};