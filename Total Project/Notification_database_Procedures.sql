USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[DeleteChannels]    Script Date: 10/1/2018 5:27:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeleteChannels]
(  
	@id int
	
)
AS  
begin
	Delete from EventChannel where EventId=@id
end
------------------------------------------------------------------------------------------------------------
USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[deleteEvent]    Script Date: 10/1/2018 5:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[deleteEvent]
(  

	@Eid int

)
AS  
begin
	Delete from EventChannel where EventId=@Eid
	Delete from Event where Id=@Eid
end
----------------------------------------------------------------------------------------------------------------
USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[InsertEvents]    Script Date: 10/1/2018 5:27:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertEvents]
(  
	  
	@name VARCHAR(50),  
	@souid int,
	@man bit
)
AS  
begin
	insert into Event (Name,SourceId,Mandatory) values(@name,@souid,@man)
	select SCOPE_IDENTITY()
end
--------------------------------------------------------------------------------------------------------------------
USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[RelationbetweenChannelsandEvent]    Script Date: 10/1/2018 5:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[RelationbetweenChannelsandEvent]
(  
	  

	@Eid int,
	@Cid int
)
AS  
begin
	insert into EventChannel (EventId,ChannelId) values(@Eid,@cid)
	
end
------------------------------------------------------------------------------------------------------------------------
USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[UpdateChannels]    Script Date: 10/1/2018 5:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdateChannels]
(  
	@id int,
	@Cid int
)
AS  
begin
	insert into EventChannel (EventId,ChannelId) values(@id,@Cid)
end
--------------------------------------------------------------------------------------------------------------------------
USE [NotificationHub]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEvent]    Script Date: 10/1/2018 5:29:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdateEvent]
(  
	 @id int,
	@name VARCHAR(50),  
	@souid int,
	@man bit
)
AS  
begin
	update Event set Name=@name,SourceId=@souid,Mandatory=@man where id=@id;
end
-----------------------------------------------------------------------------------------------------------------------------