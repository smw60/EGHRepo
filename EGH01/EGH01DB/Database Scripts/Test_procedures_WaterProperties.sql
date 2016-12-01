------------- �������� �������� WaterProperties ----------------------------------

-- create
declare @rc int = -1;
exec @rc = EGH.CreateWaterProperties 
				@����������������� = 10, 
				@����������� = 80.0,
				@�������� = 130,
				@��������� =8.98,
				@���������� =0.68;
select @rc;
go

insert into dbo.����(�����������������, �����������, ��������, ���������, ����������) 
		values(10, 80.0, 13, 8.98, .68);
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteWaterProperties @����������������� = 10;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetWaterPropertiesByCode @�����������������= 2;
select @rc;
go
-- list
exec EGH.GetWaterPropertiesList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateWaterProperties 
				@����������������� = 10, 
				@����������� = 80.0,
				@�������� = 4350,
				@��������� =8.98,
				@���������� =0.68;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextWaterPropertiesCode @�����������������=@rc output;
select @rc;
go
--near temp
declare @rc int = -1;
exec @rc = EGH.GetWaterNearTemp @�����������= 17;
select @rc;
go