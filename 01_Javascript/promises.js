let promise = new Promise( (resolve, reject) => {
    //como exemplo, criaremos um numero aleatorio entre 0 e 1
    let x = Math.random(); // ]0, 1[
    if (x > 0.5){
        resolve("Valor aceitável: " + x);
    } else {
        reject("VALOR INVÁLIDO!!! " + x )
    }
} );

promise
    .then( s => console.log(s) )
    .catch( erro => console.error(erro) );