-- Внутреннее условное соединение (Flowerbed и Tube)
SELECT 
    f.id,
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
INNER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id
WHERE 
    f.Flowerbed LIKE '%Клумба 1' -- Условие выборки

-- Эквивалент естественного соединения (Flowerbed и Tube по Tube_id)
-- В SQL Server используем INNER JOIN с явным указанием столбцов
SELECT 
    f.id,
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
INNER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id