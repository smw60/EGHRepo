------------- �������� �������� District  ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateDistrict @������� = 2, @����� = 'Test';
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteDistrict @���������= 126;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetDistrictByCode @���������= 5;
select @rc;
go
-- list
exec EGH.GetDistrictList @������� = 2;
go

-- update
declare @rc int = -1;
exec @rc = EGH.UpdateDistrict @���������= 1, @������� = 2, @����� = '�������������111';
select @rc;
go

--- full list
exec EGH.GetDistrictListFull;
go
