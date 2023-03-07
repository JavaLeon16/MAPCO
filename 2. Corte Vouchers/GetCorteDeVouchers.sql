CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCorteDeVouchers`(
	VAROpcion INT,
    VARClaveEmpresa varchar(100)
)
BEGIN
	IF VAROpcion = 1 THEN
		SELECT IdCaja, Caja
        FROM caja 
        WHERE Status = 1 
        ORDER BY IdCaja;
    ELSEIF VAROpcion = 2 THEN
		SELECT A.Empresa, A.RegistroContribuyente, A.Direccion,
			IFNULL(A.CodigoPostal,'.') AS CodigoPostal,
			IFNULL(A.PaginaWeb,'.') AS PaginaWeb,
			IFNULL(B.NombreSucursal,'.') AS NombreSucursal,
			IFNULL(B.Calle,'.') AS CalleSucursal,
			-- ifnull(B.ResponsableSucursal,'') AS ResponsableSucursal,
			-- ifnull(B.Calle,'') AS Calle,
			IFNULL(B.Colonia,'') AS ColoniaSucursal,
			IFNULL(B.CodigoPostal,'') AS CodigoPostalSucursal,
			IFNULL(B.Telefono1,'') AS TelefonoSucursal1,
			IFNULL(B.Telefono2,'') AS TelefonoSucursal2,
			IFNULL(C.Ciudad,'') AS Ciudad,
			IFNULL(D.Estado,'') AS Estado,
			IFNULL(E.Pais,'') AS Pais
		FROM empresa A 
		LEFT JOIN sucursal B ON A.IdEmpresa = B.IdEmpresa
		LEFT JOIN ciudades C ON A.IdCiudad = C.IdCiudad
		LEFT JOIN estados D ON A.IdEstado = D.IdEstado
		LEFT JOIN pais E ON A.IdPais = E.IdPais	
		WHERE A.ClaveEmpresa = VARClaveEmpresa;
	ELSEIF VAROpcion = 3 THEN
		SELECT 
			'VENTA' as Tipo, 
            '0000001' as NumeroTarjeta,
            'BBVA' as Banco, 
            '10.25' as Importe, 
            '00001' as Factura;
	END IF;
END