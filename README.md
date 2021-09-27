# Teste OCTO

## Script de criação da tabela ClientePessoaFisica:
CREATE TABLE ClientePessoaFisica ( <br />
	ID int IDENTITY(1,1) PRIMARY KEY, <br />
	[Nome] [varchar](55) NOT NULL, <br />
	[Profissao] [varchar](100) NOT NULL, <br />
	[EstadoCivil] [varchar](100) NOT NULL, <br />
	[RG] [varchar](10) NOT NULL, <br />
	[CPF] [varchar](11) NOT NULL, <br />
	[DataNascimento] [date] NOT NULL) <br />
  
  ## Script de criação da tabela ClientePessoaJurídica:
  CREATE TABLE ClientePessoaJuridica ( <br />
	ID int IDENTITY(1,1) PRIMARY KEY, <br />
	[NomeFantasia] [varchar](100) NOT NULL, <br />
	[RazaoSocial] [varchar](100) NOT NULL, <br />
	[CNPJ] [varchar](14) NOT NULL, <br />
	[DataAbertura] [date] NOT NULL) <br />
  
  ## Script de criação da tabela Endereço:
  CREATE TABLE Enderecos ( <br />
  ID int IDENTITY(1,1) PRIMARY KEY, <br />
  [TipoEndereco] [varchar](50) NOT NULL, <br />
	[Rua] [varchar](50) NOT NULL, <br />
	[CEP] [varchar](8)NOT NULL, <br />
	[Numero] [int] NOT NULL, <br />
	[Bairro] [varchar](20) NOT NULL, <br />
	[Cidade] [varchar](50) NOT NULL, <br />
	[Estado] [varchar](25) NOT NULL, <br />
	[PessoaFisicaID] [int] FOREIGN KEY REFERENCES ClientePessoaFisica(ID), <br />
	[PessoaJuridicaID] [int] FOREIGN KEY REFERENCES ClientePessoaJuridica(ID)) <br />
  
  ## Script de criação da tabela Contato:
  CREATE TABLE Contatos ( <br />
	ID int IDENTITY(1,1) PRIMARY KEY, <br />
	[TipoContato] [varchar](20) NOT NULL, <br />
	[Numero] [varchar](11) NOT NULL, <br />
	[PessoaFisicaID] [int] FOREIGN KEY REFERENCES ClientePessoaFisica(ID), <br />
	[PessoaJuridicaID] [int] FOREIGN KEY REFERENCES ClientePessoaJuridica(ID)) <br />

