----------------- �������� �������� --------- -------------------------------
---- ������ 
-----------------------------------------------------------------------------
---- ��������� ���������� ID ������
---- ���������� ������
---- �������� ������ 
---- ���������� ������
---- ��������������� �� ID 
---- ��������� ������ ������� 
---- ��������� ������ ������� �� ������� �� ������� � ������

-----------------------------------------------------------------------------
drop procedure EGH.GetNextReportCode;
drop procedure EGH.CreateReport;
drop procedure EGH.DeleteReport; 
drop procedure EGH.UpdateReport;
drop procedure EGH.GetReportByCode;
drop procedure EGH.GetReportList;
go
------------------------------------

-- ���������� ���� ��������������� �������� 
create procedure EGH.CreateReport (	@Id������ int,  
									@���������� date, 
									@����������� nchar(20), 
									@�������� int, 
									@����������� xml, 
									@������ int)
as begin 
declare @rc int  = @Id������;
	begin try
		insert into dbo.�����(Id������, ����������, �����������, ��������, �����������, ������) 
		values(@Id������, @����������, @�����������, @��������, @�����������, @������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- �������� ���� ��������������� �������� 
create procedure EGH.DeleteReport (@Id������ int)
as begin 
    declare @rc int  = @Id������;
    begin try 
	 delete dbo.����� where Id������ = @Id������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- ��������� ���� ��������������� �������� �� ID 
create  procedure EGH.GetReportByCode(@Id������ int) 
as begin 
    declare @rc int = -1;
	select  ����������,
			�����������, 
			��������, 
			�����������, 
			������
	from dbo.����� where Id������ = @Id������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ����� ��������������� �������� 
create procedure EGH.GetReportList
 as begin
	declare @rc int = -1;
	select Id������, ����������, �����������, ��������, �����������, ������ from dbo.�����;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ���� ��������������� �������� 
create  procedure EGH.UpdateReport( @Id������ int,
									@���������� date, 
									@����������� nchar(20), 
									@�������� int, 
									@����������� xml, 
									@������ int)
as begin 
    declare @rc int = -1;
	update  dbo.����� 
	set 
		���������� = @����������,
		����������� = @�����������, 
		�������� = @��������, 
		����������� = @�����������, 
		������ = @������ 
	where Id������ = @Id������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ���� ��������������� �������� 
create procedure EGH.GetNextReportCode(@Id������ int output)
 as begin
	declare @rc int = -1;
	set @Id������ = (select max(Id������)+1 from dbo.�����);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
