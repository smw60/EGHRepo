----------------- �������� �������� --------- -------------------------------
---- ��������� ����������� ������� (SoilPollutionCategories)
-----------------------------------------------------------------------------
---- ���������� ��������� ����������� �������
---- �������� ��������� ����������� �������
---- ��������� ��������� ����������� �������
---- ��������� ��������� ����������� �������
---- ���������� ��������� ����������� �������
---- ��������� ���������� ���� ��������� ����������� �������
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateSoilPollutionCategories;
drop procedure EGH.DeleteSoilPollutionCategories; 
drop procedure EGH.GetSoilPollutionCategoriesByCode;
drop procedure EGH.GetSoilPollutionCategoriesList;
drop procedure EGH.UpdateSoilPollutionCategories;
drop procedure EGH.GetNextSoilPollutionCategoriesCode;
go
------------------------------------

---- ���������� ��������� ����������� �������
create procedure EGH.CreateSoilPollutionCategories (
					@����������������������������� int,  
					@�������������������������������������� nvarchar(100),
					@����������� real, 
					@������������ real)
as begin 
declare @rc int  = @�����������������������������;
	begin try
		insert into dbo.��������������������������(
		�����������������������������, 
		��������������������������������������,
		�����������,
		������������) 
		values(@�����������������������������, 
				@��������������������������������������,
				@�����������, 
				@������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- �������� ��������� ����������� �������
create procedure EGH.DeleteSoilPollutionCategories (@����������������������������� int)
as begin 
    declare @rc int  = @�����������������������������;
    begin try 
	 delete dbo.�������������������������� 
	 where ����������������������������� = @�����������������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- ��������� ��������� ����������� ������� �� ����
create  procedure EGH.GetSoilPollutionCategoriesByCode(@����������������������������� int) 
as begin 
    declare @rc int = -1;
	select  
		�����������������������������,
		��������������������������������������,
		�����������,
		������������
	from dbo.�������������������������� 
	where ����������������������������� = @�����������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ��������� ����������� �������
create procedure EGH.GetSoilPollutionCategoriesList
 as begin
	declare @rc int = -1;
	select	�����������������������������,
			��������������������������������������,
			�����������,
			������������
	from dbo.��������������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� ���� ��������� ����������� �������
create  procedure EGH.UpdateSoilPollutionCategories(
						@����������������������������� int, 
						@�������������������������������������� nvarchar(100),
						@����������� real, 
						@������������ real) 
as begin 
    declare @rc int = -1;
	update  dbo.�������������������������� set
	 �������������������������������������� = @��������������������������������������,
	 ����������� = @�����������,
	 ������������ = @������������
	 where ����������������������������� = @�����������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ���������� ���� ��������� ����������� �������
create procedure EGH.GetNextSoilPollutionCategoriesCode(@����������������������������� int output)
 as begin
	declare @rc int = -1;
	set @����������������������������� = 
		(select max(�����������������������������)+1 from dbo.��������������������������);
	set @rc = @@ROWCOUNT;
	if @����������������������������� is null 
	begin
		set @����������������������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


