use mapco;

CREATE TABLE Abono (
	IdEntradaCaja int NOT NULL,
	IdAbono int NOT NULL AUTO_INCREMENT,
	IdCliente int NOT NULL,
	IdResponsable int NOT NULL,
	IdSucursal int NOT NULL,
	IdTipoVenta int NULL,
	IdTipoMovimiento int NOT NULL,
	IdFolioFiscal int NOT NULL,
	IdCajaSucursal int NOT NULL,
	IdEstatus int NULL,
	Importe decimal(18, 2) NULL,
	ImporteImpuesto decimal(18, 2) NULL,
	ImporteTotal decimal(18, 2) NULL,
	ImporteAplicado decimal(18, 2) NULL,
	ImporteDctoTotal decimal(18, 2) NULL,
	TasaImpuesto decimal(18, 4) NULL,
	FechaPago datetime NULL,
	ClienteRazonSocial varchar(100) NULL,
	ClienteRFC varchar(20) NULL,
	ClienteCURP varchar(18) NULL,
	ClienteDireccion varchar(250) NULL,
	ClientePoblacion varchar(100) NULL,
	ClienteCP varchar(5) NULL,
	FECHAINSERT datetime NOT NULL,
	FECHAUPDATE datetime NULL,
	FECHAAPLICA datetime NULL,
	FECHACANCELA datetime NULL,
	USUARIOINSERT int NOT NULL,
	USUARIOUPDATE int NULL,
	USUARIOAPLICA int NULL,
	USUARIOCANCELA int NULL,
	ESTATUS bit NOT NULL,
	Folio varchar(6) NULL,
	TipoMovimiento char(2) NULL,
	CodigoClienteNOUSAR varchar(6) NULL,
	CodigoResponsable varchar(6) NULL,
	PagoInicialTC bit NULL,
	ChequeBote bit NULL,
	TCNumeroCuenta varchar(20) NULL,
	DocDes varchar(8) NULL,
	IdOpenPay int NULL,
	IdEstadoCuentaXML int NULL,
	IdEstadoCuentaDetalle int NULL,
	AplicadoTC bit NULL,
	ImporteAplicadoTC decimal(18, 2) NULL,
	BajaPorDevolucionTC bit NULL,
	IdEfectivo int NULL,
	IdVoucherDetalle int NULL,
	Puntos int NULL,
	IdPuntos int NULL,
	IdTipo int NULL,
	OtrosProductos bit NULL,
	GeneroAnticipo bit NULL,
	DescuentoDisminuido bit NULL,
	GeneroDescuento bit NULL,
	FormaPagoPrecargada bit NULL,
	IdAnticipoGenerado int NULL,
	MigradoDxC bit NULL,
	PRIMARY KEY (IdAbono)
)