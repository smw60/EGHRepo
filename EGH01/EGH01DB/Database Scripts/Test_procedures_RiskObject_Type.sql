------------- �������� �������� RiskObject Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateRiskObjectType @��������������������������= 3,  @����������������������������������� = '��������������';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteRiskObjectType  @�������������������������� = 2;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetRiskObjectTypeByCode @��������������������������= 3, @����������������������������������� = @Name output;
select @rc;
print @Name;
go
-- list
exec EGH.GetRiskObjectTypeList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateRiskObjectType  @�������������������������� = 3,  @����������������� = '��������';
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextRiskObjectTypeCode @��������������������������=@rc output;
select @rc;
go
