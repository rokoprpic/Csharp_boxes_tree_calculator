CREATE DATABASE videoteka;
go

USE videoteka;
go

CREATE TABLE Članovi (
  ID INT PRIMARY KEY,
  Naziv VARCHAR(255),
  Adresa VARCHAR(255),
  Kontakt VARCHAR(255),
  DatumUčlanjenja DATE,
  Status VARCHAR(255)
);

CREATE TABLE Filmovi (
  ID INT PRIMARY KEY,
  Naziv VARCHAR(255),
  Žanr VARCHAR(255),
  Godina INT,
  Status VARCHAR(255)
);

CREATE TABLE Posudbe (
  ID INT PRIMARY KEY,
  ČlanID INT,
  FilmID INT,
  DatumPosudbe DATE,
  DatumPovratka DATE,
  VremenskiRok INT,
  FOREIGN KEY (ČlanID) REFERENCES Članovi(ID),
  FOREIGN KEY (FilmID) REFERENCES Filmovi(ID)
);

CREATE TABLE PovijestPosudbi (
  ID INT PRIMARY KEY,
  ČlanID INT,
  FilmID INT,
  DatumPosudbe DATE,
  DatumPovratka DATE,
  VremenskiRok INT,
  FOREIGN KEY (ČlanID) REFERENCES Članovi(ID),
  FOREIGN KEY (FilmID) REFERENCES Filmovi(ID)
);

go

-- Ispisati sve filmove žanra "Akcija" (SELECT): --
SELECT * FROM Filmovi WHERE Žanr = 'Akcija';

-- Ispisati sve posuđene filmove žanra "Akcija" (SELECT): --
SELECT Filmovi.* FROM Filmovi
JOIN Posudbe ON Filmovi.ID = Posudbe.FilmID
WHERE Filmovi.Žanr = 'Akcija';

-- Ažurirati žanr svih filmova starijih od 1980. na žanr "Klasika" (UPDATE): --
UPDATE Filmovi SET Žanr = 'Klasika' WHERE Godina < 1980;

-- Evidentirati povijest posudbe X na dan vraćanja filma u tablicu PovijestPosudbi (INSERT+SELECT) i obrisati posudbu X iz tablice Posudbe (DELETE): --
INSERT INTO PovijestPosudbi (ČlanID, FilmID, DatumPosudbe, DatumPovratka, VremenskiRok)
SELECT ČlanID, FilmID, DatumPosudbe, DatumPovratka, VremenskiRok FROM Posudbe WHERE ID = X;
DELETE FROM Posudbe WHERE ID = X;

-- Ažurirati status svih članova na status "Frequent" koji imaju arhivirano više od 50 posudbi (UPDATE): --
UPDATE Članovi SET Status = 'Frequent'
WHERE ID IN (SELECT ČlanID FROM Posudbe GROUP BY ČlanID HAVING COUNT(*) > 50);