CREATE TABLE IF NOT EXISTS person (
  Id bigint NOT NULL AUTO_INCREMENT,
  FirstName varchar(80) NOT NULL,
  LastName varchar(80) NOT NULL,
  Address varchar(100) NOT NULL,
  Gender varchar(80) NOT NULL,
  PRIMARY KEY (Id)
) 