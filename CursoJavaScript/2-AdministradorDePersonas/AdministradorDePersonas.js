var AdministradorDePersonas = function () {
    var btn_crear_persona = $('#btn_crear_persona');
    btn_crear_persona.click(this.crearPersona);
    var _this = this;
    $.ajax({
        url: "http://localhost:1337/GetPersonas",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson);
            _this.cargarPersonas(respuesta);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("respuesta con error:", errorThrown);
        }
    });
};

AdministradorDePersonas.prototype.cargarPersonas = function (personas) {
    var lista_de_personas = $('#lista_de_personas');
    for (var i = 0; i < personas.length; i++) {
        var una_vista_de_persona = new VistaDePersona(personas[i].nombre);
        una_vista_de_persona.dibujarEn(lista_de_personas);
    }    
};

AdministradorDePersonas.prototype.crearPersona = function () {
    var txt_nombre = $('#txt_nombre');
    var lista_de_personas = $('#lista_de_personas');

    $.ajax({
        url: "http://localhost:1337/CrearPersona",
        type: "POST",
        data: JSON.stringify({ nombre: txt_nombre.val()}),
        success: function (respuestaJson) {
            var una_vista_de_persona = new VistaDePersona(txt_nombre.val());
            una_vista_de_persona.dibujarEn(lista_de_personas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error, no se agregó la persona");
        }
    });
};