-- Количество расписаний полива на каждый цветник
SELECT 
    f.Flowerbed,
    COUNT(dw.id) AS watering_schedules_count
FROM 
    [GreenZone].[dbo].[Flowerbed] f
LEFT JOIN 
    [GreenZone].[dbo].[DateWater] dw ON f.id = dw.id_flowerbed
GROUP BY 
    f.Flowerbed

-- Группировка по дням недели и наличию удобрения
SELECT 
    week_day,
    if_fertilizer,
    COUNT(*) AS schedules_count
FROM 
    [GreenZone].[dbo].[DateWater]
GROUP BY 
    week_day,
    if_fertilizer

-- Группировка с HAVING (только цветники с более чем 1 расписанием полива)
SELECT 
    f.Flowerbed,
    COUNT(dw.id) AS schedules_count
FROM 
    [GreenZone].[dbo].[Flowerbed] f
JOIN 
    [GreenZone].[dbo].[DateWater] dw ON f.id = dw.id_flowerbed
GROUP BY 
    f.Flowerbed
HAVING 
    COUNT(dw.id) > 1