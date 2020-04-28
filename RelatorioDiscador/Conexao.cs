using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RelatorioDiscador
{
    public class Conexao
    {
        //public string conec = "Data Source = 10.0.3.119,1433; Network Library = DBMSSOCN;Initial Catalog = gen_ocs; User ID = Sercomtel; Password=genesys@2019";
        public string conec = "SERVER=10.0.2.9;DATABASE=genesys;UID=ura;PWD=ask123;";

        public MySqlConnection con = null;
        public void AbrirCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
                //HttpContext.Current.Response.Write("Conectado");
            }
            catch (System.Exception ex)
            {

                HttpContext.Current.Response.Write("Erro ao conectar" + ex);
            }
        }
        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (System.Exception ex)
            {

                HttpContext.Current.Response.Write("Erro ao conectar" + ex);
            }
        }
    }
}