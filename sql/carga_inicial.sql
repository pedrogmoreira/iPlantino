IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_user', N'inclusion_date', N'deleted', N'email', N'hash', N'login', N'name', N'telephone') AND [object_id] = OBJECT_ID(N'[authentication].[tbl_user]'))
    SET IDENTITY_INSERT [authentication].[tbl_user] ON;
INSERT INTO [authentication].[tbl_user] ([id_user], [inclusion_date], [deleted], [email], [hash], [login], [name], [telephone])
VALUES ('6aff99c8-6a4b-41cd-abb1-7bdc992832e6', '2019-05-29T11:21:21.1521215-03:00', NULL, NULL, '1000:ItTeGQJg6ruzBXgYSVOzrw+RH8WM4W7F:/vrQRBUpQ/c5z8BN2PyrjAYKJ9544VVC', 'admin', 'administrador', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id_user', N'inclusion_date', N'deleted', N'email', N'hash', N'login', N'name', N'telephone') AND [object_id] = OBJECT_ID(N'[authentication].[tbl_user]'))
    SET IDENTITY_INSERT [authentication].[tbl_user] OFF;
	
INSERT INTO iPlantino.authentication.tbl_group
(id_group, inclusion_date, name, observation)
VALUES('3C329E0F-90A7-4A6D-B9C7-1D5113CD3F4F', getutcdate(), 'Administrator', 'System\'s administrador'),
		('4A01B072-3A6B-421C-B0E1-76F623E7B887', getutcdate(), 'User', 'System\'s user');

	
INSERT INTO iPlantino.authentication.tbl_permission
(id_permission, inclusion_date, name)
VALUES('5FFB11AE-70AA-4A61-935B-2D002A0815A2', getutcdate(), 'CreateUser'),
		('F4614F11-282C-4F77-A443-38CF73016BAD', getutcdate(), 'EditUser'),
		('B63D338B-5A99-43E1-A30B-8DB887BA7B91', getutcdate(), 'DeleteUser'),
		('55687487-C1EE-472A-AC69-ECEA51457B5F', getutcdate(), 'AddDevice');

INSERT INTO iPlantino.authentication.tbl_permission_group
(id_permission, id_group)
VALUES('5FFB11AE-70AA-4A61-935B-2D002A0815A2', '3C329E0F-90A7-4A6D-B9C7-1D5113CD3F4F'),
		('F4614F11-282C-4F77-A443-38CF73016BAD', '3C329E0F-90A7-4A6D-B9C7-1D5113CD3F4F'),
		('B63D338B-5A99-43E1-A30B-8DB887BA7B91', '3C329E0F-90A7-4A6D-B9C7-1D5113CD3F4F'),
		('55687487-C1EE-472A-AC69-ECEA51457B5F', '3C329E0F-90A7-4A6D-B9C7-1D5113CD3F4F'),
		('5FFB11AE-70AA-4A61-935B-2D002A0815A2', '4A01B072-3A6B-421C-B0E1-76F623E7B887'),
		('F4614F11-282C-4F77-A443-38CF73016BAD', '4A01B072-3A6B-421C-B0E1-76F623E7B887'),
		('B63D338B-5A99-43E1-A30B-8DB887BA7B91', '4A01B072-3A6B-421C-B0E1-76F623E7B887');
	
INSERT INTO iPlantino.authentication.tbl_user_group
(id_group, id_user)
VALUES('3C329E0F-90A7-4A6D-B9C7-1D5113CD3F4F', '6AFF99C8-6A4B-41CD-ABB1-7BDC992832E6');