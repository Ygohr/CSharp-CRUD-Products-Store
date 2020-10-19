create database DbCrudProduto

use DbCrudProduto

create table Produto (
	id			int identity(1,1) primary key,
	nome		varchar(100),
	quantidade	int,
	preco		float,
	idPromocao	int null
)

create table Promocao (
	idPromocao	int identity(1,1) primary key,
	descricao	varchar(100)
)

alter table Produto add foreign key (idPromocao) references Promocao(idPromocao)

insert into Promocao 
select 'Leve 2 e Pague 1' union all
select '3 por R$ 10,00' union all
select 'N/D' 

insert into Produto
select
	'Garrafa Térmica',
	'2',
	'10',
	1