-- ���������� ��������� �� �����
SELECT * FROM [GreenZone].[dbo].[Flowerbed]
ORDER BY Flowerbed ASC

-- ���������� ���������� ������ �� ��� ������ � ������� ������
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

-- ���������� � ����������� ��������
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