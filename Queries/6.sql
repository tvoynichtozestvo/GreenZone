-- Агрегатные функции для таблицы DateWater
SELECT 
    COUNT(*) AS total_watering_schedules,
    MIN(start) AS earliest_start_time,
    MAX(end_water) AS latest_end_time,
    AVG(DATEDIFF(MINUTE, start, end_water)) AS avg_watering_duration_minutes,
    SUM(CASE WHEN if_fertilizer = 1 THEN 1 ELSE 0 END) AS fertilizing_events,
    SUM(DATEDIFF(MINUTE, start, end_water)) AS total_watering_minutes
FROM 
    [GreenZone].[dbo].[DateWater]

-- Групповые агрегатные функции по дням недели
SELECT 
    week_day,
    COUNT(*) AS schedules_count,
    AVG(DATEDIFF(MINUTE, start, end_water)) AS avg_duration_minutes
FROM 
    [GreenZone].[dbo].[DateWater]
GROUP BY 
    week_day