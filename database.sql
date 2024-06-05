use DBCar;
GO

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'CarOperation')
	drop table CarOperation;
GO

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'Operation')
	drop table Operation;
GO

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'Car')
	drop table Car;
GO


CREATE TABLE Car(

    Plate VARCHAR(8),
    Name varchar(255),
    YearManufacture INT,
    YearModel INT,
    Color VARCHAR(255),

    CONSTRAINT pkcar PRIMARY KEY (plate)
);

CREATE TABLE Operation(

    id INT IDENTITY(1,1),
    description VARCHAR(255),

    CONSTRAINT pkoperation PRIMARY KEY (id)

);

CREATE TABLE CarOperation(

    CarPlate VARCHAR(8),
    OperationId INT,
    Status BIT,

    CONSTRAINT pkcaroperation PRIMARY KEY (CarPlate, OperationId),
    CONSTRAINT fkcar FOREIGN KEY (CarPlate) REFERENCES Car(plate),
    CONSTRAINT fkoperation FOREIGN KEY (OperationId) REFERENCES Operation(id)
);


select * from car;
select * from Operation;
select * from CarOperation;