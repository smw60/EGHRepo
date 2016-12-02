------------- �������� �������� Petrochemical Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreatePetrochemicalType	@��������������������= 17,  
										@����������������������������� = 'test',
										@������������������ =  130.2,
										@��������� =  23.5,
										@���������������������� =  56.7,
										@������������� =  24.3;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeletePetrochemicalType @��������������������= 8;
select @rc;
go
-- by code
declare @rc int = -1;
declare @Name nvarchar(50) = '';
exec @rc = EGH.GetPetrochemicalTypeByCode @�������������������� = 5;
select @rc;
print @Name;
go
-- list
exec EGH.GetPetrochemicalTypeList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdatePetrochemicalType	@�������������������� = 9,  
										@����������������������������� = '������� �����������',
										@������������������ =  200,
										@��������� =  0.89,
										@���������������������� =  0.89,
										@������������� =  50;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextPetrochemicalTypeCode @�������������������� = @rc output;
select @rc;
go
