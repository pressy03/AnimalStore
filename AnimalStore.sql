CREATE DATABASE AnimalStore
GO

USE AnimalStore
GO

ALTER DATABASE AnimalStore
COLLATE Cyrillic_General_CI_AS

--| CREATING TABLES |--

CREATE TABLE Towns
(
	TownID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	TownName NVARCHAR(50) NOT NULL,
	PostCode CHAR(4) NOT NULL
);

CREATE TABLE Addresses
(
	AddressID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	AddressName NVARCHAR(50) NOT NULL,
	TownID INT FOREIGN KEY REFERENCES Towns(TownID) NOT NULL
);

CREATE TABLE ClientCards
(
	CardID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	Birthday DATE NOT NULL
);

CREATE TABLE Clients
(
	ClientID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	ClientCardID INT FOREIGN KEY REFERENCES ClientCards(CardID),
	PhoneNumber CHAR(10) UNIQUE,
	AddressID INT NOT NULL FOREIGN KEY REFERENCES Addresses(AddressID),
	Email NVARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE Animals
(
	AnimalID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	AnimalName NVARCHAR(50) NOT NULL
);

CREATE TABLE TypeOfType
(
	TypeOfTypeID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	TypeOfTypeName NVARCHAR(50) NOT NULL
);

CREATE TABLE TypesOfProduct
(
	TypeID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	TypeName NVARCHAR(50) NOT NULL,
	AnimalID  INT FOREIGN KEY REFERENCES Animals(AnimalID) NOT NULL,
	TypeOfTypeID INT FOREIGN KEY REFERENCES TypeOfType(TypeOfTypeID) NOT NULL,
	Price MONEY NOT NULL,
	AvailableQuantity INT NOT NULL
);

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	ClientCardID INT FOREIGN KEY REFERENCES ClientCards(CardID),
	Fullfilled BIT NOT NULL,
	DateAndTime SMALLDATETIME NOT NULL
);

CREATE TABLE OrderDetails
(
	OrderID INT IDENTITY(1,1) NOT NULL,
	TypeID INT FOREIGN KEY REFERENCES TypesOfProduct(TypeID) NOT NULL,
	OrderedQuantity INT NOT NULL,
	CONSTRAINT PK_OrderID_TypeID PRIMARY KEY CLUSTERED (OrderID, TypeID)
);

GO

--| INSERTING DATA |--

INSERT INTO Towns(TownName, PostCode)
VALUES
	('Варна', '9000'),
	('Велико Търново', '5000'),
	('Враца', '3000'),
	('Добрич', '9300'),
	('Ловеч', '5500'),
	('Плевен', '5800'),
	('Руси', '7000'),
	('Силистра', '7500'),
	('Шумен', '9700'),
	('Хасково', '6300'),
	('Ямбол', '8600'),
	('Смолян', '4700'),
	('Сливен', '8800'),
	('Габрово', '5300'),
	('Батак', '4580'),
	('Белоградчик', '3900'),
	('Казанлък', '6100');

INSERT INTO Addresses(AddressName,TownID)
VALUES 
	('ул. "Ген. Атанасов №56"', 12),
	('ул. "Симеон Велики №6"', 4),
	('ул. "Ген. Столетов №61"', 1),
	('ул. "Емил Димитров №44"', 5),
	('ул. "Емилиян Станев №89', 1),
	('ул. "Огнен войн №76"', 1),
	('ул. "3 март №222"', 1),
	('ул. "Желязко Тодоров №22"', 14),
	('ул. "Иван Вазов №55"', 16),
	('ул. "Добри Желязков №65"', 16),
	('ул. "Георги Атанасов №3"', 1),
	('ул. "Димитър Рачков №8"', 1),
	('ул. "Димчо Дебелянов №1"', 1),
	('ул. "Велико Димитров №5"', 12),
	('ул. "Детелина Минчева №29', 16),
	('ул. "Забравен войн №90"', 17),
	('ул. "Независимост №12"', 11),
	('ул. "Ген. Столетов №77"', 10),
	('ул. "Петя Дубарова №83"', 10),
	('ул. "Иларион Макариополски №85"', 1),
	('ул. "Люляк №8"', 15), -- адрес №21 е еднакъв за Шишкови - защото са семейство и живеят заедно
	('ул. "Красива поляна №28"', 17),
	('ул. "Улица №11"', 14),
	('ул. "Краси Радков №87"', 13),
	('ул. "Паисий Хилендарски №59', 9),
	('ул. "Троянски кон №94"', 6),
	('ул. "Свобода №2"', 5),
	('ул. "Христо Фотев №27"', 1),
	('ул. "Атанас Далчев №13"', 7);

