DELETE FROM [identity].[user_role]
GO
DELETE FROM [identity].[user]
GO
DELETE FROM [identity].[role_claims]
GO
DELETE FROM [identity].[role]
GO

SET IDENTITY_INSERT [identity].[role] ON;
INSERT [identity].[role] ([id], [name], [normalized_name], [concurrency_stamp]) VALUES (N'cc276418-c6c2-4125-9098-124f9d131347', N'user-role', N'USER-ROLE', N'e9c33860-d2ad-409e-99d5-7beb06b38d80')
INSERT [identity].[role] ([id], [name], [normalized_name], [concurrency_stamp]) VALUES (N'9f3675ee-61bc-4a50-a8d8-1ba003901c3f', N'administrator-role', N'ADMINISTRATOR-ROLE', N'7bd9c89f-3b63-4c31-a9e5-1cd0724ab3ea')
SET IDENTITY_INSERT [identity].[role] OFF; 

SET IDENTITY_INSERT [identity].[role_claims] ON; 
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (0, N'9f3675ee-61bc-4a50-a8d8-1ba003901c3f', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'user-list')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (1, N'9f3675ee-61bc-4a50-a8d8-1ba003901c3f', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'user-details')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (2, N'cc276418-c6c2-4125-9098-124f9d131347', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'user-details')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (3, N'9f3675ee-61bc-4a50-a8d8-1ba003901c3f', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-user')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (4, N'cc276418-c6c2-4125-9098-124f9d131347', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-user')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (5, N'9f3675ee-61bc-4a50-a8d8-1ba003901c3f', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-details')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (6, N'cc276418-c6c2-4125-9098-124f9d131347', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-details')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (7, N'cc276418-c6c2-4125-9098-124f9d131347', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-registration')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (8, N'cc276418-c6c2-4125-9098-124f9d131347', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-measurement-registration')
INSERT [identity].[role_claims] ([id], [role_id], [claim_type], [claim_value]) VALUES (9, N'cc276418-c6c2-4125-9098-124f9d131347', N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'device-measurement-details')
SET IDENTITY_INSERT [identity].[role_claims] OFF;

SET IDENTITY_INSERT [identity].[user] ON; 
INSERT [identity].[user] ([id], [username], [normalized_username], [email], [normalized_email], [email_confirmed], [password_hash], [security_stamp], [concurrency_stamp], [phone_number], [phone_number_confirmed], [two_factor_enabled], [lockout_end], [lockout_enabled], [access_failed_count], [name]) VALUES (N'908349f3-54ce-4fef-86f9-0d0706aa4fe8', N'admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEE+sDk2fdiFpvz0Kdv5Fdh0lFMQ8ZMyeKA+TUSIBbDm9ChnGqfkuA2ZW4Tsi6GWQIg==', N'SOVJ5HXYXPZTCTR42BJOZBWISPI2IWPJ', N'972541d5-46e0-4243-9264-b2992d74d8c5', NULL, 0, 0, CAST(N'2019-06-04T00:17:22.4866667+00:00' AS DateTimeOffset), 1, 0, N'Administrator')
SET IDENTITY_INSERT [identity].[user] OFF;

SET IDENTITY_INSERT [identity].[user_role] ON; 
INSERT [identity].[user_role] ([user_id], [role_id]) VALUES (N'908349f3-54ce-4fef-86f9-0d0706aa4fe8', N'9f3675ee-61bc-4a50-a8d8-1ba003901c3f')
SET IDENTITY_INSERT [identity].[user_role] ON;