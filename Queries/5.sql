-- Объединение цветников с удобрениями (пример)
SELECT id, Flowerbed AS name FROM [GreenZone].[dbo].[Flowerbed]
UNION
SELECT id, NameFertilizer AS name FROM [GreenZone].[dbo].[Fertilizer]

-- Объединение выборок из одной таблицы (активные и неактивные поливы)
SELECT id, start, 'Active' AS status FROM [GreenZone].[dbo].[DateWater] WHERE week_day IS NOT NULL
UNION
SELECT id, start, 'Inactive' AS status FROM [GreenZone].[dbo].[DateWater] WHERE week_day IS NULL