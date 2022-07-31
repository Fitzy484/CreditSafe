Use [db.Cities]
Go
Create table [dbo.Cities](
[CityId] [int] IDENTITY (1,1) NOT NULL,
[Name] [nvarchar](50) NOT NULL,
[State] [nvarchar](50) NOT NULL,
[Country] [nvarchar](50) NOT NULL,
[Tourist_Rating] [int] NOT NULL,
[Date_Established] [int] NOT NULL,
[Estimated_Population] [int] NOT NULL);