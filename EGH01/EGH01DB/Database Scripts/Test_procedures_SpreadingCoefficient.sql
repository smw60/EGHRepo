------------- �������� �������� Spreading Coefficient ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateSpreadingCoefficient 
			@��������� = 2,  
			@���������� = 0.1,
			@����������� = 100.0,
			@��������� = 92.0,
			@���������� =96.0,
			@������������������ = 4.0,
			@�������������������� = 2;

select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteSpreadingCoefficient  
			@��������� = 2,  
			@���������� = 20,
			@����������� = 40,
			@��������� =1.5,
			@���������� =4.6,
			@������������������ = 2;
select @rc;

go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetSpreadingCoefficientByDelta 
			@��������� = 1,  
			@���������� = 20,
			@����������� = 40,
			@��������� =1.5,
			@���������� = 4.6;
select @rc;

-- list
exec EGH.GetSpreadingCoefficientList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateSpreadingCoefficient
			@��������� = 1,  
			@���������� = 20,
			@����������� = 60,
			@��������� =2,
			@���������� =6,
			@������������������ = 20;
select @rc;
go

declare @rc int = -1;
exec @rc = EGH.UpdateSpreadingCoefficient
			@��������� = 1,  
			@���������� = 20,
			@����������� = 60,
			@��������� = 2,
			@���������� = 6,
			@������������������ = 250;
select @rc;
go
--------------------- get by data
declare @rc int = -1;
declare @c float = 0.0;
exec @rc =EGH.GetSpreadingCoefficientByData 
			@��������� = 1,  
			@����� = 30,
			@����������� = 4,
			@������������������ =@c output;
select @rc;

select @c;