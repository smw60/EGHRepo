use EGH;
go

if OBJECT_ID('dbo.�������_�����_�����������������') is not null  drop function dbo.�������_�����_�����������������;
go

create function dbo.�������_�����_�����������������(@p nvarchar(200))
returns table as
return (
	     with likefind as 
	     ( 
            select concat(�.�������,                         �.�����,                           ��.�������������������������������)  ort,
                   concat(�.�������,                         ��.�������������������������������,�.�����)                             otr,
                   concat(�.�����,                           �.�������,                         ��.�������������������������������)  rot,
                   concat(�.�����,                           ��.�������������������������������,�.�������)                           rto,
                   concat(��.�������������������������������,�.�������,                         �.�����)                             tor,
                   concat(��.�������������������������������,�.�����,                           �.�������)                           tro, 
                   �.�������, 
                   �.�����,
                   ��.Id�������������������  
            from ������� � join ����� �               on �.���������� =  �.������� 
                           join ����������������� ��  on ��.�������������������������� = �.���������� 
                                                     and ��.������������������������   = �.���������
         )
         select ort, otr, rot, rto, tor, tro, �������,�����, Id�������������������  
         from likefind                                       
         where ort like @p or otr like @p or rot like @p or rto like @p or tor like @p or tro like @p 
       ); 

go
  
--select �������, �����, Id�������������������  from dbo.�������_�����_�����������������('%%�����%���%')  
--select �������, �����, Id�������������������  from dbo.�������_�����_�����������������('%%�����%%�����%���%')
--select �������, �����, Id�������������������  from dbo.�������_�����_�����������������('%���%�����%���%') 
--select �������, �����, Id�������������������  from dbo.�������_�����_�����������������('%���%%')

if OBJECT_ID('dbo.GetRiskObjectListByLike') is not null  drop function dbo.GetRiskObjectListByLike;
go
create procedure GetRiskObjectListByLike
   @findstring nvarchar(200)
as begin
   declare @p nvarchar(200) = concat('%', replace(rtrim(ltrim(@findstring)), ' ', '%'), '%');  
   
   select �������, �����, Id������������������� 
   from dbo.�������_�����_�����������������(concat('%', replace(rtrim(ltrim(@findstring)), ' ', '%'), '%'));
   
   return @@rowcount;  
end;     
go

--declare @rc int = -1;   
--exec @rc = GetRiskObjectListByLike '�����';
--select @rc
--exec @rc = GetRiskObjectListByLike '���';
--select @rc
--go


   


                                       

