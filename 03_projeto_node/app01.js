let moment = require('moment');
moment.locale('pt-br');

let now = moment();
console.log(now); 
console.log(now.format("DD/MM/yyyy - dddd (MMMM)"));
