CREATE TABLE Pizzas
(
  imageUrl VARCHAR(188) NOT NULL PRIMARY KEY
  ,
  id INTEGER NOT NULL
  ,
  description VARCHAR(186) NOT NULL
  ,
  name VARCHAR(18) NOT NULL
  ,
  price INTEGER NOT NULL
  ,
  total INTEGER NOT NULL
);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://www.onceuponachef.com/images/2020/06/Margherita-Pizza-1200x1707.jpg', 1, 'Med tomatsauce, dobbelt mozarella ost og oregano', 'Margherita', 76, 76);

INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://upload.wikimedia.org/wikipedia/commons/2/2a/Pizza_capricciosa.jpg', 2, 'Med tomatsauce, mozarella ost, oregano, skinke og champignon', 'Capricciosa', 52, 52);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://gastromand.dk/wordpress/wp-content/uploads/2019/08/hawaiipizza3-500x375.jpg', 3, 'Med tomatsauce, mozarella ost, oregano, skinke og ananas', 'Hawaii', 72, 72);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://assets.wsimgs.com/wsimgs/rk/images/dp/recipe/202244/0070/img50l.jpg', 4, 'Med tomatsauce, mozarella ost, oregano, skinke og bacon', 'Quatro stagioni', 84, 84);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://cdn-rdb.arla.com/Files/arla-se/346864562/ec1d37f4-4a57-4cd1-857e-d42bec162498.jpg?crop=(278,0,0,0)&amp;w=375&amp;h=265&amp;mode=crop&amp;ak=f525e733&amp;hm=4b574910', 5, 'NATURLI’ Pizza Vesuvio – når det skal være hurtigt og lækkert. Den skal nok få din pizzatand til at løbe i vand på rekordtid. Flyt den fra fryseren til mikroovnen. Vent 3 minutter. Nemt!', 'Vesuvio', 53, 53);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F19%2F2014%2F07%2F10%2Fpepperoni-pizza-ck-x.jpg&amp;q=60', 6, 'Stærk pizza med pepperoni, mozzarella, og tomatoes', 'Pepperoni', 14, 14);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://i0.wp.com/www.thursdaynightpizza.com/wp-content/uploads/2022/06/veggie-pizza-side-view-out-of-oven.png?resize=720%2C480&amp;ssl=1', 7, 'Vegetarian pizza med svampe, peberfrugter, løg, og olives', 'Vegetarian', 13, 13);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://media-cdn.tripadvisor.com/media/photo-s/17/4c/19/39/pizza-pescatora.jpg', 8, 'Med tomatsauce, mozarella ost, oregano, skinke og pepperoni', 'Solo mio', 76, 76);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg', 9, 'Med tomatsauce, mozarella ost, oregano, pepperoni, løg og champignon', 'Napoli', 52, 52);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://www.vegplatter.in/files/public/images/partner/catalog/125/Italiano%20Pizza.jpg', 10, 'Med tomatsauce, mozarella ost, oregano, kødsauce, champignon, løg, chili og hvidløg', 'Italiano', 72, 72);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://www.ruokaonvalmis.com/wp-content/uploads/2022/05/gorgonzolaandwalnutpizza-resized.jpg', 11, 'Med tomatsauce, mozarella ost, oregano, kebab, champignon, gorgonzola og løg', 'Gorgonzola', 84, 84);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://www.dengroenneslagter.dk/media/208780/dgs-pizza-med-kyllingebryst-og-gule-cherrytomater.jpg?anchor=center&amp;mode=crop&amp;width=640&amp;height=640&amp;rnd=133016090290000000', 12, 'Med tomatsauce, mozarella ost, oregano, champignon, bacon og kødfars', 'Gülle', 53, 53);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://mambeno.dk/wp-content/uploads/2020/08/Vegetarpizza-med-loeg-peberfrugt-og-champignon-scaled.jpg', 13, 'Med tomatsauce, mozarella ost, oregano, champignon, løg, ananas, falaffel og rød peber', 'Vegetar', 14, 14);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://sundmad.net/wp-content/uploads/2016/01/Rodfrugtpizza-1-1000x675.jpg', 14, 'Med tomatsauce, mozarella ost, oregano, kebab, champignon, løg og pepperoni', 'Herli', 13, 13);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://slicelife.imgix.net/12043/photos/original/61819962_832497507127534_6985189374031822848_o.jpg?auto=compress&amp;auto=format', 15, 'Med tomatsauce, mozarella ost, oregano, spaghetti, kødsauce og cocktailpølser', 'Milano', 76, 76);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://images.squarespace-cdn.com/content/v1/5702d655746fb9634798af7c/1536782460678-KRN6R2FCHYB0R4N91NTP/IMG_1899.JPG?format=1500w', 16, 'Med tomatsauce, mozarella ost, oregano, kebab, champignon, løg, chili, hvidløg og dressing før ovn', 'Josef', 52, 52);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://www.sargento.com/assets/Uploads/Recipe/Image/702-Pizza_Mexicana__FillWzExNzAsNTgzXQ.jpg', 17, 'Med tomatsauce, mozarella ost, oregano, kødfars, bacon, løg, champignon og chili', 'Mexicano', 72, 72);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://static.wixstatic.com/media/d203f6_a647fb37c02c4282b53b9ca81ff2c114~mv2.jpg/v1/fill/w_640,h_582,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/d203f6_a647fb37c02c4282b53b9ca81ff2c114~mv2.jpg', 18, 'Med tomatsauce, mozarella ost, oregano, kødfars, skinke og bacon', 'Sicilie', 84, 84);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://images.deliveryhero.io/image/fd-op/LH/v2up-hero.jpg', 19, 'Med tomatsauce, mozarella ost, oregano, kylling, bacon, pepperoni og hvidløg', 'Titanic', 53, 53);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://mambeno.dk/wp-content/uploads/2017/09/Pizza-med-kylling-og-portobello.jpg', 20, 'Med tomatsauce, mozarella ost, oregano, kylling, ananas, champignon, løg og karry', 'Kylling pizza', 14, 14);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://lh3.googleusercontent.com/p/AF1QipNKuknbIH1AR5BN8JLpdKwiN7hg5mUXL6gXaHKe=w768-h768-n-o-v1', 21, 'Med tomatsauce, mozarella ost, oregano, kødfars, pommes frites, chili, hvidløg, dressing og rød dressing', 'Chaplin', 13, 13);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://pyzamadeinpoland.pl/wp-content/uploads/2020/03/barese-12-1190x793.jpg', 22, 'Med tomatsauce, mozarella ost, oregano, kødfars, pepperoni, champignon, løg, chili og hvidløg', 'Bari', 76, 76);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://sason.dk/File/128/4.jpg?ticks=637896888200000000', 23, 'Med tomatsauce, mozarella ost, oregano, kødfars, kebab og pepperoni', 'Botan', 52, 52);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('http://3.bp.blogspot.com/-5BhCCfmsldE/UA5JGxSPmbI/AAAAAAAAY3c/rHS9XS0JUrA/s1600/2012-07-23%2B18.26.25.jpg', 24, 'Med tomatsauce, mozarella ost, oregano, kebab, rød peber, sucuk, løg, chili og hvidløg', 'Super stærk', 72, 72);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://assets.website-files.com/61903595abdd6862e1d4ae00/61906f60130a2bbc1232b0c9_amalfi-pizza-mushroom.jpg', 25, 'Med tomatsauce, mozarella ost, oregano, kødsauce, bacon, pepperoni, løg og rød peber', 'Amalfi', 84, 84);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://media-cdn.tripadvisor.com/media/photo-s/17/30/5c/1c/photo0jpg.jpg', 26, 'Med tomatsauce, mozarella ost, oregano, skinke, pepperoni, bacon og cocktailpølser', 'Nico', 53, 53);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://realfood.tesco.com/media/images/1400x919-Cheats-mushroom-pizza-9952318c-cb77-422d-8af6-4246d0b491b7-0-1400x919.jpg', 27, 'Med tomatsauce, mozarella ost, oregano, kødfars, sucuk, løg, dressing før ovn og chili', 'Oliver', 14, 14);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://altidmonalisa.dk/wp-content/uploads/2021/08/HUSETS-PIZZA.jpg', 28, 'Med tomatsauce, mozarella ost, oregano, kebab, kylling, sucuk, dressing før ovn', 'Husets', 13, 13);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://spiseguidenaarhus.dk/wp-content/uploads/2021/12/San-Mario-Pizzaria-4-1024x576.jpg', 29, 'Med tomatsauce, mozarella ost, oregano, kødfars, cocktailpølser, pepperoni og bacon', 'Omario', 76, 76);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://howtothisandthat.com/wp-content/uploads/2018/03/keto-diet-tips-2.png', 30, 'Med tomatsauce, mozarella ost, oregano, kebab, pepperoni, bacon, jalapeños, chili og hvidløg', 'Jalapeño', 52, 52);
INSERT INTO Pizzas
  (imageUrl,id,description,name,price,total)
VALUES
  ('https://popmenucloud.com/cdn-cgi/image/width%3D1200%2Cheight%3D1200%2Cfit%3Dscale-down%2Cformat%3Dauto%2Cquality%3D60/oyxtwnas/10ef1dda-1a32-42f4-92d7-b6961c555366.jpeg', 31, 'Med tomatsauce, mozarella ost, oregano, skinke, kebab, kødsauce, løg, rød peber og chili', 'Amerikansk (stærk)', 72, 72);
