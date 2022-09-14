USE [RwaApartmani]
GO


--Postavljanje admin usera u bazu
insert into AspNetUsers(Guid,CreatedAt,Address,Email,PhoneNumber,EmailConfirmed,PhoneNumberConfirmed,LockoutEnabled,AccessFailedCount,UserName,PasswordHash)
values (NEWID(),GETDATE(),'admin ulica','admin@admin.com','091 0911 091',1,1,0,0,'admin admin','c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec')
go

insert into AspNetUsers(Guid,CreatedAt,Address,Email,PhoneNumber,EmailConfirmed,PhoneNumberConfirmed,LockoutEnabled,AccessFailedCount,UserName,PasswordHash)
values (NEWID(),GETDATE(),'test ulica','test@test.com','00 0900 090',1,1,0,0,'test test','c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec')
go



  /*Ciscenje slika iz baze*/
  delete ApartmentPicture

  /*UBACIVANJE SLIKA*/

  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),1,'/Images/PlaviB01.jpg','Hodnik',1)
  go
  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),1,'/Images/PlaviB02.jpg','Terasa',0)
  go
  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),1,'/Images/PlaviB03.jpg','Plaza',0)
  go

  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),2,'/Images/ZeleniB01.jpg','Spavaca',1)
  go
  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),2,'/Images/ZeleniB02.jpg','Dnevna',0)
  go
  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),2,'/Images/ZeleniB03.jpg','Kuhinja',0)
  go
    
  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),3,'/Images/BiliB01.jpg','WC',1)
  go

  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),3,'/Images/BiliB02.jpg','Dvoriste',0)
  go
  insert into ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Name, IsRepresentative)
  values(NEWID(),GETDATE(),3,'/Images/BiliB03.jpg','Kuca',0)
  go


-- APARTMENT

CREATE or alter PROCEDURE [dbo].[GetAllApartments]
AS
SELECT Id, CreatedAt, Address, OwnerId, StatusId, CityId, Address, Name, NameEng, CONVERT(int, Price) AS Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance
FROM Apartment
where DeletedAt is null
GO


CREATE or alter PROCEDURE [dbo].[GetApartmentByID]
@ID int
as
SELECT Id, CreatedAt, Address, OwnerId, StatusId, CityId, Address, Name, NameEng, CONVERT(int, Price) AS Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance
FROM Apartment WHERE Id = @ID
GO


CREATE or alter PROCEDURE GetAllApartmentsByStatusId
@statusId int
as
SELECT Id, CreatedAt, Address, OwnerId, StatusId, CityId, Address, Name, NameEng, CONVERT(int, Price) AS Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance
from Apartment 
where StatusId=@statusId and DeletedAt is null
GO


create OR ALTER procedure [dbo].[CreateApartment]
  @nameENG nvarchar(50),
  @price int,
  @maxAdults int,
  @maxChildren int,
  @totalRooms int,
  @beachDistance nvarchar(50),
  @cityID int,
  @ownerID int,
  @address nvarchar(150),
  @statusId int
  as
  insert into Apartment(Guid,Name,NameEng,Price,MaxAdults,MaxChildren,
  TotalRooms,BeachDistance,CityId,OwnerId, TypeId, StatusId, Address,
  CreatedAt)
  values (NEWID(), @nameENG, @nameENG,CONVERT(int, @price),@maxAdults,@maxChildren,@totalRooms,@beachDistance,@cityID,@ownerID,999,@statusId, @address,getdate())
GO


CREATE OR ALTER PROCEDURE [dbo].[UpdateApartment]
@nameEng nvarchar(50),
@maxChildren int,
@maxAdults int,
@beachDistance int,
@price int,
@statusID int,
@OwnerId int,
@Rooms int,
@apartmentID int,
@address nvarchar(80)
AS
update Apartment
set NameEng = @nameEng, MaxChildren = @maxChildren, MaxAdults = @maxAdults, BeachDistance = @beachDistance, Price = CONVERT(int, @price),
	StatusId = @statusID, OwnerId = @OwnerId, TotalRooms = @Rooms, Address=@address
where Id = @apartmentID
GO


CREATE or alter PROCEDURE [dbo].[DeleteApartment]
@apartmentId int
as
update Apartment
set DeletedAt = GETDATE()
where Id = @apartmentId
GO


create or alter procedure GetApartmentId
@name nvarchar(50),
@address nvarchar(50),
@rooms int,
@adults int,
@children int
as
select [Name], [Address],Id
from Apartment
where [Name]=@name and [Address]=@address and TotalRooms=@rooms and MaxChildren=@children and MaxAdults=@adults
go


--		TAGS

