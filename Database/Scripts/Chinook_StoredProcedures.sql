
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_Select]

  AS
   SET NOCOUNT ON;
SELECT [AlbumId], [Title], [ArtistId] FROM [Album]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_Select]

  AS
   SET NOCOUNT ON;
   SELECT [AlbumId], [Title], [ArtistId] FROM [Album]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_Update]
(
@AlbumId int, 
@Title nvarchar(320), 
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Album] SET [AlbumId]=@AlbumId, [Title]=@Title, [ArtistId]=@ArtistId WHERE [AlbumId]=@AlbumId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_Update]
(
@AlbumId int, 
@Title nvarchar(320), 
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Album] SET [AlbumId]=@AlbumId, [Title]=@Title, [ArtistId]=@ArtistId WHERE [AlbumId]=@AlbumId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_Insert]
(
@AlbumId int, 
@Title nvarchar(320), 
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (@AlbumId, @Title, @ArtistId);SELECT @AlbumId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_Insert]
(
@AlbumId int, 
@Title nvarchar(320), 
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (@AlbumId, @Title, @ArtistId);SELECT @AlbumId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_Delete]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Album] WHERE [AlbumId]=@AlbumId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_Delete]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Album] WHERE [AlbumId]=@AlbumId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''AlbumId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [AlbumId], [Title], [ArtistId] FROM (
		   SELECT [AlbumId], [Title], [ArtistId],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Album) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''AlbumId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [AlbumId], [Title], [ArtistId] FROM (
		   SELECT [AlbumId], [Title], [ArtistId],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Album) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(AlbumId) FROM Album'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(AlbumId) FROM Album'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_GetDataByAlbumId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_GetDataByAlbumId]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
SELECT [AlbumId], [Title], [ArtistId] FROM [Album] WHERE [AlbumId]=@AlbumId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_GetDataByAlbumId]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [AlbumId], [Title], [ArtistId] FROM [Album] WHERE [AlbumId]=@AlbumId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_GetDataByArtistId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_GetDataByArtistId]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
SELECT [AlbumId], [Title], [ArtistId] FROM [Album] WHERE [ArtistId] = @ArtistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_GetDataByArtistId]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [AlbumId], [Title], [ArtistId] FROM [Album] WHERE [ArtistId] = @ArtistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_GetDataByArtistIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_GetDataByArtistIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''ArtistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [AlbumId], [Title], [ArtistId] FROM (
		   SELECT [AlbumId], [Title], [ArtistId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Album WHERE ArtistId = @INArtistId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INArtistId int'', @ArtistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_GetDataByArtistIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''ArtistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [AlbumId], [Title], [ArtistId] FROM (
		   SELECT [AlbumId], [Title], [ArtistId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Album WHERE ArtistId = @INArtistId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INArtistId int'', @ArtistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Album_GetDataByArtistIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Album_GetDataByArtistIdRowCount]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(ArtistId) FROM Album WHERE ArtistId = @ArtistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Album_GetDataByArtistIdRowCount]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(ArtistId) FROM Album WHERE ArtistId = @ArtistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_Select]

  AS
   SET NOCOUNT ON;
SELECT [ArtistId], [Name] FROM [Artist]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_Select]

  AS
   SET NOCOUNT ON;
   SELECT [ArtistId], [Name] FROM [Artist]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_Update]
(
@ArtistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
UPDATE [Artist] SET [ArtistId]=@ArtistId, [Name]=@Name WHERE [ArtistId]=@ArtistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_Update]
(
@ArtistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Artist] SET [ArtistId]=@ArtistId, [Name]=@Name WHERE [ArtistId]=@ArtistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_Insert]
(
@ArtistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Artist] ([ArtistId], [Name]) VALUES (@ArtistId, @Name);SELECT @ArtistId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_Insert]
(
@ArtistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Artist] ([ArtistId], [Name]) VALUES (@ArtistId, @Name);SELECT @ArtistId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_Delete]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Artist] WHERE [ArtistId]=@ArtistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_Delete]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Artist] WHERE [ArtistId]=@ArtistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''ArtistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [ArtistId], [Name] FROM (
		   SELECT [ArtistId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Artist) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''ArtistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [ArtistId], [Name] FROM (
		   SELECT [ArtistId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Artist) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(ArtistId) FROM Artist'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(ArtistId) FROM Artist'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artist_GetDataByArtistId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Artist_GetDataByArtistId]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
SELECT [ArtistId], [Name] FROM [Artist] WHERE [ArtistId]=@ArtistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Artist_GetDataByArtistId]
(
@ArtistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [ArtistId], [Name] FROM [Artist] WHERE [ArtistId]=@ArtistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_Select]

  AS
   SET NOCOUNT ON;
SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM [Customer]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_Select]

  AS
   SET NOCOUNT ON;
   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM [Customer]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_Update]
