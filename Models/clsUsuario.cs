using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//------------------------------------
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
//------------------------------------

namespace apiRESTCenso.Models
{
    public class clsUsuario
    {
        // atributos
        public string cve { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string ruta { get; set; }
        public string tipo { get; set; }

       
        // Constructores
        public clsUsuario()
        {
            
        }
        public clsUsuario(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }
        public clsUsuario(string nombre, string apellidoPaterno,
                          string apellidoMaterno, string usuario, string contraseña, string ruta, string tipo)
        {
            // Inicializacion 
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.ruta = ruta;
            this.tipo = tipo;

        }
        private string cadCnn = ConfigurationManager.ConnectionStrings["control_acceso"].ConnectionString;
        

        // Insercion de usuarios (sp_InsUsuario)
        public DataSet spInsUsuario()
        {
            
            string cadSQL = "";
            cadSQL = "call spInsUsuario('" + this.nombre + "','"
                                            + this.apellidoPaterno + "','"
                                            + this.apellidoMaterno + "','"
                                            + this.usuario + "','"
                                            + this.contraseña + "','"
                                            + this.ruta + "',"
                                            + this.tipo + ");";
            MySqlConnection cnn = new MySqlConnection(cadCnn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            
            da.Fill(ds, "sp_InsUsuario"); 
            return ds;
        }
        // Validad acceso
        public DataSet spValidarAcceso()
        {
            
            string cadSQL = "";
            cadSQL = "call spValidarAcceso('" + this.usuario + "','"
                                              + this.contraseña + "');";

            MySqlConnection cnn = new MySqlConnection(cadCnn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            
            da.Fill(ds, "spValidarAcceso"); 
            return ds;


        }
        // Proceso de insercion de usuarios (vwRptUsuario)
        public DataSet vwRptUsuario()
        {
            
            string cadSQL = "";
            cadSQL = "select * from vwRptUsuario"; 

            
            MySqlConnection cnn = new MySqlConnection(cadCnn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();
            
            da.Fill(ds, "vwRptUsuario"); 
            return ds;


        }
        public DataSet vwRptUsuarioFiltro(string nomFiltro)
        {

            string cadSQL = $"select * from vwRptUsuario where Usuario like '%{nomFiltro}%'";

            MySqlConnection cnn = new MySqlConnection(cadCnn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "vwRptUsuarioFiltro");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta con filtro.", ex);
            }
            return ds;
        }
        public DataSet vwTipoUsuario()
        {

            string cadSQL = "select * from vwTipoUsuario";

            MySqlConnection cnn = new MySqlConnection(cadCnn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSQL, cnn);
            DataSet ds = new DataSet();

            
            da.Fill(ds, "vwTipoUsuario"); 
            return ds;
        }
    }
}