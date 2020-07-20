CREATE TABLE [dbo].Choice
(
	ID int identity(1,1) NOT NULL PRIMARY KEY, 
	ParentID int,
	SequenceNo int not null,
	Title nvarchar(400),
	Weight real,
	FurtherQuestionID int,
)