(
@CustomerId int, 
@FirstName nvarchar(80), 
@LastName nvarchar(40), 
@Company nvarchar(160), 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120), 
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Customer] SET [CustomerId]=@CustomerId, [FirstName]=@FirstName, [LastName]=@LastName, [Company]=@Company, [Address]=@Address, [City]=@City, [State]=@State, [Country]=@Country, [PostalCode]=@PostalCode, [Phone]=@Phone, [Fax]=@Fax, [Email]=@Email, [SupportRepId]=@SupportRepId WHERE [CustomerId]=@CustomerId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_Update]
(
@CustomerId int, 
@FirstName nvarchar(80), 
@LastName nvarchar(40), 
@Company nvarchar(160), 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120), 
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Customer] SET [CustomerId]=@CustomerId, [FirstName]=@FirstName, [LastName]=@LastName, [Company]=@Company, [Address]=@Address, [City]=@City, [State]=@State, [Country]=@Country, [PostalCode]=@PostalCode, [Phone]=@Phone, [Fax]=@Fax, [Email]=@Email, [SupportRepId]=@SupportRepId WHERE [CustomerId]=@CustomerId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_Insert]
(
@CustomerId int, 
@FirstName nvarchar(80), 
@LastName nvarchar(40), 
@Company nvarchar(160), 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120), 
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (@CustomerId, @FirstName, @LastName, @Company, @Address, @City, @State, @Country, @PostalCode, @Phone, @Fax, @Email, @SupportRepId);SELECT @CustomerId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_Insert]
(
@CustomerId int, 
@FirstName nvarchar(80), 
@LastName nvarchar(40), 
@Company nvarchar(160), 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120), 
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Customer] ([CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId]) VALUES (@CustomerId, @FirstName, @LastName, @Company, @Address, @City, @State, @Country, @PostalCode, @Phone, @Fax, @Email, @SupportRepId);SELECT @CustomerId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_Delete]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Customer] WHERE [CustomerId]=@CustomerId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_Delete]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Customer] WHERE [CustomerId]=@CustomerId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''CustomerId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM (
		   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Customer) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''CustomerId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM (
		   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Customer) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(CustomerId) FROM Customer'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(CustomerId) FROM Customer'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetDataByCustomerId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_GetDataByCustomerId]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM [Customer] WHERE [CustomerId]=@CustomerId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_GetDataByCustomerId]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM [Customer] WHERE [CustomerId]=@CustomerId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetDataBySupportRepId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_GetDataBySupportRepId]
(
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM [Customer] WHERE [SupportRepId] = @SupportRepId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_GetDataBySupportRepId]
(
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM [Customer] WHERE [SupportRepId] = @SupportRepId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetDataBySupportRepIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_GetDataBySupportRepIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''SupportRepId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM (
		   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Customer WHERE SupportRepId = @INSupportRepId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INSupportRepId int'', @SupportRepId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_GetDataBySupportRepIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''SupportRepId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId] FROM (
		   SELECT [CustomerId], [FirstName], [LastName], [Company], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], [SupportRepId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Customer WHERE SupportRepId = @INSupportRepId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INSupportRepId int'', @SupportRepId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetDataBySupportRepIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Customer_GetDataBySupportRepIdRowCount]
(
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(SupportRepId) FROM Customer WHERE SupportRepId = @SupportRepId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Customer_GetDataBySupportRepIdRowCount]
(
@SupportRepId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(SupportRepId) FROM Customer WHERE SupportRepId = @SupportRepId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_Select]

  AS
   SET NOCOUNT ON;
SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM [Employee]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_Select]

  AS
   SET NOCOUNT ON;
   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM [Employee]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_Update]
(
@EmployeeId int, 
@LastName nvarchar(40), 
@FirstName nvarchar(40), 
@Title nvarchar(60), 
@ReportsTo int, 
@BirthDate datetime, 
@HireDate datetime, 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120)
  )

  AS
   SET NOCOUNT ON;
UPDATE [Employee] SET [EmployeeId]=@EmployeeId, [LastName]=@LastName, [FirstName]=@FirstName, [Title]=@Title, [ReportsTo]=@ReportsTo, [BirthDate]=@BirthDate, [HireDate]=@HireDate, [Address]=@Address, [City]=@City, [State]=@State, [Country]=@Country, [PostalCode]=@PostalCode, [Phone]=@Phone, [Fax]=@Fax, [Email]=@Email WHERE [EmployeeId]=@EmployeeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_Update]
(
@EmployeeId int, 
@LastName nvarchar(40), 
@FirstName nvarchar(40), 
@Title nvarchar(60), 
@ReportsTo int, 
@BirthDate datetime, 
@HireDate datetime, 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120)
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Employee] SET [EmployeeId]=@EmployeeId, [LastName]=@LastName, [FirstName]=@FirstName, [Title]=@Title, [ReportsTo]=@ReportsTo, [BirthDate]=@BirthDate, [HireDate]=@HireDate, [Address]=@Address, [City]=@City, [State]=@State, [Country]=@Country, [PostalCode]=@PostalCode, [Phone]=@Phone, [Fax]=@Fax, [Email]=@Email WHERE [EmployeeId]=@EmployeeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_Insert]
(
@EmployeeId int, 
@LastName nvarchar(40), 
@FirstName nvarchar(40), 
@Title nvarchar(60), 
@ReportsTo int, 
@BirthDate datetime, 
@HireDate datetime, 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (@EmployeeId, @LastName, @FirstName, @Title, @ReportsTo, @BirthDate, @HireDate, @Address, @City, @State, @Country, @PostalCode, @Phone, @Fax, @Email);SELECT @EmployeeId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_Insert]
(
@EmployeeId int, 
@LastName nvarchar(40), 
@FirstName nvarchar(40), 
@Title nvarchar(60), 
@ReportsTo int, 
@BirthDate datetime, 
@HireDate datetime, 
@Address nvarchar(140), 
@City nvarchar(80), 
@State nvarchar(80), 
@Country nvarchar(80), 
@PostalCode nvarchar(20), 
@Phone nvarchar(48), 
@Fax nvarchar(48), 
@Email nvarchar(120)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Employee] ([EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email]) VALUES (@EmployeeId, @LastName, @FirstName, @Title, @ReportsTo, @BirthDate, @HireDate, @Address, @City, @State, @Country, @PostalCode, @Phone, @Fax, @Email);SELECT @EmployeeId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_Delete]
(
@EmployeeId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Employee] WHERE [EmployeeId]=@EmployeeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_Delete]
(
@EmployeeId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Employee] WHERE [EmployeeId]=@EmployeeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''EmployeeId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM (
		   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Employee) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''EmployeeId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM (
		   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Employee) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(EmployeeId) FROM Employee'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(EmployeeId) FROM Employee'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetDataByEmployeeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_GetDataByEmployeeId]
