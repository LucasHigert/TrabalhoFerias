CREATE TABLE usuarios (
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	logi VARCHAR(50),
	senha VARCHAR(50)
);

CREATE TABLE categorias (
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50)
);

CREATE TABLE estados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR (50),
	sigla VARCHAR (2)
	);

	CREATE TABLE cidades(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_estado INT,
	FOREIGN KEY(id_estado) REFERENCES estados(id),

	nome VARCHAR (50),
	cpf VARCHAR (50),
	data_nascimento DATETIME2(7),
	numero INT,
	complemento NCHAR(10),
	logradouro NCHAR(10),
	cep NCHAR(10)
	);


INSERT INTO estados (nome, sigla) VALUES ('heloisa', 'Sc');

SELECT cidades.id AS 'CidadeId'
FROM cidades INNER JOIN estados ON (cidades.id_estado=estados.id);

