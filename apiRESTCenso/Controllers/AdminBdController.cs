using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//----------------------------------------------
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using apiRESTCenso.Models;
using MySql.Data.MySqlClient;
//----------------------------------------------

namespace apiRESTCenso.Controllers
{
    public class AdminBdController : ApiController
    {
        // Extraccion de cadena de conexion
        private string cadCnn = ConfigurationManager.ConnectionStrings["control_acceso"].ConnectionString;


        //Endpoint para validar la conexion (MySQL)}

        [HttpGet]
        [Route("full/adminbd/checkmysqlconnection")]
        public clsApiStatus checkMySqlConnection()
        {
            //--------------------------------------------------
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            //--------------------------------------------------
            MySqlConnection cnn = new MySqlConnection(cadCnn);
            // Hacer prueba de conexion
            try
            {
                //--------------------
                cnn.Open();
                cnn.Close();
                //--------------------
                // Configurar objeto de salida
                objRespuesta.statusExec = true;
                objRespuesta.msg = "Conexion exitosa (MySQL)-control_acceso";
                objRespuesta.ban = 1;
                jsonResp.Add("msgData", "Conexion exitosa (MySQL)-control_acceso");
                objRespuesta.datos = jsonResp;
            }catch (Exception ex)
            {
                // Configurar objeto de salida
                objRespuesta.statusExec = false;
                objRespuesta.msg = "Conexion fallida (MySQL)-control_acceso";
                objRespuesta.ban = 0;
                jsonResp.Add("msgData", ex.Message.ToString());
                jsonResp.Add("msgList", ex.InnerException.ToString());
                objRespuesta.datos = jsonResp;
            }
            // Salida del objeto tipo clsApiStatus
            return objRespuesta;
        }
    }
}
