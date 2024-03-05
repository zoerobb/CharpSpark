ALTER TABLE [ReferenceContactInfo] DROP CONSTRAINT [Fk ReferenceContactInfo EmploymentHistory Id];
ALTER TABLE [Degree] DROP CONSTRAINT [Fk Degree Education Id];
ALTER TABLE [Achievements] DROP CONSTRAINT [Fk Achievements UserInfo Id];
ALTER TABLE [Projects] DROP CONSTRAINT [Fk Projects UserInfo Id];
ALTER TABLE [Projects] DROP CONSTRAINT [Fk Projects Resume Id];
ALTER TABLE [UserSkill] DROP CONSTRAINT [Fk UserSkill Skill Id];
ALTER TABLE [UserSkill] DROP CONSTRAINT [Fk UserSkill UserInfo Id];
ALTER TABLE [UserSkill] DROP CONSTRAINT [Fk UserSkill Resume Id];
ALTER TABLE [Education] DROP CONSTRAINT [Fk Education Resume Id];
ALTER TABLE [EmploymentHistory] DROP CONSTRAINT [Fk EmploymentHistory UserInfo Id];
ALTER TABLE [EmploymentHistory] DROP CONSTRAINT [Fk EmploymentHistory Resume Id];
ALTER TABLE [Education] DROP CONSTRAINT [Fk Education UserInfo Id];
ALTER TABLE [Resume] DROP CONSTRAINT [Fk Resume UserInfo Id];

DROP TABLE [ReferenceContactInfo];
DROP TABLE [Degree];
DROP TABLE [Achievements];
DROP TABLE [Projects];
DROP TABLE [UserSkill];
DROP TABLE [EmploymentHistory];
DROP TABLE [Education];
DROP TABLE [Resume];
DROP TABLE [Skills];
DROP TABLE [UserInfo];