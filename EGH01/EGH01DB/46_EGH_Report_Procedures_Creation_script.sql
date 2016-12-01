----------------- �������� �������� --------- -------------------------------
---- ������ 
-----------------------------------------------------------------------------
---- ��������� ���������� ID ������
---- ���������� ������
---- �������� ������ 
---- ���������� ������
---- ��������� ������ �� ID 
---- ��������� ������ ������� 
---- ��������� ������ ������� �� ������� �� ������� � ������

-----------------------------------------------------------------------------
drop procedure EGH.GetNextReportId;
drop procedure EGH.CreateReport;
drop procedure EGH.DeleteReport; 
drop procedure EGH.UpdateReport;
drop procedure EGH.GetReportById;
drop procedure EGH.GetReportList;
go
------------------------------------

-- ���������� ������ 
create procedure EGH.CreateReport (	@Id������ int,  
									@���������� datetime,
									@������ nchar(1),
									@�������� int, 
									@����������� xml, 
									@����������� nvarchar(MAX))
as begin 
declare @rc int  = @Id������;
	begin try
		insert into dbo.�����(Id������, ����������,������, ��������, �����������, �����������) 
		values(@Id������, @����������, @������, @��������, @�����������, @�����������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- �������� ������
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
-- ��������� ������ �� ID 
create  procedure EGH.GetReportById(@Id������ int) 
as begin 
    declare @rc int = -1;
	select Id������,
			����������,
			�.������ ������, 
			��������, 
			�����������, 
			�����������,
			�����������
	from dbo.����� � inner join dbo.����������� � on �.������ = �.������
	where Id������ = @Id������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ������ ������� 
create procedure EGH.GetReportList
 as begin
	declare @rc int = -1;
	select Id������,
			����������,
			�.������ ������, 
			��������, 
			�����������,
			�����������,
			����������� 
	from dbo.����� � inner join dbo.����������� � on �.������ = �.������
			order by Id������ desc;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ���������� ID ������ 
create procedure EGH.GetNextReportId(@Id������ int output)
 as begin
	declare @rc int = -1;
	set @Id������ = (select max(Id������)+1 from dbo.�����);
	set @rc = @@ROWCOUNT;
	if @Id������ is null 
	begin
		set @Id������ = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go
-- ���������� ����������� ������ �� ID 
create  procedure EGH.UpdateReport(@Id������ int, @����������� nvarchar(MAX)) 
as begin 
    declare @rc int = -1;
	update  dbo.����� 
	set ����������� = @����������� 
	where Id������ = @Id������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ������� � ������������ ������
create procedure EGH.GetStageReportList(@������ nchar(10) output)
 as begin
	declare @rc int = -1;
	select 
			Id������,
			����������,
			�.������ ������, 
			��������, 
			�����������,
			�����������,
			����������� 
	from dbo.����� � inner join dbo.����������� � on �.������ = �.������
	where �.������ = @������ order by Id������ desc;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ������� - ������� � ������
create procedure EGH.GetParentReportList(@Id������ int output)
 as begin
	declare @rc int = -1;
	select Id������,
			����������,
			������, 
			��������, 
			�����������, 
			����������� 
	from dbo.�����
	where �������� = @Id������ order by Id������ desc;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go


-- ��������� ������ ���������
create procedure EGH.GetEcoForecastList
 as begin
	declare @rc int = -1;
	select 
			Id������,
			����������,
			�.������ ������, 
			��������, 
			�����������,
			�����������,
			����������� 
	from dbo.����� � inner join dbo.����������� � on �.������ = �.������
	where �.������ = '�' order by Id������ desc;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

