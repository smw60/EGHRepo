----------------- �������� �������� --------- -------------------------------
---- �������
-----------------------------------------------------------------------------
---- ���������� �������
---- �������� �������
---- ��������� ���� �������
---- ��������� ������ ��������
---- ���������� �������
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateRegion;
drop procedure EGH.DeleteRegion; 
drop procedure EGH.GetRegionByCode;
drop procedure EGH.GetRegionList;
drop procedure EGH.UpdateRegion;
go
------------------------------------

-- ���������� �������
create procedure EGH.CreateRegion(@������� nvarchar(50))
as begin 
declare @rc int  = 1;
	begin try
		insert into dbo.�������(�������) values(@�������);
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� �������
create procedure EGH.DeleteRegion (@���������� int)
as begin 
    declare @rc int  = @����������;
    begin try 
	 delete ������� where ���������� = @����������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go


-- ��������� ������� �� ����
create  procedure EGH.GetRegionByCode(@���������� int) 
as begin 
    declare @rc int = -1;
	select 
			����������,
			������� 
	from dbo.������� where ���������� = @����������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


-- ��������� ������ ��������
create procedure EGH.GetRegionList
 as begin
	declare @rc int = -1;
	select 
			����������,
			�������
			from dbo.������� 
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� �������
create procedure EGH.UpdateRegion(@���������� int, @������� nvarchar(50)) 
as begin 
    declare @rc int = -1;
	update dbo.������� 
	set 
		������� = @�������
	where ���������� = @����������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

