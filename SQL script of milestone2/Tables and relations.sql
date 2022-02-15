create database Postgradoffice

go
use PostgradOffice

create table PostGradUser ( id int primary key identity,
email varchar(50),
password varchar(50));

create table Admin(
id int primary key,
foreign key (id) references PostGradUser on delete cascade on update cascade);

create table GucianStudent(id int PRIMARY KEY,
firstName varchar(50),
lastName varchar(50),
type varchar(50) ,
faculty varchar(50),
address varchar(100),
GPA decimal(10,5),
undergradID varchar(10),
foreign key (id) references PostGradUser on delete cascade on update cascade);

create table NonGucianStudent(id int PRIMARY KEY,
firstName varchar(50),
lastName varchar(50),
type varchar(50),
faculty varchar(50),
address varchar(100),
GPA decimal(10,5),
foreign key (id) references PostGradUser on delete cascade on update cascade);

create table GUCStudentPhoneNumber( id int,
phone varchar(20),
primary key(id ,phone),
FOREIGN KEY (id) references GucianStudent ON DELETE CASCADE on update cascade);


create table NonGUCStudentPhoneNumber( id int,
phone varchar(20),
primary key(id ,phone),
FOREIGN KEY (id) references NonGucianStudent ON DELETE CASCADE on update cascade);

create table AdminPhoneNumber( id int,
phone varchar(20),
primary key(id ,phone),
FOREIGN KEY (id) references Admin ON DELETE CASCADE on update cascade);

create table SupervisorPhoneNumber( id int,
phone varchar(20),
primary key(id ,phone),
FOREIGN KEY (id) references Admin ON DELETE CASCADE on update cascade);

create table ExaminerPhoneNumber( id int,
phone varchar(20),
primary key(id ,phone),
FOREIGN KEY (id) references Admin ON DELETE CASCADE on update cascade);


create table Course (id int PRIMARY KEY IDENTITY,
fees decimal(10,5),
creditHours int,
code varchar(50));

create table Supervisor (id int PRIMARY KEY, 
name varchar(100),
faculty varchar (50),
foreign key (id) references PostGradUser on delete cascade on update cascade);

create table Payment (id int PRIMARY KEY IDENTITY,
amount decimal(10,5),
no_Installments int, 
fundPercentage decimal(10,5));

create table Thesis (serialNumber int PRIMARY KEY IDENTITY, 
field varchar(50), 
type varchar(50), 
title varchar(50),
startDate date, 
endDate date,
defenseDate date, 
years AS (YEAR(endDate) - YEAR(startDate)),
grade decimal(10,5),
payment_id int ,
noExtension int,
FOREIGN KEY (payment_id) references Payment ON DELETE CASCADE on update cascade);
  

create table Publication (id int PRIMARY KEY IDENTITY,
title varchar(50),
date date,
place varchar(50),
accepted bit,
host varchar(50));

create table Examiner (id int PRIMARY Key,
name varchar(50), 
fieldOfWork varchar(50),
isNational bit,
foreign key (id) references PostGradUser on delete cascade on update cascade);


create table Defense (serialNumber int,
date date ,
location varchar(100), 
grade decimal(10,5),
primary key(serialNumber ,date),
FOREIGN KEY (serialNumber) references thesis ON DELETE CASCADE on update cascade);

create table GUCianProgressReport (sid int ,
no int, 
date date,
eval int,
state int,
thesisSerialNumber int,
supid int,
description varchar(200),
primary key(sid,no),
FOREIGN KEY (sid) references GucianStudent ON DELETE CASCADE on update cascade,
FOREIGN KEY (thesisSerialNumber) references thesis ON DELETE CASCADE on update cascade,
FOREIGN KEY (supid) references supervisor );


create table NonGUCianProgressReport (sid int,
no int ,
date date,
eval int,
state int ,
thesisSerialNumber int,
supid int,
description varchar(200),
primary key(sid ,no),
FOREIGN KEY (sid) references NonGucianStudent ON DELETE CASCADE on update cascade,
FOREIGN KEY (thesisSerialNumber) references thesis ON DELETE CASCADE on update cascade,
FOREIGN KEY (supid) references Supervisor );

create table Installment (date date,
paymentId int,
amount decimal(10,5),
done bit,
primary key(date ,paymentId),
FOREIGN KEY (paymentId) references Payment ON DELETE CASCADE on update cascade);

create table NonGucianStudentPayForCourse(sid int,
paymentNo int,
cid int,
primary key(sid ,paymentNo,cid),
FOREIGN KEY (sid) references NonGucianStudent ON DELETE CASCADE on update cascade,
FOREIGN KEY (paymentNo) references Payment ON DELETE CASCADE on update cascade,
FOREIGN KEY (cid) references Course ON DELETE CASCADE on update cascade);

create table NonGucianStudentTakeCourse (sid int ,
cid int,
grade decimal(10,5),
primary key(sid ,cid),
FOREIGN KEY (sid) references NonGucianStudent ON DELETE CASCADE on update cascade,
FOREIGN KEY (cid) references Course ON DELETE CASCADE on update cascade);

create table GUCianStudentRegisterThesis (sid int,
supid int,
serial_no int,
primary key(sid ,supid,serial_no),
FOREIGN KEY (sid) references GucianStudent ON DELETE CASCADE on update cascade,
FOREIGN KEY (supid) references Supervisor ,
FOREIGN KEY (serial_No) references Thesis ON DELETE CASCADE on update cascade);

create table NonGUCianStudentRegisterThesis (sid int,
supid int,
serial_no int,
primary key(sid ,supid,serial_no),
FOREIGN KEY (sid) references NonGucianStudent ON DELETE CASCADE on update cascade,
FOREIGN KEY (supid) references Supervisor ,
FOREIGN KEY (serial_No) references Thesis ON DELETE CASCADE on update cascade);

create table ExaminerEvaluateDefense(date date,
serialNo int ,
examinerId int,
comment varchar(500),
primary key(date,serialNo,examinerId),
FOREIGN KEY (serialNo,date) references Defense ON DELETE CASCADE on update cascade,
FOREIGN KEY (examinerId) references Examiner ON DELETE CASCADE on update cascade);


create table ThesisHasPublication(serialNo int,
pubid int,
primary key(serialNo,pubid),
FOREIGN KEY (serialNo) references Thesis ON DELETE CASCADE on update cascade,
FOREIGN KEY (pubid) references Publication ON DELETE CASCADE on update cascade);


go
