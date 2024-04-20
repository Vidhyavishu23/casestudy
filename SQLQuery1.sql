
CREATE TABLE Admins (

    AdminID INT PRIMARY KEY,

    Username VARCHAR(50),

    Password VARCHAR(50)

);
 
CREATE TABLE Classes (

    ClassID INT PRIMARY KEY,

    ClassName VARCHAR(50),

    IntakeCapacity INT

);
 
 
CREATE TABLE Students (

    StudentID INT PRIMARY KEY,

    Username VARCHAR(50),

    Password VARCHAR(50),

    Name VARCHAR(100),

    ClassID INT,

    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)

);

CREATE TABLE Admissions (

    AdmissionID INT PRIMARY KEY,

    StudentID INT,

    ClassID INT,

    AdmissionDate DATE,

    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),

    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)

);
 
CREATE TABLE Fees (

    FeeID INT PRIMARY KEY,

    StudentID INT,

    ClassID INT,

    FeeAmount DECIMAL(10, 2),

    PaymentDate DATE,

    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),

    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)

);

-- Inserting data into the Admins table
INSERT
INTO
Admins (AdminID, Username, Password) VALUES(1,'admin1','password1'),       (2,'admin2','password2'),       (3,'admin3','password3');
-- Inserting data into the Classes table
INSERT
INTO
Classes (ClassID, ClassName, IntakeCapacity)VALUES(1,'Science', 30),       (2,'Commerce', 25),       (3,'History', 20);
-- Inserting data into the Students table
INSERT
INTO
Students (StudentID, Username, Password, Name, ClassID)
VALUES
(1,
'student1'
,
'studentpass'
,
'Alice'
, 1),       (2,
'student2'
,
'studentpass'
,
'Bob'
, 2),       (3,
'student3'
,
'studentpass'
,
'Charlie'
, 3);
-- Inserting data into the Admissions table
INSERT
INTO
Admissions (AdmissionID, StudentID, ClassID, AdmissionDate)
VALUES
(1, 1, 1,
'2022-01-15'
),       (2, 2, 2,
'2022-02-20'
),       (3, 3, 3,
'2022-03-25'
);
-- Inserting data into the Fees table
INSERT
INTO
Fees (FeeID, StudentID, ClassID, FeeAmount, PaymentDate)
VALUES
(1, 1, 1, 500.00,
'2022-02-01'
),       (2, 2, 2, 600.00,
'2022-03-10'
),       (3, 3, 3, 450.00,
'2022-04-15'
);

select*from Admins
select*from Students
select*from Classes
select*from Fees
select*from Admissions
drop Table StudentLogin 

CREATE TABLE StudentLogin (
   
    UserID int PRIMARY KEY,
    Firstname VARCHAR(100),
    Lastname VARCHAR(100),
	Username varchar(50),
	Phone varchar(10) ,
	Email varchar(50),
	Password VARCHAR(50),
	ClassID INT,
	StudentID INT,
	FeeID INt,
	AdmissionID int,
	
   
  FOREIGN KEY (ClassID) REFERENCES Classes(ClassID),
	
   FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (FeeID) REFERENCES FEES(FeeID),
	FOREIGN KEY (AdmissionID) REFERENCES Admissions(AdmissionID),

);





insert into StudentLogin values(1, 'vidya','vishu','vidyavishu','9845207856','vidhyavishu23@gmail.com','Vid230800!',1,1,1,1)
select * from StudentLogin

