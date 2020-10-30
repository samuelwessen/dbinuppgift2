CREATE TABLE Errand(
[Id] int not null identity(1,1) primary key,
[Description] nvarchar(500) not null,
[CreationTime] datetime not null,
[CustomerFullName] nvarchar(100) not null,
[CustomerEmail] nvarchar(100) not null,
[CustomerPhoneNr] int null,
[Status] nvarchar(20) not null,
[Category] nvarchar(20) not null,
)