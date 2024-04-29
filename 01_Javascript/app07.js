// variaveis
let pessoa = {
    nome: 'Jose',
    idade: 23
};

let pessoas = [
    {nome: 'Ana Paula', idade: 32},
    {nome: 'José Bonifácio', idade: 45},
    {nome: 'Pradilina Soares', idade: 30},
    pessoa
];

//funcao map
let lista = pessoas.map((item, index) => {
    return item.nome + " - " + item.idade;
});

console.log(lista);

lista = pessoas.map((item, index) => {
    return { 
        posicao: index, 
        aluno: item.pessoa
    };
});

console.log(lista);


//callback com tres parametro
lista = pessoas.map((item, index, arr) => {
    if(item.nome == arr[0].nome){
        return{
            posicao: index,
            nome: item.nome,
            idade: item.idade
        }
    } else {
        return `Nome diferente na posição ${index}, diferente de ${arr[0].nome}`;
    }
});

console.log(lista);