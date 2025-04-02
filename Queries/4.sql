-- Левое внешнее соединение (все цветники, даже без трубок)
SELECT 
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
LEFT JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id

-- Правое внешнее соединение (все трубки, даже если не назначены цветнику)
SELECT 
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
RIGHT JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id

-- Полное внешнее соединение
SELECT 
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
FULL OUTER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id