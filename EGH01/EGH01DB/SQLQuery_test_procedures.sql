declare @rc int = -1;
exec @rc = EGH.CreateRiskObject
		    @Id������������������� =4,  
			@�������������������������� =1,
			@����������������������� =1,
			@������������������������������� ='ttt',
			@������������������������ ='111',
			@���������� = 0.0,
			@����������� = 5.2,
			@��������� =1,
			@������������������� = 6.7,
			@����������������� =7.4;
select @rc;


-- �������� ����������
exec EGH.GetListRiskObjectOnDistanceLessThanD @����������= 3.7, @�����������  = 5.6, @���������� = 145;

exec EGH.GetListRiskObjectOnDistanceLessThanD2MoreThanD1 @����������= 3.7, @�����������  = 5.6, @����������1 = 53, @����������2 = 55;

---- [EGH].[GetPetrochemicalTypeList]
exec EGH.GetPetrochemicalTypeList

exec EGH.GetGroundTypeByCode @������������� = 1;