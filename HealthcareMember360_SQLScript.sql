create database HealthcareMember360
go
Use HealthcareMember360
Go
create table Physican(PhysicianId int primary Key Identity(1,1),
							 PhysicianName Varchar(50),
							 PhysicianState Varchar(5))
GO
insert into Physican values ('John', 'UT')
insert into Physican values ('Hari', 'WA')
insert into Physican values ('Mittal', 'TX')
insert into Physican values ('Patrick', 'OH')
insert into Physican values ('Mark', 'CA')
insert into Physican values ('Jessica', 'NY')
insert into Physican values ('Mary', 'IL')
insert into Physican values ('Stacy', 'FL')
GO
Create table Member(MemberID int primary Key Identity(1,1),
						   FirstName varchar(50),
						   LastName varchar(50),
						   Address varchar(100),
						   State varchar(50),
						   EmailAddress varchar(50),
						   SSN varchar(50),
						   PhysicianId int foreign key references Physican(PhysicianId))
GO
create table ClaimTypes(ClaimTypeID int primary Key Identity(1,1),
						ClaimType Varchar(10))
GO
insert into ClaimTypes values('Vision')
insert into ClaimTypes values('Dental')
insert into ClaimTypes values('Medical')
GO
create table Claims(ClaimID int primary Key Identity(1,1),
					ClaimType int foreign key references ClaimTypes(ClaimTypeID),
					ClaimAmount int,
					ClaimDate datetime,
					Remarks varchar(100),
					MemberID int foreign key references Member(MemberID))
GO

select * from Physican
select * from Member
select * from ClaimTypes
select * from Claims