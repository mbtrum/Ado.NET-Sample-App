namespace AdoDotNet.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}

/*******************************
 
CREATE DATABASE FriendsDb;
GO

USE FriendsDb;
GO

CREATE TABLE dbo.Friend
(
    Id        INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50)      NOT NULL,
    LastName  NVARCHAR(50)      NOT NULL
);
GO

*******************************/
