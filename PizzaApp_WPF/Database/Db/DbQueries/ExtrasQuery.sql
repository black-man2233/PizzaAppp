--Drop Table Extras;
CREATE TABLE Extras(
   id     INTEGER  NOT NULL PRIMARY KEY 
  ,name   VARCHAR(8) NOT NULL
  ,price  INTEGER  NOT NULL
  ,amount INTEGER  NOT NULL
);
INSERT INTO Extras(id,name,price,amount) VALUES (1,'Annas',17,0);
INSERT INTO Extras(id,name,price,amount) VALUES (2,'Bacon',22,0);
INSERT INTO Extras(id,name,price,amount) VALUES (3,'Chili',3,0);
INSERT INTO Extras(id,name,price,amount) VALUES (4,'Dressing',17,0);


Select * From Extras