(
@EmployeeId int
  )

  AS
   SET NOCOUNT ON;
SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM [Employee] WHERE [EmployeeId]=@EmployeeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_GetDataByEmployeeId]
(
@EmployeeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM [Employee] WHERE [EmployeeId]=@EmployeeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetDataByReportsTo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_GetDataByReportsTo]
(
@ReportsTo int
  )

  AS
   SET NOCOUNT ON;
SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM [Employee] WHERE [ReportsTo] = @ReportsTo'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_GetDataByReportsTo]
(
@ReportsTo int
  )

  AS
   SET NOCOUNT ON;
   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM [Employee] WHERE [ReportsTo] = @ReportsTo'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetDataByReportsToPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_GetDataByReportsToPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@ReportsTo int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''ReportsTo''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM (
		   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Employee WHERE ReportsTo = @INReportsTo) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INReportsTo int'', @ReportsTo'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_GetDataByReportsToPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@ReportsTo int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''ReportsTo''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email] FROM (
		   SELECT [EmployeeId], [LastName], [FirstName], [Title], [ReportsTo], [BirthDate], [HireDate], [Address], [City], [State], [Country], [PostalCode], [Phone], [Fax], [Email], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Employee WHERE ReportsTo = @INReportsTo) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INReportsTo int'', @ReportsTo'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetDataByReportsToRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Employee_GetDataByReportsToRowCount]
(
@ReportsTo int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(ReportsTo) FROM Employee WHERE ReportsTo = @ReportsTo'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Employee_GetDataByReportsToRowCount]
(
@ReportsTo int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(ReportsTo) FROM Employee WHERE ReportsTo = @ReportsTo'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_Select]

  AS
   SET NOCOUNT ON;
SELECT [GenreId], [Name] FROM [Genre]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_Select]

  AS
   SET NOCOUNT ON;
   SELECT [GenreId], [Name] FROM [Genre]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_Update]
(
@GenreId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
UPDATE [Genre] SET [GenreId]=@GenreId, [Name]=@Name WHERE [GenreId]=@GenreId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_Update]
(
@GenreId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Genre] SET [GenreId]=@GenreId, [Name]=@Name WHERE [GenreId]=@GenreId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_Insert]
(
@GenreId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (@GenreId, @Name);SELECT @GenreId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_Insert]
(
@GenreId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Genre] ([GenreId], [Name]) VALUES (@GenreId, @Name);SELECT @GenreId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_Delete]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Genre] WHERE [GenreId]=@GenreId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_Delete]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Genre] WHERE [GenreId]=@GenreId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''GenreId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [GenreId], [Name] FROM (
		   SELECT [GenreId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Genre) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''GenreId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [GenreId], [Name] FROM (
		   SELECT [GenreId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Genre) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(GenreId) FROM Genre'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(GenreId) FROM Genre'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre_GetDataByGenreId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Genre_GetDataByGenreId]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
SELECT [GenreId], [Name] FROM [Genre] WHERE [GenreId]=@GenreId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Genre_GetDataByGenreId]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [GenreId], [Name] FROM [Genre] WHERE [GenreId]=@GenreId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_Select]

  AS
   SET NOCOUNT ON;
SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM [Invoice]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_Select]

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM [Invoice]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_Update]
(
@InvoiceId int, 
@CustomerId int, 
@InvoiceDate datetime, 
@BillingAddress nvarchar(140), 
@BillingCity nvarchar(80), 
@BillingState nvarchar(80), 
@BillingCountry nvarchar(80), 
@BillingPostalCode nvarchar(20), 
@Total numeric
  )

  AS
   SET NOCOUNT ON;
