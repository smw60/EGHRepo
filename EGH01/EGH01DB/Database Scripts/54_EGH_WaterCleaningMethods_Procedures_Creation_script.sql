----------------- �������� �������� --------- -------------------------------
---- ��������� ������� ���������� ����������� ��������� ��� (WaterCleaningMethods)
-----------------------------------------------------------------------------
---- ���������� ��������� ������� ���������� ����������� ��������� ���
---- �������� ��������� ������� ���������� ����������� ��������� ���
---- ��������� ��������� ������� ���������� ����������� ��������� ���
---- ��������� ��������� ������� ���������� ����������� ��������� ���
---- ���������� ��������� ������� ���������� ����������� ��������� ���
---- ��������� ���������� ���� ��������� ������� ���������� ����������� ��������� ���
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateWaterCleaningMethods;
drop procedure EGH.DeleteWaterCleaningMethods; 
drop procedure EGH.GetWaterCleaningMethodsByCode;
drop procedure EGH.GetWaterCleaningMethodsList;
drop procedure EGH.UpdateWaterCleaningMethods;
drop procedure EGH.GetNextWaterCleaningMethodsCode;
go
------------------------------------

---- ���������� ��������� ������� ���������� ����������� ��������� ���
create procedure EGH.CreateWaterCleaningMethods (
					@���������������� int,  
					@�������������� nvarchar(MAX))
as begin 
declare @rc int  = @����������������;
	begin try
		insert into dbo.������������������������(
		����������������, 
		��������������) 
		values(@����������������, 
				@��������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- �������� ��������� ������� ���������� ����������� ��������� ���
create procedure EGH.DeleteWaterCleaningMethods (@���������������� int)
as begin 
    declare @rc int  = @����������������;
    begin try 
	 delete dbo.������������������������ where ���������������� = @����������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- ��������� ��������� ������� ���������� ����������� ��������� ��� �� ����
create  procedure EGH.GetWaterCleaningMethodsByCode(@���������������� int) 
as begin 
    declare @rc int = -1;
	select  
		����������������,
		��������������
	from dbo.������������������������ 
	where ���������������� = @����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ��������� ������� ���������� ����������� ��������� ���
create procedure EGH.GetWaterCleaningMethodsList
 as begin
	declare @rc int = -1;
	select	����������������,
			��������������
	from dbo.������������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� ��������� ������� ���������� ����������� ��������� ���
create  procedure EGH.UpdateWaterCleaningMethods(
						@���������������� int, 
						@�������������� nvarchar(max)) 
as begin 
    declare @rc int = -1;
	update  dbo.������������������������ set
	 �������������� = @��������������
	 where ���������������� = @����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ���������� ���� ��������� ������� ���������� ����������� ��������� ���
create procedure EGH.GetNextWaterCleaningMethodsCode(@���������������� int output)
 as begin
	declare @rc int = -1;
	set @���������������� = 
		(select max(����������������)+1 from dbo.������������������������);
	set @rc = @@ROWCOUNT;
	if @���������������� is null 
	begin
		set @���������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


