----------------- Создание процедур --------- -------------------------------
---- Отчеты 
-----------------------------------------------------------------------------
---- Получение следующего ID отчета
---- Добавление отчета
---- Удаление отчета 
---- Обновление отчета
---- Получениеотчета по ID 
---- Получение списка отчетов 
---- Получение списка отчетов по цепочке от потомка к предку

-----------------------------------------------------------------------------
drop procedure EGH.GetNextReportCode;
drop procedure EGH.CreateReport;
drop procedure EGH.DeleteReport; 
drop procedure EGH.UpdateReport;
drop procedure EGH.GetReportByCode;
drop procedure EGH.GetReportList;
go
------------------------------------

-- Добавление отчета 
create procedure EGH.CreateReport (	@IdОтчета int,  
									@ДатаОтчета datetime,
									@Стадия nchar(1),
									@Родитель int, 
									@ТекстОтчета xml, 
									@Комментарий nvarchar(MAX))
as begin 
declare @rc int  = @IdОтчета;
	begin try
		insert into dbo.Отчет(IdОтчета, ДатаОтчета,Стадия, Родитель, ТекстОтчета, Комментарий) 
		values(@IdОтчета, @ДатаОтчета, @Стадия, @Родитель, @ТекстОтчета, @Комментарий); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- Удаление отчета
create procedure EGH.DeleteReport (@IdОтчета int)
as begin 
    declare @rc int  = @IdОтчета;
    begin try 
	 delete dbo.Отчет where IdОтчета = @IdОтчета;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go
-- Получение отчета по ID 
create  procedure EGH.GetReportByCode(@IdОтчета int) 
as begin 
    declare @rc int = -1;
	select IdОтчета,
			ДатаОтчета,
			Стадия, 
			Родитель, 
			ТекстОтчета, 
			Комментарий
	from dbo.Отчет where IdОтчета = @IdОтчета;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Получение списка отчетов 
create procedure EGH.GetReportList
 as begin
	declare @rc int = -1;
	select IdОтчета,
			ДатаОтчета,
			Стадия, 
			Родитель, 
			ТекстОтчета, 
			Комментарий from dbo.Отчет;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- Получение следующего ID отчета 
create procedure EGH.GetNextReportCode(@IdОтчета int output)
 as begin
	declare @rc int = -1;
	
	set @IdОтчета = (select max(IdОтчета)+1 from dbo.Отчет);
	if @IdОтчета is null 
	begin
		set @IdОтчета = 1;
		set @rc = 1;
	end;
	else
		set @rc = @@ROWCOUNT;
	return @rc;    
end;
go