UPDATE [Invoice] SET [InvoiceId]=@InvoiceId, [CustomerId]=@CustomerId, [InvoiceDate]=@InvoiceDate, [BillingAddress]=@BillingAddress, [BillingCity]=@BillingCity, [BillingState]=@BillingState, [BillingCountry]=@BillingCountry, [BillingPostalCode]=@BillingPostalCode, [Total]=@Total WHERE [InvoiceId]=@InvoiceId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_Update]
(
@InvoiceId int, 
@CustomerId int, 
@InvoiceDate datetime, 
@BillingAddress nvarchar(140), 
@BillingCity nvarchar(80), 
@BillingState nvarchar(80), 
@BillingCountry nvarchar(80), 
@BillingPostalCode nvarchar(20), 
@Total numeric
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Invoice] SET [InvoiceId]=@InvoiceId, [CustomerId]=@CustomerId, [InvoiceDate]=@InvoiceDate, [BillingAddress]=@BillingAddress, [BillingCity]=@BillingCity, [BillingState]=@BillingState, [BillingCountry]=@BillingCountry, [BillingPostalCode]=@BillingPostalCode, [Total]=@Total WHERE [InvoiceId]=@InvoiceId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_Insert]
(
@InvoiceId int, 
@CustomerId int, 
@InvoiceDate datetime, 
@BillingAddress nvarchar(140), 
@BillingCity nvarchar(80), 
@BillingState nvarchar(80), 
@BillingCountry nvarchar(80), 
@BillingPostalCode nvarchar(20), 
@Total numeric
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (@InvoiceId, @CustomerId, @InvoiceDate, @BillingAddress, @BillingCity, @BillingState, @BillingCountry, @BillingPostalCode, @Total);SELECT @InvoiceId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_Insert]
(
@InvoiceId int, 
@CustomerId int, 
@InvoiceDate datetime, 
@BillingAddress nvarchar(140), 
@BillingCity nvarchar(80), 
@BillingState nvarchar(80), 
@BillingCountry nvarchar(80), 
@BillingPostalCode nvarchar(20), 
@Total numeric
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Invoice] ([InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total]) VALUES (@InvoiceId, @CustomerId, @InvoiceDate, @BillingAddress, @BillingCity, @BillingState, @BillingCountry, @BillingPostalCode, @Total);SELECT @InvoiceId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_Delete]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Invoice] WHERE [InvoiceId]=@InvoiceId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_Delete]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Invoice] WHERE [InvoiceId]=@InvoiceId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''InvoiceId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM (
		   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Invoice) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''InvoiceId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM (
		   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Invoice) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(InvoiceId) FROM Invoice'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(InvoiceId) FROM Invoice'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_GetDataByInvoiceId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_GetDataByInvoiceId]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM [Invoice] WHERE [InvoiceId]=@InvoiceId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_GetDataByInvoiceId]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM [Invoice] WHERE [InvoiceId]=@InvoiceId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_GetDataByCustomerId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_GetDataByCustomerId]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM [Invoice] WHERE [CustomerId] = @CustomerId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_GetDataByCustomerId]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM [Invoice] WHERE [CustomerId] = @CustomerId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_GetDataByCustomerIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_GetDataByCustomerIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''CustomerId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM (
		   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Invoice WHERE CustomerId = @INCustomerId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INCustomerId int'', @CustomerId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_GetDataByCustomerIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''CustomerId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total] FROM (
		   SELECT [InvoiceId], [CustomerId], [InvoiceDate], [BillingAddress], [BillingCity], [BillingState], [BillingCountry], [BillingPostalCode], [Total], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Invoice WHERE CustomerId = @INCustomerId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INCustomerId int'', @CustomerId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice_GetDataByCustomerIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Invoice_GetDataByCustomerIdRowCount]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(CustomerId) FROM Invoice WHERE CustomerId = @CustomerId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Invoice_GetDataByCustomerIdRowCount]
(
@CustomerId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(CustomerId) FROM Invoice WHERE CustomerId = @CustomerId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_Select]

  AS
   SET NOCOUNT ON;
SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_Select]

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_Update]
(
@InvoiceLineId int, 
@InvoiceId int, 
@TrackId int, 
@UnitPrice numeric, 
@Quantity int
  )

  AS
   SET NOCOUNT ON;
UPDATE [InvoiceLine] SET [InvoiceLineId]=@InvoiceLineId, [InvoiceId]=@InvoiceId, [TrackId]=@TrackId, [UnitPrice]=@UnitPrice, [Quantity]=@Quantity WHERE [InvoiceLineId]=@InvoiceLineId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_Update]
(
@InvoiceLineId int, 
@InvoiceId int, 
@TrackId int, 
@UnitPrice numeric, 
@Quantity int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [InvoiceLine] SET [InvoiceLineId]=@InvoiceLineId, [InvoiceId]=@InvoiceId, [TrackId]=@TrackId, [UnitPrice]=@UnitPrice, [Quantity]=@Quantity WHERE [InvoiceLineId]=@InvoiceLineId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_Insert]
(
@InvoiceLineId int, 
@InvoiceId int, 
@TrackId int, 
@UnitPrice numeric, 
@Quantity int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (@InvoiceLineId, @InvoiceId, @TrackId, @UnitPrice, @Quantity);SELECT @InvoiceLineId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_Insert]
(
@InvoiceLineId int, 
@InvoiceId int, 
@TrackId int, 
@UnitPrice numeric, 
@Quantity int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [InvoiceLine] ([InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity]) VALUES (@InvoiceLineId, @InvoiceId, @TrackId, @UnitPrice, @Quantity);SELECT @InvoiceLineId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_Delete]
(
@InvoiceLineId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [InvoiceLine] WHERE [InvoiceLineId]=@InvoiceLineId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_Delete]
(
@InvoiceLineId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [InvoiceLine] WHERE [InvoiceLineId]=@InvoiceLineId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''InvoiceLineId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM (
		   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM InvoiceLine) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''InvoiceLineId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM (
		   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM InvoiceLine) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(InvoiceLineId) FROM InvoiceLine'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(InvoiceLineId) FROM InvoiceLine'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByInvoiceLineId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceLineId]
