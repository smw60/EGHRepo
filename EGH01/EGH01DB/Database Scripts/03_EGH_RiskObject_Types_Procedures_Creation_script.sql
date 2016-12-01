----------------- �������� �������� --------- -------------------------------
---- ���� ����������� �������� 
-----------------------------------------------------------------------------
---- ���������� ���� ����������� �������� 
---- �������� ���� ����������� �������� 
---- ��������� ���� ����������� �������� �� ID 
---- ��������� ������ ����� ����������� �������� 
---- ���������� ���� ����������� ��������
---- ��������� ���������� ID ���� ����������� ��������
-----------------------------------------------------------------------------
drop procedure EGH.CreateRiskObjectType;
drop procedure EGH.DeleteRiskObjectType; 
drop procedure EGH.GetRiskObjectTypeByCode;
drop procedure EGH.GetRiskObjectTypeList;
drop procedure EGH.UpdateRiskObjectType;
drop procedure EGH.GetNextRiskObjectTypeCode;
go;
------------------------------------

-- ���������� ���� ����������� �������� 
create procedure EGH.CreateRiskObjectType (@�������������������������� int,  @����������������������������������� nvarchar(30))
as begin 
declare @rc int  = @��������������������������;
	begin try
		insert into dbo.����������������������(��������������������������, �����������������������������������) values(@��������������������������, @�����������������������������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- �������� ���� ����������� �������� 
create procedure EGH.DeleteRiskObjectType (@�������������������������� int)
as begin 
    declare @rc int  = @��������������������������;
    begin try 
	 delete dbo.���������������������� where �������������������������� = @��������������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- ��������� ���� ����������� �������� �� ID 
create  procedure EGH.GetRiskObjectTypeByCode(@�������������������������� int, @����������������������������������� nvarchar(30) output) 
as begin 
    declare @rc int = -1;
	select  @����������������������������������� = ����������������������������������� from dbo.���������������������� where �������������������������� = @��������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ����� ����������� �������� 
create procedure EGH.GetRiskObjectTypeList
 as begin
	declare @rc int = -1;
	select ��������������������������, ����������������������������������� from dbo.����������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ���� ����������� �������� 
create  procedure EGH.UpdateRiskObjectType(@�������������������������� int, @����������������� nvarchar(30)) 
as begin 
    declare @rc int = -1;
	update  dbo.���������������������� set ����������������������������������� = @����������������� where �������������������������� = @��������������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ���� ����������� �������� 
create procedure EGH.GetNextRiskObjectTypeCode(@�������������������������� int output)
 as begin
	declare @rc int = -1;
	set @�������������������������� = (select max(��������������������������)+1 from [dbo].[����������������������]);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
