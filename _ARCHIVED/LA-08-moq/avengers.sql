IF OBJECT_ID('Avenger', 'U') IS NOT NULL DROP TABLE Avenger;

CREATE TABLE Avenger 
    (Name               VARCHAR(30),
     Gender              BIT,
     Superpower          BIT,
     Strength            NUMERIC(3),
  CONSTRAINT AVENGER_PRIMARY_KEY PRIMARY KEY (Name));

INSERT INTO Avenger VALUES ('Captain America',1,1,31);
INSERT INTO Avenger VALUES ('Thor',1,1,20);
INSERT INTO Avenger VALUES ('Black Widow',0,0,5);
INSERT INTO Avenger VALUES ('Scarlet Witch',0,1,18);
INSERT INTO Avenger VALUES ('Spider-Man',1,1,13);
INSERT INTO Avenger VALUES ('Ant-Man',1,0,9);
INSERT INTO Avenger VALUES ('Vision',1,1,17);
INSERT INTO Avenger VALUES ('Iron Man',1,0,16);
