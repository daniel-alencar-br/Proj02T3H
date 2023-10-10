
Create Table Clientes 
   (Codigo int not null Primary Key, 
    Nome varchar(50), 
	Endereco varchar(100))

Create Table Pedidos 
  (CodCliente Int Not Null, 
   CodPedido Int Not Null, 
   DataPedido DateTime, 
   Valor Numeric(10, 2))

Alter Table Pedidos Add Constraint 
   pkPed Primary Key (CodCliente, CodPedido)

Alter Table Pedidos Add Constraint 
   fkPed Foreign Key (CodCliente)
     References Clientes (Codigo)
