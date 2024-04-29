//consumindo as funcoes definidas em appFuncoes.js

let fn = require('./funcoes/appFuncoes');

// let soma1 = fn.somar(20, 25);
// console.log(`soma1 = ${soma}`);

let maior1 = fn.buscarMaior(3, 5);
let maior2 = fn.buscarMaior(-10);

console.log(`maior1 = ${maior1}`);
console.log(`maior2 = ${maior2}`);
