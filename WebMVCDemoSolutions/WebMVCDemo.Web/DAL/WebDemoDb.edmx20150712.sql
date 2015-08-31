
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2015 16:00:36
-- Generated from EDMX file: C:\Users\Kapil.Khadgi\Documents\All Projects\DemoSite\WebDemo_MVC_2013\Source Code\WebMVCDemoSolutions\WebMVCDemo.Web\DAL\WebDemoDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebMVCDemoDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_deptno_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_deptno_fk];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DeptNo] decimal(2,0)  NOT NULL,
    [DeptName] varchar(14)  NULL,
    [Location] varchar(13)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmpNo] decimal(4,0)  NOT NULL,
    [Name] varchar(10)  NOT NULL,
    [Job] varchar(9)  NULL,
    [Manager] decimal(4,0)  NULL,
    [HireDate] datetime  NULL,
    [Salary] decimal(19,4)  NULL,
    [DeptNo] decimal(2,0)  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [TaskId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Description] nvarchar(100)  NULL,
    [DueDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DeptNo] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DeptNo] ASC);
GO

-- Creating primary key on [EmpNo] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmpNo] ASC);
GO

-- Creating primary key on [TaskId] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([TaskId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DeptNo] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_deptno_fk]
    FOREIGN KEY ([DeptNo])
    REFERENCES [dbo].[Departments]
        ([DeptNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_deptno_fk'
CREATE INDEX [IX_FK_deptno_fk]
ON [dbo].[Employees]
    ([DeptNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------