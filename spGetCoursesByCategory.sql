CREATE OR ALTER PROCEDURE [spGetCoursesByCategory] 
    @CategoryId UNIQUEIDENTIFIER
AS
    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId

SELECT  [Id],[Title] FROM Category

EXEC spGetCoursesByCategory '09ce0b7b-cfca-497b-92c0-3290ad9d5142'

