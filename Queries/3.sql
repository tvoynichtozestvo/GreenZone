SELECT 
    f.Flowerbed,
    t.Tube,
    dw.start AS watering_time,
    dw.week_day
FROM 
    [GreenZone].[dbo].[Flowerbed] f
INNER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id
INNER JOIN 
    [GreenZone].[dbo].[DateWater] dw ON dw.id_tube = t.id
WHERE 
    dw.if_fertilizer = 1 -- Условие: только поливы с удобрением