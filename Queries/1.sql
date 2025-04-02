-- Простая выборка из трех таблиц
SELECT * FROM [GreenZone].[dbo].[Flowerbed]
SELECT * FROM [GreenZone].[dbo].[Tube]
SELECT * FROM [GreenZone].[dbo].[DateWater]

-- Проекция и выборка из трех таблиц
SELECT 
    f.id AS flowerbed_id,
    f.Flowerbed AS flowerbed_name,
    t.Tube AS tube_name,
    dw.start AS watering_start_time,
    dw.end_water AS watering_end_time
FROM 
    [GreenZone].[dbo].[Flowerbed] f,
    [GreenZone].[dbo].[Tube] t,
    [GreenZone].[dbo].[DateWater] dw
WHERE 
    f.Tube_id = t.id
    AND dw.id_tube = t.id