INSERT INTO ClientCards(Birthday)
VALUES
	(CONVERT(DATE,'1999-04-01')),
	(CONVERT(DATE,'1998-11-10')),
	(CONVERT(DATE,'1987-08-03')),
	(CONVERT(DATE,'2000-04-23')),
	(CONVERT(DATE,'1995-10-29')),
	(CONVERT(DATE,'1977-07-19')),
	(CONVERT(DATE,'1985-12-25')),
	(CONVERT(DATE,'1993-09-20')),
	(CONVERT(DATE,'1998-03-27')),
	(CONVERT(DATE,'1979-01-01')),
	(CONVERT(DATE,'1980-12-28')),
	(CONVERT(DATE,'1990-09-09')),
	(CONVERT(DATE,'2002-02-02')),
	(CONVERT(DATE,'1983-08-17')),
	(CONVERT(DATE,'1996-12-18')),
	(CONVERT(DATE,'2001-08-19')),
	(CONVERT(DATE,'1970-11-05')),
	(CONVERT(DATE,'2000-05-13')),
	(CONVERT(DATE,'1994-07-11'));



INSERT INTO Animals(AnimalName)
VALUES 
('Куче'),--1--
('Рибки'),--2--
('Хамстер'),--3--
('Котка'),--4--
('Папагал'),--5--
('Заек');

INSERT INTO TypeOfType(TypeOfTypeName)
VALUES 
('Играчка'),--1--
('Легло'),--2--
('Храна'),--3--
('Дреха'),--4--
('Каишка'),--5--
('Аквариум');

INSERT INTO TypesOfProduct(TypeName,AnimalID,TypeOfTypeID,Price,AvailableQuantity)
VALUES
--dog--
('Топка Рекси Медиум',1,1,7.80,11),
('Въже Лоре Късо',1,1,5.20,6),
('Тенис Топка Мани',1,1,8.70,3),
('Макс S',1,2,5.10,6),
('Макс M',1,2,8.30,6),
('Макс L',1,2,9.10,1),
('Макс XL',1,2,12.10,11),
('Есеншъл Риба',1,3,8.30,7),
('Есеншъл Пиле',1,3,11.10,1),
('Есеншъл Агне',1,3,8.70,4),
('Есеншъл Пуйка',1,3,6.40,10),
('Adidus Sportmax',1,4,7.10,11),
('Mike hairDog',1,4,5.80,8),
('Flexi S',1,5,7.10,8),
('Flexi M',1,5,10.40,7),
('Flexi L',1,5,12.10,0),
('Flexi XL',1,5,15.00,3),
--fish--
('Аква Мост',2,1,6.60,10),
('Аква Водорасло',2,1,10.40,4),
('Аква Камък',2,1,12.60,0),
('Ликуи 100 г.',2,3,6.40,10),
('Ликуи 200 г.',2,3,8.00,11),
('Ликуи 500 г.',2,3,10.50,3),
('Ликуи 1 кг.',2,3,14.10,4),
('Гласи Аква 20 л.',2,5,36.70,10),
('Гласи Аква 50 л.',2,5,90.00,7),
('Гласи Аква 100 л.',2,5,230.90,9),
('Гласи Аква 500 л.',2,5,480.00,2),
--hamster--
('Колело Емси',3,1,5.40,5),
('Топка Лори',3,1,9.80,9),
('Мапи Огледалце',3,1,9.00,0),
('Сбито Сено Лори S',3,2,10.90,8),
('Сушени Червеи Макси',3,3,7.00,7),
('Пълноценна Лори',3,3,9.00,1),
('Чия Керпи',3,3,5.30,5),
('Лекси Терариум S',3,6,5.80,10),
('Лекси Терариум M',3,6,7.30,4),
('Лекси Терариум L',3,6,9.40,2),
--cat--
('Перо Кори',4,1,11.30,1),
('Въже Кити Късо',4,1,10.20,9),
('Мини Мишле Мани',4,1,11.40,3),
('Кити S',4,2,6.30,8),
('Кити M',4,2,9.10,8),
('Кити L',4,2,11.40,6),
('Кити XL',4,2,15.60,4),
('Федър Риба',4,3,11.70,1),
('Федър Пиле',4,3,9.90,5),
('Яке Кити',4,4,5.30,10),
('Пуловерче Лори',4,4,5.00,0),
--parrot--
('Мини Огледало Коки',5,1,10.30,8),
('Мини Люлка Коки',5,1,11.90,9),
('Слънчогледови Семки Малки Керпи',5,3,6.70,5),
('Слънчогледови Семки Големи Керпи',5,3,5.20,10),
('Тиквени Семки Керпи',5,3,10.70,3),
('Чия',5,3,5.10,15),
('Самолетна Шапка Фъни',5,4,7.10,0),
('Клетка с Люлка и Декорация Фъни',5,6,36.00,2),
('Клетка Фъни малка',5,6,25.40,0),
('Клетка Фъни голяма',5,6,34.80,10),
--bunny--
('Препядствие малко Бъни',6,1,9.70,7),
('Топка за дъвкане Бъни',6,1,6.00,0),
('Сбито Сено Лори L',6,2,14.56,6),
('Сушен Морков Бъни',6,3,7.90,9),
('Витамини Хапче Лоре',6,3,11.30,11),
('Худи Бъни',6,4,11.40,6),
('Худи Емси',6,4,8.70,5),
('Клетка Бъни малка',6,6,25.80,0),
('Клетка Бъни голяма',6,6,40.90,1);

