# SQL To ElasticSearch Query Converter

[Demo website](https://sqltoelasticsearch.azurewebsites.net/).

![Build Status](https://github.com/rgelb/SQL-To-ElasticSearch/workflows/SqlToElasticBuild/badge.svg)

This quickie app converts SQL statements into ElasticSearch equivalent queries.  Note that the converter is very much a work in progress, and as such, doesn't support great many things.

## What works
At the moment the application supports SELECT, FROM, WHERE, GROUP BY statements.  
For SELECT, you can either place * or specify column names.
The FROM statement works with either aliases or indexes.  
The WHERE conditions support a subset of operators: =, >, >=, <, <=, IN, BETWEEN.
The GROUP BY statement only supports column names.  Columns in the GROUP BY must match those in SELECT.  

Examples:
```sql
SELECT name, type, state, pin
FROM cities
WHERE name = 'Miami'
   AND state = 'FL'
   AND zipCodes IN (33126, 33151)
   AND averageAge BETWEEN 34 AND 65
   AND averageSalary >= 55230
   AND averageTemperature < 80 
```
   
```sql
SELECT *
FROM Planets
WHERE SpacecraftWithinKilometers < 10000
```

```sql
SELECT SolarSystem, Galaxy
FROM Planets
WHERE SpacecraftWithinKilometers < 10000
GROUP BY SolarSystem, Galaxy
```

## What doesn't work yet
+ Inequality operator (!=)
+ Sorting
+ Joins (because ElasticSearch doesn't support them)
+ Common SQL functions like GetDate, DateDiff, Count(*), etc are not supported yet

## The Plan
See the "What doesn't work yet" section
