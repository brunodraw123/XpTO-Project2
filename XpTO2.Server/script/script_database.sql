

CREATE DATABASE XpTO
GO

 create table [dbo].[Order](
    OrderId int not null primary key identity(0,1),
    CustomerName NVARCHAR(55),
    CustomerMail NVARCHAR(55),
    DrinkName NVARCHAR(55),
    DrinkValue DECIMAL,
    MainFoodName NVARCHAR(55),
    MainFoodValue decimal,
    DessertName NVARCHAR(55),
    DesserValue DECIMAL,
    AccompanimentFoodName NVARCHAR(55),
    AccompanimentFoodValue decimal,
    StatusName NVARCHAR(55),
    ReceivedDate DateTime null,
    StatDate DateTime null,
    FinishDate DATETIME null,
    OrderType nvarchar(55),
    TotalValue DECIMAL
)