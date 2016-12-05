----------------- �������� �������� --------- -------------------------------
---- ��������� ������� ���������� ����������� ������ (SoilCleaningMethods)
-----------------------------------------------------------------------------
---- ���������� ��������� ������� ���������� ����������� ������
---- �������� ��������� ������� ���������� ����������� ������
---- ��������� ��������� ������� ���������� ����������� ������
---- ��������� ��������� ������� ���������� ����������� ������
---- ���������� ��������� ������� ���������� ����������� ������
---- ��������� ���������� ���� ��������� ������� ���������� ����������� ������
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateSoilCleaningMethods;
drop procedure EGH.DeleteSoilCleaningMethods; 
drop procedure EGH.GetSoilCleaningMethodsByCode;
drop procedure EGH.GetSoilCleaningMethodsList;
drop procedure EGH.UpdateSoilCleaningMethods;
drop procedure EGH.GetNextSoilCleaningMethodsCode;
go
------------------------------------

---- ���������� ��������� ������� ���������� ����������� ������
create procedure EGH.CreateSoilCleaningMethods (
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

---- �������� ��������� ������� ���������� ����������� ������
create procedure EGH.DeleteSoilCleaningMethods (@���������������� int)
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

---- ��������� ��������� ������� ���������� ����������� ������ �� ����
create  procedure EGH.GetSoilCleaningMethodsByCode(@���������������� int) 
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

-- ��������� ������ ��������� ������� ���������� ����������� ������
create procedure EGH.GetSoilCleaningMethodsList
 as begin
	declare @rc int = -1;
	select	����������������,
			��������������
	from dbo.������������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� ��������� ������� ���������� ����������� ������
create  procedure EGH.UpdateSoilCleaningMethods(
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

---- ��������� ���������� ���� ��������� ������� ���������� ����������� ������
create procedure EGH.GetNextSoilCleaningMethodsCode(@���������������� int output)
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



