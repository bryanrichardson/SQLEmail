exec sp_configure 'show advanced options',1
reconfigure
GO
exec sp_configure 'clr enabled',1
reconfigure
go
alter database [Enter your database here] set trustworthy on
go
use [Enter your database here]
go
create assembly SqlEmail from 'path to the dll'
with permission_set = external_access
GO
CREATE PROCEDURE [dbo].[SendSqlMail] 
 @recipients [nvarchar](MAX), 
 @cc [nvarchar](MAX),
 @bcc [nvarchar](MAX),
 @subject [nvarchar](MAX), 
 @from [nvarchar](MAX), 
 @body [nvarchar](MAX),
 @attachments [nvarchar](MAX),
 @server [nvarchar](MAX), 
 @port int,
 @user [nvarchar](MAX), 
 @pwd [nvarchar](MAX)
WITH EXECUTE AS CALLER 
AS 
EXTERNAL NAME [SqlMail].[SqlMail].[SendSqlMail]