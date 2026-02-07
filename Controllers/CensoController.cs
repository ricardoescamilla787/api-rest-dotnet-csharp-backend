using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
//------------------------
using apiRESTCenso.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//------------------------

namespace apiRESTCenso.Controllers
{
    public class CensoController : ApiController
    {

        // Arreglo de Objetos tipo clsCensoDatos
        public static clsCensoDatos[] objCensoDatos = null;
        public static int ban = -1;

        // GET: api/Censo
        public IHttpActionResult Get()
        {
            if (objCensoDatos != null && objCensoDatos.Length > 0)
            {
                return Ok(objCensoDatos);
            }
            else
            {
                return Ok("ban= " + ban);
            }

        }

        // GET: api/Censo?id=
        public IHttpActionResult Get(int id)
        {
            if (objCensoDatos == null || objCensoDatos.Length == 0)
            {
                return Ok("ban=" + ban); 
            }
            var objeto = objCensoDatos.FirstOrDefault(x => x.id == id);
            if (objeto != null)
            {
                return Ok(objeto); 
            }
            else
            {
                return Ok("ban=" + ban); 
            }
        }

        // POST: api/Censo
        public clsApiStatus Post ([FromBody] clsCensoDatos modelo)
        {

            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();


            // PROCESO PARA MANIPULAR OBJETOS DE DATOS DEL TIPO clsCensoDatos
            // SE VALIDA LA INSERCIÓN DE OBJETOS INDEPENDIENTES AL REPOSITORIO GLOBAL DE LA API
            int i;
            if (objCensoDatos == null)
            {
                objCensoDatos = new clsCensoDatos[1];
                objCensoDatos[0] = modelo;
            }
            else
            {
                clsCensoDatos[] objCensoDatosAux = new clsCensoDatos[objCensoDatos.Length + 1];
                for (i = 0; i < objCensoDatos.Length; i++)
                    objCensoDatosAux[i] = objCensoDatos[i];
                objCensoDatosAux[i] = modelo;

                objCensoDatos = null;
                objCensoDatos = new clsCensoDatos[objCensoDatosAux.Length];
                objCensoDatos = objCensoDatosAux;
            }

            objRespuesta.statusExec = true;
            objRespuesta.msg = "Persona registrada exitosamente en Censo";
            objRespuesta.ban = 1;
            jsonResp.Add("msgData", "Registro Exitoso (clsCensoDatos)");
            objRespuesta.datos = jsonResp;
            return objRespuesta;
        }

        // PUT: api/Censo?id=
        public IHttpActionResult Put(int id, [FromBody] clsCensoDatos modelo)
        {

            if (objCensoDatos == null || objCensoDatos.Length == 0)
            {
                return Ok("ban=" + ban); 
            }

            var objeto = objCensoDatos.FirstOrDefault(x => x.id == id);
            if (objeto != null)
            {
                int ban = 1;
                objeto.nombre = modelo.nombre;
                objeto.apellidoPaterno = modelo.apellidoPaterno;
                objeto.rol = modelo.rol;

                return Ok("ban=" + ban); 
            }
            else
            {
                ban = 0;
                return Ok("ban=" + ban); 
            }
        }

        // DELETE: api/Censo/5
        public clsApiStatus Delete(int id)
        {
            int i, j, ban = 0;
            
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            

            if (objCensoDatos != null)
            {
                
                for (i = 0; i < objCensoDatos.Length; i++)
                    if (objCensoDatos[i].id == id)
                        ban = 1;

                
                if (ban == 1)
                {
                    clsCensoDatos[] objCensoDatosAux = new clsCensoDatos[objCensoDatos.Length - 1];

                    for (i = 0, j = 0; i < objCensoDatos.Length; i++)
                    {
                        
                        
                        if (objCensoDatos[i].id != id)
                        {
                            objCensoDatosAux[j] = objCensoDatos[i];
                            j++;
                        }
                    }

                    
                    objCensoDatos = null;
                    objCensoDatos = new clsCensoDatos[objCensoDatosAux.Length];
                    objCensoDatos = objCensoDatosAux;
                    objCensoDatosAux = null;
                }

                
                objRespuesta.statusExec = true;
                if (ban == 0)
                    objRespuesta.msg = "Persona no está registrada en Censo";
                else
                    objRespuesta.msg = "Persona eliminada exitosamente en Censo";

                objRespuesta.ban = ban;
                
                jsonResp.Add("msgData", "Eliminación Exitosa (clsCensoDatos)");
                objRespuesta.datos = jsonResp;

            }
            else
            {
                ban = -1;
                
                objRespuesta.statusExec = true;
                objRespuesta.msg = "No hay un Censo registrado hasta ahora";
                objRespuesta.ban = ban;
                
                jsonResp.Add("msgData", "Eliminación fallida (clsCensoDatos)");
                objRespuesta.datos = jsonResp;
            }

            return objRespuesta;
        }
    }
}