CREATE or alter PROCEDURE [dbo].[LoadAllTags]
as
SELECT t.Id, t.Name, t.NameEng, tt.Id as 'TagTypeID', tt.Name as 'TagTypeName', tt.NameEng from Tag as t
INNER JOIN TagType as tt on t.TypeId = tt.Id 
GO


CREATE or alter procedure [dbo].[GetTypeNameEng]
@typeID int
as
select TagType.NameEng
from TagType
where Id = @typeID
GO


CREATE or alter PROCEDURE [dbo].[GetUsedTags]
@Id int
as
select count(*) as 'Used'
from TaggedApartment
where TagId = @Id
GO


CREATE or alter PROCEDURE [dbo].[GetTags]
as
select Id, [NameEng] 
from Tag
GO


CREATE or alter PROCEDURE [dbo].[LoadAllTagTypes]
AS
SELECT NameEng as 'TagTypeNameEng'
FROM TagType
GO


CREATE or ALTER PROCEDURE [dbo].[GetApartmentTags]
@Id INT
AS
SELECT t.Id,t.Name, t.NameEng, tt.NameEng AS 'TagTypeNameEng', tt.Id as 'TagTypeID'
FROM TaggedApartment AS ta
INNER JOIN Tag AS t ON ta.TagId = t.Id
INNER JOIN Apartment AS a ON ta.ApartmentId = a.Id
INNER JOIN TagType AS tt ON t.TypeId = tt.Id
WHERE a.Id = @Id	
GO


CREATE or alter PROCEDURE [dbo].[AddNewTag]
@nameEng nvarchar(30), 
@typeID INT
as 
insert into Tag([NameEng],[Name], [TypeId], [CreatedAt] , [Guid])
values (@nameEng,@nameEng, @typeID, GETDATE(), NEWID())
GO


CREATE or alter PROCEDURE [dbo].[DeleteTag]
@Id int
as
delete from Tag
where Id=@Id
GO


CREATE or alter PROCEDURE [dbo].[DeleteApartmentTagByID]
@tagID INT,
@apartmentID INT
AS
DELETE from TaggedApartment
where @apartmentID = ApartmentId and @tagID = TagId
GO


CREATE or alter  PROCEDURE [dbo].[AddNewTagToApartment]
@tagID INT,
@apartmentID INT,
@guid uniqueidentifier 
AS
insert into TaggedApartment (TagId,ApartmentId, Guid) values (@tagID,@apartmentID, @guid)
GO


CREATE OR ALTER   PROCEDURE [dbo].GetUnusedTagsOnApartment
@apartmentID INT
AS
select t.Id, t.NameEng, tt.NameEng as 'TagTypeNameEng', tt.Id as 'TagTypeID' from tag AS t
inner join TagType as tt on tt.Id = t.TypeId
where t.Id not in(select TaggedApartment.TagId from TaggedApartment where TaggedApartment.ApartmentId = @apartmentID) 
GO



--		USER - ADMIN

CREATE OR ALTER PROCEDURE [dbo].[GetAllUsers]
AS
SELECT * FROM AspNetUsers
WHERE DeletedAt IS NULL
GO


CREATE or alter PROCEDURE [dbo].[GetUserByID]
@apartmentId INT
AS
SELECT ar.UserId as 'Id', au.UserName as 'UserName', ar.Details as 'Details'
FROM ApartmentReservation as ar
inner join AspNetUsers as au on ar.UserId=au.Id
WHERE ApartmentId = @apartmentId and UserId is not null
GO


create or alter procedure GetUnregisteredUser
@apartmentId int
as
select UserName, UserEmail as 'Email', UserPhone as 'PhoneNumber', Details, UserAddress as 'Address'
from ApartmentReservation
where ApartmentId=@apartmentId and UserId is null
go


CREATE or alter PROC [dbo].[AuthUser]
	@username NVARCHAR(50),
	@password NVARCHAR(128)
AS
BEGIN
	SELECT * FROM AspNetUsers WHERE Username=@username AND PasswordHash=@password AND DeletedAt IS NULL
END
GO

--	User - Public

CREATE OR ALTER PROCEDURE CreateUser
@email nvarchar(50),
@username nvarchar(50),
@passwordHash nvarchar(max),
@address nvarchar(50),
@phonenumber nvarchar(20)
as 
insert into AspNetUsers(Guid, CreatedAt,Email,UserName,PasswordHash, Address, PhoneNumber,EmailConfirmed, PhoneNumberConfirmed, LockoutEnabled, AccessFailedCount)
values (NEWID(),GETDATE(),@email,@username,@passwordHash,@address,@phonenumber,1,1,0,0)
go


-- Apartment reservation

create or alter procedure CreateApartmentReservationById
@registeredUserId int,
@apartmentId int,
@details nvarchar(max)
as
insert into ApartmentReservation(Guid, CreatedAt, ApartmentId, UserId,Details)
values (NEWID(),GETDATE(),@apartmentId,@registeredUserId,@details)
go


