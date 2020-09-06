IF object_id('CAR', 'U') is not null DROP TABLE CAR;
IF object_id('BRAND', 'U') is not null DROP TABLE BRAND;
GO

CREATE TABLE BRAND (
	brand_id int primary key, -- no IDENTITY!
	brand_name nvarchar(100)
);

CREATE TABLE CAR (
	car_id int primary key,  -- no IDENTITY!
	car_brand int references BRAND(brand_id),
	car_model nvarchar(100),
	car_baseprice int,
    car_discountprice int
);

INSERT INTO BRAND VALUES (1, 'BMW');
INSERT INTO BRAND VALUES (2, 'Audi');

INSERT INTO CAR VALUES (1, 1, 'BMW 116d', 30000, 300);
INSERT INTO CAR VALUES (2, 1, 'BMW i8', 90000, 770);
INSERT INTO CAR VALUES (3, 2, 'Audi A2', 40000, 1000);
INSERT INTO CAR VALUES (4, 2, 'Audi A4', 60000, 980);