(
@InvoiceLineId int
  )

  AS
   SET NOCOUNT ON;
SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine] WHERE [InvoiceLineId]=@InvoiceLineId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceLineId]
(
@InvoiceLineId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine] WHERE [InvoiceLineId]=@InvoiceLineId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByInvoiceId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceId]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine] WHERE [InvoiceId] = @InvoiceId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceId]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine] WHERE [InvoiceId] = @InvoiceId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByInvoiceIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''InvoiceId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM (
		   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM InvoiceLine WHERE InvoiceId = @INInvoiceId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INInvoiceId int'', @InvoiceId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''InvoiceId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM (
		   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM InvoiceLine WHERE InvoiceId = @INInvoiceId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INInvoiceId int'', @InvoiceId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByInvoiceIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceIdRowCount]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(InvoiceId) FROM InvoiceLine WHERE InvoiceId = @InvoiceId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByInvoiceIdRowCount]
(
@InvoiceId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(InvoiceId) FROM InvoiceLine WHERE InvoiceId = @InvoiceId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByTrackId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine] WHERE [TrackId] = @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM [InvoiceLine] WHERE [TrackId] = @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByTrackIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByTrackIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM (
		   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM InvoiceLine WHERE TrackId = @INTrackId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTrackId int'', @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByTrackIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity] FROM (
		   SELECT [InvoiceLineId], [InvoiceId], [TrackId], [UnitPrice], [Quantity], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM InvoiceLine WHERE TrackId = @INTrackId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTrackId int'', @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceLine_GetDataByTrackIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InvoiceLine_GetDataByTrackIdRowCount]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(TrackId) FROM InvoiceLine WHERE TrackId = @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[InvoiceLine_GetDataByTrackIdRowCount]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(TrackId) FROM InvoiceLine WHERE TrackId = @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_Select]

  AS
   SET NOCOUNT ON;
SELECT [MediaTypeId], [Name] FROM [MediaType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_Select]

  AS
   SET NOCOUNT ON;
   SELECT [MediaTypeId], [Name] FROM [MediaType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_Update]
(
@MediaTypeId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
UPDATE [MediaType] SET [MediaTypeId]=@MediaTypeId, [Name]=@Name WHERE [MediaTypeId]=@MediaTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_Update]
(
@MediaTypeId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   UPDATE [MediaType] SET [MediaTypeId]=@MediaTypeId, [Name]=@Name WHERE [MediaTypeId]=@MediaTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_Insert]
(
@MediaTypeId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [MediaType] ([MediaTypeId], [Name]) VALUES (@MediaTypeId, @Name);SELECT @MediaTypeId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_Insert]
(
@MediaTypeId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [MediaType] ([MediaTypeId], [Name]) VALUES (@MediaTypeId, @Name);SELECT @MediaTypeId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_Delete]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [MediaType] WHERE [MediaTypeId]=@MediaTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_Delete]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [MediaType] WHERE [MediaTypeId]=@MediaTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''MediaTypeId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [MediaTypeId], [Name] FROM (
		   SELECT [MediaTypeId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM MediaType) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''MediaTypeId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [MediaTypeId], [Name] FROM (
		   SELECT [MediaTypeId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM MediaType) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(MediaTypeId) FROM MediaType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(MediaTypeId) FROM MediaType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MediaType_GetDataByMediaTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[MediaType_GetDataByMediaTypeId]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT [MediaTypeId], [Name] FROM [MediaType] WHERE [MediaTypeId]=@MediaTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[MediaType_GetDataByMediaTypeId]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [MediaTypeId], [Name] FROM [MediaType] WHERE [MediaTypeId]=@MediaTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_Select]

  AS
   SET NOCOUNT ON;
SELECT [PlaylistId], [Name] FROM [Playlist]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_Select]

  AS
   SET NOCOUNT ON;
   SELECT [PlaylistId], [Name] FROM [Playlist]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_Update]
