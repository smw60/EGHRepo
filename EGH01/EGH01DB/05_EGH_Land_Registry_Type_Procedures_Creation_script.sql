----------------- �������� �������� --------- -------------------------------
---- ���� ������������ ���������� ������
-----------------------------------------------------------------------------
---- ���������� ���� ������������ ���������� ������
---- �������� ���� ������������ ���������� ������
---- ��������� ���� ������������ ���������� ������ �� ID
---- ��������� ������ ����� ������������ ���������� ������
---- ���������� ���� ������������ ���������� ������
---- ��������� ���������� ID ���� ������������ ���������� ������
-----------------------------------------------------------------------------
drop procedure EGH.CreateLandRegistryType;
drop procedure EGH.DeleteLandRegistryType;
drop procedure EGH.GetLandRegistryTypeByCode;
drop procedure EGH.GetLandRegistryTypeList;
drop procedure EGH.UpdateLandRegistryType;
drop procedure EGH.GetNextLandRegistryTypeCode;
go;

------------------------------------

-- ���������� ���� ������������ ���������� ������
create procedure EGH.CreateLandRegistryType(
						@������������������� int,  
						@���������������������������� nvarchar(100),
						@��� int)
as begin 
declare @rc int  = @�������������������;
	begin try
		insert into dbo.����������������(
							�������������������,
							����������������������������,
							���) 
				values (@�������������������,  
						@����������������������������,
						@���); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- �������� ���� ������������ ���������� ������
create procedure EGH.DeleteLandRegistryType (@������������������� int)
as begin 
    declare @rc int  = @�������������������;
    begin try 
	 delete dbo.���������������� where ������������������� = @�������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- ��������� ���� ������������ ���������� ������ �� ID
create  procedure EGH.GetLandRegistryTypeByCode(
						@������������������� int,  
						@���������������������������� nvarchar(100) output,
						@��� int output)
as begin 
    declare @rc int = -1;
	select  @���������������������������� = ����������������������������,
			@��� = ���
		from  dbo.���������������� where ������������������� = @�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ����� ������������ ���������� ������
create procedure EGH.GetLandRegistryTypeList
 as begin
	declare @rc int = -1;
	select	�������������������,
			����������������������������,
			���
	from dbo.����������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ���� ������������ ���������� ������
create  procedure UpdateLandRegistryType(@������������������� int, @����������������� nvarchar(50), @���������������� int) 
as begin 
    declare @rc int = -1;
	update  dbo.���������������� set ���������������������������� = @�����������������, ��� = @���������������� where ������������������� = @�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ���� ������������ ���������� ������
create procedure EGH.GetNextLandRegistryTypeCode(@������������������� int output)
 as begin
	declare @rc int = -1;
	set @������������������� =(select (max(�������������������)+1) from [dbo].����������������);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
