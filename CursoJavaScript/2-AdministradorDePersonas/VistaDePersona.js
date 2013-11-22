var VistaDePersona = function (un_nombre) {
    this.ui = $('#plantillas .vista_de_persona').clone();
    this.nombre = un_nombre;
    this.label_nombre = this.ui.find('#nombre');
    this.label_nombre.text(un_nombre);
    this.btn_eliminar = this.ui.find('#btn_eliminar');
    var _this = this;
    this.btn_eliminar.click(function () {
        _this.eliminar();
    });
};

VistaDePersona.prototype.eliminar = function () {
    var _this = this;
    $.ajax({
        url: "http://localhost:1337/QuitarPersona",
        type: "POST",
        data: JSON.stringify({ nombre: this.nombre }),       
        success: function (respuestaJson) {
            _this.ui.remove();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error, no se eliminó la persona");
        }
    });
};

VistaDePersona.prototype.dibujarEn = function (un_div) {
    un_div.append(this.ui);
};