------------- �������� �������� RiskObject ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateRiskObject 
			@Id������������������� = 5,  
			@�������������������������� = 3,
			@����������������������� = 5,
			@������������������������������� = '���-31',
			@������������������������ = '�.�����, ���������, 16',
			@���������� = 26.6,
			@����������� = 56.7,
			@��������� = 1,
			@������������������� = 8.5,
			@����������������� =12.6;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteRiskObject  @Id������������������� = 2;
select @rc;
go
-- by code
declare @rc int = -1;
exec @rc = EGH.GetRiskObjectByID 
		@Id�������������������= 3;
select @rc;
go
-- list
exec EGH.GetRiskObjectList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateRiskObject  
				@Id������������������� = 3, 
				@�������������������������� = 1,
				@����������������������� = 2,
				@������������������������������� = '���-13',
				@������������������������ = '�.�����, ���������, 16',
				@���������� = 26.6,
				@����������� = 56.4,
				@��������� = 1,
				@������������������� = 23.7,
				@����������������� = 45.2;
select @rc;
go
-- next
declare @rc int = -1;
exec EGH.GetNextRiskObjectId @Id������������������� = @rc output;
select @rc;
go
-- less than d
exec EGH.GetListRiskObjectOnDistanceLessThanD @���������� = 26.6, @����������� =56.4, @���������� = 2.2
go
-- between d1 and d2
exec EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1
			 @���������� = 26.6, 
			 @����������� = 56.4, 
			 @����������1 = 1.0, 
			 @����������2 = 2.0;
go