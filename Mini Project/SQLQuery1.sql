CREATE DATABASE TrainDB;

USE TrainDB;

-- USERS
CREATE TABLE Users
(
    UserId INT IDENTITY PRIMARY KEY,
    Email VARCHAR(100) UNIQUE,
    Password VARCHAR(50),
    UserType VARCHAR(20),
    IsActive BIT DEFAULT 1
);

-- TRAIN
CREATE TABLE TrainDetails
(
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(50),
    FromPlace VARCHAR(50),
    ToPlace VARCHAR(50),
    Status VARCHAR(20) DEFAULT 'Active'
);

-- TRAIN CLASS
CREATE TABLE TrainClassDetails
(
    Id INT IDENTITY PRIMARY KEY,
    TrainNo INT,
    Class VARCHAR(20),
    Availability INT,
    Charges FLOAT,

    FOREIGN KEY (TrainNo)
    REFERENCES TrainDetails(TrainNo)
);

-- BOOKINGS
CREATE TABLE BookingDetails
(
    BookingId INT IDENTITY PRIMARY KEY,
    PNR VARCHAR(20),
    UserEmail VARCHAR(100),
    BookDate DATETIME DEFAULT GETDATE(),
    TravelDate DATE,
    TrainNo INT,
    TravelClass VARCHAR(20),
    Passengers INT,
    Amount FLOAT,
    PaymentMethod VARCHAR(30),
    BookingStatus VARCHAR(20) DEFAULT 'Confirmed'
);

-- PASSENGERS
CREATE TABLE PassengerDetails
(
    PassengerId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    PassengerName VARCHAR(50),
    Age INT,
    Gender VARCHAR(10),
    IdentityProof VARCHAR(50),
    MobileNo VARCHAR(15),

    FOREIGN KEY (BookingId)
    REFERENCES BookingDetails(BookingId)
);

-- CANCELLATIONS
CREATE TABLE CancellationDetails
(
    CId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    PassengerName VARCHAR(50),
    RefundAmount FLOAT,
    CancelDate DATETIME DEFAULT GETDATE()
);

-- ADMIN
INSERT INTO Users
VALUES('admin@gmail.com','admin123','Admin',1);

select*from TrainDetails
select*from CancellationDetails
