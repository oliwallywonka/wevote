


CREATE TABLE Country (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    CountryName NVARCHAR(20) NOT NULL,
    CurrencyCode NVARCHAR(3) NOT NULL,
    CurrencyName NVARCHAR(20) NOT NULL,
    CurrencySymbol NVARCHAR(5) NOT NULL
);

CREATE TABLE Visit (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    CountryId UNIQUEIDENTIFIER NOT NULL,
    Ip NVARCHAR(45) NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Country(Id) ON DELETE CASCADE
);