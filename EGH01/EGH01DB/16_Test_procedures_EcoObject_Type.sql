------------- �������� �������� EcoObject Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateEcoObjectType @������������������������������ = 4,  @��������������������������������������� = '����������';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteEcoObjectType @������������������������������= 4;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetEcoObjectTypeByCode
					@������������������������������ = 3, 
					@��������������������������������������� = @Name output;
select @rc;
print @Name;
go
-- list
exec EGH.GetEcoObjectTypeList;
go

-- update
declare @rc int = -1;
exec @rc = EGH.UpdateEcoObjectType @������������������������������= 3,  @����������������� = '����������';
select @rc;
go

-- next
declare @rc int = -1;
exec EGH.GetNextEcoObjectTypeCode @������������������������������ = @rc output;
select @rc;
go
