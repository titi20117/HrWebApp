use HrProject;
Go

CREATE TABLE Companies (
    company_id INT PRIMARY KEY IDENTITY(1,1),
    company_name VARCHAR(100) NOT NULL,
	company_sector VARCHAR(100) NOT NULL,
	company_type VARCHAR(100) NOT NULL,
    company_number_of_employees INT NOT NULL,
    company_location VARCHAR(255) NOT NULL,
	company_date_of_creation INT NOT NULL,
	company_description VARCHAR(1000) NOT NULL,
	company_url VARCHAR(100) unique NOT NULL
);
GO

CREATE TABLE Skills (
	skill_id INT PRIMARY KEY IDENTITY(1,1),
	skill_name VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Contracts(
	contract_id INT PRIMARY KEY IDENTITY(1,1),
	contract_title VARCHAR(50) NOT NULL
);
GO
--must to update vacancies table where is skills
CREATE TABLE Vacancies (
    vacancy_id INT PRIMARY KEY IDENTITY(1,1),
    company_id INT NOT NULL,
    title VARCHAR(255) NOT NULL,
	responsibilities TEXT NOT NULL,
	study_level_id INT NOT NULL,
	working_experience INT NOT NULL CHECK(working_experience > 0),
	working_hours INT NOT NULL CHECK(working_hours >= 35),
	contract_id INT NOT NULL,
	salary DECIMAL NOT NULL CHECK(salary >= 30000),
    vacancy_description TEXT NOT NULL,
    publication_date DATETIME NOT NULL,
    FOREIGN KEY (company_id) REFERENCES Companies(company_id),
    FOREIGN KEY (contract_id) REFERENCES Contracts(contract_id),
);
GO

CREATE TABLE Vacancies_Skills (
	vacancy_id INT NOT NULL FOREIGN KEY (skill_id) REFERENCES Vacancies(vacancy_id),
	skill_id INT NOT NULL FOREIGN KEY (skill_id) REFERENCES Skills(skill_id)

	CONSTRAINT PK_Vacancies_Skills PRIMARY KEY(vacancy_id, skill_id)
);
GO

CREATE TABLE User_Categories (
	user_category_id INT PRIMARY KEY IDENTITY(1,1),
	user_category_name VARCHAR(50)
);
GO

CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    user_email VARCHAR(50) UNIQUE,
    user_password VARCHAR(255),
	user_confirmation_password VARCHAR(255)
);
GO

ALTER TABLE Users 
ALTER COLUMN user_password VARCHAR(255) NOT NULL;
GO

ALTER TABLE Users 
ADD user_confirmation_password VARCHAR(255) NOT NULL;
GO

ALTER TABLE Users 
ADD user_category_id INT FOREIGN KEY REFERENCES User_Categories(user_category_id);
GO

CREATE TABLE Educations(
	education_id INT PRIMARY KEY IDENTITY(1,1),
	education_name VARCHAR(50) NOT NULL,
	education_averageScore VARCHAR(50)
);
GO
--переименование education_category на education_averageScore
EXEC sp_rename 'dbo.Educations.education_category', 'education_averageScore', 'COLUMN';

ALTER TABLE Educations
ALTER COLUMN education_averageScore FLOAT NOT NULL;
GO

CREATE TABLE Languages(
	language_id INT PRIMARY KEY IDENTITY(1,1),
	language_name VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Student_Status (
	student_status_id INT PRIMARY KEY IDENTITY(1,1),
	student_status_name VARCHAR(50)
);
GO

CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    student_first_name VARCHAR(50) NOT NULL,
    student_last_name VARCHAR(50) NOT NULL,
    student_email VARCHAR(100) NOT NULL,
    student_phone_number VARCHAR(20) NOT NULL,
	student_work_experience INT NOT NULL CHECK(student_work_experience >= 0),
	student_number_projects INT CHECK(student_number_projects >= 0),
	student_url_github VARCHAR(3000),
	student_awards_honors VARCHAR(3000),
	student_status_id INT NOT NULL FOREIGN KEY REFERENCES Student_Status(student_status_id)
);
GO

ALTER TABLE Students
DROP COLUMN student_email;
GO

ALTER TABLE Students
ADD user_id INT FOREIGN KEY REFERENCES Users(user_id);
GO

CREATE TABLE Students_Skills (
	student_id INT NOT NULL FOREIGN KEY REFERENCES Students(student_id),
	skill_id INT NOT NULL FOREIGN KEY REFERENCES Skills(skill_id)

	CONSTRAINT PK_Students_Skills PRIMARY KEY(student_id, skill_id)
);
GO

CREATE TABLE Students_Educations (
	student_id INT NOT NULL FOREIGN KEY REFERENCES Students(student_id),
	education_id INT NOT NULL FOREIGN KEY REFERENCES Educations(education_id)

	CONSTRAINT PK_Students_Educations PRIMARY KEY(student_id, education_id)
);
GO

CREATE TABLE Students_Languages (
	student_id INT NOT NULL FOREIGN KEY REFERENCES Students(student_id),
	language_id INT NOT NULL FOREIGN KEY REFERENCES Languages(language_id)

	CONSTRAINT PK_Students_Languages PRIMARY KEY(student_id, language_id)
);
GO

