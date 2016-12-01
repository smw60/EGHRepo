----------------- �������� �������� --------- -------------------------------
---- ��������� ������������� - PetrochemicalCategories
-----------------------------------------------------------------------------
---- ���������� ��������� �������������
---- �������� ��������� �������������
---- ��������� ��������� ������������� �� ����
---- ��������� ������ ����� �������������
---- ���������� ��������� �������������
---- ��������� ���������� ���� ��������� �������������
-----------------------------------------------------------------------------
use egh;
go
--drop procedure EGH.CreatePetrochemicalCategories;
--drop procedure EGH.DeletePetrochemicalCategories;
--drop procedure EGH.GetPetrochemicalCategoriesByCode;
--drop procedure EGH.GetPetrochemicalCategoriesList;
--drop procedure EGH.UpdatePetrochemicalCategories;
--drop procedure EGH.GetNextPetrochemicalCategoriesCode;
--go
------------------------------------

-- ���������� ��������� �������������
create procedure EGH.CreatePetrochemicalCategories(
						@������������������������� int,  
						@���������������������������������� nvarchar(max))
as begin 
declare @rc int  = @�������������������������;
	begin try
		insert into dbo.���������_�������������(
							�������������������������,
							����������������������������������) 
				values(@�������������������������,
					   @����������������������������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� ��������� �������������
create procedure EGH.DeletePetrochemicalCategories (@������������������������� int)
as begin 
    declare @rc int  = @�������������������������;
    begin try 
	 delete dbo.���������_������������� 
	 where ������������������������� = @�������������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

-- ��������� ��������� ������������� �� ID
create  procedure EGH.GetPetrochemicalCategoriesByCode(@������������������������� int) 
as begin 
    declare @rc int = -1;
	select  ����������������������������������
	from dbo.���������_������������� 
	where ������������������������� = @�������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ����� �������������
create procedure EGH.GetPetrochemicalCategoriesList
 as begin
	declare @rc int = -1;
	select	�������������������������,
			����������������������������������
	from dbo.���������_�������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ���������� �������� ��������� �������������
create procedure EGH.GetNextPetrochemicalCategoriesCode(@������������������������� int output)
 as begin
	declare @rc int = -1;
	set @������������������������� = 
	(select	max(�������������������������) +1 from dbo.���������_�������������);
	set @rc = @@ROWCOUNT;
	if @������������������������� is null 
	begin
		set @������������������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go
---- ���������� ��������� �������������
create  procedure EGH.UpdatePetrochemicalCategories(
						@������������������������� int, 
						@���������������������������������� nvarchar(max)) 
as begin 
    declare @rc int = -1;
	update  dbo.���������_������������� set
			���������������������������������� = @����������������������������������
	from dbo.���������_������������� 
	where ������������������������� = @�������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


