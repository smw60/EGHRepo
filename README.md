﻿# EGH
<<<<<<< HEAD
---------------------------------------------------------------------------------------------------------------------------------------
smw60-05.11.2016-Adeln: просьба проверять формы (перврначаьное тестирование), потом утонем - не проверим.  
-------------------------------------------------------------------------------------------------------------------------------------------------------
smw60-05.11.2016-Adeln,DaryaCherniak:  в списке техногенных объектов показывать координта град, мин, сек - в классе в классе Coordinates есть меттоды для перевод в
разные формы, если есть вопросы объясню 
-----------------------------------------------------------------------------------------------------------------------------------------------------
smw60-05.11.2016-Adeln: посм. SMW60/Repo - вики - я правильно поимаю - 2 знака после запятой для секунд в координатах - это достаточно- нам нужна точность до метра 
проверьте пож., чтобы во всех формах была одинаковая (правильная точность) для секунд, а для целых градусов и минут - правильные ограничения    
--------------------------------------------------------------------------------------------------------------------------------------------------------
smw60-05.11.2016-Adeln, DaryaCherniak: при вводе корректировке техн объект, ограничения глубина >0, высота > 0, 0 <= секунды <=60 и три знака после точки   
----------------------------------------------------------------------------------------------------------------------
smw60-05.11.2016-BlinovaE, DaryaCherniak: сделал много изменений в RiskObjectsList - если проблемы сразу мне говорите 

---------------------------------------------------------------------------------------------------------------------------------------------
=======

-------------------------------------------------------------------------------------------------------------
Adeln-05.11.2016 smw60, обновление формул для расчета
-----------------------------------------------------------------------------------------------
smw60-05.11.2016-DaryaCherniak: Извини, вместо float.TryParse примени Helper.FloatTryParse,  на всякий случай       чтобы потом не ползать-именять Culture по всему коду. 
--------------------------------------------------------------------------------------------------------------
>>>>>>> 72048cb46c7bfdc50d248dd55877e76e8d0dabf9
smw60-05.11.2016-DaryaCherniak:
   if (!float.TryParse(strvolume, NumberStyles.Any, new CultureInfo("en-US"), out volume))
   {
          volume = 0.0f;
   } 
-------------------------------------------------------------------------------------------------------------------------
smw60-04.11.2016-BlinovaE: написал процедуру и вспомогательную функцию в БД  лежит в EGH01\EGH01DOC\Комментарии Блиновой
------------------------------------------------------------------------------------------------
smw60-04.11.2016-Nadeghda: хорошо бы на нижней полосе вместо Разработчики - какой-нибудь значок (в качестве бреда - может BSTU с тем же лепестком? ), вместо Система АС - такой значок EGH как на верхней, но меньшего размера . 

----------------------------------------------------------------------------------------------
Adeln-03.11.2016 smw60, файлы от Алексея в EGH01DOC\Данные от Заказчика
smw60 - спсибо, увидел 

--------------------------------
smw60-03.11.2016-AzarkevichO нет коф. разлива не зависит от нефтепрдукта, а только от объема, угла наклона 
и грунта 
----------------------------------------------------------------------------------------------


AzarkevichO-03.11.2016 smw60, в форме Коэффициент разлива не должно быть пункта с выбором типа нефтепродукта?

----------------------------------------------------------------------------------------------

Adeln-03.11.2016  Формулы для расчета в папке Техническое задание

----------------------------------------------------------------------------------------------

 smw60-03.11.2016  DaryaCherniak подойли ко мне исправим кое-что в коде EGH01DB.CAIContext db = new EGH01DB.CAIContext();


----------------------------------------------------------------------------------------------------
smw60-03.11.2016 Adeln, BlinovaE:  EGH01\EGH01DOC\Формы\EGHRGE-П(Прогноз) Коф. разлива - делаем, читаем 
прямо на форме коментарии, можно посмотреть https://ninjamock.com/s/N5R2F5, отдаем DaryaCherniak и AzarkevichO
как заполнить справочник знаю я


smw60-03.11.2016 Adeln, BlinovaE:  EGH01\EGH01DOC\Формы\EGHRGE-П(Прогноз) Типы грунтов - проверяем, делаем, можно посмотреть https://ninjamock.com/s/N5R2F5, отдаем DaryaCherniak и AzarkevichO, составляем таблицы для заполнения 
оправляем


smw60-03.11.2016 Adeln, надо сделать справочник (я так понимаю, там одна строка) по воде опишите и отдаем DaryaCherniak и AzarkevichO предлагаю его в Прогноз\Справочники,    Nadeghda пусть добавит 

smw60-03.11.2016 Adeln, Справочник Категории земли, делать форму  у Алексея выяснить -  ПДК  от типа т Категории земли. Категории в Wiki 

smw60-03.11.2016 Adeln, Справочник типы преродохраных объектов, у Алексея выяснить - зависит ли ПДК  от типа природоохранного объекта или только от Категории земли. Делать справочник. 


smw60-03.11.2016 !!! Adeln, DaryaCherniak и AzarkevichO сегодня оправляем таблицы для заполнения Артему
 4.11 - забираем