(
@PlaylistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
UPDATE [Playlist] SET [PlaylistId]=@PlaylistId, [Name]=@Name WHERE [PlaylistId]=@PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_Update]
(
@PlaylistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Playlist] SET [PlaylistId]=@PlaylistId, [Name]=@Name WHERE [PlaylistId]=@PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_Insert]
(
@PlaylistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Playlist] ([PlaylistId], [Name]) VALUES (@PlaylistId, @Name);SELECT @PlaylistId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_Insert]
(
@PlaylistId int, 
@Name nvarchar(240)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Playlist] ([PlaylistId], [Name]) VALUES (@PlaylistId, @Name);SELECT @PlaylistId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_Delete]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Playlist] WHERE [PlaylistId]=@PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_Delete]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Playlist] WHERE [PlaylistId]=@PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [Name] FROM (
		   SELECT [PlaylistId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Playlist) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [Name] FROM (
		   SELECT [PlaylistId], [Name],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Playlist) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(PlaylistId) FROM Playlist'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(PlaylistId) FROM Playlist'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_GetDataByPlaylistId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_GetDataByPlaylistId]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
SELECT [PlaylistId], [Name] FROM [Playlist] WHERE [PlaylistId]=@PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_GetDataByPlaylistId]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [PlaylistId], [Name] FROM [Playlist] WHERE [PlaylistId]=@PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_GetPlaylistsByTrackId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_GetPlaylistsByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
Playlist.[PlaylistId], 
Playlist.[Name]
FROM [Playlist] INNER JOIN PlaylistTrack ON Playlist.[PlaylistId] = PlaylistTrack.[PlaylistId]
WHERE PlaylistTrack.[TrackId] = @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_GetPlaylistsByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
Playlist.[PlaylistId], 
Playlist.[Name]
FROM [Playlist] INNER JOIN PlaylistTrack ON Playlist.[PlaylistId] = PlaylistTrack.[PlaylistId]
WHERE PlaylistTrack.[TrackId] = @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_GetPlaylistsByTrackIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_GetPlaylistsByTrackIdPagableSubSet]
(
@TrackId int, 
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT 
[PlaylistId], 
[Name] FROM (
		   SELECT 
Playlist.[PlaylistId], 
Playlist.[Name], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM [Playlist] INNER JOIN PlaylistTrack ON Playlist.[PlaylistId] = PlaylistTrack.[PlaylistId]          WHERE PlaylistTrack.[TrackId] = @INTrackId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTrackId int'', @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_GetPlaylistsByTrackIdPagableSubSet]
(
@TrackId int, 
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT 
[PlaylistId], 
[Name] FROM (
		   SELECT 
Playlist.[PlaylistId], 
Playlist.[Name], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM [Playlist] INNER JOIN PlaylistTrack ON Playlist.[PlaylistId] = PlaylistTrack.[PlaylistId]          WHERE PlaylistTrack.[TrackId] = @INTrackId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTrackId int'', @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlist_GetPlaylistsByTrackIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Playlist_GetPlaylistsByTrackIdRowCount]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(Playlist.[PlaylistId])  FROM [Playlist] INNER JOIN PlaylistTrack ON Playlist.[PlaylistId] = PlaylistTrack.[PlaylistId]
WHERE PlaylistTrack.[TrackId] = @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Playlist_GetPlaylistsByTrackIdRowCount]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(Playlist.[PlaylistId])  FROM [Playlist] INNER JOIN PlaylistTrack ON Playlist.[PlaylistId] = PlaylistTrack.[PlaylistId]
WHERE PlaylistTrack.[TrackId] = @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_Select]

  AS
   SET NOCOUNT ON;
SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_Select]

  AS
   SET NOCOUNT ON;
   SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_Update]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [PlaylistTrack] SET [PlaylistId]=@PlaylistId, [TrackId]=@TrackId WHERE [PlaylistId]=@PlaylistId and  [TrackId]=@TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_Update]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [PlaylistTrack] SET [PlaylistId]=@PlaylistId, [TrackId]=@TrackId WHERE [PlaylistId]=@PlaylistId and  [TrackId]=@TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_Insert]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (@PlaylistId, @TrackId);SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [PlaylistId] = @PlaylistId and [TrackId] = @TrackId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_Insert]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [PlaylistTrack] ([PlaylistId], [TrackId]) VALUES (@PlaylistId, @TrackId);SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [PlaylistId] = @PlaylistId and [TrackId] = @TrackId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_Delete]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [PlaylistTrack] WHERE [PlaylistId]=@PlaylistId and [TrackId]=@TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_Delete]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [PlaylistTrack] WHERE [PlaylistId]=@PlaylistId and [TrackId]=@TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [TrackId] FROM (
		   SELECT [PlaylistId], [TrackId],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM PlaylistTrack) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [TrackId] FROM (
		   SELECT [PlaylistId], [TrackId],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM PlaylistTrack) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(PlaylistId) FROM PlaylistTrack'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(PlaylistId) FROM PlaylistTrack'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByPlaylistIdTrackId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistIdTrackId]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [PlaylistId]=@PlaylistId and [TrackId]=@TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistIdTrackId]
