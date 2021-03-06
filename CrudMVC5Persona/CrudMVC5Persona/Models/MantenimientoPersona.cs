﻿using System;
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
        public int Registrar(Persona per)
        {
            int Resul;
            using (SqlConnection cn = getConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRARPERSONA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOMBRES", per.NOMBRES);
                cmd.Parameters.AddWithValue("@APELLIDOP", per.APELLIDOP);
                cmd.Parameters.AddWithValue("@APELLIDOM", per.APELLIDOM);
                cmd.Parameters.AddWithValue("@EDAD", per.EDAD);
                cmd.Parameters.AddWithValue("@TELEFONO", per.TELEFONO);
                cmd.Parameters.AddWithValue("@CORREO", per.CORREO);
                cmd.Parameters.AddWithValue("@DIRECCION", per.DIRECCION);
                cmd.Parameters.AddWithValue("@SEXO", per.SEXO);
                cn.Open();
                Resul = cmd.ExecuteNonQuery();

            }
            return Resul;
        }
        public int Eliminar(int id)
        {
            int Resul;
            using (SqlConnection cn= getConexion())
            {
                SqlCommand cmd = new SqlCommand("ELIMINARPERSONA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PERSONA", id);
                cn.Open();
                Resul=cmd.ExecuteNonQuery();
            }
            return Resul;
        }
        public Persona TraerPersona(int id)
        {
            Persona oPer= new Persona();
            using (SqlConnection cn= getConexion())
            {
                SqlCommand cmd = new SqlCommand("LISTARPERSONA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PERSONA", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oPer.ID_PERSONA = int.Parse(dr[0].ToString());
                    oPer.NOMBRES = dr[1].ToString();
                    oPer.APELLIDOP = dr[2].ToString();
                    oPer.APELLIDOM = dr[3].ToString();
                    oPer.SEXO = dr[4].ToString();
                    oPer.EDAD = int.Parse(dr[5].ToString());
                    oPer.TELEFONO = dr[6].ToString();
                    oPer.CORREO = dr[7].ToString();
                    oPer.DIRECCION = dr[8].ToString();
                }
                return oPer;
            }
        }
         
        public int Actualizar(Persona per)
        {
            int Resul;
            using (SqlConnection cn = getConexion())
            {
                SqlCommand cmd = new SqlCommand("ACTUALIZARPERSONA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PERSONA", per.ID_PERSONA);
                cmd.Parameters.AddWithValue("@NOMBRES", per.NOMBRES);
                cmd.Parameters.AddWithValue("@APELLIDOP", per.APELLIDOP);
                cmd.Parameters.AddWithValue("@APELLIDOM", per.APELLIDOM);
                cmd.Parameters.AddWithValue("@EDAD", per.EDAD);
                cmd.Parameters.AddWithValue("@TELEFONO", per.TELEFONO);
                cmd.Parameters.AddWithValue("@CORREO", per.CORREO);
                cmd.Parameters.AddWithValue("@DIRECCION", per.DIRECCION);
                cmd.Parameters.AddWithValue("@SEXO", per.SEXO);
                cn.Open();
             Resul = cmd.ExecuteNonQuery();

            }
            return Resul;
        }
    }
}