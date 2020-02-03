--
-- File generated with SQLiteStudio v3.2.1 on Mon Feb 3 15:08:31 2020
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Brands
CREATE TABLE "Brands" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Brands" PRIMARY KEY AUTOINCREMENT,
    "CreateDate" TEXT NOT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "IsDeleted" INTEGER NOT NULL,
    "Name" TEXT NULL,
    "Slug" TEXT NULL,
    "Description" TEXT NULL,
    "MetaDescription" TEXT NULL,
    "MetaKeywords" TEXT NULL,
    "BrandStatus" INTEGER NOT NULL
);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (1, '2019-09-05 12:11:26.9625642+01:00', '2019-09-05 12:11:26.9667414+01:00', 0, 'AMICO', 'amico', 'AMICO', 'AMICO', 'AMICO', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (2, '2019-09-05 12:11:35.0107962+01:00', '2019-09-05 12:11:35.0108102+01:00', 0, 'ARDEX', 'ardex', 'ARDEX', 'ARDEX', 'ARDEX', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (3, '2019-09-05 12:11:38.1845219+01:00', '2019-09-05 12:11:38.1845351+01:00', 0, 'CertainTeed', 'certainteed', 'CertainTeed', 'CertainTeed', 'CertainTeed', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (4, '2019-09-05 12:11:39.7762466+01:00', '2019-09-05 12:11:39.7762591+01:00', 0, 'Sika Scofield', 'sika-scofield', 'Sika Scofield', 'Sika Scofield', 'Sika Scofield', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (5, '2019-09-05 12:11:41.4107006+01:00', '2019-09-05 12:11:41.4107135+01:00', 0, 'SpecChem', 'specchem', 'SpecChem', 'SpecChem', 'SpecChem', 0);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
