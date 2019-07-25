CREATE DATABASE linktrixDb

CREATE TABLE Customers
(
	customerId bigint NOT NULL PRIMARY KEY,
	customerName varchar(30),
	birthdate datetime, 
	contactEmail varchar(25),
	mobileNumber bigint,
);

CREATE TABLE CustomerTransactions
(
	transactionId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	customerId bigint,
	transactionDatetime datetime, 
	amount decimal(17,2),
	currencyCode varchar(3),
	status varchar(10),
	CONSTRAINT FK_Customer FOREIGN KEY (customerID) REFERENCES Customers(customerId)
);

INSERT INTO Customers(customerId, customerName, birthdate, contactEmail, mobileNumber) VALUES (123456, 'Aditya Nugraha', '1991-01-20', 'adityanugraha@gmail.com', 6281231234);
INSERT INTO Customers(customerId, customerName, birthdate, contactEmail, mobileNumber) VALUES (123457, 'Johnny Welch', '1951-06-07', 'JohnnyWelch@gmail.com', 7272072858);
INSERT INTO Customers(customerId, customerName, birthdate, contactEmail, mobileNumber) VALUES (123458, 'Danielle Chang', '1962-03-18', 'DanielleJChang@gmail.com', 9142024512);
INSERT INTO Customers(customerId, customerName, birthdate, contactEmail, mobileNumber) VALUES (123459, 'Paula Taylor', '1988-11-30', 'PaulaTaylor@gmail.com', 6108144644);
INSERT INTO Customers(customerId, customerName, birthdate, contactEmail, mobileNumber) VALUES (123460, 'David Beavers', '1970-01-12', 'DavidBeavers@gmail.com', 8014837972);

INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123456, '2019-02-01', 1234.89, 'USD', 'Success');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123456, '2019-02-06', 100.00, 'USD', 'Canceled');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123456, '2019-02-07', 100.00, 'USD', 'Success');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123456, '2019-04-25', 59.99, 'USD', 'Failed');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123458, '2019-03-25', 69.69, 'SGD', 'Success');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123458, '2019-05-05', 8.50, 'SGD', 'Failed');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123459, '2019-01-01', 500000, 'IDR', 'Failed');
INSERT INTO CustomerTransactions(customerId, transactionDatetime, amount, currencyCode, status) VALUES (123460, '2019-01-01', 500000, 'IDR', 'Success');
