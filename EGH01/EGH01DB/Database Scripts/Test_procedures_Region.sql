------------- �������� �������� Region  ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateRegion @������� = 'Test';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteRegion @����������= 7;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetRegionByCode @����������= 5;
select @rc;
go
-- list
exec EGH.GetRegionList;
go

-- update
declare @rc int = -1;
exec @rc = EGH.UpdateRegion @����������= 1, @������� ='���������';
select @rc;
go
