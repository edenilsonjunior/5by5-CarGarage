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

    plate VARCHAR(8),
    name varchar(255),
    year_manufacture INT,
    year_model INT,
    color VARCHAR(255),

    CONSTRAINT pkcar PRIMARY KEY (plate)
);

CREATE TABLE Operation(

    id INT IDENTITY(1,1),
    description VARCHAR(255),

    CONSTRAINT pkoperation PRIMARY KEY (id)

);

CREATE TABLE CarOperation(

    car_plate VARCHAR(8),
    operation_id INT,
    status BIT,

    CONSTRAINT pkcaroperation PRIMARY KEY (car_plate, operation_id),
    CONSTRAINT fkcar FOREIGN KEY (car_plate) REFERENCES Car(plate),
    CONSTRAINT fkoperation FOREIGN KEY (operation_id) REFERENCES Operation(id)
);


select * from car;
select * from Operation;
select * from CarOperation;