INSERT INTO OrderDetails(TypeID,OrderedQuantity)
VALUES
(29,4),
(40,4),
(37,3),
(27,2),
(46,1),
(17,1),
(5,3),
(42,2),
(10,2),
(42,3),
(60,1),
(18,3),
(38,2),
(32,3),
(58,4),
(19,3),
(2,3),
(65,2),
(51,4),
(62,4),
(49,2),
(1,4),
(37,3),
(66,2),
(68,1),
(10,1),
(42,2),
(40,1),
(61,3),
(51,2),
(38,3),
(7,3),
(5,4),
(63,1),
(36,1),
(2,4),
(25,2),
(61,1),
(2,1),
(3,1),
(24,3),
(21,4),
(34,2),
(48,3),
(68,1),
(9,2),
(39,3),
(46,3),
(28,3),
(1,3),
(1,4),
(6,3),
(30,3),
(42,2),
(1,4);

INSERT INTO Orders(ClientCardID, Fullfilled, DateAndTime)
VALUES

(3,0,CONVERT(SMALLDATETIME,'2021-12-19 11:20:55')),
(1,0,CONVERT(SMALLDATETIME,'2021-9-22 17:40:38')),  ---Ден на Независимостта на България---
(2,1,CONVERT(SMALLDATETIME,'2021-12-27 8:9:22')),
(4,0,CONVERT(SMALLDATETIME,'2021-11-25 13:42:41')),
(1,1,CONVERT(SMALLDATETIME,'2021-11-2 12:30:16')),
(13,0,CONVERT(SMALLDATETIME,'2021-12-19 12:14:20')),
(4,1,CONVERT(SMALLDATETIME,'2021-10-5 17:5:57')),
(12,1,CONVERT(SMALLDATETIME,'2021-9-9 7:18:32')), ---Благой/№12/Рожден Ден----
(5,1,CONVERT(SMALLDATETIME,'2021-11-7 8:10:25')),
(8,1,CONVERT(SMALLDATETIME,'2021-9-14 10:3:27')),
(19,0,CONVERT(SMALLDATETIME,'2021-12-18 16:50:45')),
(3,1,CONVERT(SMALLDATETIME,'2021-9-22 12:17:7')), ---Ден на Независимостта на България---
(1,0,CONVERT(SMALLDATETIME,'2021-10-16 10:4:9')),
(11,1,CONVERT(SMALLDATETIME,'2021-9-4 16:58:18')),
(12,1,CONVERT(SMALLDATETIME,'2021-11-16 14:9:1')),
(14,0,CONVERT(SMALLDATETIME,'2021-9-6 7:54:27')),
(18,1,CONVERT(SMALLDATETIME,'2021-11-26 7:18:11')),
(4,1,CONVERT(SMALLDATETIME,'2021-10-7 7:33:14')),
(1,1,CONVERT(SMALLDATETIME,'2021-9-17 14:18:20')),
(4,1,CONVERT(SMALLDATETIME,'2021-9-10 16:41:18')),
(16,0,CONVERT(SMALLDATETIME,'2021-10-23 11:43:46')),
(2,0,CONVERT(SMALLDATETIME,'2021-11-1 14:56:50')), ---Ден на народните будители---
(6,1,CONVERT(SMALLDATETIME,'2021-12-13 12:20:22')),
(6,1,CONVERT(SMALLDATETIME,'2021-11-8 17:19:22')),
(15,1,CONVERT(SMALLDATETIME,'2021-12-18 9:26:46')),---Янина/№15/Рожден Ден---
(1,0,CONVERT(SMALLDATETIME,'2021-12-8 17:8:5')),
(4,1,CONVERT(SMALLDATETIME,'2021-11-13 11:55:55')),
(5,0,CONVERT(SMALLDATETIME,'2021-10-4 14:48:21')),
(19,1,CONVERT(SMALLDATETIME,'2021-10-1 11:28:38')),
(3,0,CONVERT(SMALLDATETIME,'2021-9-10 9:35:22')),
(1,0,CONVERT(SMALLDATETIME,'2021-11-5 14:55:42')),
(11,0,CONVERT(SMALLDATETIME,'2021-12-28 7:40:28')), ----Генадии/№11/Рожден Ден---
(8,0,CONVERT(SMALLDATETIME,'2021-11-1 12:5:6')), ---Ден на народните будители---
(2,0,CONVERT(SMALLDATETIME,'2021-11-10 14:36:7')), ---Николай/№2/Рожден Ден---
(5,0,CONVERT(SMALLDATETIME,'2021-10-11 7:12:23')),
(4,0,CONVERT(SMALLDATETIME,'2021-9-17 12:10:55')),
(16,0,CONVERT(SMALLDATETIME,'2021-11-9 14:29:12')),
(18,0,CONVERT(SMALLDATETIME,'2021-10-15 11:58:34')),
(1,0,CONVERT(SMALLDATETIME,'2021-9-10 11:40:11')),
(1,1,CONVERT(SMALLDATETIME,'2021-10-20 10:51:23')),
(17,0,CONVERT(SMALLDATETIME,'2021-10-17 7:8:23')),
(15,0,CONVERT(SMALLDATETIME,'2021-10-27 13:15:0')),
(12,1,CONVERT(SMALLDATETIME,'2021-10-16 9:27:37')),
(6,0,CONVERT(SMALLDATETIME,'2021-10-7 10:53:13')),
(3,0,CONVERT(SMALLDATETIME,'2021-11-3 8:12:7')),
(7,0,CONVERT(SMALLDATETIME,'2021-12-25 7:28:34')),---Йоана/№7/Рожден Ден/Рождество Христово {двойна отстъпка!}----
(17,1,CONVERT(SMALLDATETIME,'2022-01-20 9:40:31')),
(18,1,CONVERT(SMALLDATETIME,'2021-11-1 17:18:13')),  ---Ден на народните будители---
(4,0,CONVERT(SMALLDATETIME,'2021-9-26 16:9:39')),
(17,1,CONVERT(SMALLDATETIME,'2021-11-5 12:55:45')), ---Здраво/№17/Рожден Ден---
(11,0,CONVERT(SMALLDATETIME,'2021-10-16 15:27:13')),
(3,1,CONVERT(SMALLDATETIME,'2021-9-25 9:9:30')),
(16,0,CONVERT(SMALLDATETIME,'2021-12-26 15:25:5')), ---Рождество Христово---
(12,1,CONVERT(SMALLDATETIME,'2022-01-13 14:1:22')),
(1,0,CONVERT(SMALLDATETIME,'2021-12-12 11:47:41'));

