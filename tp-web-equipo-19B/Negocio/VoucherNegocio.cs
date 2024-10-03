using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
        public Voucher buscaPorCodigo(string codigo)
        {
            Voucher voucher = new Voucher();
            AccesoDatos datos = new AccesoDatos();

            if (!string.IsNullOrEmpty(codigo))
            {
                try
                {
                    string consulta = "SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @codigo";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@codigo", codigo);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        voucher.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                        if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("IdCliente")))
                        {
                            voucher.IdCliente = (int?)datos.Lector["IdCliente"];
                        }
                        else
                        {
                            voucher.IdCliente = null;
                        }
                        if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("FechaCanje")))
                        {
                            voucher.FechaCanje = (DateTime?)datos.Lector["FechaCanje"];
                        }
                        else
                        {
                            voucher.FechaCanje = null;
                        }
                        if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("FechaCanje")))
                        {
                            voucher.IdArticulo = (int?)datos.Lector["IdArticulo"];
                        }
                        else
                        {
                            voucher.IdArticulo = null;
                        }
                    }

                    return voucher;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
            else return voucher;
        }
    }
}
