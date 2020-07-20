CREATE TABLE [dbo].SurveyQuestion
(
	ID int identity(1,1) NOT NULL PRIMARY KEY, 
	
	Discriminator tinyint not null, 
	--1=Survey Section, 
	--2=Choice question, 
	--3=Likert question, 
	--4=Text question, 
	--5=Int32 question
	--6=DateTime question

	SequenceNo int not null,
	Title nvarchar(400),
    TitleSuffix nvarchar(200),
	Instructions nvarchar(2000),
	SurveyFormID int, --FK -> SurveyForm.ID
	ParentID int, --FK -> SurveySection.ID
	DefaultValue nvarchar(2000),
	MaxValue nvarchar(2000),
	MinValue nvarchar(2000),
	MaxNumberOfSelection int,
	MinNumberOfSelection int,
	[Weight] real,
)
