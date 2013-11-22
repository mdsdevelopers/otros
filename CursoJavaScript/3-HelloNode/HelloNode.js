var http = require('http');

var servidor = http.createServer(function (req, res) {
    res.write('Hello World\n');
    res.end();
});

servidor.listen(1337, '127.0.0.1');

console.log('Arrancó la cosa');