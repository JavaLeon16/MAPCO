select Descripcion, tipo, importe, fecha, idcaja, caja, CStatus, agrupador, orden
from (
  select C1.Descripcion, c1.tipo, ifnull(m.importe, 0) importe,
    ifnull(m.fecha, '  FechaIni.ToString(yyy-MM-dd) ') fecha,
    concat('CAJA: ', ifnull(m.idcaja, idcaja)) idcaja,
    ifnull(m.caja, '0') caja, ifnull(m.CStatus, 0) CStatus,
    ifnull(m.agrupador, 0) agrupador, c1.orden
  from cortevoucherorden c1
  left join (
    SELECT tipooperacion, agrupador, sum(importe) as importe, fecha, idcaja, caja, statusDetalle, count(statusDetalle) CStatus
    FROM (
      select concat(vd.tmref, '--', tmv.des) as Movimiento,
        case
          when op.descripcion = 'AMERICAN EXPRESS' then 'AMERICAN EXPRESS'
          when op.tipooperacion = 1 then 'CREDITO'
          when op.tipooperacion = 2 then 'DEBITO'
        END AS TIPOOPERACION,
        EsPromocion IdEsPromocion,
        if(op.espromocion = 0, 'SIN PROMOCION', 'PROMOCION') ESPROMOCION,
        case
          when op.descripcion = 'AMERICAN EXPRESS' then 0
          else op.tipooperacion
        end as agrupador,
        ifnull(V.IMPORTE, 0) as importe,
        v.fecha as fecha,
        c.idcaja,
        caja,
        if(V.status = 1, 'VENTA', 'CANCELACION') Status,
        if(Vd.status = 1, 'VENTA', 'CANCELACION') StatusDetalle
      from voucher V
      inner join voucherdetalle VD on VD.idvoucher = V.idvoucher
      inner join tmov tmv on tmv.tm = vd.tmref
      inner join banco b on v.idbanco = b.idbanco 
      -- inner join operaciontarjeta op on op.idoperaciontarjeta=V.IdOperacionTarjeta and op.status=1  
      inner join operaciontarjeta op on op.idoperaciontarjeta = V.IdOperacionTarjeta
      inner join caja c on v.idcaja = c.idcaja
      where v.idcaja = idcaja
        and Vd.status <> 2
        and left(V.fecha, 10) = '  FechaIni.ToString(yyy-MM-dd)  '
    ) AS K
    group by agrupador, statusdetalle
  ) as M on M.tipooperacion = c1.descripcion and M.StatusDetalle = c1.tipo
  UNION ALL
  select 'Total' AS descripcion, c1.tipo, ifnull(sum(m.importe), 0) as importe,
    'FechaIni.ToString(yyy-MM-dd)' as fecha, idcaja as idcaja, idcaja as caja,
    0 as CStatus, 3 as agrupador, 100 as orden
  from cortevoucherorden c1
  left join (
    SELECT tipooperacion, agrupador, ifnull(sum(importe), 0) as importe,
      fecha, idcaja, caja, statusDetalle, count(statusDetalle) CStatus
    FROM (
      select concat(vd.tmref, '--', tmv.des) as Movimiento,
        case
          when op.descripcion = 'AMERICAN EXPRESS' then 'AMERICAN EXPRESS'
          when op.tipooperacion = 1 then 'CREDITO'
          when op.tipooperacion = 2 then 'DEBITO'
        END AS TIPOOPERACION,
        EsPromocion IdEsPromocion,
        if(op.espromocion = 0, 'SIN PROMOCION', 'PROMOCION') ESPROMOCION,
        case
          when op.descripcion = 'AMERICAN EXPRESS' then 0
          else op.tipooperacion
        end as agrupador,
        ifnull(V.IMPORTE, 0) as importe,
        v.fecha as fecha,
        c.idcaja,
        caja,
        if(V.status = 1, 'VENTA', 'CANCELACION') Status,
        if(Vd.status = 1, 'VENTA', 'CANCELACION') StatusDetalle
      from voucher V
      inner join voucherdetalle VD on VD.idvoucher = V.idvoucher
      inner join tmov tmv on tmv.tm = vd.tmref
      inner join banco b on v.idbanco = b.idbanco
      inner join operaciontarjeta op on op.idoperaciontarjeta = V.IdOperacionTarjeta
      inner join caja c on v.idcaja = c.idcaja
      where v.idcaja = idcaja and Vd.status <> 2 and left(V.fecha, 10) = '  FechaIni.ToString(yyy-MM-dd)  '
    ) AS K
    group by agrupador, statusdetalle
  ) as M on M.tipooperacion = c1.descripcion
  and M.StatusDetalle = c1.tipo
  group by c1.tipo
) as j
order by orden, tipo desc