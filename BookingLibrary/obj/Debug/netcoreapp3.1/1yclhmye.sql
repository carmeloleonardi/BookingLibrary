IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Authors] (
    [AuthorId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);

GO

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Price] decimal(5, 2) NOT NULL,
    [Isbn] nvarchar(max) NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
);

GO

CREATE TABLE [AuthorBooks] (
    [AuthorId] int NOT NULL,
    [BookId] int NOT NULL,
    CONSTRAINT [PK_AuthorBooks] PRIMARY KEY ([AuthorId], [BookId]),
    CONSTRAINT [FK_AuthorBooks_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorBooks_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] ON;
INSERT INTO [Authors] ([AuthorId], [FirstName], [LastName])
VALUES (1, N'Italo', N'Calvivo'),
(2, N'Italo', N'Svevo'),
(3, N'Martin', N'Fowler'),
(4, N'Erich', N'Gamma'),
(5, N'Richard', N'Helm'),
(6, N'Ralph', N'Johnson'),
(7, N'John', N'Vlissides');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'Isbn', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([BookId], [Isbn], [Price], [Title])
VALUES (1, N'5ab6829o', 13.5, N'Il sentiero dei nidi di ragno'),
(2, N'7493b423', 12.2, N'Il barone rampante'),
(3, N'6283472992a', 13.5, N'Il visconte dimezzato'),
(4, N'3738347383', 17.5, N'La coscienza di Zeno'),
(5, N'127238437', 24.5, N'UML distilled'),
(6, N'887192150X', 39.0, N'Design Patterns');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'Isbn', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'BookId') AND [object_id] = OBJECT_ID(N'[AuthorBooks]'))
    SET IDENTITY_INSERT [AuthorBooks] ON;
INSERT INTO [AuthorBooks] ([AuthorId], [BookId])
VALUES (1, 1),
(1, 2),
(1, 3),
(2, 4),
(3, 5),
(4, 6),
(5, 6),
(6, 6),
(7, 6);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'BookId') AND [object_id] = OBJECT_ID(N'[AuthorBooks]'))
    SET IDENTITY_INSERT [AuthorBooks] OFF;

GO

