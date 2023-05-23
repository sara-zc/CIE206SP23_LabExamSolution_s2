-- Step 1: Database and Schema Creation
Go
IF db_id('LabExam_SaraAhmed_UniversityDB') IS NULL 
    CREATE DATABASE LabExam_SaraAhmed_UniversityDB
Go
use LabExam_SaraAhmed_UniversityDB
Go
create table Course(
id varchar(20) primary key, 
course_name varchar(50),
credit_hours int
)
create table Section(
id int primary key,
semester varchar(20),
instructor_name varchar(20),
course_id varchar(20) foreign key references Course(id)
)
create table Student(
id int primary key,
username varchar(20) unique,
[name] varchar(20)
)
create table Grade(
student_id int foreign key references Student(id),
section_id int foreign key references Section(id),
grade_Letter varchar(2)
)
Go

-- Step 2: Value Insertion
Go
insert into Course values ('CIE2113','OOP',3)
insert into Course values ('SPC1475','Data Structure',3)
insert into Course values ('SCH2531','Leadership',2)
insert into Course values ('CIE3321','Electronics',4)

insert into Section values (1,'Spring2023','Ehab','CIE2113')
insert into Section values (2,'Spring2023','Mohamed','SPC1475')
insert into Section values (3,'Spring2023','Ahmed','SPC1475')
insert into Section values (4,'Spring2023','Sayed','SCH2531')
insert into Section values (5,'Spring2023','Ahmed','CIE3321')
insert into Section values (6,'Spring2023','Mohamed','SPC1475')
insert into Section values (7,'Spring2023','Sameh','CIE3321')
insert into Section values (8,'Spring2023','Ibrahim','SCH2531')
insert into Section values (9,'Spring2023','Ehab','CIE2113')

insert into Student values (20190356, 'a-said', 'Ahmed Said')
insert into Student values (20210123, 'y-wael', 'Yara Wael')
insert into Student values (20219631, 'ahmed12', 'Ahmed Said')
insert into Student values (20200891, 'seif-omar', 'Saif Omar')
insert into Student values (20190112, 'abdo-khaled', 'Abdelrahman Khaled')

insert into Grade values (20190356, 2, 'A')
insert into Grade values (20190356, 4, 'B')
insert into Grade values (20190356, 7, 'C+')
insert into Grade values (20210123, 4, 'B+')
insert into Grade values (20210123, 1, 'A-')
insert into Grade values (20219631, 8, 'B-')
insert into Grade values (20200891, 9, 'A')
insert into Grade values (20200891, 4, 'D')
insert into Grade values (20190112, 6, 'C')
Go

select * from Grade
select * from Student
select * from Section
select * from Course

select * from Student where username = 'y-wael'

select Course.id, Course.course_name, Section.id, Section.instructor_name, Grade.grade_Letter 
from Course inner join Section on Course.id = Section.course_id 
inner join Grade on Grade.section_id = Section.id 
inner join Student on Student.id = Grade.student_id
where Student.id = '20190356'