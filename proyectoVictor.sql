
use registryTime
go 
create table users(
id int primary key identity(1,1) not null,
userName nvarchar(25) not null,
password nvarchar(25) not null,
rol int not null,
image nvarchar(max),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table statusBook(
id int primary key identity(1,1) not null,
name nvarchar(25) not null,
type nvarchar(25) not null,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)

GO

INSERT INTO [dbo].[statusBook]([name],[type]) VALUES('Activo','Dato')
INSERT INTO [dbo].[statusBook]([name],[type]) VALUES('Inactivo','Dato')
           
GO

insert into [registryTime].[dbo].[users](userName, password, rol,_registry,dateInsert) values('ADMIN','ADMIN',1,1,getDate())
insert into [registryTime].[dbo].[users](userName, password, rol,_registry,dateInsert) values('INVITADO','INVITADO',2,1,getDate())
go
create table role(
id int primary key identity(1,1) not null,
name nvarchar(25) not null,
description nvarchar(max),
_registry int,
idUserinsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
INSERT INTO [dbo].[role]([name],[description]) VALUES('ADMIN','USUARIO PARA CONFIGURACION')
INSERT INTO [dbo].[role]([name],[description]) VALUES('CAPTURA','USUARIO PARA CAPTURA DE HORA')

go
create table job (
id int primary key identity(1,1) not null,
name nvarchar(50) not null,
description nvarchar(250),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table departament (
id int primary key identity(1,1) not null,
name nvarchar(50) not null,
manager nvarchar(50) not null,
description nvarchar(250),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)

go
create table employee(
id int primary key identity(1,1) not null,
rfc nvarchar(25),
curp nvarchar(25),
name nvarchar(50) not null,
lastname nvarchar(50) not null,
scholarship nvarchar(50),
birthdate date null,
gender nvarchar(10)null,
nationality nvarchar(25) null,
address nvarchar(100) null,
municipality nvarchar(100) null,
country nvarchar(50) null,
email nvarchar(50) null,
civilStatus  nvarchar(20) null,
colony nvarchar(50) null,
stateCountry nvarchar(50) null,
postalCode int null,
controlNumber nvarchar(max),
sureType nvarchar(25),
idJob int not null,
idDepartament int not null,
idUser int not null,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_employee_idUser FOREIGN KEY (idUser)     
    REFERENCES users (id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_employee_idDepartament FOREIGN KEY (idDepartament)     
    REFERENCES Departament(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_employee_idJob FOREIGN KEY (idJob)     
    REFERENCES job (id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)
go
create table festive(
id int primary key identity(1,1) not null,
date date not null,
name nvarchar(50) not null,
typeJob int,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_festive_typeJob FOREIGN KEY (typeJob)     
    REFERENCES job(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)
go
create table absenteeism(
id int primary key identity(1,1) not null,
isKey nvarchar(5) not null,
concept nvarchar(50) not null,
description nvarchar(max),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table turn(
id int primary key identity(1,1) not null,
name nvarchar(50) not null,
startTime time not null,
endTime time not null,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table days(
id int primary key identity(1,1) not null,
name nvarchar(10),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table daysOfTurn(
id int primary key identity(1,1) not null,
idDays int,
idTurn int,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_daysOfTurn_idTurn FOREIGN KEY (idTurn)     
    REFERENCES turn(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_daysOfTurn_idDays FOREIGN KEY (idDays)     
    REFERENCES days(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
)
go
create table turnsOfEmployee(
id int primary key identity(1,1) not null,
idTurn int,
idEmployee int,
observation nvarchar(max),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_turnsOfEmployee_idTurn FOREIGN KEY (idTurn)     
    REFERENCES turn(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_turnsOfEmployee_idEmployee FOREIGN KEY (idEmployee)     
    REFERENCES employee(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)
go
create table company(
id int primary key identity(1,1) not null,
rfc nvarchar(25),
businessName nvarchar(50),
street nvarchar(10),
musicipality nvarchar(25),
state nvarchar(25),
country nvarchar(25),
email nvarchar(25),
poltalCode nvarchar(5),
telephone nvarchar(25),
image nvarchar(10),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table permission(
id int primary key identity(1,1) not null,
name nvarchar(25),
type nvarchar(20),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)
go
create table permissionsOfUser(
id int primary key identity(1,1) not null,
idUser int not null,
idPermission int not null,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_permissionsOfUser_idPermission FOREIGN KEY (idPermission)     
    REFERENCES users(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_permissionsOfUser_idUser FOREIGN KEY (idUser)     
    REFERENCES users(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)
go
create table checkInHours(
id int primary key identity(1,1) not null,
date datetime not null,
idEmployee int not null,
type nvarchar(10),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_checkInHours_idEmployee FOREIGN KEY (idEmployee)     
    REFERENCES users(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
)
go