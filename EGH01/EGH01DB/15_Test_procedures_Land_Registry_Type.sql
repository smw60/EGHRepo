------------- �������� �������� Land Registry Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateLandRegistryType 
					@�������������������= 8,  
					@���������������������������� = '�������� �����',
					@��� = 20;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteLandRegistryType @�������������������= 8;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
declare @p int = -1;
exec @rc = EGH.GetLandRegistryTypeByCode @�������������������= 6,
										 @���������������������������� = @Name output,
										 @��� = @p output;
select @rc;
print @Name;
print @p;
go
-- list
exec EGH.GetLandRegistryTypeList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateLandRegistryType 
				@������������������� = 6, 
				@����������������� = '������� ������� ����� ���������',
				@���������������� = 50;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextLandRegistryTypeCode @������������������� = @rc output;
select @rc;
go
