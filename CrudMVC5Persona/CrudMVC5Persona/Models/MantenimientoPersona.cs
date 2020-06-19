using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CrudMVC5Persona.Models
{
    public class MantenimientoPersona:ConexDB
    {
        public List<Persona> Listar()
        {
            List<Persona> LstPersona = new List<Persona>();

            using (SqlConnection cn = getConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_LISTARPERSONA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Persona oPersona;
                while (dr.Read())
                {
                    oPersona = new Persona()
                    {
                        ID_PERSONA = int.Parse(dr[0].ToString()),
                        NOMBRES = dr[1].ToString(),
                        APELLIDOP = dr[2].ToString(),
                        APELLIDOM = dr[3].ToString(),
                        SEXO = dr[4].ToString(),
                        EDAD = int.Parse(dr[5].ToString()),
                        TELEFONO=dr[6].ToString(),
                        CORREO=dr[7].ToString(),
                        DIRECCION=dr[8].ToString()
                    };
                    LstPersona.Add(oPersona);
                }
            }
            return LstPersona;
        }


    }
}