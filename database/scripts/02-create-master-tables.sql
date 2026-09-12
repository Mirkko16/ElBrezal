USE ElBrezalDB;
GO

CREATE TABLE dbo.Familias
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Porcentaje DECIMAL(10,2) NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_Familias_Eliminado DEFAULT 0,

    CONSTRAINT PK_Familias PRIMARY KEY (Id)
);
GO

CREATE TABLE dbo.Marcas
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_Marcas_Eliminado DEFAULT 0,

    CONSTRAINT PK_Marcas PRIMARY KEY (Id)
);
GO

CREATE TABLE dbo.Unidades
(
    Id INT IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(20) NOT NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_Unidades_Eliminado DEFAULT 0,

    CONSTRAINT PK_Unidades PRIMARY KEY (Id)
);
GO

CREATE TABLE dbo.Provincias
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,

    CONSTRAINT PK_Provincias PRIMARY KEY (Id),
    CONSTRAINT UQ_Provincias_Nombre UNIQUE (Nombre)
);
GO

CREATE TABLE dbo.Localidades
(
    Id INT IDENTITY(1,1) NOT NULL,
    CodigoPostal VARCHAR(8) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    ProvinciaId INT NOT NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_Localidades_Eliminado DEFAULT 0,

    CONSTRAINT PK_Localidades PRIMARY KEY (Id),

    CONSTRAINT FK_Localidades_Provincias
        FOREIGN KEY (ProvinciaId)
        REFERENCES dbo.Provincias(Id)
);
GO

CREATE TABLE dbo.Vendedores
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NULL,
    Telefono VARCHAR(50) NULL,
    LocalidadId INT NULL,
    Email VARCHAR(150) NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_Vendedores_Eliminado DEFAULT 0,

    CONSTRAINT PK_Vendedores PRIMARY KEY (Id),

    CONSTRAINT FK_Vendedores_Localidades
        FOREIGN KEY (LocalidadId)
        REFERENCES dbo.Localidades(Id)
);
GO