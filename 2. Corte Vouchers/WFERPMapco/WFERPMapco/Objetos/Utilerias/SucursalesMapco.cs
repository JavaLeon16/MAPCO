using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WFERPMapco.Objetos.Utilerias
{
    public class SucursalesMapco
    {

        public List<WFERPMapco.Clases.Sucursales> getSucursales()
        {
            string appPath = Application.StartupPath;
            string dbPath = @"\Objetos\Utilerias\Sucursales.xml";
            string ruta = appPath + dbPath;

            List<Clases.Sucursales> sucursales = new List<Clases.Sucursales>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Clases.Sucursales>));


            XDocument xmlDoc = XDocument.Load(ruta);
            var list = xmlDoc.Root.Elements("Sucursal").Select(element => element).ToList();

            var lis = xmlDoc.Elements("Sucursales").Descendants("Sucursal");


            sucursales = list.Select(m => new Clases.Sucursales()
            {
                IdSucursal = int.Parse(m.Descendants("IdSucursal").First().Value.ToString()),
                IdEmpresa = int.Parse(m.Descendants("IdEmpresa").First().Value.ToString()),
                IdEstado = int.Parse(m.Descendants("IdEstado").First().Value.ToString()),
                IdMunicipio = int.Parse(m.Descendants("IdMunicipio").First().Value.ToString()),
                NombreSucursal = m.Descendants("NombreSucursal").First().Value.ToString(),
                CodigoSucursal = m.Descendants("CodigoSucursal").First().Value.ToString(),
                IP = m.Descendants("IP").First().Value.ToString(),
                BasedeDatos = m.Descendants("BasedeDatos").First().Value.ToString(),
            }).ToList();

            //foreach(var e  in lis)
            //{
            //    Clases.Sucursales i = new Clases.Sucursales();
            //    i.IdSucursal = int.Parse(e.Descendants("IdSucursal").First().Value.ToString());
            //    sucursales.Add(i);
            //   // var a = 
            //}

            return sucursales;
        }
    }
}
