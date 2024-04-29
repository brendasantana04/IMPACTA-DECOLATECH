//lista de nomes
let nomes = ['Jonas', 'João', 'Denis', 'Daniela', 'Ana Paula', 'Luciana'];
let resposta1 = nomes.filter(item => item.endsWith('a'));
console.log(resposta1);

let pessoa = {
    nome: 'Jose',
    idade: 23
};

let pessoas = [
    {
        nome: 'Ana Paula',
        idade: 32
    },
    {
        nome: 'José Bonifácio',
        idade: 45
    },
    {
        nome: 'Pradilina Soares',
        idade: 30
    },
    pessoa
] ;
console.log(pessoas);

//definindo um objeto "complexo"
let empresa = {
    descricao: 'Avanade',
    cursos: ['Angular', 'Java', '.NET'],
    funcionarios: pessoas
};

console.log(empresa);

//efetuando buscas na lista de pessoas
let lista = pessoas.filter(p => p.idade <= 30);
console.log(lista);