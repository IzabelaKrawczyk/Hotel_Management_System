CREATE TABLE [dbo].[Address]
(
	[AddressId] INT NOT NULL PRIMARY KEY, 
    [StreetName] CHAR(10) NOT NULL, 
    [StreetNumber] INT NOT NULL, 
    [FlatNumber] CHAR(10) NULL, 
    [CityName] TEXT NOT NULL, 
    [PostalCode] CHAR(10) NOT NULL

)
