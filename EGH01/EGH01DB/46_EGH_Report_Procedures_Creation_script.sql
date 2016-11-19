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

-- Добавление типа природоохранных объектов 
create procedure EGH.CreateReport (	@IdОтчета int,  
									@ДатаОтчета date, 
									@НомерОтчета nchar(20), 
									@Родитель int, 
									@ТекстОтчета xml, 
									@Стадия int)
as begin 
declare @rc int  = @IdОтчета;
	begin try
		insert into dbo.Отчет(IdОтчета, ДатаОтчета, НомерОтчета, Родитель, ТекстОтчета, Стадия) 
		values(@IdОтчета, @ДатаОтчета, @НомерОтчета, @Родитель, @ТекстОтчета, @Стадия); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go
-- Удаление типа природоохранных объектов 
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
-- Получение типа природоохранных объектов по ID 
create  procedure EGH.GetReportByCode(@IdОтчета int) 
as begin 
    declare @rc int = -1;
	select  ДатаОтчета,
			НомерОтчета, 
			Родитель, 
			ТекстОтчета, 
			Стадия
	from dbo.Отчет where IdОтчета = @IdОтчета;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Получение списка типов природоохранных объектов 
create procedure EGH.GetReportList
 as begin
	declare @rc int = -1;
	select IdОтчета, ДатаОтчета, НомерОтчета, Родитель, ТекстОтчета, Стадия from dbo.Отчет;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Обновление типа природоохранных объектов 
create  procedure EGH.UpdateReport( @IdОтчета int,
									@ДатаОтчета date, 
									@НомерОтчета nchar(20), 
									@Родитель int, 
									@ТекстОтчета xml, 
									@Стадия int)
as begin 
    declare @rc int = -1;
	update  dbo.Отчет 
	set 
		ДатаОтчета = @ДатаОтчета,
		НомерОтчета = @НомерОтчета, 
		Родитель = @Родитель, 
		ТекстОтчета = @ТекстОтчета, 
		Стадия = @Стадия 
	where IdОтчета = @IdОтчета;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go
-- Получение следующего ID типа природоохранных объектов 
create procedure EGH.GetNextReportCode(@IdОтчета int output)
 as begin
	declare @rc int = -1;
	set @IdОтчета = (select max(IdОтчета)+1 from dbo.Отчет);
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