create or alter procedure CreateApartmentReservation
@apartmentId int,
@username nvarchar(50),
@email nvarchar(50),
@phonenumber nvarchar(50),
@address nvarchar(50),
@details nvarchar(max)
as
insert into ApartmentReservation(Guid, CreatedAt, ApartmentId,UserName,UserEmail,UserPhone, UserAddress,Details )
values (NEWID(),GETDATE(),@apartmentId,@username,@email,@phonenumber, @address,@details)
go

create or alter procedure DeleteApartmentReservation
@apartmentId int
as 
delete ApartmentReservation
where ApartmentId=@apartmentId
go


create or alter procedure UpdateApartmentReservation
@apartmentId int,
@details nvarchar(max),
@username nvarchar(50),
@phonenumber nvarchar(50),
@email nvarchar(50),
@address nvarchar(50)
as 
update ApartmentReservation
set UserAddress=@address,UserEmail=@email, UserName=@username, UserPhone=@phonenumber,Details=@details
where ApartmentId=@apartmentId and UserId is null
go


create or alter procedure UpdateApartmentReservationByUserId
@apartmentId int,
@details nvarchar(max),
@userId int
as 
update ApartmentReservation
set Details=@details, UserId=@userId
where ApartmentId=@apartmentId and UserId is not null
go



create or alter procedure CreateNewPublicReservation
@apartmentId int,
@username nvarchar(50),
@email nvarchar(50),
@phone nvarchar(50),
@details nvarchar(max)
as
insert into ApartmentReservation(Guid, CreatedAt, ApartmentId, Details, UserName, UserEmail, UserPhone)
values(NEWID(),GETDATE(),@apartmentId,@details,@username,@email,@phone)
go


 --			STATUSES

CREATE or alter  PROCEDURE [dbo].[GetApartmentStatus]
@apartmentId int
as 
select StatusId
from Apartment
where Id=@apartmentId
GO


CREATE OR ALTER PROCEDURE GetStatuses
as
select *
from ApartmentStatus
go


--		CITY

CREATE or alter PROC [dbo].[GetCityByID]
@id int
AS
SELECT * FROM City WHERE Id = @id
GO


CREATE or alter PROCEDURE [dbo].[GetAllCities]
AS
SELECT Id,[Name]
FROM City 
GO


--	Apartment owners 

CREATE or alter PROCEDURE [dbo].GetApartmentOwnerById
@ID int
as
SELECT Id, Name
FROM [dbo].[ApartmentOwner] WHERE Id = @ID
GO

CREATE or alter PROCEDURE [dbo].[GetApartmentOwners]
AS
SELECT Id, [Name]
FROM dbo.ApartmentOwner
GO



--		APARTMENTS PICTURES

CREATE or alter  PROCEDURE [dbo].[GetApartmentPicturesByID]
@id int
AS
SELECT * FROM ApartmentPicture
WHERE ApartmentId = @id AND DeletedAt is null
GO


create or alter procedure [dbo].[AddPictures]
@apartmentId int,
@path nvarchar(max)
as
insert into ApartmentPicture(ApartmentId,Path,Name,CreatedAt,Guid)
values (@apartmentId,@path,'Slika',GETDATE(),NEWID())
GO


create or alter procedure [dbo].[GetNumberOfApartmentPictures]
@apartmentId int
as 
select COUNT(*) as 'NumberOfPictures' from ApartmentPicture
where ApartmentId = @apartmentId AND DeletedAt is null
GO


CREATE or ALTER PROCEDURE [dbo].[SetRepresentativePicture]
@apartmentId int,
@imgId int
AS
update ApartmentPicture
set IsRepresentative = 0
where ApartmentId = @apartmentId
update ApartmentPicture
set IsRepresentative = 1
where Id = @imgId
GO


create or alter procedure [dbo].[DeleteApartmentPictureByID]
@pictureID int
AS
UPDATE ApartmentPicture
SET DeletedAt=GETDATE()
where Id = @pictureID
GO


create or alter procedure GetImagePath
@imageId int
as
select Id, Path
from ApartmentPicture
where Id=@imageId
go


CREATE OR ALTER PROCEDURE GetApartmentPictures  -- Public procedure
as
select * 
from ApartmentPicture
where DeletedAt is null
go


--		Review

create or alter procedure CreateNewReview
@userId int,
@numberOfStars int,
@description nvarchar(max),
@apartmentId int
as
insert into ApartmentReview(Guid, CreatedAt, ApartmentId, UserId, Details, Stars)
values (NEWID(),GETDATE(),@apartmentId,@userId,@description,@numberOfStars)
GO


create or alter procedure GetReview
@apartmentId int
as 
select *
from ApartmentReview
where ApartmentId=@apartmentId
go