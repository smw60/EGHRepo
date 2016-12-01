----------------- �������� �������� --------- -------------------------------
---- ��������� ������������ ���������� - WaterProtectionArea
-----------------------------------------------------------------------------
---- ���������� ��������� ������������ ����������
---- �������� ��������� ������������ ����������
---- ��������� ��������� ������������ ���������� �� ����
---- ��������� ������ ����� ������������ ����������
---- ���������� ��������� ������������ ����������
---- ��������� ���������� ���� ��������� ������������ ����������
-----------------------------------------------------------------------------
use egh;
go
--drop procedure EGH.CreateWaterProtectionArea;
--drop procedure EGH.DeleteWaterProtectionArea;
--drop procedure EGH.GetWaterProtectionAreaByCode;
--drop procedure EGH.GetWaterProtectionAreaList;
--drop procedure EGH.UpdateWaterProtectionArea;
--drop procedure EGH.GetNextWaterProtectionAreaCode;
--go
------------------------------------

-- ���������� ��������� ������������ ����������
create procedure EGH.CreateWaterProtectionArea(
						@���������������� int,  
						@��������������������� nvarchar(max))
as begin 
declare @rc int  = @����������������;
	begin try
		insert into dbo.�������������������������������(
							����������������,
							���������������������) 
				values(@����������������,
					   @���������������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� ��������� ������������ ����������
create procedure EGH.DeleteWaterProtectionArea (@���������������� int)
as begin 
    declare @rc int  = @����������������;
    begin try 
	 delete dbo.������������������������������� 
	 where ���������������� = @����������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

-- ��������� ��������� ������������ ���������� �� ID
create  procedure EGH.GetWaterProtectionAreaByCode(@���������������� int) 
as begin 
    declare @rc int = -1;
	select  ���������������������
	from dbo.������������������������������� 
	where ���������������� = @����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ����� ������������ ����������
create procedure EGH.GetWaterProtectionAreaList
 as begin
	declare @rc int = -1;
	select	����������������,
			���������������������
	from dbo.�������������������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ���������� �������� ��������� ������������ ����������
create procedure EGH.GetNextWaterProtectionAreaCode(@���������������� int output)
 as begin
	declare @rc int = -1;
	set @���������������� = 
	(select	max(����������������) +1 from dbo.�������������������������������);
	set @rc = @@ROWCOUNT;
	if @���������������� is null 
	begin
		set @���������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go
---- ���������� ��������� ������������ ����������
create  procedure EGH.UpdateWaterProtectionArea(
						@���������������� int, 
						@��������������������� nvarchar(max)) 
as begin 
    declare @rc int = -1;
	update  dbo.������������������������������� set
			��������������������� = @���������������������
	from dbo.������������������������������� 
	where ���������������� = @����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


