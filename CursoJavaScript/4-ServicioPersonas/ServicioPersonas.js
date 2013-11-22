    var http = require('http');

    var personas = [
        { nombre: 'Fer' },
        { nombre: 'Javi' },
        { nombre: 'Agus' },
        { nombre: 'Zambri' },
        { nombre: 'Jorge' }
    ];

    var RequestHelper = {
        recibirPostData: function (req, al_terminar) {
            var datos_recibidos = '';
            req.on('data', function (chunk) {
                datos_recibidos += chunk;
            });

            req.on('end', function () {
                console.log(datos_recibidos);
                al_terminar(JSON.parse(datos_recibidos));
            });
        }
    };

    var servidor = http.createServer(function (req, res) {
        res.writeHead(200, {
            'Content-Type': 'text/html;charset=UTF-8',
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'GET, POST'
        });
        if (req.url.indexOf('GetPersonas') > 0) {
            res.write(JSON.stringify(personas));
            res.end();
        }
        if (req.url.indexOf('CrearPersona') > 0) {
            RequestHelper.recibirPostData(req, function (persona) {
                personas.push(persona);
                res.end();
            });
        }
        if (req.url.indexOf('QuitarPersona') > 0) {
            RequestHelper.recibirPostData(req, function (persona) {
                var index_persona = -1;
                for (var i = 0; i < personas.length; i++) {
                    if (personas[i].nombre == persona.nombre) { index_persona = i }
                }
                if (index_persona > -1) {
                    personas.splice(index_persona, 1);
                }
                res.end();
            });     
        }
    });

    servidor.listen(1337, '127.0.0.1');

    console.log('Arranco la cosa');