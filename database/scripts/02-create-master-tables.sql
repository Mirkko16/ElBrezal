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
    Porce DECIMAL(5,2) NOT NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_SituacionesImpositivas_Eliminado DEFAULT 0,
        CONSTRAINT DF_SituacionesImpositivas_Porce DEFAULT 0;

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

CREATE TABLE dbo.Proveedores
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(150) NULL,

    LocalidadId INT NULL,

    Telefono VARCHAR(50) NULL,

    CUIT VARCHAR(13) NULL,
    IngresosBrutos VARCHAR(30) NULL,
    Email VARCHAR(150) NULL,

    SituacionImpositivaId INT NULL,

    Observacion VARCHAR(500) NULL,

    Eliminado BIT NOT NULL
        CONSTRAINT DF_Proveedores_Eliminado DEFAULT 0,

    CONSTRAINT PK_Proveedores
        PRIMARY KEY (Id),

    CONSTRAINT FK_Proveedores_Localidades
        FOREIGN KEY (LocalidadId)
        REFERENCES dbo.Localidades(Id),

    CONSTRAINT FK_Proveedores_SituacionesImpositivas
        FOREIGN KEY (SituacionImpositivaId)
        REFERENCES dbo.SituacionesImpositivas(Id)
);
GO

USE ElBrezalDB;
GO

CREATE TABLE dbo.Productos
(
    Id INT IDENTITY(1,1) NOT NULL,

    Nombre VARCHAR(150) NOT NULL,

    FamiliaId INT NULL,
    MarcaId INT NULL,
    UnidadId INT NULL,
    ProveedorId INT NULL,

    Costo DECIMAL(18,4) NOT NULL
        CONSTRAINT DF_Productos_Costo DEFAULT 0,

    AlicuotaIVA DECIMAL(5,2) NOT NULL
        CONSTRAINT DF_Productos_AlicuotaIVA DEFAULT 21,

    RentabilidadContado DECIMAL(7,2) NOT NULL
        CONSTRAINT DF_Productos_RentabilidadContado DEFAULT 0,

    PrecioContado DECIMAL(18,4) NOT NULL
        CONSTRAINT DF_Productos_PrecioContado DEFAULT 0,

    RentabilidadReventa DECIMAL(7,2) NOT NULL
        CONSTRAINT DF_Productos_RentabilidadReventa DEFAULT 0,

    PrecioReventa DECIMAL(18,4) NOT NULL
        CONSTRAINT DF_Productos_PrecioReventa DEFAULT 0,

    RentabilidadCuentaCorriente DECIMAL(7,2) NOT NULL
        CONSTRAINT DF_Productos_RentabilidadCuentaCorriente DEFAULT 0,

    PrecioCuentaCorriente DECIMAL(18,4) NOT NULL
        CONSTRAINT DF_Productos_PrecioCuentaCorriente DEFAULT 0,

    Stock DECIMAL(18,4) NOT NULL
        CONSTRAINT DF_Productos_Stock DEFAULT 0,

    FechaAlta DATETIME2 NOT NULL
        CONSTRAINT DF_Productos_FechaAlta DEFAULT SYSDATETIME(),

    FechaModificacion DATETIME2 NULL,

    Eliminado BIT NOT NULL
        CONSTRAINT DF_Productos_Eliminado DEFAULT 0,

    CONSTRAINT PK_Productos
        PRIMARY KEY (Id),

    CONSTRAINT FK_Productos_Familias
        FOREIGN KEY (FamiliaId)
        REFERENCES dbo.Familias(Id),

    CONSTRAINT FK_Productos_Marcas
        FOREIGN KEY (MarcaId)
        REFERENCES dbo.Marcas(Id),

    CONSTRAINT FK_Productos_Unidades
        FOREIGN KEY (UnidadId)
        REFERENCES dbo.Unidades(Id),

    CONSTRAINT FK_Productos_Proveedores
        FOREIGN KEY (ProveedorId)
        REFERENCES dbo.Proveedores(Id)
);
GO

ALTER TABLE dbo.Productos
DROP CONSTRAINT DF_Productos_AlicuotaIVA;
GO

ALTER TABLE dbo.Productos
DROP COLUMN AlicuotaIVA;
GO

ALTER TABLE dbo.Productos
ADD AlicuotaIVAId INT NOT NULL
    CONSTRAINT DF_Productos_AlicuotaIVAId DEFAULT 3;
GO

ALTER TABLE dbo.Productos
ADD CONSTRAINT FK_Productos_AlicuotasIVA
    FOREIGN KEY (AlicuotaIVAId)
    REFERENCES dbo.AlicuotasIVA(Id);
GO

CREATE TABLE CondicionesVenta
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    Eliminado BIT NOT NULL
        CONSTRAINT DF_CondicionesVenta_Eliminado DEFAULT 0,

    CONSTRAINT PK_CondicionesVenta
        PRIMARY KEY (Id)
);
GO

ALTER TABLE Clientes
DROP COLUMN
    Telefono2,
    Fax,
    Ocupacion,
    Matricula;

EXEC sp_rename
    'Clientes.Telefono1',
    'Telefono',
    'COLUMN';

INSERT INTO CondicionesVenta (Nombre)
VALUES
    ('CONTADO'),
    ('TARJETA DE DEBITO'),
    ('TARJETA DE CREDITO'),
    ('CUENTA CORRIENTE');
GO

