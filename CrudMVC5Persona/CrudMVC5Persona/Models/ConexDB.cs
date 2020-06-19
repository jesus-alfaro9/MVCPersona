using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace CrudMVC5Persona.Models
{
    public class ConexDB
    {
        private string conex;
        public ConexDB()
        {
            this.conex = ConfigurationManager.ConnectionStrings["Conex"].ConnectionString;
        }
        public SqlConnection getConexion()
        {
            SqlConnection cn = new SqlConnection(conex);
            return cn;
        }

    }
}