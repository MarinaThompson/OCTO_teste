# OCTO_teste

## Script de criação da tabela ClientePessoaFisica:
CREATE TABLE ClientePessoaFisica ( /n
	ID int IDENTITY(1,1) PRIMARY KEY, /n
	[Nome] [varchar](55) NOT NULL, /n
	[Profissao] [varchar](100) NOT NULL, /n
	[EstadoCivil] [varchar](100) NOT NULL, /n
	[RG] [varchar](10) NOT NULL, /n
	[CPF] [varchar](11) NOT NULL, /n
	[DataNascimento] [date] NOT NULL) /n
  
  ## Script de criação da tabela ClientePessoaJurídica:
  CREATE TABLE ClientePessoaJuridica (
	ID int IDENTITY(1,1) PRIMARY KEY,
	[NomeFantasia] [varchar](100) NOT NULL,
	[RazaoSocial] [varchar](100) NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[DataAbertura] [date] NOT NULL)
  
  ## Script de criação da tabela Endereço:
  CREATE TABLE Enderecos (
  ID int IDENTITY(1,1) PRIMARY KEY,
  [TipoEndereco] [varchar](50) NOT NULL,
	[Rua] [varchar](50) NOT NULL,
	[CEP] [varchar](8)NOT NULL,
	[Numero] [int] NOT NULL,
	[Bairro] [varchar](20) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Estado] [varchar](25) NOT NULL,
	[PessoaFisicaID] [int] FOREIGN KEY REFERENCES ClientePessoaFisica(ID),
	[PessoaJuridicaID] [int] FOREIGN KEY REFERENCES ClientePessoaJuridica(ID))
  
  ## Script de criação da tabela Endereço:
  CREATE TABLE Contatos (
	ID int IDENTITY(1,1) PRIMARY KEY, 
	[TipoContato] [varchar](20) NOT NULL,
	[Numero] [varchar](11) NOT NULL, 
	[PessoaFisicaID] [int] FOREIGN KEY REFERENCES ClientePessoaFisica(ID),
	[PessoaJuridicaID] [int] FOREIGN KEY REFERENCES ClientePessoaJuridica(ID))

