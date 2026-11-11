
CREATE DATABASE CatalogoDB;
GO
USE CatalogoDB;
GO

CREATE TABLE Categoria (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL
);

CREATE TABLE Marca (
    IdMarca INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    PaisOrigen VARCHAR(100) NULL
);

CREATE TABLE Producto (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    IdCategoria INT NOT NULL,
    IdMarca INT NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    SKU VARCHAR(50) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Estado BIT NOT NULL, 
    CONSTRAINT FK_Producto_Categoria 
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
    CONSTRAINT FK_Producto_Marca 
    FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca)
);
GO  


select * from categoria;

CREATE DATABASE InventarioDB2;
GO
USE InventarioDB2;
GO

CREATE TABLE Bodega (
    IdBodega INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Ciudad VARCHAR(100) NULL,
    Direccion VARCHAR(255) NULL
);

CREATE TABLE Existencia (
    IdExistencia INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL, 
    IdBodega INT NOT NULL,
    Stock INT NOT NULL,
    CONSTRAINT FK_Existencia_Bodega 
    FOREIGN KEY (IdBodega) REFERENCES Bodega(IdBodega)
);

CREATE TABLE MovimientoInventario (
    IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL, 
    IdBodega INT NOT NULL,
    Tipo VARCHAR(50) NOT NULL, 
    Cantidad INT NOT NULL,
    Fecha DATETIME NOT NULL,
    
    CONSTRAINT FK_Movimiento_Bodega FOREIGN KEY (IdBodega) REFERENCES Bodega(IdBodega)
);

CREATE TABLE ReservaStock (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL, 
    IdBodega INT NOT NULL,
    Cantidad INT NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    
    CONSTRAINT FK_Reserva_Bodega FOREIGN KEY (IdBodega) REFERENCES Bodega(IdBodega)
);
GO


CREATE DATABASE PedidosDB;
GO
USE PedidosDB;
GO

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(150) NOT NULL,
    Cedula VARCHAR(20) NOT NULL,
    Correo VARCHAR(150) NULL
);

CREATE TABLE Pedido (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    Estado VARCHAR(50) NOT NULL, 
    
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE DetallePedido (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    IdProducto INT NOT NULL, 
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    
    CONSTRAINT FK_Detalle_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)
);
GO


