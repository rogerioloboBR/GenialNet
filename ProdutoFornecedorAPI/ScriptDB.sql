CREATE DATABASE GenialNetDbTesteBackEnd;
GO

USE GenialNetDbTesteBackEnd;
GO

CREATE TABLE Fornecedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    CNPJ NVARCHAR(20) NOT NULL,
    Cep NVARCHAR(10) NOT NULL,
    Endereco NVARCHAR(200) NOT NULL,
    Telefone NVARCHAR(15) NOT NULL,
    CONSTRAINT UQ_CNPJ UNIQUE (CNPJ)
);
GO

CREATE TABLE Produtos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descricao NVARCHAR(100) NOT NULL,
    Marca NVARCHAR(50) NOT NULL,
    UnidadeMedida NVARCHAR(20) NOT NULL,
    FornecedorId INT NOT NULL,
    CONSTRAINT UQ_Descricao UNIQUE (Descricao),
    CONSTRAINT FK_Produtos_Fornecedores FOREIGN KEY (FornecedorId) REFERENCES Fornecedores(Id)
);
GO

INSERT INTO Fornecedores (Nome, CNPJ, Cep, Endereco, Telefone)
VALUES ('Fornecedor A', '00.000.000/0000-00', '01001-000', 'Praça da Sé, Sé, São Paulo - SP', '(00) 0000-0000'),
       ('Fornecedor B', '11.111.111/1111-11', '20040-010', 'Praça Pio X, Centro, Rio de Janeiro - RJ', '(11) 1111-1111');
GO

INSERT INTO Produtos (Descricao, Marca, UnidadeMedida, FornecedorId)
VALUES ('Produto A', 'Marca A', 'Unidade', 1),
       ('Produto B', 'Marca B', 'Quilograma', 2);
GO