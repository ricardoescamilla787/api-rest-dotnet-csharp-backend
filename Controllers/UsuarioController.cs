using apiRESTCenso.Models;
//-------------------------
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Web.Http;
using MySql.Data.MySqlClient;
//-------------------------

namespace apiRESTCenso.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("full/usuario/spinsusuario")]
        public clsApiStatus sp_InsUsuario([FromBody] clsUsuario modelo)
        {
            //--------------------------------------------------
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            //--------------------------------------------------
            try
            {
                //Creacion del objeto usuario para inserccion
                clsUsuario objUsuario = new clsUsuario(modelo.nombre,
                                                       modelo.apellidoPaterno,
                                                       modelo.apellidoMaterno,
                                                       modelo.usuario,
                                                       modelo.contraseña,
                                                       modelo.ruta,
                                                       modelo.tipo);
                DataSet ds = new DataSet();
                // Ejecucion del metodo de inserccion y recepcion de resultados
                ds = objUsuario.spInsUsuario();
                // Configuracion de los atributos de salida (clsUsuario)
                objRespuesta.statusExec = true;
                objRespuesta.msg = "Registro de usuario exitoso (control_acceso)";
                objRespuesta.ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                jsonResp.Add("msgData", "Registro de usuario exitoso (control_acceso)");
                objRespuesta.datos = jsonResp;
            }
            catch (Exception ex)
            {
                // Configuracion de los atributos de salida (clsUsuario)
                objRespuesta.statusExec = false;
                objRespuesta.msg = "Registro de usuario fallido exitoso (control_acceso)";
                objRespuesta.ban = -1;
                jsonResp.Add("msgData", ex.Message.ToString());
                objRespuesta.datos = jsonResp;
            }
            return objRespuesta;
        }

        [HttpPost]
        [Route("full/usuario/spvalidaracceso")]
        public DataSet spValidarAcceso([FromBody] clsUsuario modelo)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creacion del objeto usuario para inserccion
                clsUsuario objUsuario = new clsUsuario(modelo.usuario,
                                                       modelo.contraseña);
                // Ejecucion del metodo de inserccion y recepcion de resultados
                ds = objUsuario.spValidarAcceso();

            }
            catch (Exception ex)
            {
                //configurar el Dataset para salida
                //(formateo con clsApiStatus)
                DataTable dt = new DataTable("spValidarAcceso");
                dt.Columns.Add("statusExec");
                dt.Columns.Add("msg");
                dt.Columns.Add("ban");
                dt.Columns.Add("msgData");
                dt.Columns.Add("msgException");
                //Formateo de los datos de salida
                DataRow dr = dt.NewRow();
                dr["statusExec"] = "false";
                dr["msg"] = "Error en control de acceso,verificar ...";
                dr["ban"] = "-1";
                dr["msgData"] = ex.Message.ToString();
                dr["msgException"] = ex.InnerException.ToString();
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

            }
            // Return del DataSet con los datos recibidos 
            // (o formateados dentro del catch)
            return ds;
        }

        [HttpGet]
        [Route("full/usuario/vwrptusuario")]
        public DataSet vwRptUsuario()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creacion del objeto usuario para inserccion
                clsUsuario objUsuario = new clsUsuario();
                // Ejecucion del metodo de inserccion y recepcion de resultados
                ds = objUsuario.vwRptUsuario();
            }
            catch (Exception ex)
            {
                //configurar el Dataset para salida
                //(formateo con clsApiStatus)
                DataTable dt = new DataTable("vwRptUsuario");
                dt.Columns.Add("statusExec");
                dt.Columns.Add("msg");
                dt.Columns.Add("ban");
                dt.Columns.Add("msgData");
                dt.Columns.Add("msgException");
                //Formateo de los datos de salida
                DataRow dr = dt.NewRow();
                dr["statusExec"] = "false";
                dr["msg"] = "Error en reportes de usuarios,verificar ...";
                dr["ban"] = "-1";
                dr["msgData"] = ex.Message.ToString();
                dr["msgException"] = ex.InnerException.ToString();
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
            }
            // Return del DataSet con los datos recibidos 
            // (o formateados dentro del catch)
            return ds;
        }

        [HttpGet]
        [Route("full/usuario/vwrptusuariofiltro")]
        public DataSet vwRptUsuarioFiltro(string nomFiltro)
        {
            DataSet ds = new DataSet();
            // Crear un objeto de clsUsuario y ejecutar el método con el filtro
            clsUsuario objUsuario = new clsUsuario();
            ds = objUsuario.vwRptUsuarioFiltro(nomFiltro);
            // Verificar si el DataSet no es nulo y no tiene resultados
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                // Limpiar el DataSet si ya contiene tablas
                ds.Tables.Clear();

                // Si no se encontraron resultados, formatear un DataTable con el mensaje de error
                DataTable dt = new DataTable("vwRptUsuarioFiltro");
                dt.Columns.Add("statusExec");
                dt.Columns.Add("msg");
                dt.Columns.Add("ban");
                dt.Columns.Add("msgData");
                // Añadir fila de error al DataTable
                DataRow dr = dt.NewRow();
                dr["statusExec"] = "false";
                dr["msg"] = "No se encontraron usuarios con el filtro especificado.";
                dr["ban"] = "-1";
                dr["msgData"] = $"Filtro aplicado: {nomFiltro}";
                dt.Rows.Add(dr);

                // Añadir el DataTable al DataSet vacío
                ds.Tables.Add(dt);
            }
            // Retornar el DataSet, ya sea con los resultados o con el error
            return ds;
        }

        [HttpGet]
        [Route("full/usuario/vwtipousuario")]
        public DataSet vwTipoUsuario()
        {
            DataSet ds = new DataSet();
            try
            {
                // Crear un objeto de clsUsuario y ejecutar el método vwTipoUsuario
                clsUsuario objUsuario = new clsUsuario();
                ds = objUsuario.vwTipoUsuario();
            }
            catch (Exception ex)
            {
                // Verificar si se encontraron resultados
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    // Limpiar el DataSet si ya contiene tablas
                    ds.Tables.Clear();
                    // Si no se encontraron resultados, formatear un DataTable con el mensaje de error
                    DataTable dt = new DataTable("vwTipoUsuario");
                    dt.Columns.Add("statusExec");
                    dt.Columns.Add("msg");
                    dt.Columns.Add("ban");
                    dt.Columns.Add("msgData");
                    // Añadir fila de error al DataTable
                    DataRow dr = dt.NewRow();
                    dr["statusExec"] = "false";
                    dr["msg"] = "No se encontraron tipos de usuario registrados.";
                    dr["ban"] = "-1";
                    dr["msgData"] = "No hay tipos de usuario en la base de datos.";
                    dt.Rows.Add(dr);
                    // Añadir el DataTable al DataSet vacío
                    ds.Tables.Add(dt);
                }
            }
            // Retornar el DataSet, ya sea con los resultados o con el error
            return ds;
        }
        [HttpDelete]
        [Route("full/usuario/delete")]
        public clsApiStatus DeleteUsuario(int id)
        {
            //--------------------------------------------------
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            //--------------------------------------------------
            try
            {
                string cadCnn = System.Configuration.ConfigurationManager.ConnectionStrings["control_acceso"].ConnectionString;

                using (MySqlConnection cnn = new MySqlConnection(cadCnn))
                {
                    cnn.Open();
                    string query = "DELETE FROM USUARIO WHERE USU_CVE_USUARIO = @id";
                    MySqlCommand cmd = new MySqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@id", id);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        objRespuesta.statusExec = true;
                        objRespuesta.msg = "Usuario eliminado correctamente";
                        objRespuesta.ban = 1;
                        jsonResp.Add("msgData", "Usuario eliminado correctamente");
                    }
                    else
                    {
                        objRespuesta.statusExec = false;
                        objRespuesta.msg = "Usuario no encontrado";
                        objRespuesta.ban = 0;
                        jsonResp.Add("msgData", "Usuario no encontrado");
                    }

                    objRespuesta.datos = jsonResp;
                }
            }
            catch (Exception ex)
            {
                objRespuesta.statusExec = false;
                objRespuesta.msg = "Error al eliminar usuario";
                objRespuesta.ban = -1;
                jsonResp.Add("msgData", ex.Message.ToString());
                objRespuesta.datos = jsonResp;
            }

            return objRespuesta;
        }
        [HttpPut]
        [Route("api/usuario/update")]
        public clsApiStatus UpdateUsuario([FromBody] clsUsuario modelo)
        {
            //--------------------------------------------------
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            //--------------------------------------------------
            try
            {
                string cadCnn = System.Configuration.ConfigurationManager.ConnectionStrings["control_acceso"].ConnectionString;

                using (MySqlConnection cnn = new MySqlConnection(cadCnn))
                {
                    cnn.Open();
                    string query = @"UPDATE USUARIO 
                             SET USU_NOMBRE = @nombre, 
                                 USU_APELLIDO_PATERNO = @paterno, 
                                 USU_APELLIDO_MATERNO = @materno,
                                 USU_USUARIO = @usuario,
                                 USU_CONTRASENA = @contrasena,
                                 USU_RUTA = @ruta,
                                 TIP_CVE_TIPOUSUARIO = @tipo
                             WHERE USU_CVE_USUARIO = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@id", modelo.cve);
                    cmd.Parameters.AddWithValue("@nombre", modelo.nombre);
                    cmd.Parameters.AddWithValue("@paterno", modelo.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@materno", modelo.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@usuario", modelo.usuario);
                    cmd.Parameters.AddWithValue("@contrasena", modelo.contraseña);
                    cmd.Parameters.AddWithValue("@ruta", modelo.ruta);
                    cmd.Parameters.AddWithValue("@tipo", modelo.tipo);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        objRespuesta.statusExec = true;
                        objRespuesta.msg = "Usuario actualizado correctamente.";
                        objRespuesta.ban = 1;
                        jsonResp.Add("msgData", "Usuario actualizado correctamente.");
                    }
                    else
                    {
                        objRespuesta.statusExec = false;
                        objRespuesta.msg = "No se encontró el usuario.";
                        objRespuesta.ban = 0;
                        jsonResp.Add("msgData", "No se encontró el usuario.");
                    }

                    objRespuesta.datos = jsonResp;
                }
            }
            catch (Exception ex)
            {
                objRespuesta.statusExec = false;
                objRespuesta.msg = "Error al actualizar usuario.";
                objRespuesta.ban = -1;
                jsonResp.Add("msgData", ex.Message);
                objRespuesta.datos = jsonResp;
            }

            return objRespuesta;
        }


    }
}