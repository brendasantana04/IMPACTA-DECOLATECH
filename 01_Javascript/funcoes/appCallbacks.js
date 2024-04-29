exports.executar = function (callback) {
    return callback('Impacta - Avanade');
}

exports.buscar = function (lista, callback) {
    let sublista = [];

    //vamos executar  uma iteração sobre os elementos da lista
    for (let index = 0; index < array.length; index++) {
        if(callback(lista[index])){
            sublista.push(lista[index]);
        }
    }
    return sublista;
}