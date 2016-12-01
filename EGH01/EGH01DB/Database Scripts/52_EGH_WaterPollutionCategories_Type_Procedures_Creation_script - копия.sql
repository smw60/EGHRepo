----------------- Создание процедур --------- -------------------------------
---- Категории загрязнения грунтовых вод (WaterPollutionCategories)
-----------------------------------------------------------------------------
---- Добавление категории загрязнения грунтовых вод 
---- Удаление категории загрязнения грунтовых вод 
---- Получение категории загрязнения грунтовых вод 
---- Получение категории загрязнения грунтовых вод 
---- Обновление категории загрязнения грунтовых вод 
---- Получение следующего кода категории загрязнения грунтовых вод 
-----------------------------------------------------------------------------
use egh;
go

drop procedure EGH.CreateWaterPollutionCategories;
drop procedure EGH.DeleteWaterPollutionCategories; 
drop procedure EGH.GetWaterPollutionCategoriesByCode;
drop procedure EGH.GetWaterPollutionCategoriesList;
drop procedure EGH.UpdateWaterPollutionCategories;
drop procedure EGH.GetNextWaterPollutionCategoriesCode;
go
------------------------------------

---- Добавление категории загрязнения грунтовых вод 
create procedure EGH.CreateWaterPollutionCategories (
					@КодКатегорииЗагрязненияГВ int,  
					@НаименованиеКатегорииЗагрязненияГВ nvarchar(100),
					@МинДиапазон real, 
					@МаксДиапазон real)
as begin 
declare @rc int  = @КодКатегорииЗагрязненияГВ;
	begin try
		insert into dbo.КатегорияЗагрязненияГрунтовыхВод(
		КодКатегорииЗагрязненияГВ, 
		НаименованиеКатегорииЗагрязненияГВ,
		МинДиапазон,
		МаксДиапазон) 
		values(@КодКатегорииЗагрязненияГВ, 
				@НаименованиеКатегорииЗагрязненияГВ,
				@МинДиапазон, 
				@МаксДиапазон); 
	end try
	begin catch
	    set @rc = -1;
	end catch 
  return @rc;  
end;
go

---- Удаление категории загрязнения грунтовых вод 
create procedure EGH.DeleteWaterPollutionCategories (@КодКатегорииЗагрязненияГВ int)
as begin 
    declare @rc int  = @КодКатегорииЗагрязненияГВ;
    begin try 
	 delete dbo.КатегорияЗагрязненияГрунтовыхВод where КодКатегорииЗагрязненияГВ = @КодКатегорииЗагрязненияГВ;
	end try
	begin catch
	    set @rc = -1;
	end catch   
	return @rc;
end; 
go

---- Получение категории загрязнения грунтовых вод  по коду
create  procedure EGH.GetWaterPollutionCategoriesByCode(@КодКатегорииЗагрязненияГВ int) 
as begin 
    declare @rc int = -1;
	select  
		КодКатегорииЗагрязненияГВ,
		НаименованиеКатегорииЗагрязненияГВ,
		МинДиапазон,
		МаксДиапазон
	from dbo.КатегорияЗагрязненияГрунтовыхВод 
	where КодКатегорииЗагрязненияГВ = @КодКатегорииЗагрязненияГВ;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

-- Получение списка категории загрязнения грунтовых вод 
create procedure EGH.GetWaterPollutionCategoriesList
 as begin
	declare @rc int = -1;
	select	КодКатегорииЗагрязненияГВ,
			НаименованиеКатегорииЗагрязненияГВ,
			МинДиапазон,
			МаксДиапазон
	from dbo.КатегорияЗагрязненияГрунтовыхВод;
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- Обновление типа категории загрязнения грунтовых вод  
create  procedure EGH.UpdateWaterPollutionCategories(
						@КодКатегорииЗагрязненияГВ int, 
						@НаименованиеКатегорииЗагрязненияГВ nvarchar(100),
						@МинДиапазон real, 
						@МаксДиапазон real) 
as begin 
    declare @rc int = -1;
	update  dbo.КатегорияЗагрязненияГрунтовыхВод set
	 НаименованиеКатегорииЗагрязненияГВ = @НаименованиеКатегорииЗагрязненияГВ,
	 МинДиапазон = @МинДиапазон,
	 МаксДиапазон = @МаксДиапазон
	 where КодКатегорииЗагрязненияГВ = @КодКатегорииЗагрязненияГВ;  
	set @rc = @@ROWCOUNT;
	return @rc;    
end;
go

---- Получение следующего кода категории загрязнения грунтовых вод  
create procedure EGH.GetNextWaterPollutionCategoriesCode(@КодКатегорииЗагрязненияГВ int output)
 as begin
	declare @rc int = -1;
	set @КодКатегорииЗагрязненияГВ = 
		(select max(КодКатегорииЗагрязненияГВ)+1 from dbo.КатегорияЗагрязненияГрунтовыхВод);
	set @rc = @@ROWCOUNT;
	if @КодКатегорииЗагрязненияГВ is null 
	begin
		set @КодКатегорииЗагрязненияГВ = 1;
		set @rc = 1;
	end;
	return @rc;    
end;
go


