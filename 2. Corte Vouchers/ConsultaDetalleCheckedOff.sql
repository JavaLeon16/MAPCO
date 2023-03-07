select 0 as Movimiento, V.numeroautorizacion, FECHA,
    op.Descripcion as OperacionTarjeta, EsPromocion IdEsPromocion,
    if(op.espromocion = 0, 'SIN PROMOCION', 'PROMOCION') ESPROMOCION,
    v.NumeroTarjeta, v.importe, b.Banco, c.idcaja, caja,
    if(V.status = 1, 'VENTA', 'CNCL.') Status,
    if(V.status = 1, 'VENTA', 'CNCL.') StatusDetalle
from voucher V
inner join banco b on v.idbanco = b.idbanco
inner join operaciontarjeta op on op.idoperaciontarjeta = V.IdOperacionTarjeta
inner join caja c on v.idcaja = c.idcaja
where v.idcaja = idcaja
    and left(V.fecha, 10) = '  FechaIni.ToString(yyy-MM-dd)  '
    and V.status <> 2
order by EsPromocion, statusdetalle desc