select * from AspNetUsers;
select * from AspNetRoles;
select * from [dbo].[AspNetUserRoles];

insert into AspNetRoles values (1,'Super Admin');
insert into AspNetRoles values (2,'ServiceLine Manager');
insert into AspNetRoles values (3,'Operation Manager');
insert into AspNetRoles values (4,'End User');

insert into AspNetUserRoles values ('b7c8fb71-f627-4a5f-a3aa-342fa1968f71',1);
