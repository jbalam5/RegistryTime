
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
email nvarchar(25) null,
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
dateTimeRecord DATETIME null, 
dateOnlyRecord DATE null,
timeOnlyRecord TIME null,
turn NVARCHAR(20) null,
Type NVARCHAR(25) null,
diffhours TIME null,
totalhoursTurn TIME null,
machineNumber int null
--CONSTRAINT FK_checkInHours_idEmployee FOREIGN KEY (idEmployee)     
  --  REFERENCES users(id)     
    --ON DELETE NO ACTION    
    --ON UPDATE NO ACTION
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

INSERT INTO [dbo].[ModelReader]([brand],[model],[_registry]) VALUES('ZKTeco','z629C',1);

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

---TABLA PARA CONTROLAR LOS REGISTROS VALIDOS 
CREATE TABLE timeOutCheck
(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
name nvarchar(25),
description nvarchar(max),
timeCheck time
)
insert into timeOutCheck(_registry,dateInsert,name,description,timeCheck) values(1,GETDATE(),'checkin', 'tiempo de espera para registros validos','00:30:00')



----- procedimiento de progracion
create procedure  dbo.sp_migrar_check @date1 date , @date2 date 
as begin
	--DECLARE @date1 date = '2017-01-20', @date2 date = '2017-02-28'
	--DECLARACION DE VARIABLES
	DECLARE @COUNT INT, @ID INT, @IDUSER INT
	DECLARE @CHECKISVALID TIME
	DECLARE @DATETIMERECORD DATETIME
	DECLARE @DATEONLYRECORD DATE
	DECLARE @TIMEONLYRECORD TIME
	DECLARE @TURNO NVARCHAR(20)
	--DECLARE @TIPO NVARCHAR(25)
	DECLARE @TIMEENTRY TIME, @STARTENTRY TIME, @LIMITENTRY TIME, @DEPARTURETIME TIME, @LIMITDEPARTURE TIME, @HOURSJORNADA TIME
	DECLARE @TIPOCHECK NVARCHAR(25)
	DECLARE @DIFFHOURSEXIT TIME, @DIFFHOURSENTRY TIME
	DECLARE @VERIFICATION1 INT, @VERIFICATION2 INT, @COUNVALI INT
	DECLARE @TIMERECORD TIME, @TOTALHOURSTURN TIME, @TIMEENTRYTURN TIME
	--TIEMPO TIME OUT PARA VERIFICAR SI REGISTRO ES VALIDO
	SELECT @CHECKISVALID = timeCheck from timeOutCheck where _registry = 1 and name='checkin' 
	--CREAR TABLAS TEMPORAL PARA ALMACENAR DATOS
	CREATE TABLE #TMPTURNOCHECK (ID INT IDENTITY(1,1), IDUSER INT, DATETIMERECORD DATETIME, DATEONLYRECORD DATE,TIMEONLYRECORD TIME,TURNO NVARCHAR(20))
	--RANGO DE FECHA PARA VERIFICAR REGISTRO
	select id as idn, idUser,dateTimeRecord, dateOnlyRecord,timeOnlyRecord, _registry INTO #TMPGLOBAL from HoursAssistance where dateOnlyRecord between @date1 and @date2
	
	INSERT INTO #TMPTURNOCHECK SELECT TG.idUser, Tg.dateTimeRecord,TG.dateOnlyRecord, TG.timeOnlyRecord ,isnull((SELECT top 1 name FROM turn as TT WHERE Convert(datetime, TT.timeEntry) <= Convert(datetime,TG.timeOnlyRecord) and Convert(datetime,TG.timeOnlyRecord) <= (Convert(datetime, TT.hoursJornada) + Convert(datetime, TT.timeEntry)) and  TT._registry = 1 ),'NINGUNO') AS turno FROM #TMPGLOBAL as TG

	--OBTENER TOTAL DE REGISTROS DEL RANGO DE DATOS
	SET @COUNT = (SELECT count(*) AS T FROM #TMPTURNOCHECK)
	while @COUNT > 0
	begin
		SET @TOTALHOURSTURN = '00:00:00'
		--OBTENER EL PRIMER REGISTRO PARA VERIFICAR TIEMPOS
		SELECT TOP 1 @ID = TT.ID , @IDUSER= TT.idUser, @DATETIMERECORD = TT.dateTimeRecord, @DATEONLYRECORD = TT.dateOnlyRecord, @TIMEONLYRECORD = TT.timeOnlyRecord, @TURNO = TT.turno FROM #TMPTURNOCHECK AS TT
		--OBTENER LOS DATOS DEL TURNO INVOLUTRADO
		SELECT @TIMEENTRY = T.timeEntry, @STARTENTRY = T.startEntry, @LIMITENTRY = T.limitEntry, @DEPARTURETIME = T.departuretime, @LIMITDEPARTURE = T.limitDeparture, @HOURSJORNADA = T.hoursJornada FROM turn AS T WHERE T.name = @TURNO
		---VERIFICAR SI EXISTE UN REGISTRO CON LOS MISMO PARAETROS
		SELECT @VERIFICATION1 = COUNT(*) FROM checkInHours WHERE idEmployee = @IDUSER  and DATEONLYRECORD = @DATEONLYRECORD
		SELECT @COUNVALI = (count(*) %2) FROM checkInHours WHERE idEmployee = @IDUSER AND DATEONLYRECORD = @DATEONLYRECORD
		--VERIFICAR QUE TIPO DE ENTRADA ES
		IF @COUNVALI = 0
			BEGIN
				SET @TIPOCHECK = 'ENTRADA'
				IF CONVERT(datetime, @TIMEONLYRECORD) > CONVERT(datetime, @LIMITENTRY)
				BEGIN
					SET @DIFFHOURSENTRY = CONVERT(datetime, @TIMEONLYRECORD) - CONVERT(datetime, @LIMITENTRY)
				END
				ELSE
				BEGIN
					SET @DIFFHOURSENTRY = '00:00:00'
				END
			END
			ELSE
			BEGIN
				SET @TIPOCHECK = 'SALIDA'
				SELECT TOP 1 @TIMEENTRYTURN = TIMEONLYRECORD FROM (SELECT TOP 2 * FROM checkInHours AS TF WHERE TF.idEmployee = @IDUSER AND TF.DATEONLYRECORD = @DATEONLYRECORD AND TF.TURN = @TURNO ORDER BY TF.ID DESC ) TMP ORDER BY ID ASC
				SET @TOTALHOURSTURN = CONVERT(datetime, @TIMEONLYRECORD) - CONVERT(datetime, @TIMEENTRYTURN)
				IF CONVERT(datetime, @TIMEONLYRECORD) > CONVERT(datetime, @LIMITDEPARTURE)
				BEGIN
					SET @DIFFHOURSENTRY = CONVERT(datetime, @TIMEONLYRECORD) - CONVERT(datetime, @LIMITDEPARTURE)
				END
				ELSE
				BEGIN
					SET @DIFFHOURSENTRY = '00:00:00'
				END
					
			END
		IF (@VERIFICATION1 > 0)
		begin
			SELECT @TIMERECORD  = TIMEONLYRECORD  FROM checkInHours WHERE idEmployee = @IDUSER  and DATEONLYRECORD = @DATEONLYRECORD ORDER BY ID DESC
			IF( (CONVERT(datetime, @TIMERECORD )+CONVERT(datetime,@CHECKISVALID)) < CONVERT(datetime,@TIMEONLYRECORD))
			begin
				INSERT INTO checkInHours(_registry,idUserInsert,dateInsert,machineNumber,idEmployee, DATETIMERECORD, DATEONLYRECORD ,TIMEONLYRECORD ,TURN ,type,DIFFHOURS,TOTALHOURSTURN) VALUES(1,1,getdate(),1,@IDUSER,@DATETIMERECORD, @DATEONLYRECORD, @TIMEONLYRECORD, @TURNO,@TIPOCHECK, @DIFFHOURSENTRY, @TOTALHOURSTURN)
			end
		end
		ELSE
		BEGIN
			INSERT INTO checkInHours(_registry,idUserInsert,dateInsert,machineNumber,idEmployee, DATETIMERECORD, DATEONLYRECORD ,TIMEONLYRECORD ,TURN ,type,DIFFHOURS,TOTALHOURSTURN) VALUES(1,1,getdate(),1,@IDUSER,@DATETIMERECORD, @DATEONLYRECORD, @TIMEONLYRECORD, @TURNO,@TIPOCHECK, @DIFFHOURSENTRY, @TOTALHOURSTURN)
		END
		
		--ELIMINAR EL REGISTRO VERIFICADO
		DELETE FROM #TMPTURNOCHECK WHERE ID = @ID
		--VERIFICAR NUEVAMENTE EL NUMERO DE REGISTRO DE LA TEMPORAL
		SET @COUNT = ( SELECT COUNT(*) FROM #TMPTURNOCHECK)
	end

	SELECT * FROM checkInHours
	--ELIMINAR TABLAS TEMPORALES
	DROP TABLE #TMPGLOBAL
	DROP TABLE #TMPTURNOCHECK
end

--HISTORIAL DE MIGRACION DE LECTOR
create table MigrationHistory(
_registry int,
idUserInsert int,
dateInsert datetime,
idUserUpdate int, 
dateUpdate datetime,
idUserDelete int,
dateDelete datetime,
id int primary key identity(1,1) not null,
dateStart datetime null,
dateEnd datetime null
)
--Entorno de pruebas
INSERT INTO MigrationHistory(_registry, idUserInsert,dateInsert,dateStart,dateEnd) VALUES(1,1,GETDATE(),'2017-01-01','2017-01-01')
--INSERT INTO MigrationHistory(_registry, idUserInsert,dateInsert,dateStart,dateEnd) VALUES(1,1,GETDATE(),GETDATE(),GETDATE())

