-- Capture your answer here for each "Test It With SQL" section of this assignment
    -- write each as comments


--Part 1: List the columns and their data types in the Jobs table.
--Id (integer), Name (string), EmployerId (integer)

--Part 2: Write a query to list the names of the employers in St. Louis City.
--SELECT * FROM Employers
--WHERE Location = 'St. Louis'

--Part 3: Write a query to return a list of the names of all skills that are attached to jobs in alphabetical order.
    --If a skill does not have a job listed, it should not be included in the results of this query.
--SELECT Skills.SkillName, Jobs.Id, Jobs.Name
--FROM Skills
--JOIN JobSkills ON Skills.Id = JobSkills.SkillsId
--JOIN Jobs ON JobSkills.JobsId = Jobs.Id
--WHERE Jobs.Id IS NOT NULL
--ORDER BY Skills.SkillName;