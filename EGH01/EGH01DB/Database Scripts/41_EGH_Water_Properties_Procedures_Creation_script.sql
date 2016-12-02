----------------- �������� �������� --------- -------------------------------
---- �������� ���� 
---- �����������
---- ��������
---- ���������
---- ����������� �������������� ���������
-----------------------------------------------------------------------------
---- ���������� �������� ����������� ���� � ��������������� �������
---- �������� �������� ����������� ���� � ��������������� �������
---- ��������� �������� ����������� ���� � ��������������� ������� �� ����
---- ��������� ������ �������� ����������� ���� � ��������������� �������
---- ���������� �������� ����������� ���� � ��������������� �������
---- ��������� ���������� ���� ��� �������� ����������� ���� � ��������������� �������
---- ��������� ���������� �������� �������� ����������� ���� � ��������������� ������� �� �����������
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateWaterProperties;
drop procedure EGH.DeleteWaterProperties; 
drop procedure EGH.GetWaterPropertiesByCode;
drop procedure EGH.GetWaterPropertiesList;
drop procedure EGH.UpdateWaterProperties;
drop procedure EGH.GetNextWaterPropertiesCode;
drop procedure EGH.GetWaterNearTemp;
go
------------------------------------

-- ���������� �������� ����������� ���� � ��������������� �������
create procedure EGH.CreateWaterProperties (
	@����������������� int, 
	@����������� real,
	@�������� real,
	@��������� real,
	@���������� real)
as begin 
declare @rc int  = @�����������������;
	begin try
		insert into dbo.����(�����������������, �����������, ��������, ���������, ����������) 
		values(@�����������������, @�����������, @��������, @���������, @����������);
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� �������� ����������� ���� � ��������������� �������
create procedure EGH.DeleteWaterProperties (@����������������� int)
as begin 
    declare @rc int  = @�����������������;
    begin try 
	 delete ���� where ����������������� = @�����������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go


-- ��������� �������� ����������� ���� � ��������������� ������� �� ����
create  procedure EGH.GetWaterPropertiesByCode (@����������������� int) 
as begin 
    declare @rc int = -1;
	select 
		�����������������,
		�����������,
		��������,
		���������,
		����������
	from dbo.���� where ����������������� = @�����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


-- ��������� ������ �������� ����������� ���� � ��������������� �������
create procedure EGH.GetWaterPropertiesList
 as begin
	declare @rc int = -1;
	select 
		�����������������, 
		�����������,
		��������, 
		���������, 
		����������
	from dbo.����;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� �������� ����������� ���� � ��������������� �������
create  procedure EGH.UpdateWaterProperties(
					@����������������� int, 
					@����������� real,
					@�������� real,
					@��������� real,
					@���������� real) 
as begin 
    declare @rc int = -1;
	update  dbo.���� set 
		����������� = @�����������, 
		�������� = @��������,
		��������� = @���������,
		���������� = @����������
	where ����������������� = @�����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ���������� ���� �������� ����������� ���� � ��������������� �������
create procedure EGH.GetNextWaterPropertiesCode(@����������������� int output)
 as begin
	declare @rc int = -1;
	set @�����������������= (select max(�����������������)+1 from dbo.����);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� �������� ����������� ���� � ��������������� ������� �� ��������� �����������
create procedure EGH.GetWaterNearTemp(@����������� real)
 as begin
	declare @rc int = -1;
select 
		�����������������, 
		�����������,
		��������, 
		���������, 
		����������,
		����������� - @����������� delta
	from dbo.����
	where ����������� - @�����������  = (
			select min(�����������-@�����������) 
			from dbo.���� where ����������� > @�����������);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go