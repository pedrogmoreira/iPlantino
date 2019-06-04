IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'concurrency_stamp', N'name', N'normalized_name') AND [object_id] = OBJECT_ID(N'[identity].[role]'))
    SET IDENTITY_INSERT [identity].[role] ON;
INSERT INTO [identity].[role] ([id], [concurrency_stamp], [name], [normalized_name])
VALUES ('9f3675ee-61bc-4a50-a8d8-1ba003901c3f', N'7bd9c89f-3b63-4c31-a9e5-1cd0724ab3ea', N'administrator-role', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'concurrency_stamp', N'name', N'normalized_name') AND [object_id] = OBJECT_ID(N'[identity].[role]'))
    SET IDENTITY_INSERT [identity].[role] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'concurrency_stamp', N'name', N'normalized_name') AND [object_id] = OBJECT_ID(N'[identity].[role]'))
    SET IDENTITY_INSERT [identity].[role] ON;
INSERT INTO [identity].[role] ([id], [concurrency_stamp], [name], [normalized_name])
VALUES ('cc276418-c6c2-4125-9098-124f9d131347', N'e9c33860-d2ad-409e-99d5-7beb06b38d80', N'user-role', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'concurrency_stamp', N'name', N'normalized_name') AND [object_id] = OBJECT_ID(N'[identity].[role]'))
    SET IDENTITY_INSERT [identity].[role] OFF;
	
	
	
	
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'claim_type', N'claim_value', N'role_id') AND [object_id] = OBJECT_ID(N'[identity].[role_claims]'))
    SET IDENTITY_INSERT [identity].[role_claims] ON;
INSERT INTO [identity].[role_claims] ([id], [claim_type], [claim_value], [role_id])
VALUES (-1, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'administrator', '9f3675ee-61bc-4a50-a8d8-1ba003901c3f');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'claim_type', N'claim_value', N'role_id') AND [object_id] = OBJECT_ID(N'[identity].[role_claims]'))
    SET IDENTITY_INSERT [identity].[role_claims] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'claim_type', N'claim_value', N'role_id') AND [object_id] = OBJECT_ID(N'[identity].[role_claims]'))
    SET IDENTITY_INSERT [identity].[role_claims] ON;
INSERT INTO [identity].[role_claims] ([id], [claim_type], [claim_value], [role_id])
VALUES (-2, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'user', 'cc276418-c6c2-4125-9098-124f9d131347');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'claim_type', N'claim_value', N'role_id') AND [object_id] = OBJECT_ID(N'[identity].[role_claims]'))
    SET IDENTITY_INSERT [identity].[role_claims] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'claim_type', N'claim_value', N'role_id') AND [object_id] = OBJECT_ID(N'[identity].[role_claims]'))
    SET IDENTITY_INSERT [identity].[role_claims] ON;
INSERT INTO [identity].[role_claims] ([id], [claim_type], [claim_value], [role_id])
VALUES (-3, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'user-device', 'cc276418-c6c2-4125-9098-124f9d131347');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'claim_type', N'claim_value', N'role_id') AND [object_id] = OBJECT_ID(N'[identity].[role_claims]'))
    SET IDENTITY_INSERT [identity].[role_claims] OFF;