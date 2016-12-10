----------------- �������� �������� --------- -------------------------------
---- ������������� ������  (EmergencyClass)
-----------------------------------------------------------------------------
---- ���������� ���� ������
---- �������� ���� ������ 
---- ��������� ���� ������
---- ��������� ���� ������ �� ����
---- ���������� ���� ������
---- ��������� ���������� ���� ���� ������ 
---- ��������� ���� ������ �� �����
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

---- ���������� ���� ������
create procedure EGH.CreateEmergencyClass (
					@������������� int,  
					@���������������������� nvarchar(max),
					@�������� real, 
					@��������� real)
as begin 
declare @rc int  = @�������������;
	begin try
		insert into dbo.�������������������(
		�������������, 
		����������������������,
		��������,
		���������) 
		values(@�������������, 
				@����������������������,
				@��������, 
				@���������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- �������� ���� ������
create procedure EGH.DeleteEmergencyClass (@������������� int)
as begin 
    declare @rc int  = @�������������;
    begin try 
	 delete dbo.������������������� 
	 where ������������� = @�������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- ��������� ���� ������ �� ����
create  procedure EGH.GetEmergencyClassByCode(@������������� int) 
as begin 
    declare @rc int = -1;
	select  
		�������������,
		����������������������,
		��������,
		���������
	from dbo.������������������� 
	where ������������� = @�������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ����� ������ 
create procedure EGH.GetEmergencyClassList
 as begin
	declare @rc int = -1;
	select	�������������,
			����������������������,
			��������,
			���������
	from dbo.�������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� ���� ������ 
create  procedure EGH.UpdateEmergencyClass(
						@������������� int, 
						@���������������������� nvarchar(max),
						@�������� real, 
						@��������� real) 
as begin 
    declare @rc int = -1;
	update  dbo.������������������� set
	 ���������������������� = @����������������������,
	 �������� = @��������,
	 ��������� = @���������
	 where ������������� = @�������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ���������� ���� ���� ������ 
create procedure EGH.GetNextEmergencyClassCode(@������������� int output)
 as begin
	declare @rc int = -1;
	set @������������� = 
		(select max(�������������)+1 from dbo.�������������������);
	set @rc = @@ROWCOUNT;
	if @������������� is null 
	begin
		set @������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


---- ��������� ���� ������ �� �����
create  procedure EGH.GetEmergencyClassByMass(@����� real) 
as begin 
    declare @rc int = -1;
	select  
		�������������,
		����������������������,
		��������,
		���������
	from dbo.������������������� 
	where (�������� <= @�����)  and (��������� >= @�����);  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

