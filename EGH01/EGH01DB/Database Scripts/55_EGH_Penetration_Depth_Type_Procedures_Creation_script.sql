----------------- �������� �������� --------- -------------------------------
---- ��������� ������������� ������������� (PenetrationDepth)
-----------------------------------------------------------------------------
---- ���������� ��������� ������������� ������������� 
---- �������� ��������� ������������� ������������� 
---- ��������� ��������� ������������� ������������� 
---- ��������� ��������� ������������� ������������� 
---- ���������� ��������� ������������� ������������� 
---- ��������� ���������� ���� ��������� ������������� ������������� 
---- ��������� ��������� ������������� ������������� �� ������� �������������
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreatePenetrationDepth;
drop procedure EGH.DeletePenetrationDepth; 
drop procedure EGH.GetPenetrationDepthByCode;
drop procedure EGH.GetPenetrationDepthList;
drop procedure EGH.UpdatePenetrationDepth;
drop procedure EGH.GetNextPenetrationDepthCode;
go
------------------------------------

---- ���������� ��������� ������������� ������������� 
create procedure EGH.CreatePenetrationDepth (
					@���������������� int,  
					@������������������������� nvarchar(max),
					@����������� real, 
					@������������ real)
as begin 
declare @rc int  = @����������������;
	begin try
		insert into dbo.�����������������������������������(
		����������������, 
		�������������������������,
		�����������,
		������������) 
		values(@����������������, 
				@�������������������������,
				@�����������, 
				@������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- �������� ��������� ������������� ������������� 
create procedure EGH.DeletePenetrationDepth (@���������������� int)
as begin 
    declare @rc int  = @����������������;
    begin try 
	 delete dbo.����������������������������������� 
	 where ���������������� = @����������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- ��������� ��������� ������������� �������������  �� ����
create  procedure EGH.GetPenetrationDepthByCode(@���������������� int) 
as begin 
    declare @rc int = -1;
	select  
		����������������,
		�������������������������,
		�����������,
		������������
	from dbo.����������������������������������� 
	where ���������������� = @����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ��������� ������������� ������������� 
create procedure EGH.GetPenetrationDepthList
 as begin
	declare @rc int = -1;
	select	����������������,
			�������������������������,
			�����������,
			������������
	from dbo.�����������������������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ���������� ���� ��������� ������������� ������������� 
create  procedure EGH.UpdatePenetrationDepth(
						@���������������� int, 
						@������������������������� nvarchar(max),
						@����������� real, 
						@������������ real) 
as begin 
    declare @rc int = -1;
	update  dbo.����������������������������������� set
	 ������������������������� = @�������������������������,
	 ����������� = @�����������,
	 ������������ = @������������
	 where ���������������� = @����������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- ��������� ���������� ���� ��������� ������������� ������������� 
create procedure EGH.GetNextPenetrationDepthCode(@���������������� int output)
 as begin
	declare @rc int = -1;
	set @���������������� = 
		(select max(����������������)+1 from dbo.�����������������������������������);
	set @rc = @@ROWCOUNT;
	if @���������������� is null 
	begin
		set @���������������� = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


---- ��������� ��������� ������������� ������������� �� ������� �������������
create  procedure EGH.GetPenetrationDepthByDepth(@������� real) 
as begin 
    declare @rc int = -1;
	select  
		����������������,
		�������������������������,
		�����������,
		������������
	from dbo.����������������������������������� 
	where (����������� <= @�������) and (������������ >= @�������);  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go





