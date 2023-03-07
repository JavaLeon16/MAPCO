select concat(vd.tmref, '--', tmv.des) as Movimiento, V.numeroautorizacion, 
    FECHA, op.Descripcion as OperacionTarjeta, EsPromocion IdEsPromocion,
    if(op.espromocion = 0, 'SIN PROMOCION', 'PROMOCION') ESPROMOCION,
    v.NumeroTarjeta, v.importe, b.Banco, vd.tmref, vd.folref, vd.FecRef,
    c.idcaja, caja,
    if(V.status = 1, 'VENTA', 'CNCL.') Status,
    if(Vd.status = 1, 'VENTA', 'CNCL.') StatusDetalle
from voucher V
inner join voucherdetalle VD on VD.idvoucher = V.idvoucher
inner join tmov tmv on tmv.tm = vd.tmref
inner join banco b on v.idbanco = b.idbanco
inner join operaciontarjeta op on op.idoperaciontarjeta = V.IdOperacionTarjeta
inner join caja c on v.idcaja = c.idcaja
where v.idcaja = idcaja
    and left(V.fecha, 10) = '  FechaIni.ToString(yyy-MM-dd)  '
    and Vd.status <> 2
order by EsPromocion, statusdetalle desc