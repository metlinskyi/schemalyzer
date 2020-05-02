USE [A]
GO
DECLARE @UserId UNIQUEIDENTIFIER
DECLARE @ProfileId UNIQUEIDENTIFIER
DECLARE @ContactId UNIQUEIDENTIFIER

INSERT INTO [Dictionary].[GenderType] 
([Key],[Value])
VALUES
(0,'Undefined'),
(1,'Male'),
(2,'Female');

INSERT INTO [Dictionary].[ContactType] 
([Key],[Value])
VALUES
(0,'Undefined'),
(1,'Phone'),
(2,'Email');

SET @ProfileId = NEWID()        
INSERT INTO [Data].[Profile] 
([Id], [FirstName], [LastName], [DateOfBirth], [Gender])
VALUES 
(@ProfileId, 'Roman', 'Metlinskyi', '2-Oct-1980', 1);

SET @UserId = NEWID()        
INSERT INTO [Entity].[User]
([Id], [ProfileId])
VALUES 
(@UserId, @ProfileId);

SET @ContactId = NEWID() 
INSERT INTO [Data].[Contact] 
([Id], [Type], [Value])
VALUES 
(@ContactId, 1, '+420704916942');

INSERT INTO [Entity].[UserContact]
([UserId], [ContactId])
VALUES 
(@UserId, @ContactId);

SET @ContactId = NEWID() 
INSERT INTO [Data].[Contact] 
([Id], [Type], [Value])
VALUES 
(@ContactId, 2, 'gmail@metlinskyi.com');

INSERT INTO [Entity].[UserContact]
([UserId], [ContactId])
VALUES 
(@UserId, @ContactId);




