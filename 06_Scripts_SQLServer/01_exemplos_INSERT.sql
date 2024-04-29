USE DB_MYRH
GO

/*
	Exemplo de uso do comando INSERT para inserir dados nas tabelas do DB_MYRH
*/

--TB_AREAS
INSERT INTO TB_AREAS(DESCRICAO) VALUES ('Web Front End');
INSERT INTO TB_AREAS(DESCRICAO) VALUES ('Back End');
INSERT INTO TB_AREAS(DESCRICAO) VALUES
('Tecnologia da Informação'),
('Financeiro'),
('Saúde'),
('Recursos Humanos');

SELECT * FROM TB_AREAS;
 
--TB_CANDIDADOS
INSERT INTO TB_CANDIDATOS(CPF, NOME, TELEFONE, EMAIL) VALUES('10290019822', 'Matilde da Silva', '11999901234', 'matilde@email.com.br');
INSERT INTO TB_CANDIDATOS(CPF, NOME, TELEFONE, EMAIL) VALUES('01928374656', 'José Antônio', '11988990123', 'joseantonio@email.com.br');
INSERT INTO TB_CANDIDATOS(CPF, NOME, TELEFONE, EMAIL) VALUES('35592039872', 'Antonieta de Castro', '1174002281', 'antonieta@email.com.br');

--Tabela TB_CARGOS
INSERT INTO TB_CARGOS (ID_AREA, DESCRICAO, SALARIO, TP_SALARIO) VALUES
(1, 'Programador Junior HTML, CSS e Javascript', 3800, 1),
(1, 'Programador Angular Pleno', 6000, 1),
(5, 'Enfermeiro Chefe', 7000, 1),
(5, 'Instrumentador', 100, 2)

--Tabela TB_CANDIDATOS
INSERT INTO TB_CANDIDATOS (CPF, NOME, TELEFONE, EMAIL) VALUES
('40417734077', 'Eliel Matoso', '3266-6000', 'elie@gmail.com'),
('05519598002', 'Vivaneide Rocha', '99587-1234', 'viva@neide.com'),
('49227828001', 'Pradilina Codonilha Santos', '98731-8371', 'pradilina@avanade.com')

--Tabela TB_INSCRICOES
INSERT INTO TB_INSCRICOES (ID_CARGO, CPF, DATA_EFETIVACAO) VALUES
(1, '40417734077', GETDATE()),
(3, '49227828001', '2024-04-24'),
(1, '05519598002', '2024-04-19'),
