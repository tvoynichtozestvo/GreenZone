-- ����� ������� ���������� (��� ��������, ���� ��� ������)
SELECT 
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
LEFT JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id

-- ������ ������� ���������� (��� ������, ���� ���� �� ��������� ��������)
SELECT 
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
RIGHT JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id

-- ������ ������� ����������
SELECT 
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
FULL OUTER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id