(
@PlaylistId int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [PlaylistId]=@PlaylistId and [TrackId]=@TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByPlaylistId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistId]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [PlaylistId] = @PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistId]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [PlaylistId] = @PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByPlaylistIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [TrackId] FROM (
		   SELECT [PlaylistId], [TrackId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM PlaylistTrack WHERE PlaylistId = @INPlaylistId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INPlaylistId int'', @PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''PlaylistId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [TrackId] FROM (
		   SELECT [PlaylistId], [TrackId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM PlaylistTrack WHERE PlaylistId = @INPlaylistId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INPlaylistId int'', @PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByPlaylistIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistIdRowCount]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(PlaylistId) FROM PlaylistTrack WHERE PlaylistId = @PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByPlaylistIdRowCount]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(PlaylistId) FROM PlaylistTrack WHERE PlaylistId = @PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByTrackId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [TrackId] = @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [PlaylistId], [TrackId] FROM [PlaylistTrack] WHERE [TrackId] = @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByTrackIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByTrackIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [TrackId] FROM (
		   SELECT [PlaylistId], [TrackId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM PlaylistTrack WHERE TrackId = @INTrackId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTrackId int'', @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByTrackIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [PlaylistId], [TrackId] FROM (
		   SELECT [PlaylistId], [TrackId], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM PlaylistTrack WHERE TrackId = @INTrackId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTrackId int'', @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlaylistTrack_GetDataByTrackIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PlaylistTrack_GetDataByTrackIdRowCount]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(TrackId) FROM PlaylistTrack WHERE TrackId = @TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[PlaylistTrack_GetDataByTrackIdRowCount]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(TrackId) FROM PlaylistTrack WHERE TrackId = @TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_Select]

  AS
   SET NOCOUNT ON;
SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_Select]

  AS
   SET NOCOUNT ON;
   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_Update]
(
@TrackId int, 
@Name nvarchar(400), 
@AlbumId int, 
@MediaTypeId int, 
@GenreId int, 
@Composer nvarchar(440), 
@Milliseconds int, 
@Bytes int, 
@UnitPrice numeric
  )

  AS
   SET NOCOUNT ON;
UPDATE [Track] SET [TrackId]=@TrackId, [Name]=@Name, [AlbumId]=@AlbumId, [MediaTypeId]=@MediaTypeId, [GenreId]=@GenreId, [Composer]=@Composer, [Milliseconds]=@Milliseconds, [Bytes]=@Bytes, [UnitPrice]=@UnitPrice WHERE [TrackId]=@TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_Update]
(
@TrackId int, 
@Name nvarchar(400), 
@AlbumId int, 
@MediaTypeId int, 
@GenreId int, 
@Composer nvarchar(440), 
@Milliseconds int, 
@Bytes int, 
@UnitPrice numeric
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Track] SET [TrackId]=@TrackId, [Name]=@Name, [AlbumId]=@AlbumId, [MediaTypeId]=@MediaTypeId, [GenreId]=@GenreId, [Composer]=@Composer, [Milliseconds]=@Milliseconds, [Bytes]=@Bytes, [UnitPrice]=@UnitPrice WHERE [TrackId]=@TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_Insert]
(
@TrackId int, 
@Name nvarchar(400), 
@AlbumId int, 
@MediaTypeId int, 
@GenreId int, 
@Composer nvarchar(440), 
@Milliseconds int, 
@Bytes int, 
@UnitPrice numeric
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Track] ([TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice]) VALUES (@TrackId, @Name, @AlbumId, @MediaTypeId, @GenreId, @Composer, @Milliseconds, @Bytes, @UnitPrice);SELECT @TrackId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_Insert]
(
@TrackId int, 
@Name nvarchar(400), 
@AlbumId int, 
@MediaTypeId int, 
@GenreId int, 
@Composer nvarchar(440), 
@Milliseconds int, 
@Bytes int, 
@UnitPrice numeric
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Track] ([TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice]) VALUES (@TrackId, @Name, @AlbumId, @MediaTypeId, @GenreId, @Composer, @Milliseconds, @Bytes, @UnitPrice);SELECT @TrackId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_Delete]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
DELETE FROM [Track] WHERE [TrackId]=@TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_Delete]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   DELETE FROM [Track] WHERE [TrackId]=@TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice],
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql '
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(TrackId) FROM Track'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(TrackId) FROM Track'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByTrackId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [TrackId]=@TrackId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByTrackId]
(
@TrackId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [TrackId]=@TrackId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetTracksByPlaylistId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetTracksByPlaylistId]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
Track.[TrackId], 
Track.[Name], 
Track.[AlbumId], 
Track.[MediaTypeId], 
Track.[GenreId], 
Track.[Composer], 
Track.[Milliseconds], 
Track.[Bytes], 
Track.[UnitPrice]
FROM [Track] INNER JOIN PlaylistTrack ON Track.[TrackId] = PlaylistTrack.[TrackId]
WHERE PlaylistTrack.[PlaylistId] = @PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetTracksByPlaylistId]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
Track.[TrackId], 
Track.[Name], 
Track.[AlbumId], 
Track.[MediaTypeId], 
Track.[GenreId], 
Track.[Composer], 
Track.[Milliseconds], 
Track.[Bytes], 
Track.[UnitPrice]
FROM [Track] INNER JOIN PlaylistTrack ON Track.[TrackId] = PlaylistTrack.[TrackId]
WHERE PlaylistTrack.[PlaylistId] = @PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetTracksByPlaylistIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetTracksByPlaylistIdPagableSubSet]
(
@PlaylistId int, 
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT 
[TrackId], 
[Name], 
[AlbumId], 
[MediaTypeId], 
[GenreId], 
[Composer], 
[Milliseconds], 
[Bytes], 
[UnitPrice] FROM (
		   SELECT 
Track.[TrackId], 
Track.[Name], 
Track.[AlbumId], 
Track.[MediaTypeId], 
Track.[GenreId], 
Track.[Composer], 
Track.[Milliseconds], 
Track.[Bytes], 
Track.[UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM [Track] INNER JOIN PlaylistTrack ON Track.[TrackId] = PlaylistTrack.[TrackId]          WHERE PlaylistTrack.[PlaylistId] = @INPlaylistId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INPlaylistId int'', @PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetTracksByPlaylistIdPagableSubSet]
(
@PlaylistId int, 
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''TrackId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT 
[TrackId], 
[Name], 
[AlbumId], 
[MediaTypeId], 
[GenreId], 
[Composer], 
[Milliseconds], 
[Bytes], 
[UnitPrice] FROM (
		   SELECT 
Track.[TrackId], 
Track.[Name], 
Track.[AlbumId], 
Track.[MediaTypeId], 
Track.[GenreId], 
Track.[Composer], 
Track.[Milliseconds], 
Track.[Bytes], 
Track.[UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM [Track] INNER JOIN PlaylistTrack ON Track.[TrackId] = PlaylistTrack.[TrackId]          WHERE PlaylistTrack.[PlaylistId] = @INPlaylistId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INPlaylistId int'', @PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetTracksByPlaylistIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetTracksByPlaylistIdRowCount]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(Track.[TrackId])  FROM [Track] INNER JOIN PlaylistTrack ON Track.[TrackId] = PlaylistTrack.[TrackId]
WHERE PlaylistTrack.[PlaylistId] = @PlaylistId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetTracksByPlaylistIdRowCount]
(
@PlaylistId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(Track.[TrackId])  FROM [Track] INNER JOIN PlaylistTrack ON Track.[TrackId] = PlaylistTrack.[TrackId]
WHERE PlaylistTrack.[PlaylistId] = @PlaylistId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByAlbumId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByAlbumId]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [AlbumId] = @AlbumId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByAlbumId]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [AlbumId] = @AlbumId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByAlbumIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByAlbumIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''AlbumId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track WHERE AlbumId = @INAlbumId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INAlbumId int'', @AlbumId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByAlbumIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''AlbumId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track WHERE AlbumId = @INAlbumId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INAlbumId int'', @AlbumId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByAlbumIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByAlbumIdRowCount]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(AlbumId) FROM Track WHERE AlbumId = @AlbumId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByAlbumIdRowCount]
(
@AlbumId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(AlbumId) FROM Track WHERE AlbumId = @AlbumId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByGenreId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByGenreId]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [GenreId] = @GenreId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByGenreId]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [GenreId] = @GenreId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByGenreIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByGenreIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@GenreId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''GenreId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track WHERE GenreId = @INGenreId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INGenreId int'', @GenreId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByGenreIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@GenreId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''GenreId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track WHERE GenreId = @INGenreId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INGenreId int'', @GenreId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByGenreIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByGenreIdRowCount]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(GenreId) FROM Track WHERE GenreId = @GenreId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByGenreIdRowCount]
(
@GenreId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(GenreId) FROM Track WHERE GenreId = @GenreId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByMediaTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByMediaTypeId]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [MediaTypeId] = @MediaTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByMediaTypeId]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM [Track] WHERE [MediaTypeId] = @MediaTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByMediaTypeIdPagableSubSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByMediaTypeIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
IF LEN(@sortExpression) = 0 
SET @sortExpression = ''MediaTypeId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track WHERE MediaTypeId = @INMediaTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INMediaTypeId int'', @MediaTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByMediaTypeIdPagableSubSet]
(
@sortExpression VarChar(125), 
@startRowIndex Int, 
@MaximumRows Int, 
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
   IF LEN(@sortExpression) = 0 
SET @sortExpression = ''MediaTypeId''
SET @startRowIndex = @startRowIndex + 1
DECLARE @sql nvarchar(4000)
SET @sql = ''SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice] FROM (
		   SELECT [TrackId], [Name], [AlbumId], [MediaTypeId], [GenreId], [Composer], [Milliseconds], [Bytes], [UnitPrice], 
			  ROW_NUMBER() OVER (ORDER BY '' + @sortExpression + '') AS ResultSetRowNumber
		   FROM Track WHERE MediaTypeId = @INMediaTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN '' + CONVERT(nvarchar(10), @startRowIndex) + '' AND ('' + CONVERT(nvarchar(10), @startRowIndex) + '' + '' 
			+ CONVERT(nvarchar(10), @maximumRows) + '') - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INMediaTypeId int'', @MediaTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track_GetDataByMediaTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Track_GetDataByMediaTypeIdRowCount]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(MediaTypeId) FROM Track WHERE MediaTypeId = @MediaTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Track_GetDataByMediaTypeIdRowCount]
(
@MediaTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(MediaTypeId) FROM Track WHERE MediaTypeId = @MediaTypeId'
  END
GO
