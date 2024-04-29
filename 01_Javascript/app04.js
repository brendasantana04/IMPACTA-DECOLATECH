//fazendo referencia a funcao
let fn = require('./funcoes/appCallbacks');

//trabalhando com a função executar
//exemplo 01
let res1 = fn.executar(function (item){
    return item.length; //number
});
console.log(res1);

//exemplo02
let res2 = fn.executar(function (item) {
    return item == 'Avanade'; //boolean
});
console.log(res2);

//exemplo03
let res3 = fn.executar(function (item) {
    return item.toUpperCase(); //string
});
console.log(res3);

//exemplo04
let res4 = fn.executar(function (item) {
    return [item.length, item == 'Avanade', item.toUpperCase()]; //array
});
console.log(res4);