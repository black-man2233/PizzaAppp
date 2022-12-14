CREATE TABLE Toppings
(
  Toppings0id INTEGER NOT NULL PRIMARY KEY 
  ,
  Toppings0name VARCHAR(10) NOT NULL
  ,
  Toppings0selected VARCHAR(4) NOT NULL
  ,
  Toppings1id INTEGER NOT NULL
  ,
  Toppings1name VARCHAR(3) NOT NULL
  ,
  Toppings1selected VARCHAR(4) NOT NULL
  ,
  Toppings2id INTEGER NOT NULL
  ,
  Toppings2name VARCHAR(7) NOT NULL
  ,
  Toppings2selected VARCHAR(4) NOT NULL
  ,
  Toppings3id INTEGER 
  ,
  Toppings3name VARCHAR(6)
  ,
  Toppings3selected VARCHAR(4)
  ,
  Toppings4id INTEGER 
  ,
  Toppings4name VARCHAR(10)
  ,
  Toppings4selected VARCHAR(4)
);
INSERT INTO Toppings
  (Toppings0id,Toppings0name,Toppings0selected,Toppings1id,Toppings1name,Toppings1selected,Toppings2id,Toppings2name,Toppings2selected,Toppings3id,Toppings3name,Toppings3selected,Toppings4id,Toppings4name,Toppings4selected)
VALUES
  (1, 'TomatSauce', 'true', 1, 'Ost', 'true', 1, 'Oregano', 'true', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO Toppings
  (Toppings0id,Toppings0name,Toppings0selected,Toppings1id,Toppings1name,Toppings1selected,Toppings2id,Toppings2name,Toppings2selected,Toppings3id,Toppings3name,Toppings3selected,Toppings4id,Toppings4name,Toppings4selected)
VALUES
  (2, 'TomatSauce', 'true', 2, 'Ost', 'true', 2, 'Oregano', 'true', 2, 'Skinke', 'true', NULL, NULL, NULL);
INSERT INTO Toppings
  (Toppings0id,Toppings0name,Toppings0selected,Toppings1id,Toppings1name,Toppings1selected,Toppings2id,Toppings2name,Toppings2selected,Toppings3id,Toppings3name,Toppings3selected,Toppings4id,Toppings4name,Toppings4selected)
VALUES
  (3, 'TomatSauce', 'true', 3, 'Ost', 'true', 3, 'Oregano', 'true', 3, 'Skinke', 'true', 3, 'Champignon', 'true');
INSERT INTO Toppings
  (Toppings0id,Toppings0name,Toppings0selected,Toppings1id,Toppings1name,Toppings1selected,Toppings2id,Toppings2name,Toppings2selected,Toppings3id,Toppings3name,Toppings3selected,Toppings4id,Toppings4name,Toppings4selected)
VALUES
  (4, 'TomatSauce', 'true', 4, 'Ost', 'true', 4, 'Oregano', 'true', 4, 'Skinke', 'true', 4, 'Annas', 'true');
INSERT INTO Toppings
  (Toppings0id,Toppings0name,Toppings0selected,Toppings1id,Toppings1name,Toppings1selected,Toppings2id,Toppings2name,Toppings2selected,Toppings3id,Toppings3name,Toppings3selected,Toppings4id,Toppings4name,Toppings4selected)
VALUES
  (5, 'TomatSauce', 'true', 5, 'Ost', 'true', 5, 'Oregano', 'true', 5, 'Skinke', 'true', 5, 'Bacon', 'true');
