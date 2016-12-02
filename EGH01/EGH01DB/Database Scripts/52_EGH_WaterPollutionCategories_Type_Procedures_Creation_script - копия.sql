----------------- �������� �������� --------- -------------------------------
---- ��������� ����������� ��������� ��� (WaterPollutionCategories)
-----------------------------------------------------------------------------
---- ���������� ��������� ����������� ��������� ��� 
---- �������� ��������� ����������� ��������� ��� 
---- ��������� ��������� ����������� ��������� ��� 
---- ��������� ��������� ����������� ��������� ��� 
---- ���������� ��������� ����������� ��������� ��� 
---- ��������� ���������� ���� ��������� ����������� ��������� ��� 
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateWaterPollutionCategories;
drop procedure EGH.DeleteWaterPollutionCategories; 
drop procedure EGH.GetWaterPollutionCategoriesByCode;
drop procedure EGH.GetWaterPollutionCategoriesList;
drop procedure EGH.UpdateWaterPollutionCategories;
drop procedure EGH.GetNextWaterPollutionCategoriesCode;
go
------------------------------------

---- ���������� ��������� ����������� ��������� ��� 
create procedure EGH.CreateWaterPollutionCategories (
					@������������������������� int,  
					@���������������������������������� nvarchar(100),
					@����������� real, 
					@������������ real)
as begin 
declare @rc int  = @�������������������������;
	begin try
		insert into dbo.��������������������������������(
		�������������������������, 
		����������������������������������,
		�����������,
		������������) 
		values(@�������������������������, 
				@����������������������������������,
				@�����������, 
				@������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- �������� ��������� ����������� ��������� ��� 
create procedure EGH.DeleteWaterPollutionCategories (@������������������������� int)
as begin 
    declare @rc int  = @�������������������������;
    begin try 
	 delete dbo.�������������������������������� where ������������������������� = @�������������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- ��������� ��������� ����������� ��������� ���  �� ����
create  procedure EGH.GetWaterPollutionCategoriesByCode(@������������������������� int) 
as begin 
    declare @rc int = -1;
	select  
		�������������������������,
		����������������������������������,
		�����������,
		������������
	from dbo.�������������������������������� 
	where ������������������������� = @�������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ��������� ����������� ��������� ��� 
create procedure EGH.GetWaterPollutionCategoriesList
 as begin
	declare @rc int = -1;
	select	�������������������������,
			����������������������������������,
			�����������,
			������������
	from dbo.��������������������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� ���� ��������� ����������� ��������� ���  
create  procedure EGH.UpdateWaterPollutionCategories(
						@������������������������� int, 
						@���������������������������������� nvarchar(100),
						@����������� real, 
						@������������ real) 
as begin 
    declare @rc int = -1;
	update  dbo.�������������������������������� set
	 ���������������������������������� = @����������������������������������,
	 ����������� = @�����������,
	 ������������ = @������������
	 where ������������������������� = @�������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ���������� ���� ��������� ����������� ��������� ���  
create procedure EGH.GetNextWaterPollutionCategoriesCode(@������������������������� int output)
 as begin
	declare @rc int = -1;
	set @������������������������� = 
		(select max(�������������������������)+1 from dbo.��������������������������������);
	set @rc = @@ROWCOUNT;
	if @������������������������� is null 
	begin
		set @������������������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


