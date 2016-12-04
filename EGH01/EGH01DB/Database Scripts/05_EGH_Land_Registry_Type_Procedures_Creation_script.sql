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

use egh;
go

drop procedure EGH.CreateLandRegistryType;
drop procedure EGH.DeleteLandRegistryType;
drop procedure EGH.GetLandRegistryTypeByCode;
drop procedure EGH.GetLandRegistryTypeList;
drop procedure EGH.UpdateLandRegistryType;
drop procedure EGH.GetNextLandRegistryTypeCode;
go

------------------------------------

-- ���������� ���� ������������ ���������� ������
create procedure EGH.CreateLandRegistryType(
						@������������������� int,  
						@���������������������������� nvarchar(max),
						@��� real,
						@������� real,
						@����������������� nvarchar(max),
						@���������������� nvarchar(max))
as begin 
declare @rc int  = @�������������������;
	begin try
		insert into dbo.����������������(
							�������������������,
							����������������������������,
							���,
							�������,
							�����������������,
							����������������) 
				values (@�������������������,  
						@����������������������������,
						@���,
						@�������,
						@�����������������,
						@����������������); 
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
create  procedure EGH.GetLandRegistryTypeByCode(@������������������� int)
as begin 
    declare @rc int = -1;
	select  �������������������,
			����������������������������,
			���,
			�������,
			�����������������,
			����������������
		from  dbo.����������������
		where ������������������� = @�������������������;  
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
			���,
			�������,
			�����������������,
			����������������
	from dbo.���������������� K
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ���� ������������ ���������� ������
create  procedure EGH.UpdateLandRegistryType(
					@������������������� int, 
					@������������ nvarchar(max) output,
					@����������� real output,
					@������� real output,
					@����������������� nvarchar(max) output,
					@���������������� nvarchar(max) output)
as begin 
    declare @rc int = -1;
	update  dbo.���������������� 
	set 
	���������������������������� = @������������, 
	��� = @�����������,
	������� = @�������,
	����������������� = @�����������������,
	���������������� = @����������������
	where ������������������� = @�������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ���� ������������ ���������� ������
create procedure EGH.GetNextLandRegistryTypeCode(@������������������� int output)
 as begin
	declare @rc int = -1;
	set @������������������� =(select max(�������������������)+1 from dbo.����������������);
	set @rc = @@ROWCOUNT;
	if @������������������� is null 
		begin
			set @������������������� = 1;
			set @rc = 1;
		end;
	return @rc;    
end;
go
