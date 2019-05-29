IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_user', N'inclusion_date', N'deleted', N'email', N'hash', N'login', N'name', N'telephone') AND [object_id] = OBJECT_ID(N'[authentication].[tbl_user]'))
    SET IDENTITY_INSERT [authentication].[tbl_user] ON;
INSERT INTO [authentication].[tbl_user] ([id_user], [inclusion_date], [deleted], [email], [hash], [login], [name], [telephone])
VALUES ('6aff99c8-6a4b-41cd-abb1-7bdc992832e6', '2019-05-29T11:21:21.1521215-03:00', NULL, NULL, '1000:ItTeGQJg6ruzBXgYSVOzrw+RH8WM4W7F:/vrQRBUpQ/c5z8BN2PyrjAYKJ9544VVC', 'admin', 'administrador', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_user', N'inclusion_date', N'deleted', N'email', N'hash', N'login', N'name', N'telephone') AND [object_id] = OBJECT_ID(N'[authentication].[tbl_user]'))
    SET IDENTITY_INSERT [authentication].[tbl_user] OFF;