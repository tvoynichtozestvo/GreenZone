-- ���������� ���������� ������ �� ������ �������
SELECT 
    f.Flowerbed,
    COUNT(dw.id) AS watering_schedules_count
FROM 
    [GreenZone].[dbo].[Flowerbed] f
LEFT JOIN 
    [GreenZone].[dbo].[DateWater] dw ON f.id = dw.id_flowerbed
GROUP BY 
    f.Flowerbed

-- ����������� �� ���� ������ � ������� ���������
SELECT 
    week_day,
    if_fertilizer,
    COUNT(*) AS schedules_count
FROM 
    [GreenZone].[dbo].[DateWater]
GROUP BY 
    week_day,
    if_fertilizer

-- ����������� � HAVING (������ �������� � ����� ��� 1 ����������� ������)
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