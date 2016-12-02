------------- �������� �������� EcoObject ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateEcoObject
			@Id����������������������� = 2,  
			@����������������������������������� = '���� ������',
			@������������������������������ = 3,
			@����������������������� = 5,
			@���������� = 26.6,
			@����������� = 56.8,
			@��������� = 1,
			@������������������� = 42.3,
			@����������������� = 12.3;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteEcoObject @Id����������������������� = 2;
select @rc;
go
-- by ID
declare @rc int = -1;
exec @rc = EGH.GetEcoObjectByID @Id����������������������� = 1;
select @rc;
go
-- list
exec EGH.GetEcoObjectList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateEcoObject
			@Id����������������������� = 2,  
			@����������������������������������� = '����� ������',
			@������������������������������ = 3,
			@����������������������� = 5,
			@���������� = 26.6,
			@����������� = 56.8,
			@��������� = 1,
			@������������������� = 42.3,
			@����������������� = 12.3;
select @rc;
go

-- next
declare @rc int = -1;
exec EGH.GetNextEcoObjectId @Id����������������������� = @rc output;
select @rc;
go
-- less than d
exec EGH.GetListEcoObjectOnDistanceLessThanD
			@���������� = 26.6, 
			@����������� = 56.4, 
			@���������� = 1.1
go
-- between d1 and d2
exec EGH.GetListEcoObjectOnDistanceLessThanD2MoreThanD1
			 @���������� = 26.6, 
			 @����������� = 56.4, 
			 @����������1 = 1.0, 
			 @����������2 = 2.0;
go
