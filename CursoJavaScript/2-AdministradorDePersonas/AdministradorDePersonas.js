var AdministradorDePersonas = function () {
    var btn_crear_persona = $('#btn_crear_persona');
    btn_crear_persona.click(this.crearPersona);
};

AdministradorDePersonas.prototype.crearPersona = function () {
    var txt_nombre = $('#txt_nombre');
    var lista_de_personas = $('#lista_de_personas');

    var una_vista_de_persona = new VistaDePersona(txt_nombre.val());
    una_vista_de_persona.dibujarEn(lista_de_personas);
};