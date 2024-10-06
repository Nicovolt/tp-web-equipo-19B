using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public void registrarUsoVoucher(int idCliente, int idArticulo, string codigo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                DateTime dateTime = DateTime.Now;
                data.setearConsulta("UPDATE Vouchers SET IdCliente=@idCliente@, FechaCanje=@fecha@, IdArticulo=@idArticulo@ WHERE CodigoVoucher=@codigo@;");
                data.setearParametro("@idCliente@", idCliente);
                data.setearParametro("@idArticulo@", idArticulo);
                data.setearParametro("@fecha@", dateTime);
                data.setearParametro("@codigo@", codigo);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { data.cerrarConexion(); }
        }
    }
}
