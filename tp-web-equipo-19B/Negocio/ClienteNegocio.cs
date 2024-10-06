using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("select Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP from Clientes;");
                data.ejecutarLectura();

                while (data.Lector.Read())
                { 
                    Cliente cliente = new Cliente();

                    cliente.Id = (int)data.Lector["Id"];
                    cliente.Documento = (string)data.Lector["Documento"];
                    cliente.Nombre = (string)data.Lector["Nombre"];
                    cliente.Apellido = (string)data.Lector["Apellido"];
                    cliente.Email = (string)data.Lector["Email"];
                    cliente.Direccion = (string)data.Lector["Direccion"];
                    cliente.Ciudad = (string)data.Lector["Ciudad"];
                    cliente.Cp = (int)data.Lector["CP"];

                    lista.Add(cliente);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { data.cerrarConexion(); }
        }

        public void agregarCliente(Cliente item)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES(@documento@, @nombre@, @apellido@, @email@, @direccion@, @ciudad@, @cp@);");

                datos.setearParametro("@documento@", item.Documento);
                datos.setearParametro("@nombre@", item.Nombre);
                datos.setearParametro("@apellido@", item.Apellido);
                datos.setearParametro("@email@", item.Email);
                datos.setearParametro("@direccion@", item.Direccion);
                datos.setearParametro("@ciudad@", item.Ciudad);
                datos.setearParametro("@cp@", item.Cp);

                datos.ejecutarAccion();
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
        public int obtenerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            int id;
            try
            {
                datos.setearConsulta("SELECT TOP(1) Id FROM Clientes ORDER BY Id DESC;");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    id = (int)datos.Lector["Id"];
                }
                else
                {
                    id = 0;
                }

                return id;
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

        public Cliente getClienteByDNi(String dni)
        {
            Cliente cliente = new Cliente();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("select TOP(1) Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP from Clientes where Documento like @dni@ order by Id desc;");
                data.setearParametro("@dni@", dni);
                data.ejecutarLectura();

                if (data.Lector.Read())
                {
                    cliente.Id = (int)data.Lector["Id"];
                    cliente.Documento = (string)data.Lector["Documento"];
                    cliente.Nombre = (string)data.Lector["Nombre"];
                    cliente.Apellido = (string)data.Lector["Apellido"];
                    cliente.Email = (string)data.Lector["Email"];
                    cliente.Direccion = (string)data.Lector["Direccion"];
                    cliente.Ciudad = (string)data.Lector["Ciudad"];
                    cliente.Cp = (int)data.Lector["CP"];
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.cerrarConexion(); }
        }
    }
}
