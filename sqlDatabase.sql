
create table users(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
userName nvarchar(25) not null,
password nvarchar(max) not null,
rol int not null,
image nvarchar(max)
)

create table statusBook(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(25) not null,
type nvarchar(25) not null
)

INSERT INTO [dbo].[statusBook]([name],[type],[_registry],[dateInsert]) VALUES('Activo','Dato',1,getDate())
INSERT INTO [dbo].[statusBook]([name],[type],[_registry],[dateInsert]) VALUES('Inactivo','Dato',1,getDate())
           
create table role(
_registry int,
idUserinsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(25) not null,
description nvarchar(max)
)

INSERT INTO [dbo].[role]([name],[description],[_registry]) VALUES('ADMIN','USUARIO PARA CONFIGURACION',1)
INSERT INTO [dbo].[role]([name],[description],[_registry]) VALUES('CAPTURA','USUARIO PARA CAPTURA DE HORA',1)


create table job (
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(50) not null,
description nvarchar(250)
)

create table departament (
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(50) not null,
manager nvarchar(50) not null,
description nvarchar(250)
)


create table employee(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
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
telephone nvarchar(25) null,
civilStatus  nvarchar(20) null,
postalCode int null,
colony nvarchar(50) null,
stateCountry nvarchar(50) null,
controlNumber nvarchar(max),
idDepartament int not null,
sureType nvarchar(25) null,
numberSure nvarchar(25) null,
admissionDate date null,
idJob int not null,
salary decimal(10,2) null,
idUser int not null,
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

create table turn(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(50) not null,
description nvarchar(250),
timeEntry time not null,
startEntry time,
limitEntry time,
departuretime time not null,
limitDeparture time,
hoursJornada time
)

create table days(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(10),
)

insert into days(name,_registry) values('Lunes',1)
insert into days(name,_registry) values('Martes',1)
insert into days(name,_registry) values('Miercoles',1)
insert into days(name,_registry) values('Jueves',1)
insert into days(name,_registry) values('Viernes',1)
insert into days(name,_registry) values('Sabado',1)
insert into days(name,_registry) values('Domingo',1)

create table daysOfTurn(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
idDays int,
idTurn int,
CONSTRAINT FK_daysOfTurn_idTurn FOREIGN KEY (idTurn)     
    REFERENCES turn(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_daysOfTurn_idDays FOREIGN KEY (idDays)     
    REFERENCES days(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
)

create table daysOfWorkEmployee(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
idDays int,
idEmployee int,
CONSTRAINT FK_daysOfWorkEmployee_idEmployee FOREIGN KEY (idEmployee)     
    REFERENCES employee(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_daysOfWorkEmployee_idDays FOREIGN KEY (idDays)     
    REFERENCES days(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
)

create table turnsOfEmployee(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
idTurn int,
idEmployee int,
observation nvarchar(max),
CONSTRAINT FK_turnsOfEmployee_idTurn FOREIGN KEY (idTurn)     
    REFERENCES turn(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
CONSTRAINT FK_turnsOfEmployee_idEmployee FOREIGN KEY (idEmployee)     
    REFERENCES employee(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)

create table company(
id int primary key identity(1,1) not null,
rfc nvarchar(25),
businessName nvarchar(50),
street nvarchar(25),
municipality nvarchar(25),
state nvarchar(25),
country nvarchar(25),
email nvarchar(25),
postalCode nvarchar(5),
telephone nvarchar(25),
image nvarchar(50),
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)

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

create table AbsenteeismAssignment(
id int primary key identity(1,1) not null,
controlNumber nvarchar(max),
KeyAbsenteeism nvarchar(5) not null,
Description nvarchar(max),
Status nvarchar(30) not null,
DateStar datetime,
DateEnd datetime,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)

create table checkInHours(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
date datetime not null,
idEmployee int not null,
type nvarchar(10),
machineNumber int null,
CONSTRAINT FK_checkInHours_idEmployee FOREIGN KEY (idEmployee)     
    REFERENCES users(id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION,
)
-- Tablas para la configuracion del lector
create table ModelReader(
id int primary key identity(1,1) not null,
brand varchar(50) not null,
model varchar(50) not null,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
);

create table ReaderConnection(
id int primary key identity(1,1) not null,
name varchar(50) not null,
ip varchar(15) not null,
port varchar(5),
isDefault bit,
idReader int not null,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
CONSTRAINT FK_ReaderConnection_idReader FOREIGN KEY (idReader)     
    REFERENCES ModelReader (id)     
    ON DELETE NO ACTION    
    ON UPDATE NO ACTION
)

--TABLA PARA ALMACENAR LOS HORARIOS QUE DEVUELVE EL LECTOR

create table HoursAssistance(
id int primary key identity(1,1) not null,
machineNumer int,
idUser int,
verifyType int,
verifyState int,
workCode int,
dateTimeRecord datetime,
dateOnlyRecord date,
timeOnlyRecord time,
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime
)