INSERT INTO Clients(FirstName, MiddleName, LastName, ClientCardID, PhoneNumber, AddressID, Email)
VALUES
	('Иван', 'Георгиев', 'Шишарков', 1, 0846382736, 1, 'vankobg@abv.bg'),
	('Николай', 'Жеков', 'Станев', 2, 0473662989, 2, 'nikooto@gmail.com'),
	('Калоян', 'Филипов', 'Велев', 3, 0473663746, 3, 'kokokko@abv.bg'),
	('Таня', 'Огнянова', 'Петрова', 4, 0998764453, 4, 'tan43toe15top@gmail.com'),
	('Айсун', 'Мехмед', 'Чаушева', NULL, 0853325132, 27, 'AisunnM77@gmail.com'),
	('Милен', 'Радославов', 'Радков', NULL, 0834521222, 26, 'milenmilen4@abv.bg'),
	('Тея', 'Невенова', 'Обретенова', 5, 0994837636, 5, 'obbfteya76@abv.bg'),
	('Емил', 'Танев', 'Лилов', 6, 0787876542, 6, 'emil.lilov@gmail.com'),
	('Йоана', 'Емилова', 'Христова', 7, 0876873332, 7, 'yoni5554@gmail.com'),
	('Димитрина', 'Ханзърова', 'Шишкова', NULL, 0843325132, 21, 'dima89@abv.bg'),
	('Драган', 'Огаров', 'Шишков', NULL, 0843224442, 21, 'dragoenomeredno_1@abv.bg'),
	('Велина', 'Жейнова', 'Шопова', 8, 0888765542, 8, 'vivi6op@abv.bg'),
	('Яна', 'Петрова', 'Йорданова', NULL, 0843355632, 28, 'yana_jordan21@abv.bg'),
	('Росен', 'Чавдаров', 'Яворов', 9, 0889912332, 9, 'rosen.yavorov77@abv.bg'),
	('Виктор', 'Иванов', 'Иванов', 10, 0846768742, 10, 'viki66556@abv.bg'),
	('Eмилияна', 'Иванововска', 'Унурбашева', NULL, 08432651412, 20, 'emiliana_iva.unu@abv.bg'),
	('Генадий', 'Атанасов', 'Радев', 11, 0988565576, 11, 'genataetop@abv.bg'),
	('Благой', 'Яворов', 'Стоянов', 12, 0854500942, 12, 'blagoto56@abv.bg'),
	('Tраяна', 'Янева', 'Яворова', NULL, 0865525132, 29, 'trayana33@abv.bg'),
	('Жана', 'Иларионова', 'Узунова', 13, 0881115652, 13, 'zhana.ana.yzynova@abv.bg'),
	('Желя', 'Димитрова', 'Цънцарова', 14, 0885435112, 14, 'jelqa2333@abv.bg'),
	('Мелиса', 'Филипова', 'Цецкова', NULL, 082425112, 24, 'melito_tseko@abv.bg'),
	('Янина', 'Любенова', 'Варнева', 15, 0888987322, 15, 'qananina65@abv.bg'),
	('Габриела', 'Йорданова', 'Щерева', 16, 0878125432, 16, '89gananaga@abv.bg'),
	('Здраво', 'Благоев', 'Димитров', 17, 0832462342, 17, 'zdravo.dimitrov@abv.bg'),
	('Георги', 'Тодоров', 'Желев', 18, 0899761111, 18, 'gosho_momchetolosho1@abv.bg'),
	('Урун', 'Янев', 'Янакиев', NULL, 08438771321, 23, 'urun_yan32@abv.bg'),
	('Стамат', 'Христов', 'Христов', 19, 0866665562, 19, 'stamatata56@abv.bg');

