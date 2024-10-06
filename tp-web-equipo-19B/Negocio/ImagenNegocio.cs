using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("SELECT i.Id, i.IdArticulo, i.ImagenUrl FROM IMAGENES i;");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)data.Lector["i.Id"];
                    aux.IdArticulo = (int)data.Lector["i.IdArticulo"];
                    aux.Url = (string)data.Lector["i.ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }
        public void agregar(Imagen item)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setearConsulta("INSERT INTO IMAGENES (IdArticulo,ImagenUrl) VALUES (@IdArticulo@,@Url@)");
                data.setearParametro("@IdArticulo@", item.IdArticulo);
                data.setearParametro("@Url@", item.Url);
                data.ejecutarAccion();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }
        public void editar(Imagen item)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @Url@ WHERE Id = @Id@");
                data.setearParametro("@Url@", item.Url);
                data.setearParametro("@Id@", item.Id);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }
        
        public List<Imagen> listaImagenesPorArticulo(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES i WHERE i.IdArticulo = @id@;");
                data.setearParametro("@id@", id);
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)data.Lector["Id"];
                    aux.IdArticulo = (int)data.Lector["IdArticulo"];
                    aux.Url = (string)data.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { data.cerrarConexion(); }
        }
    }
}
