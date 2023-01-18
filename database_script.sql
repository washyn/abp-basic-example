IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230115235326_initial')
BEGIN
    CREATE TABLE [Pruebas] (
        [Id] bigint NOT NULL,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Pruebas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230115235326_initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [UserName] nvarchar(255) NOT NULL,
        [Email] nvarchar(255) NULL,
        [Name] nvarchar(255) NULL,
        [Surname] nvarchar(255) NULL,
        [IsActive] bit NOT NULL,
        [PhoneNumber] nvarchar(255) NULL,
        [PasswordHash] nvarchar(255) NULL,
        [RolName] nvarchar(255) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230115235326_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230115235326_initial', N'5.0.17');
END;
GO

COMMIT;
GO

