CREATE TABLE [dbo].[SurveyForm]
(
	ID int identity(1,1) NOT NULL primary key, 
	Title nvarchar(400) not NULL,
	Instructions nvarchar(2000) NULL,
	EndNote nvarchar(2000),
	EffectiveFrom datetime2,
	EffectiveTo datetime2
)
