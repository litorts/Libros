Comentarios
-perdon por escribir el connection string asi, pero por tiempo no hice mas;
-dejare los script para crear la tabla y los procedimientos almacenados;
-Use c#, net core 3.1 en especifico, ya que es la tecnologia que uso a diario;
-Carlos Castro Tobar Carlos.castrot@utem.cl

------------------------------------------------------------------------------------------------------
USE [Books]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 27-05-2022 15:45:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Books](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Editorial] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



-----------------------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
CREATE PROCEDURE GetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Title, Author, Editorial, Location from dbo.Books
END
GO
--------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
CREATE PROCEDURE GetById
	@Id as bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Title, Author, Editorial, Location from dbo.Books
	where Id = @Id
END
GO
-------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
CREATE PROCEDURE GetByName
	@Title as varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Title, Author, Editorial, Location from dbo.Books
	where Title = @Title
END
GO

---------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
CREATE PROCEDURE GetByEditorial
	@Editorial as varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Title, Author, Editorial, Location from dbo.Books
	where Editorial = @Editorial
END
GO
 ----------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
CREATE PROCEDURE GetByAuthor
	@Author as varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Title, Author, Editorial, Location from dbo.Books
	where Author = @Author
END
GO
 
 -----------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
CREATE PROCEDURE GetByLocation
	@Location as varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Title, Author, Editorial, dbo.Books.Location from dbo.Books
	where Location = @Location
END
GO
-------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
Create PROCEDURE AddBook
	@Title as varchar(50),
	@Author as varchar(50),
	@Location as varchar(50) = null,
	@Editorial as varchar(50) = null
AS
BEGIN
	SET NOCOUNT ON;
	Insert 
		into Books (Title, Author, Location, Editorial)
		values (@Title, @Author, @Location, @Editorial)
	select @@IDENTITY
END
GO


---------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
Create PROCEDURE EditBook
	@Id as bigint,
	@Title as varchar(50),
	@Author as varchar(50),
	@Location as varchar(50) = null,
	@Editorial as varchar(50) = null
AS
BEGIN
	SET NOCOUNT ON;
	Update Books set Title = @Title, Author = @Author, Location = @Location, Editorial = @Editorial
		where Id = @Id
	select @@IDENTITY
END
GO

--------------------------------------------------------------------------------------------------------

USE [Books]
GO
/****** Object:  StoredProcedure [dbo].[GetByEditorial]    Script Date: 27-05-2022 15:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlitos
-- =============================================
create PROCEDURE [dbo].[GetByLocation]
	@Location as varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Title, Author, Editorial, Location from dbo.Books
	where Location = @Location
END
