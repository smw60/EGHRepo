----------------- —оздание процедур --------- -------------------------------
----  лассификаци€ аварий  (EmergencyClass)
-----------------------------------------------------------------------------
---- ƒобавление типа аварии
---- ”даление типа аварии 
---- ѕолучение типа аварии
---- ѕолучение типа аварии по коду
---- ќбновление типа аварии
---- ѕолучение следующего кода типа аварии 
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateEmergencyClass;
drop procedure EGH.DeleteEmergencyClass; 
drop procedure EGH.GetEmergencyClassByCode;
drop procedure EGH.GetEmergencyClassList;
drop procedure EGH.UpdateEmergencyClass;
drop procedure EGH.GetNextEmergencyClassCode;
go
--------------------------------------

---- ƒобавление типа аварии
create procedure EGH.CreateEmergencyClass (
					@ од“ипајварии int,  
					@Ќаименование“ипајварии nvarchar(max),
					@ћинћасса real, 
					@ћаксћасса real)
as begin 
declare @rc int  = @ од“ипајварии;
	begin try
		insert into dbo. лассификаци€јварий(
		 од“ипајварии, 
		Ќаименование“ипајварии,
		ћинћасса,
		ћаксћасса) 
		values(@ од“ипајварии, 
				@Ќаименование“ипајварии,
				@ћинћасса, 
				@ћаксћасса); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- ”даление типа аварии
create procedure EGH.DeleteEmergencyClass (@ од“ипајварии int)
as begin 
    declare @rc int  = @ од“ипајварии;
    begin try 
	 delete dbo. лассификаци€јварий 
	 where  од“ипајварии = @ од“ипајварии;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- ѕолучение типа аварии по коду
create  procedure EGH.GetEmergencyClassByCode(@ од“ипајварии int) 
as begin 
    declare @rc int = -1;
	select  
		 од“ипајварии,
		Ќаименование“ипајварии,
		ћинћасса,
		ћаксћасса
	from dbo. лассификаци€јварий 
	where  од“ипајварии = @ од“ипајварии;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ѕолучение списка типов аварии 
create procedure EGH.GetEmergencyClassList
 as begin
	declare @rc int = -1;
	select	 од“ипајварии,
			Ќаименование“ипајварии,
			ћинћасса,
			ћаксћасса
	from dbo. лассификаци€јварий;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ќбновление типа аварии 
create  procedure EGH.UpdateEmergencyClass(
						@ од“ипајварии int, 
						@Ќаименование“ипајварии nvarchar(max),
						@ћинћасса real, 
						@ћаксћасса real) 
as begin 
    declare @rc int = -1;
	update  dbo. лассификаци€јварий set
	 Ќаименование“ипајварии = @Ќаименование“ипајварии,
	 ћинћасса = @ћинћасса,
	 ћаксћасса = @ћаксћасса
	 where  од“ипајварии = @ од“ипајварии;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ѕолучение следующего кода типа аварии 
create procedure EGH.GetNextEmergencyClassCode(@ од“ипајварии int output)
 as begin
	declare @rc int = -1;
	set @ од“ипајварии = 
		(select max( од“ипајварии)+1 from dbo. лассификаци€јварий);
	set @rc = @@ROWCOUNT;
	if @ од“ипајварии is null 
	begin
		set @ од“ипајварии = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


