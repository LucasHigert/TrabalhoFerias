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


INSERT INTO categorias (nome) VALUES ('heloisa');