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

CREATE TABLE dbo.SituacionesImpositivas
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Abreviatura VARCHAR(10) NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_SituacionesImpositivas_Eliminado DEFAULT 0,

    CONSTRAINT PK_SituacionesImpositivas PRIMARY KEY (Id),
    CONSTRAINT UQ_SituacionesImpositivas_Nombre UNIQUE (Nombre)
);
GO

CREATE TABLE dbo.EstadosCuentaCliente
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(30) NOT NULL,

    CONSTRAINT PK_EstadosCuentaCliente PRIMARY KEY (Id),
    CONSTRAINT UQ_EstadosCuentaCliente_Nombre UNIQUE (Nombre)
);
GO

CREATE TABLE dbo.Clientes
(
    Id INT IDENTITY(1,1) NOT NULL,

    Nombre VARCHAR(100) NOT NULL,

    DNI VARCHAR(20) NULL,
    CUIT VARCHAR(13) NULL,
    IngresosBrutos VARCHAR(30) NULL,

    Direccion VARCHAR(150) NULL,

    LocalidadId INT NOT NULL,

    Telefono1 VARCHAR(50) NULL,
    Telefono2 VARCHAR(50) NULL,
    Fax VARCHAR(50) NULL,
    Email VARCHAR(150) NULL,

    Ocupacion VARCHAR(100) NULL,
    Matricula VARCHAR(50) NULL,

    SituacionImpositivaId INT NOT NULL,
    EstadoCuentaId INT NOT NULL,

    VendedorId INT NULL,

    Observacion VARCHAR(500) NULL,

    Eliminado BIT NOT NULL
        CONSTRAINT DF_Clientes_Eliminado DEFAULT 0,

    CONSTRAINT PK_Clientes PRIMARY KEY (Id),

    CONSTRAINT FK_Clientes_Localidades
        FOREIGN KEY (LocalidadId)
        REFERENCES dbo.Localidades(Id),

    CONSTRAINT FK_Clientes_SituacionesImpositivas
        FOREIGN KEY (SituacionImpositivaId)
        REFERENCES dbo.SituacionesImpositivas(Id),

    CONSTRAINT FK_Clientes_EstadosCuentaCliente
        FOREIGN KEY (EstadoCuentaId)
        REFERENCES dbo.EstadosCuentaCliente(Id),

    CONSTRAINT FK_Clientes_Vendedores
        FOREIGN KEY (VendedorId)
        REFERENCES dbo.Vendedores(Id)
);
GO