CREATE INDEX [IX_AuthorBooks_BookId] ON [AuthorBooks] ([BookId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201104140328_BookAuthorEntities', N'3.1.9');

GO

CREATE TABLE [Authors] (
    [AuthorId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);

GO

CREATE TABLE [Categories] (
    [CategoryId] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
);

GO

CREATE TABLE [Editors] (
    [EditorId] int NOT NULL IDENTITY,
    [EdtitorName] nvarchar(max) NULL,
    CONSTRAINT [PK_Editors] PRIMARY KEY ([EditorId])
);

GO

CREATE TABLE [AuthorBiographies] (
    [AuthorBiographyId] int NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [Nationality] nvarchar(max) NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_AuthorBiographies] PRIMARY KEY ([AuthorBiographyId]),
    CONSTRAINT [FK_AuthorBiographies_Authors_AuthorBiographyId] FOREIGN KEY ([AuthorBiographyId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Price] decimal(5, 2) NOT NULL,
    [Isbn] nvarchar(max) NULL,
    [EditorId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
    CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Editors_EditorId] FOREIGN KEY ([EditorId]) REFERENCES [Editors] ([EditorId]) ON DELETE CASCADE
);

GO

CREATE TABLE [AuthorBooks] (
    [AuthorId] int NOT NULL,
    [BookId] int NOT NULL,
    CONSTRAINT [PK_AuthorBooks] PRIMARY KEY ([AuthorId], [BookId]),
    CONSTRAINT [FK_AuthorBooks_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AuthorBooks_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] ON;
INSERT INTO [Authors] ([AuthorId], [FirstName], [LastName])
VALUES (1, N'Italo', N'Calvivo'),
(2, N'Italo', N'Svevo'),
(3, N'Martin', N'Fowler'),
(4, N'Erich', N'Gamma'),
(5, N'Richard', N'Helm'),
(6, N'Ralph', N'Johnson'),
(7, N'John', N'Vlissides');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'CategoryName') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([CategoryId], [CategoryName])
VALUES (6, N'Crime'),
(5, N'Romantic'),
(4, N'Horror'),
(2, N'Computer Science'),
(1, N'Narrative'),
(3, N'Thriller');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'CategoryName') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EditorId', N'EdtitorName') AND [object_id] = OBJECT_ID(N'[Editors]'))
    SET IDENTITY_INSERT [Editors] ON;
INSERT INTO [Editors] ([EditorId], [EdtitorName])
VALUES (4, N'PEARSON Addison Wesley'),
(1, N'Rizzoli'),
(2, N'PACKT'),
(3, N'Mondadori'),
(5, N'Mondadori');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EditorId', N'EdtitorName') AND [object_id] = OBJECT_ID(N'[Editors]'))
    SET IDENTITY_INSERT [Editors] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorBiographyId', N'AuthorId', N'DateOfBirth', N'Description', N'Nationality') AND [object_id] = OBJECT_ID(N'[AuthorBiographies]'))
    SET IDENTITY_INSERT [AuthorBiographies] ON;
INSERT INTO [AuthorBiographies] ([AuthorBiographyId], [AuthorId], [DateOfBirth], [Description], [Nationality])
VALUES (1, 3, '1963-12-18T00:00:00.0000000', N'Together with Kent Beck he was one of the fathers of extreme programming and agile software development. He is a member of the Agile Alliance and one of the authors of the Agile Manifesto. Among his most influential works we can mention UML Distilled on the UML language and Refactoring: Improving the Design of Existing Code which introduced the concept of refactoring, today among the cornerstones of agile and test driven development methodologies. He introduced the concept of dependency injection, widely used in the practice of developing automated tests.', N'England');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorBiographyId', N'AuthorId', N'DateOfBirth', N'Description', N'Nationality') AND [object_id] = OBJECT_ID(N'[AuthorBiographies]'))
    SET IDENTITY_INSERT [AuthorBiographies] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'CategoryId', N'EditorId', N'Isbn', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([BookId], [CategoryId], [EditorId], [Isbn], [Price], [Title])
VALUES (1, 1, 3, N'5ab6829o', 13.5, N'Il sentiero dei nidi di ragno'),
(2, 1, 3, N'7493b423', 12.2, N'Il barone rampante'),
(3, 1, 3, N'6283472992a', 13.5, N'Il visconte dimezzato'),
(4, 1, 3, N'3738347383', 17.5, N'La coscienza di Zeno'),
(5, 2, 4, N'127238437', 24.5, N'UML distilled'),
(6, 2, 4, N'887192150X', 39.0, N'Design Patterns');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'CategoryId', N'EditorId', N'Isbn', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'BookId') AND [object_id] = OBJECT_ID(N'[AuthorBooks]'))
    SET IDENTITY_INSERT [AuthorBooks] ON;
INSERT INTO [AuthorBooks] ([AuthorId], [BookId])
VALUES (1, 1),
(1, 2),
(1, 3),
(2, 4),
(3, 5),
(4, 6),
(5, 6),
(6, 6),
(7, 6);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AuthorId', N'BookId') AND [object_id] = OBJECT_ID(N'[AuthorBooks]'))
    SET IDENTITY_INSERT [AuthorBooks] OFF;

GO

CREATE INDEX [IX_AuthorBooks_BookId] ON [AuthorBooks] ([BookId]);

GO

CREATE INDEX [IX_Books_CategoryId] ON [Books] ([CategoryId]);

GO

CREATE INDEX [IX_Books_EditorId] ON [Books] ([EditorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201104165400_CategoryEditorBiographyEntities', N'3.1.9');

GO