GO

--| CREATING PROCEDURES |--

CREATE OR ALTER PROC usp_OrdersByClientCardID (@ClientCardID INT)
AS
BEGIN
	SELECT *
	FROM Orders
	WHERE ClientCardID = @ClientCardID
END
GO

CREATE OR ALTER PROC usp_OrdersByDate (@Date VARCHAR(19))
AS
BEGIN
	SELECT *
	FROM Orders
	WHERE DateAndTime = @Date
END
GO

CREATE OR ALTER PROC usp_OrdersBySum (@Sum MONEY, @Status VARCHAR(50)='Equal')
AS
BEGIN
	IF (@Status = 'Equal')
	BEGIN
		SELECT
			o.OrderID,
			o.ClientCardID,
			o.Fullfilled,
			o.DateAndTime,
			Price * OrderedQuantity AS [Sum]
		FROM Orders AS o
		JOIN OrderDetails AS od ON od.OrderID = o.OrderID
		JOIN TypesOfProduct AS tp ON tp.TypeID = od.TypeID
		WHERE Price * OrderedQuantity = @Sum
	END
	ELSE IF (@Status = 'Less')
	BEGIN
		SELECT
			o.OrderID,
			o.ClientCardID,
			o.Fullfilled,
			o.DateAndTime,
			Price * OrderedQuantity AS [Sum]
		FROM Orders AS o
		JOIN OrderDetails AS od ON od.OrderID = o.OrderID
		JOIN TypesOfProduct AS tp ON tp.TypeID = od.TypeID
		WHERE Price * OrderedQuantity < @Sum
	END
	ELSE IF (@Status = 'More')
	BEGIN
		SELECT
			o.OrderID,
			o.ClientCardID,
			o.Fullfilled,
			o.DateAndTime,
			Price * OrderedQuantity AS [Sum]
		FROM Orders AS o
		JOIN OrderDetails AS od ON od.OrderID = o.OrderID
		JOIN TypesOfProduct AS tp ON tp.TypeID = od.TypeID
		WHERE Price * OrderedQuantity > @Sum
	END
