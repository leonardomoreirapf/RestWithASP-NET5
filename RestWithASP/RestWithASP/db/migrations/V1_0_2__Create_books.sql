CREATE TABLE IF NOT EXISTS books (
  Id bigint NOT NULL AUTO_INCREMENT,
  Title varchar(80) NOT NULL,
  Author varchar(80) NOT NULL,
  Price decimal NOT NULL,
  LauchDate DateTime NOT NULL,
  PRIMARY KEY (Id)
) 