---------------------------------------------------------------------------------------------------

smw60-02.11.2016 - тест подключилcя к EGHRepo 
=======
smw60-02.11.2016 - тест подключилcя к EGHRepo и с другого компьютера подключился 

-----------------------------------------------------------------------------------------------
smw60 - 01.11.2016
Nadeghda: на верхней оранжевой - должен отражаться весь путь по меню, чтобы было видно текущее положение относительно
главной страницы 
давайте попробуем  нижнюю линию  сделаем уже, уберем слова Контакты, Сайт компании и так ясно 

Adeln, BlinovaE: нужен объект (и соотв. табл в БД, помните та, что XML) для записи отчета по в модуле RGE и чтения/записи в посл.
Посм. формы отчетов по RGE

Adeln, BlinovaE: нужен объект (и соотв. табл в БД) и для записи внутренних сообщений об ошибках (надо чтобы было ясно где произошла,когда ) - туда будем писать 
со всех мест кода (в т.ч. из SQL-процедур) - это для внутреннего потребления. Не тянем (по-хорошему позавчера) -  кода нарастет, потом менять много     
               
BlinovaE: вы будете примерно так писать в EGH01DB 

           try
                {
                    cmd.ExecuteNonQuery();
                    rc = (int)cmd.Parameters["@exitrc"].Value == district.code;
                   // если < 0 пишем в БД об ошибке  Helper.WritereError( ОТКУДА ПРИШЛА, что произошло) 
                }
                catch (Exception e)
                {
                   // пишем в БД об ошибке Helper.WritereError( ОТКУДА ПРИШЛА, что произшло )
                    rc = false;
                };

  Сигнатуру(ы) предложите Helper.WritereError( ОТКУДА ПРИШЛА )  подумаю и соглашусь - пишите сразу заглушки и мне сообщите
  Мой вариант: Helper.WritereError(EGH/EGHDB,  Класс.метод, номер-места в коде, коментарий - необязятельный)
        из EGH01         Helper.WritereErrorEGH (Класс.метод, номер-места в коде, коментарий - необязятельный)
        из EGH01DB       Helper.WritereErrorEGHDB (Класс.метод, номер-места в коде, коментарий - необязятельный)
        из DB T-SQL      WritereError (процедура, номер-места в коде, коментарий - необязятельный)
   Может отдельный сделать класс в Primitives,  например:  Diagnostics и в нем WritereError ?
    Диагностика из трех подсистем EGH, ERHDB, DB ?

   Помним: DaryaCherniak и AzarkevichO тоже будут использовать (диагностика из EGH).


Adeln: в опубликовнной версии Прогноз\Справочники\Справочник типов инцидентов\Excel-формат почему-то не работает
а выдает вниз гряз c  <<<HEAD  .... Я проверял - локально вроде все ОК
PULL последнюю версию, проверить локально. если все ок, то публиковать и проверить, 
если не помогло, то написать в README  

BlinovaE: выбирайте время - давайте разбермся с сериализаций объектов в XML

-----------------------------------------------------------------------------------
Adeln - 01.11.2016
BlinovaE: Отправлены дополнения/изменения в таблицы GroundType и PetrochemicalType.

---------------------------------------------------------------------------------------------------------------------------
smw60 - 31.10.2016

3. Nadeghda : см.  Google -переводчик - полосы снизу и сверху - хочу примерно так, но внутри, чтобы прокручивалось

2.Nadeghda  :все рисунки теперь в папке проекта Resources, при необходимости скадывайте туда  и ссылаться 
по образцу 
 <img src="~/Resources/Layout_Mobile_Whiteframe1.png" alt="EGH" />


1.DaryaCherniak почему делаешь PUSH неоткомпилировнные  коды? 
 Ведь ты не одна работаешь.
 Даша, я должен  все это исправлять?
 Исправил,  много закоментил, в следущий раз задушу в объятиях!!!
----------------------------------------------------------------------------------------------------------------------------  

smw60 - 30.10.2016
1.Nadeghda  : отверстать гл. меню, 
            по верней оранжевой линии текущий заголовок 
            зелень внизу убрать,
            внизу  еще одна неподвижная (как верхняя) оранжевая линия      
            все пункты меню уже прописаны  - только отверстать (см. EGH01DOC)
            надо  все сделать к вечеру 31.10. - во вторник  совещание с НПЦ  будем согласовывать.

2.Adeln:    после п.1,  опубликовать 
            отправить формы по отчету прогоноза (см.EGH01DOC) на согласование  
            договориться о совещании на вторник (по очереди оно на нашей территории) по согласованию меню и формы 
            отчета по прогнозированию, что должно быть сделано к следующему вторнику
             
            отправить формы по техногенным объектам на согласование 
             

3.BlinovaE: можем ли с карт получить: высоту над уровнем моря,  глубину грутовых вод, тип грунта,
            если да то с какой точностью?  получить именно такие карты и поробовать загрузить
            если не грузится, то пусть Игорь тащит к нам и  показывает, что эти данные вообще есть


4. Пишем все и обо всем сюда -  в  обратной хронологии      
