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
	numero_habitantes INT
	);

INSERT INTO cidades
(id_estado, nome, numero_habitantes)
OUTPUT INSERTED.ID VALUES
('2', 'helo', '2')

SELECT cidades.id AS 'id',
                                    cidades.nome AS 'nome',
                                    cidades.id_estado AS 'id_estado',
                                    cidades.numero_habitantes AS 'numero_habitantes',
                                    estados.id AS 'idEstado',
                                    estados.nome AS 'nome_estado',
                                    estados.sigla AS 'sigla' FROM cidades
                             INNER JOIN estados ON (cidades.id_estado = estados.id)