-- Сортировка цветников по имени
SELECT * FROM [GreenZone].[dbo].[Flowerbed]
ORDER BY Flowerbed ASC

-- Сортировка расписаний полива по дню недели и времени начала
SELECT 
    id_flowerbed,
    start,
    end_water,
    week_day
FROM 
    [GreenZone].[dbo].[DateWater]
ORDER BY 
    week_day,
    start

-- Сортировка с несколькими уровнями
SELECT 
    f.Flowerbed,
    t.Tube,
    dw.start
FROM 
    [GreenZone].[dbo].[Flowerbed] f
JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id
JOIN 
    [GreenZone].[dbo].[DateWater] dw ON dw.id_tube = t.id
ORDER BY 
    f.Flowerbed,
    dw.week_day,
    dw.start