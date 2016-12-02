----------------- Создание процедур --------- -------------------------------
---- Категории загрязнения грунтов (SoilPollutionCategories)
-----------------------------------------------------------------------------
---- Добавление категории загрязнения грунтов
---- Удаление категории загрязнения грунтов
---- Получение категории загрязнения грунтов
---- Получение категории загрязнения грунтов
---- Обновление категории загрязнения грунтов
---- Получение следующего кода категории загрязнения грунтов
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateSoilPollutionCategories;
drop procedure EGH.DeleteSoilPollutionCategories; 
drop procedure EGH.GetSoilPollutionCategoriesByCode;
drop procedure EGH.GetSoilPollutionCategoriesList;
drop procedure EGH.UpdateSoilPollutionCategories;
drop procedure EGH.GetNextSoilPollutionCategoriesCode;
go
------------------------------------

---- Добавление категории загрязнения грунтов
create procedure EGH.CreateSoilPollutionCategories (
					@КодКатегорииЗагрязненияГрунта int,  
					@НаименованиеКатегорииЗагрязненияГрунта nvarchar(100),
					@МинДиапазон real, 
					@МаксДиапазон real)
as begin 
declare @rc int  = @КодКатегорииЗагрязненияГрунта;
	begin try
		insert into dbo.КатегорияЗагрязненияГрунта(
		КодКатегорииЗагрязненияГрунта, 
		НаименованиеКатегорииЗагрязненияГрунта,
		МинДиапазон,
		МаксДиапазон) 
		values(@КодКатегорииЗагрязненияГрунта, 
				@НаименованиеКатегорииЗагрязненияГрунта,
				@МинДиапазон, 
				@МаксДиапазон); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- Удаление категории загрязнения грунтов
create procedure EGH.DeleteSoilPollutionCategories (@КодКатегорииЗагрязненияГрунта int)
as begin 
    declare @rc int  = @КодКатегорииЗагрязненияГрунта;
    begin try 
	 delete dbo.КатегорияЗагрязненияГрунта 
	 where КодКатегорииЗагрязненияГрунта = @КодКатегорииЗагрязненияГрунта;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- Получение категории загрязнения грунтов по коду
create  procedure EGH.GetSoilPollutionCategoriesByCode(@КодКатегорииЗагрязненияГрунта int) 
as begin 
    declare @rc int = -1;
	select  
		КодКатегорииЗагрязненияГрунта,
		НаименованиеКатегорииЗагрязненияГрунта,
		МинДиапазон,
		МаксДиапазон
	from dbo.КатегорияЗагрязненияГрунта 
	where КодКатегорииЗагрязненияГрунта = @КодКатегорииЗагрязненияГрунта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- Получение списка категории загрязнения грунтов
create procedure EGH.GetSoilPollutionCategoriesList
 as begin
	declare @rc int = -1;
	select	КодКатегорииЗагрязненияГрунта,
			НаименованиеКатегорииЗагрязненияГрунта,
			МинДиапазон,
			МаксДиапазон
	from dbo.КатегорияЗагрязненияГрунта;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- Обновление типа категории загрязнения грунтов
create  procedure EGH.UpdateSoilPollutionCategories(
						@КодКатегорииЗагрязненияГрунта int, 
						@НаименованиеКатегорииЗагрязненияГрунта nvarchar(100),
						@МинДиапазон real, 
						@МаксДиапазон real) 
as begin 
    declare @rc int = -1;
	update  dbo.КатегорияЗагрязненияГрунта set
	 НаименованиеКатегорииЗагрязненияГрунта = @НаименованиеКатегорииЗагрязненияГрунта,
	 МинДиапазон = @МинДиапазон,
	 МаксДиапазон = @МаксДиапазон
	 where КодКатегорииЗагрязненияГрунта = @КодКатегорииЗагрязненияГрунта;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- Получение следующего кода категории загрязнения грунтов
create procedure EGH.GetNextSoilPollutionCategoriesCode(@КодКатегорииЗагрязненияГрунта int output)
 as begin
	declare @rc int = -1;
	set @КодКатегорииЗагрязненияГрунта = 
		(select max(КодКатегорииЗагрязненияГрунта)+1 from dbo.КатегорияЗагрязненияГрунта);
	set @rc = @@ROWCOUNT;
	if @КодКатегорииЗагрязненияГрунта is null 
	begin
		set @КодКатегорииЗагрязненияГрунта = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


