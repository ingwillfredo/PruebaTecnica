Create Database DB_Recargas

Create table Vendedor(
Id_Vendedor Int primary key identity,
nombre_Vendedor Varchar(150),
Email_Vendedor Varchar(150),
Direcion_Vendedor Varchar(150),
Telefono_Vendedor Varchar(10),
Documento_Vendedor Varchar(15),
Estado_Vendedor Int
);

Insert into Vendedor 
Values
('Pedro Perez', 'pepe@gmail.com', 'Calle 15 # 20-35', '3101112233', '1000123645', 1),
('Sandra Gomez', 'sago@gmail.com', 'Calle 20 # 15-35', '3102223344', '1002065321', 1),
('Jenny Ruiz', 'jeru@gmail.com', 'Calle 12 # 32-55', '3103334455', '1006578945', 1),
('Mario Moreno', 'marmo@gmail.com', 'Calle 19 # 18-96', '3104445566', '1009865324', 1);

Create table Operador(
Id_Operador Int primary key identity,
nombre_Operador Varchar(150),
Estado_Operador Int
);

Insert into Operador 
Values
('TIGO', 1),
('MOVISTAR', 1),
('COMCEL', 1),
('UFF', 1);

Create table Recarga(
Id_Recarga Int primary key identity,
Id_Vendedor Int,
Id_Operador Int,
Numero_Celular varchar(10),
Valor int,
Fecha DateTime,
Foreign Key (Id_Vendedor) References Vendedor(Id_Vendedor),
Foreign Key (Id_Operador) References Operador(Id_Operador)
);

Create Procedure AgregaRecarga 
@Id_Vendedor int,
@Id_Operador int,
@Numero_Celular Varchar(10),
@Valor int
AS

Insert into Recarga
Values
(@Id_Vendedor, @Id_Operador, @Numero_Celular, @Valor, GETDATE());

Declare @Result Varchar(50);
Set @Result = 'Ejecutado';
Select @Result;

Exec AgregaRecarga 1, 2, '3156391777', 15000;


Create Procedure VentasPorOperador
@Id_Operador int
AS

Select Count(Id_Operador) AS Cantidad, SUM(Valor) AS Ventas_Total
From  Recarga
Where Id_Operador = @Id_Operador


Create Procedure Listavendedores
AS

Select Id_Vendedor, nombre_Vendedor
From Vendedor;

Create Procedure ListaOperadores
AS

Select Id_Operador, nombre_Operador
From Operador;
