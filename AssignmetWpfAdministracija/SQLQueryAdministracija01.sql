CREATE TABLE Users(
Id int IDENTITY(1,1) PRIMARY KEY,
UserName nvarchar(20) NOT NULL,
UserPass nvarchar (20) NOT NULL,
IsAdmin bit NOT NULL
);

INSERT INTO Users VALUES
('Peter', 'Parker', 1);
INSERT INTO Users VALUES
('Tony', 'Stark', 0);
INSERT INTO Users VALUES
('Bary', 'Alan', 0);


SELECT * FROM Users