CREATE TABLE CompanySectors (
	companySector_id INT PRIMARY KEY IDENTITY(1,1),
	companySector_name VARCHAR(100)
);
GO
--small,medium or large companies
CREATE TABLE CompanyTypes (
	companyType_id INT PRIMARY KEY IDENTITY(1,1),
	companyType_name VARCHAR(100)
);
GO

ALTER TABLE Companies
ADD company_name VARCHAR(100) NOT NULL;
GO

ALTER TABLE Companies
ADD company_recruiterFirstName VARCHAR(100) NOT NULL;
GO

ALTER TABLE Companies
ADD company_recruiterLastName VARCHAR(100) NOT NULL;
GO

ALTER TABLE Companies
ADD company_phone VARCHAR(100) NOT NULL;
GO

ALTER TABLE Companies
DROP COLUMN company_type;
GO

ALTER TABLE Companies
ADD companySector_id INT FOREIGN KEY REFERENCES CompanySectors(companySector_id);
GO

ALTER TABLE Companies
ADD companyType_id INT FOREIGN KEY REFERENCES CompanyTypes(companyType_id);
GO

ALTER TABLE Companies
ADD user_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id);
GO

CREATE TABLE StudentStatistics (
	statistic_id INT PRIMARY KEY IDENTITY(1,1),
	student_id INT NOT NULL,
	education_score FLOAT NOT NULL,
	profil_score FLOAT NOT NULL,
	personalityTest_score FLOAT NOT NULL,
	individualAchievements_score FLOAT NOT NULL,
	FOREIGN KEY (student_id) REFERENCES Students(student_id)
);
GO

CREATE TABLE PersonalityTests (
	personalityTest_id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT NOT NULL,
	--Openness
	personalityTest_question1 VARCHAR(1000) NOT NULL,
	personalityTest_question2 VARCHAR(1000) NOT NULL,
	personalityTest_question3 VARCHAR(1000) NOT NULL,
	--Conscientiousness 
	personalityTest_question4 VARCHAR(1000) NOT NULL,
	personalityTest_question5 VARCHAR(1000) NOT NULL,
	personalityTest_question6 VARCHAR(1000) NOT NULL,
	--Extraversion
	personalityTest_question7 VARCHAR(1000) NOT NULL,
	personalityTest_question8 VARCHAR(1000) NOT NULL,
	personalityTest_question9 VARCHAR(1000) NOT NULL,
	--Agreeableness
	personalityTest_question10 VARCHAR(1000) NOT NULL,
	personalityTest_question11 VARCHAR(1000) NOT NULL,
	personalityTest_question12 VARCHAR(1000) NOT NULL,
	--Neuroticism
	personalityTest_question13 VARCHAR(1000) NOT NULL,
	personalityTest_question14 VARCHAR(1000) NOT NULL,
	personalityTest_question15 VARCHAR(1000) NOT NULL,
	--Dominance
	personalityTest_question16 VARCHAR(1000) NOT NULL,
	personalityTest_question17 VARCHAR(1000) NOT NULL,
	personalityTest_question18 VARCHAR(1000) NOT NULL,
	--Influence
	personalityTest_question19 VARCHAR(1000) NOT NULL,
	personalityTest_question20 VARCHAR(1000) NOT NULL,
	personalityTest_question21 VARCHAR(1000) NOT NULL,
	FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
GO

INSERT INTO User_Categories(user_category_name)
VALUES
	('Student'),
	('Recruiter');
GO

ALTER TABLE Students
ADD education_averageScore FLOAT NOT NULL check (education_averageScore > 0);

INSERT INTO Educations
VALUES('Doctorate degree'),
('Master"s" degree'),
('Bachelor"s" degree'),
('Secondary')
GO

INSERT INTO Languages
VALUES
	('English'),
	('French'),
	('Arabic'),
	('Spanish'),
	('German'),
	('Russian'),
	('Chinese')
GO

INSERT INTO Skills
VALUES
	('T-SQL/SQL'),
	('Kotlin'),
	('Git'),
	('Cybersecurity'),
	('NoSQL'),
	('Cloud computing'),
	('Data science'),
	('Machine learning'),
	('Communication and collaboration'),
	('Project management and'),
	('Software development lifecycles'),
	('Bash & Shell & PowerShell'),
	('TypeScript'),
	('C'),
	('Ruby'),
	('Linux'),
	('.Net'),
	('Docker'),
	('Kubernetes')
GO

INSERT INTO Contracts
VALUES
	('Intership'),
	('Part time'),
	('Full Time'),
	('Remote')
GO

INSERT INTO CompanySectors
VALUES
	('Software development'),
	('Telecommunication'),
	('IT services'),
	('Bank'),
	('Food Industry'),
	('Construction'),
	('Delivery'),
	('Health')
GO

INSERT INTO CompanyTypes
VALUES ('Startup'),
('Large company'),
('SME'),
('Government/Charity/Public Institution/Other'),
('Collectives')
GO





