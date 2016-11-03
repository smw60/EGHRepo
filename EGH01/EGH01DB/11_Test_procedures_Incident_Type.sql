------------- �������� �������� Incident Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateIncidentType @�������= 7,  @������������ = '��������';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteIncidentType @�������= 7;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetIncidentTypeByCode @�������= 5, @������������ = @Name output;
select @rc;
print @Name;
go
-- list
exec EGH.GetIncidentTypeList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateIncidentType @�������= 6,  @����������������� = '��������';
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextIncidentTypeCode @�������=@rc output;
select @rc;
go
