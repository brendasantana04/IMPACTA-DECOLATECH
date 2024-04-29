function calcularSoma(valor1, valor2) {

}

exports.somar = calcularSoma;

//2. função anonima
exports.buscarMaior = function (a, b = 0) {
    if(typeof(a) != 'number' || typeof(b) != 'number'){
        throw new TypeError('Os parâmetros devem ser numéricos');
    }
    return a > b ? a : b;
}