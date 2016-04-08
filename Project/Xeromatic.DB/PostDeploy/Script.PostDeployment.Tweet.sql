--Reference Data for Tweet 
MERGE INTO Tweet AS Target 
USING (VALUES 
  (1, 'I''m a tweet'),
  (2, 'Also a tweet')
) 
AS Source ([Id], [Text]) 
ON Target.[Id] = Source.[Id] 
--update matched rows 
WHEN MATCHED THEN 
UPDATE SET [Id] = Source.[Id] 
--insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [Text]) 
VALUES ([Id], [Text]);