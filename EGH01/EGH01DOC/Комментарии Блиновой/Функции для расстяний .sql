use EGH;
go

select * from dbo.����������������
select * from dbo.���������
-------------- ���������� ������� ������������� ����� ---------------------------------------
go
declare @id  int = -1, 
        @rc1 int =  0, 
        @rc2 int =  0;
exec  @rc1 = EGH.GetNextAnchorPointId @Id������������������������� = @id output
if @rc1 > 0 
begin
    exec  @rc2 = EGH.CreateAnchorPoint  @Id������������������������� = @id,
                                        @���������� = 53.663197,  @����������� = 27.143456,
                                        @��������� = 1,
                                        @������������������� = 6.0,
                                        @����������������� = 120.0,
                                        @������������������� = 1;  
end;
if @rc1 > 0 and @rc2 > 0  select * from  dbo.������������������������� where  Id������������������������� = @id;
else select @rc1 as rc1, @rc2 as rc2;

go
------------- -------------------------------------------------------------------------------------------------
-- ���������� ����� ����� �������
drop function EGH.Distance;
go
create function EGH.Distance(@lat1 float, @lng1 float, @lat2 float, @lng2 float) returns float as 
begin
  declare @LatM float = 111321.4, @LngM float = 111134.9;
  declare @x float = power(@LatM*cos(@lat1*pi()/180.0)*(@lng1-@lng2),2), 
          @y float = power(@LngM*(@lat1-@lat2),2);
  return (round(sqrt(@x+@y),0)); 
end;
go
-------------------------------------------------------------------------------------------------------------------------
go
drop procedure EGH.GetCoordinatesByAngle;
go
-- �� �������� ���. �����, ���������  � ���� ����� ����������  ����� �����
create procedure EGH.GetCoordinatesByAngle @lat1 float, @lng1 float, @angle float, @distance float, 
                                            @lat2 float out, @lng2 float out       
as begin 
  declare @LatM float = 111321.4, @LngM float = 111134.9; 
  declare @dy    float =  @distance*sin(@angle *pi()/180.0)/@LngM,
          @dx    float =  @distance*cos(@angle *pi()/180.0)/(@LatM*cos(@lat1*pi()/180.0)); 
  set @lat2 = round(@lat1 + @dy, 6); 
  set @lng2 = round(@lng1 + @dx, 6); 
 end;

----------------------------------------------------------

declare @lat float = 0.0 , @lng float = 0.0;
exec  EGH.GetCoordinatesByAngle @lat1 = 53.663197,     -- ������ 
                                @lng1 = 27.143456,     -- �������  
                                @angle  = 360,         -- ����������� - ����
                                @distance  = 100.0,    -- ����������
                                @lat2 = @lat out,      --  ������ 
                                @lng2 = @lng out       -- �������
 select @lat, @lng  
 
 

select EGH.Distance(53.663197, 27.143456, 53.663197, 27.144972)   --  0 
select EGH.Distance(53.663197, 27.143456, 53.663833, 27.144528)   --  45
select EGH.Distance(53.663197, 27.143456, 53.664097, 27.143456)   --  90
select EGH.Distance(53.663197, 27.143456, 53.663833, 27.142384)   --  135
select EGH.Distance(53.663197, 27.143456, 53.663197, 27.14194)    -- 180
select EGH.Distance(53.663197, 27.143456, 53.662561, 27.142384)    -- 225
select EGH.Distance(53.663197, 27.143456, 53.662297, 27.143456)    -- 270
select EGH.Distance(53.663197, 27.143456, 53.662561, 27.144528)    -- 315
select EGH.Distance(53.663197, 27.143456, 53.663197, 27.144972)    -- 360


