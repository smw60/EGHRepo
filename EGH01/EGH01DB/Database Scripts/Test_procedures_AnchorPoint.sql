------------- �������� �������� Anchor Point ----------------------------------
-- create
declare @rc int = -1;
exec @rc = EGH.CreateAnchorPoint
		    @Id������������������������� = 1 ,  
			@���������� = 26.6, 
			@����������� = 56.8,
			@��������� = 1,
			@������������������� = 3.7,
			@����������������� = 150.2,
			@������������������� = 3;
select @rc;
go
-- delete
declare @rc int = -1;
exec @rc = EGH.DeleteAnchorPoint @Id������������������������� = 2;
select @rc;
go
-- by ID
declare @rc int = -1;
exec @rc = EGH.GetAnchorPointByID @Id������������������������� = 2;
select @rc;
go
-- list
exec EGH.GetAnchorPointList;
go
-- update
declare @rc int = -1;
exec @rc = EGH.UpdateAnchorPoint
			@Id������������������������� =2 ,  
			@���������� = 26.6, 
			@����������� = 56.8,
			@��������� = 1,
			@������������������� = 3.7,
			@����������������� = 15.2,
			@������������������� = 2;
select @rc;
go

-- next
declare @rc int = -1;
declare @Id������������������������� int = -1;
exec  @rc = EGH.GetNextAnchorPointId @Id������������������������� output;
select @rc;
select @Id�������������������������;
go


-- less than d
exec EGH.GetListAnchorPointOnDistanceLessThanD
			@���������� = 8.1339502334594727, 
			@����������� = 142.68394470214844, 
			@���������� = 1000000000;
go
-- between d1 and d2
exec EGH.GetListAnchorPointOnDistanceLessThanD2MoreThanD1
			 @���������� = 8.6, 
			 @����������� = 142.4, 
			 @����������1 = 10, 
			 @����������2 = 200000;
go