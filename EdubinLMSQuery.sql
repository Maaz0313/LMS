create database Edubin
use Edubin 
/* To retain COPYRIGHT don't give .sql, give .bak file */
	--/*--OUT of DB's Context*/--
EXEC sp_DROPSERVER 'DESKTOP-PNJ70HL'
    
-- 2. Execute below to add a new server name. Make sure local is specified.

	EXEC sp_ADDSERVER '.', 'local'

-- 3. Restart SQL Services.

-- 4. Verify the new name using:

	SELECT @@SERVERNAME
	SELECT * FROM sys.servers WHERE server_id = 0
	--/*--STARTS FROM HERE*/--
-- Creating Employee table
GO

-- Creating Users table
CREATE TABLE Users
(
 ID INT PRIMARY KEY IDENTITY(1,1),
 UserName VARCHAR(50),
 UserPassword VARCHAR(50)
)
GO
-- Creating RoleMaster Table
CREATE TABLE RoleMaster
(
 ID INT PRIMARY KEY IDENTITY(1,1),
 RollName VARCHAR(50)
)
GO
-- Creating User Roles Mapping table
CREATE TABLE RolesMapper
(
 ID INT PRIMARY KEY,
 UserID INT NOT NULL,
 RoleID INT NOT NULL,
)
GO
CREATE TABLE Departments
(
 DeptID INT PRIMARY KEY,
 DepartmentName VARCHAR(50) NOT NULL
)
GO
CREATE TABLE Employee
(
EmpID INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(50),
Gender VARCHAR(50),
Age INT,
Position VARCHAR(50),
Office VARCHAR(50),
HireDate VARCHAR(50),
Salary INT,
DepartmentId INT 
)
--EmpId,Name,Gender,Age,Position,Office,HireDate,Salary,DepartmentId
--href="https://www.c-sharpcorner.com/article/role-based-menus-in-asp-net-mvc/"
GO
-- Adding Foreign KeyS
ALTER TABLE RolesMapper
ADD FOREIGN KEY (UserID) REFERENCES Users(ID);
GO
ALTER TABLE RolesMapper
ADD FOREIGN KEY (RoleID) REFERENCES RoleMaster(ID);
GO
ALTER TABLE Departments
ADD FOREIGN KEY (DeptID) REFERENCES Employee(DepartmentId);
GO
-- EXEC SP_RENAME 'table_name.current_name' , 'new_name', 'COLUMN'
-- Firstly, create above 3 tables only & apply role-based authentication alongwith forms authentication 
-- href: https://dotnettutorials.net/lesson/forms-authentication-in-mvc/ /*relating emp & users table*/
GO
/*
Roles within the system:

webmaster (software.technician)
admin (institution admin)
staff (institution staff)
student (regular user; has most data)
*/
GO
-- Inserting data into Role Master table
INSERT INTO RoleMaster VALUES('Admin')
INSERT INTO RoleMaster VALUES('webmaster')
INSERT INTO RoleMaster VALUES('Faculty')
INSERT INTO RoleMaster VALUES('Student')
GO
-- Inserting data into Users table
INSERT INTO Users VALUES('Admin','admin')
INSERT INTO Users VALUES('webmaster','webmaster')
INSERT INTO Users VALUES('Faculty','faculty')
INSERT INTO Users VALUES('Student','student')
GO
--number 1 for admin
--number 2 for webmaster
--number 3 for faculty
--number 4 for students
GO
-- Inserting data into User Roles Mapping table
INSERT INTO RolesMapper VALUES(1, 1, 1)
INSERT INTO RolesMapper VALUES(2, 1, 2)
INSERT INTO RolesMapper VALUES(3, 1, 3)
INSERT INTO RolesMapper VALUES(4, 2, 2)
--INSERT INTO RolesMapper VALUES(5, 3, 3)

-- Inserting data into Employee table
INSERT INTO Employee VALUES('Anurag', 'Software Engineer', 10000)
INSERT INTO Employee VALUES('Preety', 'Tester', 20000)
INSERT INTO Employee VALUES('Priyanka', 'Software Engineer', 20000)
INSERT INTO Employee VALUES('Ramesh', 'Team Lead', 10000)
INSERT INTO Employee VALUES('Santosh', 'Tester', 15000)
GO
--********First create and insert above work in Database then apply role-based authentication in VS********
create table Faculty
(
F_id int primary key identity(0,1),
F_name varchar(MAX) not null,
Email varchar(MAX) not null,
Contact bigint not null,
F_User int not null foreign key references dbo.Users(UserID)
)
GO
create table Batch_Details
(
Batch_Code varchar(15) primary key not null,
Batch_Start date not null,
Batch_end date not null,
Timing time not null,
Faculty int not null foreign key references Faculty(F_id)
)
GO
create table Course_Details
(
Course_Code varchar(15) primary key not null,
Course_Name varchar(MAX) not null,
Course_fee bigint not null,
Batch varchar(15) not null foreign key references Batch_Details(Batch_Code)
)
GO
create table Course_Fee
(
id int primary key identity,
Course varchar(15) not null foreign key references Course_Details(Course_Code),
Fee bigint not null
)
GO
						-- For Student Signup:
GO
create table Student_Details 
(
Std_Id int primary key identity,
C_Name varchar(MAX) not null,
D_O_B date not null,
Email varchar(255) not null,
Contact bigint not null,
D_O_A date not null,
User_ int not null foreign key references dbo.Users(userid), /*userid = rolename*/
Batch varchar(255) not null,
Course varchar(15) not null foreign key references Course_Details(Course_Code)
)
GO
create table Exam_Details
(
Exam_Id int primary key identity,
Exam_Date date not null,
Exam_Time time not null,
Course varchar(15) not null foreign key references Course_Details(Course_Code),
Student int foreign key references dbo.Student_Details(Std_Id)
)
GO
create table Exam_Result
(
Result_Id int primary key identity not null,
Exam int not null foreign key references dbo.Exam_Details(Exam_Id),
Student int foreign key references Student_Details(Std_Id),
Total_Marks int not null,
Obtained_Marks int not null
)
GO
exec sp_help User