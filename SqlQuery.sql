create database Student

use Student

create table StudentInfo 
(
Id int identity primary key ,
FirstName nvarchar(50),
LastName nvarchar(50),
Gender nvarchar(50),
Class int
)

insert into StudentInfo values ('t','test1','male',1)
insert into StudentInfo values ('s','test2','male',2)
insert into StudentInfo values ('r','test3','male',3)
insert into StudentInfo values ('m','test4','female',4)
insert into StudentInfo values ('n','test5','female',5)