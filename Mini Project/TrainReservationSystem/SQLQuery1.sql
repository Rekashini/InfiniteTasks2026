CREATE DATABASE TrainBookingDB;

USE TrainBookingDB;

CREATE TABLE Users
(
    Email VARCHAR(100) PRIMARY KEY,
    Password VARCHAR(200) NOT NULL,
    UserType VARCHAR(20) CHECK(UserType IN ('Admin','User')),
    IsActive BIT DEFAULT 1
);

CREATE TABLE TrainDetails
(
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(50),
    FromPlace VARCHAR(50),
    ToPlace VARCHAR(50),
    DepartureTime TIME,
    ArrivalTime TIME,
    Status VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE TrainClassDetails
(
    Id INT IDENTITY PRIMARY KEY,
    TrainNo INT,
    Class VARCHAR(20),
    Availability INT,
    Charges DECIMAL(10,2),

    FOREIGN KEY (TrainNo) REFERENCES TrainDetails(TrainNo)
);

CREATE TABLE BookingDetails
(
    BookingId INT IDENTITY PRIMARY KEY,
    PNR VARCHAR(20),
    UserEmail VARCHAR(100),
    PassengerName VARCHAR(50),
    Age INT,
    Gender VARCHAR(10),
    MobileNo VARCHAR(15),
    BookDate DATETIME,
    TravelDate DATE,
    TrainNo INT,
    TravelClass VARCHAR(20),
    Amount DECIMAL(10,2),
    PaymentMethod VARCHAR(30),
    BookingStatus VARCHAR(20),

    FOREIGN KEY (UserEmail) REFERENCES Users(Email),
    FOREIGN KEY (TrainNo) REFERENCES TrainDetails(TrainNo)
);

CREATE TABLE PassengerDetails
(
    PassengerId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    PassengerName VARCHAR(50),
    Age INT,
    Gender VARCHAR(10),

    FOREIGN KEY (BookingId) REFERENCES BookingDetails(BookingId)
);

CREATE TABLE CancellationDetails
(
    CId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    RefundAmount DECIMAL(10,2),
    CancelDate DATETIME,

    FOREIGN KEY (BookingId) REFERENCES BookingDetails(BookingId)
);

INSERT INTO Users
VALUES('admin@gmail.com','admin123','Admin',1);

SELECT * FROM Users;
SELECT * FROM TrainDetails;
SELECT * FROM TrainClassDetails;
SELECT * FROM BookingDetails;
SELECT * FROM CancellationDetails;
