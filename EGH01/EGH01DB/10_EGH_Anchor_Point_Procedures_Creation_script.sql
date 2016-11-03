----------------- �������� �������� --------- -------------------------------
---- ������������� �����
-----------------------------------------------------------------------------
---- ���������� ������������� �����
---- �������� ������������� �����
---- ��������� ������������� �����  
---- ��������� ������������� �����
---- ���������� ������������� �����
---- ��������� ���������� ID ������������� �����
-----------------------------------------------------------------------------
drop procedure EGH.CreatePoint;
drop procedure EGH.DeletePoint;
drop procedure EGH.GetPointByID;
drop procedure EGH.GetPointList;
drop procedure EGH.UpdatePoint;
drop procedure EGH.GetNextPointCode;
GO
------------------------------------

-- ���������� ������������� ����� 
create procedure EGH.CreatePoint(
		    @��������������������� int,  
			@���������� float, 
			@����������� float,
			@��������� int,
			@������������������� float,
			@����������������� float)
as begin 
declare @rc int  = @���������������������;
	begin try
		insert into dbo.������������������(
					[���������������������],
					[����������],
					[�����������],
					[���������],
					[�������������������],
					[�����������������]) 
			values (@���������������������,  
					@����������, 
					@�����������,
					@���������,
					@�������������������,
					@�����������������); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

-- �������� ������������� �����
create procedure EGH.DeletePoint (@��������������������� int)
as begin 
    declare @rc int  = @���������������������;
    begin try 
	 delete [dbo].������������������ where ��������������������� = @���������������������;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end;
go

-- ��������� ������������� �����  �� ID 
create  procedure EGH.GetPointByID(@��������������������� int, 
										@���������� float output, 
										@����������� float output,  
										@��������� int output,
										@������������������� float output,
										@����������������� float output) 
as begin 
    declare @rc int = -1;
	select	@���������� = ����������,  
			@����������� = �����������,
			@��������� = ���������,
			@������������������� = �������������������,
			@����������������� = �����������������
	from dbo.������������������ where ��������������������� = @���������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- ��������� ������ ������������� ����� 
create procedure EGH.GetPointList
 as begin
	declare @rc int = -1;
	select	���������������������, 
			����������,
			�����������,
			���������,
			�������������������,
			�����������������
		from dbo.������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ���������� ������������� �����
create  procedure EGH.UpdatePoint(	@��������������������� int, 
									@���������� float,  
									@����������� float,
									@��������� int,
									@������������������� float,
									@����������������� float) 
as begin 
    declare @rc int = -1;
	update  dbo.������������������ set 
	���������� = @����������,
	����������� = @�����������,
	��������� = @���������,
	������������������� = @�������������������,
	����������������� = @�����������������  
	where ��������������������� = @���������������������;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- ��������� ���������� ID ������������� �����
create procedure  EGH.GetNextPointCode
 as begin
	declare @rc int = -1;
	select max(���������������������)+1 from dbo.������������������;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go