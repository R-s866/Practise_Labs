﻿DROP DATABASE IF EXISTS PensDb

CREATE DATABASE PensDb

CREATE TABLE Pens(
	PenId INT NOT NULL IDENTITY PRIMARY KEY,
	PenType VARCHAR(30) NULL,
	InkColor VARCHAR(30) NULL
)

INSERT INTO Pens VALUES ('Quil', 'Black')
INSERT INTO Pens VALUES ('Biro', 'Black')
INSERT INTO Pens VALUES ('Biro', 'blue')
INSERT INTO Pens VALUES ('Biro', 'green')
INSERT INTO Pens VALUES ('Fountain', 'Black')
INSERT INTO Pens VALUES ('Fountain', 'Blue')
INSERT INTO Pens VALUES ('Fountain', 'Blue')