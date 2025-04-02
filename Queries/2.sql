-- ���������� �������� ���������� (Flowerbed � Tube)
SELECT 
    f.id,
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
INNER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id
WHERE 
    f.Flowerbed LIKE '%������ 1' -- ������� �������

-- ���������� ������������� ���������� (Flowerbed � Tube �� Tube_id)
-- � SQL Server ���������� INNER JOIN � ����� ��������� ��������
SELECT 
    f.id,
    f.Flowerbed,
    t.Tube
FROM 
    [GreenZone].[dbo].[Flowerbed] f
INNER JOIN 
    [GreenZone].[dbo].[Tube] t ON f.Tube_id = t.id