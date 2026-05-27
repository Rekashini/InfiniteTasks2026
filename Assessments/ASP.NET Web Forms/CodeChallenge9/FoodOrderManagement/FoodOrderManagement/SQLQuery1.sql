CREATE DATABASE FoodOrderDB

USE FoodOrderDB


CREATE TABLE MenuItems
(
    MenuId INT PRIMARY KEY IDENTITY(1,1),
    ItemName VARCHAR(100),
    Category VARCHAR(50),
    FoodType VARCHAR(20),
    Price DECIMAL(10,2),
    AvailableQuantity INT,
    IsAvailable BIT,
    CreatedDate DATETIME
)

Select*from MenuItems;