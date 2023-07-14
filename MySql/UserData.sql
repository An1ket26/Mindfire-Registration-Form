create table UserData(
	UserId int  primary key auto_increment,
	FirstName varchar(50) not null,     
	LastName varchar(50),     
	Email varchar(100) not null unique,     
	Password varchar(50) not null,     
	CountryID int,     
	StateId int,     
	AddressLine1 varchar(100),     
	AddressLine2 varchar(100),     
	City varchar(100) not null,     
	ZipCode varchar(20) 
);

create table roles(
	roleId int primary key,
    roleName varchar(50)
);

create table userRole(
	userId int,
    roleId int,
    foreign key(userId) references userdata(UserId),
    foreign key(roleId) references roles(roleId)
);

create table country(
	countryId int primary key,
    countryName varchar(100) unique,
    counntryAbbr varchar(10)
);

create table state(
	stateId int primary key,
    stateName varchar(100) unique,
    countryId int,
    foreign key(countryId) references country(countryId)
);

alter table userdata add constraint fk_country foreign key(countryId) references country(countryId); 
alter table userdata add constraint fk_state foreign key(stateId) references state(stateId); 

insert into userdata(firstname,lastname,email,password,countryid,stateid,addressline1,city,zipcode) values('aniket','ani','abc@xyz.com','12345','1','1','address','bbsr','751024');
insert into roles values(1,'admin');
insert into userrole values(2,1);
select * from userdata;

DELIMITER $$
USE `profileapplication`$$
CREATE PROCEDURE `getStateByCountry` (cntryID int)
BEGIN
	select * from state where countryId=cntryID;
END$$


DELIMITER ;
call getStateByCountry(1);
create view userRoleName as select firstname,email,roleName from userdata join userrole join roles on userdata.userId=userrole.userId and userrole.roleId=roles.roleId;
select * from userRoleName
