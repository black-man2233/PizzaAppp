CREATE TABLE Drinks(
   imageUrl          VARCHAR(95) NOT NULL PRIMARY KEY
  ,name              VARCHAR(11) NOT NULL
  ,price             INTEGER  NOT NULL
  ,description       VARCHAR(90) NOT NULL
  ,capacity0name     VARCHAR(5) NOT NULL
  ,capacity0price    INTEGER  NOT NULL
  ,capacity0selected VARCHAR(5) NOT NULL
  ,capacity1name     VARCHAR(6) NOT NULL
  ,capacity1price    INTEGER  NOT NULL
  ,capacity1selected VARCHAR(5) NOT NULL
  ,capacity2name     VARCHAR(5) NOT NULL
  ,capacity2price    INTEGER  NOT NULL
  ,capacity2selected VARCHAR(5) NOT NULL
);
INSERT INTO Drinks(imageUrl,name,price,description,capacity0name,capacity0price,capacity0selected,capacity1name,capacity1price,capacity1selected,capacity2name,capacity2price,capacity2selected) VALUES ('https://lyngenspizza.dk/wp-content/uploads/2018/02/kv_mineralvand.png','Kildevand',20,'Det er bare vand','small',18,'false','medium',20,'false','Large',40,'false');
INSERT INTO Drinks(imageUrl,name,price,description,capacity0name,capacity0price,capacity0selected,capacity1name,capacity1price,capacity1selected,capacity2name,capacity2price,capacity2selected) VALUES ('https://i.pinimg.com/originals/fd/44/db/fd44db55e70aafdfee35ed9b184b82db.png','Coca Cola',15,'Drikken indeholder ofte kulsyre, koffein, fosforsyre og karamel.','small',15,'false','medium',20,'false','Large',23,'false');
INSERT INTO Drinks(imageUrl,name,price,description,capacity0name,capacity0price,capacity0selected,capacity1name,capacity1price,capacity1selected,capacity2name,capacity2price,capacity2selected) VALUES ('https://www.fanta.com/content/dam/nagbrands/us/fanta/en/products/berry/can_12_berry_desktop.png','Fanta Berry',13,'Fanta Berry er en læskedrik med kulsyre og med frisk smag af blåbær og hindbær. Koffeinfri','small',8,'false','medium',15,'false','Large',20,'false');
INSERT INTO Drinks(imageUrl,name,price,description,capacity0name,capacity0price,capacity0selected,capacity1name,capacity1price,capacity1selected,capacity2name,capacity2price,capacity2selected) VALUES ('https://fadølslageret.dk/wp-content/uploads/2021/12/Faxe-Kondi-3.png','Faxe Kondi',10,'. Den indeholder glukose, også kaldet druesukker','small',8,'false','medium',15,'false','Large',20,'false');
INSERT INTO Drinks(imageUrl,name,price,description,capacity0name,capacity0price,capacity0selected,capacity1name,capacity1price,capacity1selected,capacity2name,capacity2price,capacity2selected) VALUES ('https://cdn.pixabay.com/photo/2018/03/06/18/00/liquor-3204101_960_720.png','Spiritus',49,'Alkoholiske drikkevarer med en alkoholprocent på over ca. 25%.','small',8,'false','medium',15,'false','Large',20,'false');
