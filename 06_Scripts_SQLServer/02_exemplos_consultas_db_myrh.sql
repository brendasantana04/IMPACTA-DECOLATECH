-- Consultas na TB_AREAS
-- Todos os registros
SELECT * FROM TB_AREAS;
 
--Buscando a descrição de todas as áreas
SELECT DESCRICAO FROM TB_AREAS;
 
-- Consultas na TB_CANDIDATOS
-- Todos os registros
SELECT * FROM TB_CANDIDATOS;
 
-- Consultas na TB_CARGOS
-- Todos os registros

SELECT * FROM TB_CARGOS;
 
-- Consultas na TB_CARGOS
-- Todos os registros
SELECT * FROM TB_INSCRICOES;

--2. buscando a descricao de todas as areas
SELECT DESCRICAO FROM TB_AREAS
SELECT DISTINCT DESCRICAO FROM TB_AREAS
SELECT DISTINCT ID, DESCRICAO FROM TB_AREAS

--3. Buscando uma area com base no id informado
SELECT * FROM TB_AREAS WHERE ID = 3

SELECT * FROM TB_AREAS WHERE ID > 2

SELECT * FROM TB_AREAS WHERE ID > 2 AND ID <> 4

--buscando todas as areas cuja descricao inicie com a palavra 'tec'
SELECT * FROM TB_AREAS WHERE DESCRICAO LIKE 'TEC%'

SELECT * FROM TB_AREAS WHERE DESCRICAO = 'TEC%'