# CentroDePreguntasApi

Breve descripción de lo que hace tu proyecto.

Esta es el backedn con c# asp Net Core para nuestra aplicación web que nos permitiria crear un usuario e iniciar sesión con nuestras credenciales, también podremos crear preguntas y responder preguntas de otros usuarios, cuando la preguntas ya esté contestada, de modo que ya no acepte más respuestas.


## Requisitos previos

1. [.NET SDK](https://dotnet.microsoft.com/) (versión utilizada: 8.0.401)
2. [SQL Server](https://www.microsoft.com/en-us/sql-server) (Docker con SQL Server)
3. [Visual Studio Code](https://code.visualstudio.com/) con extensiones para C#

 ## Configuración del proyecto
1. Clonar el repositorio
```bash
git clone https://github.com/eduardom-34/CentroDePreguntasApi



 1. Correr configurar el DBConnection que está ubicado en appsettings.json, configuarlo para la red local se su maquina
 2. Hacer las migraciones y updates para crear las tablas
 4. En sql server, correr los siguientes scripts para crear los stored procedures:

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAnswer]
    @Content NVARCHAR(MAX),
    @UserId INT,
    @QuestionId INT
AS
BEGIN
    INSERT INTO Answers (Content, CreatedAt, UserId, QuestionId)
    VALUES (@Content, GETDATE(), @UserId, @QuestionId);

END;
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @UserName NVARCHAR(50),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PasswordHash VARBINARY(MAX),
    @PasswordSalt VARBINARY(MAX)
AS
BEGIN

    INSERT INTO Users (UserName, FirstName, LastName, PasswordHash, PasswordSalt)
    VALUES (@UserName, @FirstName, @LastName, @PasswordHash, @PasswordSalt);
END
GO

**************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUserExists]
    @UserName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT * FROM Users WHERE UserName = @UserName;

END
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUsernameAvailability]
    @UserName NVARCHAR(100)
AS
BEGIN
    SELECT UserName
    FROM Users
    WHERE UserName = @UserName
END
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateQuestion]
@Content NVARCHAR(max), @UserId int
AS
BEGIN
    
    insert into Questions(Content, UserId, CreatedAt, IsClosed)
    VALUES(@Content, @UserId, GETDATE(), 0)
END
GO

**************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Users
    WHERE UserId = @UserId;
END;
GO

**************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAnswers]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        a.AnswerId,
        a.Content,
        a.CreatedAt,
        a.UserId,
        u.UserName AS UserName,
        a.QuestionId
    FROM 
        Answers a
    INNER JOIN 
        Users u ON a.UserId = u.UserId
    INNER JOIN 
        Questions q ON a.QuestionId = q.QuestionId
    ORDER BY 
        a.CreatedAt DESC; 
END;
GO

**************************************


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllQuestions]
AS
BEGIN
    SELECT 
    q.QuestionId,
    q.Content,
    q.CreatedAt,
    q.IsClosed,
    q.UserId,
    u.FirstName,
    u.LastName,
    u.UserName
    
    from Questions q

INNER JOIN
users u ON q.UserId = u.UserId
ORDER BY
q.CreatedAt DESC
END
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SELECT * FROM Users
END
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAnswersByQuestionId]
    @QuestionId INT
AS
BEGIN
    SELECT 
        A.AnswerId,
        A.Content,
        A.CreatedAt,
        A.UserId,
        U.UserName,
        A.QuestionId
    FROM Answers A
    INNER JOIN Users U ON A.UserId = U.UserId
    
    WHERE A.QuestionId = @QuestionId
    ORDER BY A.CreatedAt DESC;
END;
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
    @UserId INT
AS
BEGIN
    SELECT 
    UserId,
    UserName,
    FirstName,
    LastName,
    PasswordHash,
    PasswordSalt
    FROM Users
    WHERE UserId = @UserId
END
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByUsername]
    @UserName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Consultar al usuario
    SELECT 
        UserId,
        UserName,
        FirstName,
        LastName,
        PasswordHash,
        PasswordSalt
    FROM 
        Users
    WHERE 
        Username = @Username;
END
GO

**************************************

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateQuestionIsClosed]
    @QuestionId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Questions
    SET IsClosed = 1
    WHERE QuestionId = @QuestionId;
END
GO

