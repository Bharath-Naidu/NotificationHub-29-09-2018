USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[GetSubscribedData]    Script Date: 10/6/2018 11:37:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[GetSubscribedData]
	@Id int
AS
BEGIN
	SELECT Id,EventId,ServiceLineId,ServiceLineManagerId
	FROM Event_slm_subscribe 
	WHERE Id = (select Max(id) from Event_slm_subscribe where EventId=@id)
END
-----------------------------------------------------------------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[GetSubscribedData]    Script Date: 10/6/2018 11:37:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROC [dbo].[GetSubscribedUsers]
	@Id int
AS
BEGIN
	SELECT *
	FROM Event_slm_subscribe_users where Event_slm_subscribe_Id=@Id
	
END
-------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[GetSubscribedData]    Script Date: 10/6/2018 11:37:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROC [dbo].[UpdateSubscribed]
	@Id int
AS
BEGIN
	Delete from Event_slm_subscribe_users where Event_slm_subscribe_Id=@Id
	Delete from Event_slm_subscribe_channel where Event_slm_subscribe_Id=@Id
END
----------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[GetSubscribedData]    Script Date: 10/6/2018 11:37:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROC [dbo].[UpdateSubscribedList]
	@Id int,
	@Eid int,
	@Sid int,
	@SMid int,
	@con bit,
	@man bit
AS
BEGIN
	update Event_slm_subscribe set EventId=@Eid,ServiceLineId=@Sid,ServiceLineManagerId=@SMid,Confidential=@con,Mandatory=@man where Id=@Id
END
-----------------------------------------------------------------------------------------------------------------------
USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[UpdateDatatypes]    Script Date: 10/6/2018 4:55:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateDatatypes]
(  
	  @id int,
	  @Name varchar(20)
)
AS  
begin
	update Datatype set Name=@Name where id=@id
end