END
GO

CREATE OR ALTER PROC usp_ProductByName (@Product VARCHAR(50))
AS
BEGIN
	SELECT
		tp.TypeID,
		tp.TypeName,
		a.AnimalName AS Animal,
		t.TypeOfTypeName AS TypeOfType,
		tp.Price
	FROM TypesOfProduct AS tp
	JOIN Animals AS a ON a.AnimalID = tp.AnimalID
	JOIN TypeOfType AS t ON t.TypeOfTypeID = tp.TypeOfTypeID
	WHERE TypeName LIKE CONCAT('%', @Product, '%')
END
GO

CREATE OR ALTER PROC usp_ProductByPriceRange (@MinPrice MONEY, @MaxPrice MONEY)
AS
BEGIN
	SELECT
		tp.TypeID,
		tp.TypeName,
		a.AnimalName AS Animal,
		t.TypeOfTypeName AS TypeOfType,
		tp.Price
	FROM TypesOfProduct AS tp
	JOIN Animals AS a ON a.AnimalID = tp.AnimalID
	JOIN TypeOfType AS t ON t.TypeOfTypeID = tp.TypeOfTypeID
	WHERE tp.Price BETWEEN @MinPrice AND @MaxPrice
END
GO

CREATE OR ALTER PROC usp_OrdersWithClientCard
AS
BEGIN
	SELECT CONCAT((COUNT(OrderID)*100)/(SELECT COUNT(OrderID) FROM Orders), '%') AS [OrdersWithClientCard]
	FROM Orders
	WHERE ClientCardID IS NOT NULL
END
GO

CREATE OR ALTER PROC usp_ProductsNotInStock
AS
BEGIN
	SELECT
		tp.TypeID,
		tp.TypeName,
		a.AnimalName AS Animal,
		t.TypeOfTypeName AS TypeOfType,
		tp.Price
	FROM TypesOfProduct AS tp
	JOIN Animals AS a ON a.AnimalID = tp.AnimalID
	JOIN TypeOfType AS t ON t.TypeOfTypeID = tp.TypeOfTypeID
	WHERE tp.AvailableQuantity = 0
END
GO

CREATE OR ALTER PROC usp_SumOfOrdersLastThreeMonths
AS
BEGIN
	SELECT
		CONCAT(SUM(Price * OrderedQuantity), ' BGN') AS [Total sum of orders for the last three months]
	FROM Orders AS o
	JOIN OrderDetails AS od ON od.OrderID = o.OrderID
	JOIN TypesOfProduct AS tp ON tp.TypeID = od.TypeID
	WHERE DATEDIFF(M, o.DateAndTime, GETDATE()) <= 3
END
GO

CREATE OR ALTER PROC usp_ClientsWhoUsedClientCard
AS
BEGIN
	SELECT
		c.ClientID,
		c.FirstName,
		C.LastName,
		c.PhoneNumber,
		c.ClientCardID
	FROM Clients AS c
	JOIN Orders AS o ON o.ClientCardID = c.ClientCardID
	GROUP BY
		c.ClientID,
		c.FirstName,
		c.LastName,
		c.PhoneNumber,
		c.ClientCardID
END
GO