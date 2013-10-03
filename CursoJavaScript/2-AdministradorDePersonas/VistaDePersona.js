var VistaDePersona = function (un_nombre) {
    this.ui = $('#plantillas .vista_de_persona').clone();
    this.nombre = this.ui.find('#nombre');
    this.nombre.text(un_nombre);
    this.btn_eliminar = this.ui.find('#btn_eliminar');
    var _this = this;
    this.btn_eliminar.click(function () {
        _this.eliminar();
    });
};

VistaDePersona.prototype.eliminar = function () {
    this.ui.remove();
};

VistaDePersona.prototype.dibujarEn = function (un_div) {
    un_div.append(this.ui);
};