CREATE TABLE TiposComprobante
(
    Id INT NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    Abreviatura NVARCHAR(10) NULL,

    Signo SMALLINT NOT NULL
        CONSTRAINT DF_TiposComprobante_Signo DEFAULT 1,

    MovimientoStock SMALLINT NOT NULL
        CONSTRAINT DF_TiposComprobante_MovimientoStock DEFAULT 0,

    Eliminado BIT NOT NULL
        CONSTRAINT DF_TiposComprobante_Eliminado DEFAULT 0,

    CONSTRAINT PK_TiposComprobante
        PRIMARY KEY (Id),

    CONSTRAINT CK_TiposComprobante_Signo
        CHECK (Signo IN (-1, 1)),

    CONSTRAINT CK_TiposComprobante_MovimientoStock
        CHECK (MovimientoStock IN (-1, 0, 1))
);

INSERT INTO TiposComprobante
    (Id, Nombre, Abreviatura, Signo, MovimientoStock)
VALUES
    (1,  'FACTURA A',       'FA',   1, -1),
    (3,  'N. CREDITO A',    'NCA', -1,  1),
    (5,  'FACTURA B',       'FB',   1, -1),
    (7,  'N. CREDITO B',    'NCB', -1,  1),
    (9,  'FACTURA C',       'FC',   1, -1),
    (11, 'N. CREDITO C',    'NCC', -1,  1),
    (26, 'PRESUPUESTO',     'PRES', 1,  0),
    (27, 'REMITO',          'REMI', 1, -1),
    (28, 'DEVOLUCION',      'DEVO', -1, 1);

CREATE TABLE NumeracionesComprobante
(
    Id INT IDENTITY(1,1) NOT NULL,

    TipoComprobanteId INT NOT NULL,

    PuntoVenta INT NOT NULL,

    UltimoNumero INT NOT NULL
        CONSTRAINT DF_NumeracionesComprobante_UltimoNumero DEFAULT 0,

    Eliminado BIT NOT NULL
        CONSTRAINT DF_NumeracionesComprobante_Eliminado DEFAULT 0,

    CONSTRAINT PK_NumeracionesComprobante
        PRIMARY KEY (Id),

    CONSTRAINT FK_NumeracionesComprobante_TiposComprobante
        FOREIGN KEY (TipoComprobanteId)
        REFERENCES TiposComprobante(Id),

    CONSTRAINT UQ_NumeracionesComprobante_Tipo_PuntoVenta
        UNIQUE (TipoComprobanteId, PuntoVenta)
);

ALTER TABLE dbo.Productos
ADD StockMinimo DECIMAL(18,4) NOT NULL
    CONSTRAINT DF_Productos_StockMinimo DEFAULT (0);
GO

CREATE TABLE Comprobantes
(
    Id INT IDENTITY(1,1) NOT NULL,
    TipoComprobanteId INT NOT NULL,
    PuntoVenta INT NOT NULL,
    Numero INT NOT NULL,
    Fecha DATETIME2 NOT NULL,

    ClienteId INT NOT NULL,
    VendedorId INT NOT NULL,
    CondicionVentaId INT NOT NULL,
    SituacionImpositivaId INT NOT NULL,

    PorcentajeVariacion DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Comprobantes_PorcentajeVariacion DEFAULT 0,

    Subtotal DECIMAL(18,2) NOT NULL,

    MontoVariacion DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_Comprobantes_MontoVariacion DEFAULT 0,

    Total DECIMAL(18,2) NOT NULL,

    Observacion NVARCHAR(500) NULL,

    Anulado BIT NOT NULL
        CONSTRAINT DF_Comprobantes_Anulado DEFAULT 0,

    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_Comprobantes_CreatedAt DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Comprobantes
        PRIMARY KEY (Id),

    CONSTRAINT FK_Comprobantes_TiposComprobante
        FOREIGN KEY (TipoComprobanteId)
        REFERENCES TiposComprobante(Id),

    CONSTRAINT FK_Comprobantes_Clientes
        FOREIGN KEY (ClienteId)
        REFERENCES Clientes(Id),

    CONSTRAINT FK_Comprobantes_Vendedores
        FOREIGN KEY (VendedorId)
        REFERENCES Vendedores(Id),

    CONSTRAINT FK_Comprobantes_CondicionesVenta
        FOREIGN KEY (CondicionVentaId)
        REFERENCES CondicionesVenta(Id),

    CONSTRAINT FK_Comprobantes_SituacionesImpositivas
        FOREIGN KEY (SituacionImpositivaId)
        REFERENCES SituacionesImpositivas(Id),

    CONSTRAINT UQ_Comprobantes_Numeracion
        UNIQUE (TipoComprobanteId, PuntoVenta, Numero)
);

CREATE TABLE ComprobantesDetalle
(
    Id INT IDENTITY(1,1) NOT NULL,
    ComprobanteId INT NOT NULL,
    ProductoId INT NOT NULL,

    Descripcion NVARCHAR(200) NOT NULL,

    Cantidad DECIMAL(18,3) NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Importe DECIMAL(18,2) NOT NULL,

    CONSTRAINT PK_ComprobantesDetalle
        PRIMARY KEY (Id),

    CONSTRAINT FK_ComprobantesDetalle_Comprobantes
        FOREIGN KEY (ComprobanteId)
        REFERENCES Comprobantes(Id),

    CONSTRAINT FK_ComprobantesDetalle_Productos
        FOREIGN KEY (ProductoId)
        REFERENCES Productos(Id)
);