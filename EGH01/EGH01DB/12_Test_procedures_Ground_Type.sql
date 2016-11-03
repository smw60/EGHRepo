------------- �������� �������� Ground Type ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateGroundType 
				@�������������= 2, 
				@���������������������� = '����������',
				@�������������� = 0.7,
				@�������������������� = 5.2,
				@������������������ =7.5,
				@������������ = 3.6,
				@����������������� = 8.6,
				@����������� = 2.0;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteGroundType @������������� = 2;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetGroundTypeByCode @�������������= 1;
select @rc;
go
-- list
exec EGH.GetGroundTypeList;
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateGroundType 
				@�������������= 2, 
				@��������������������������� = '���������',
				@������������������� = 0.7,
				@������������������������� = 5.2,
				@����������������������� =7.5,
				@����������������� = 3.6,
				@���������������������� = 8.6,
				@���������������� = 2.0;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextGroundTypeCode @�������������=@rc output;
select @rc;
go
