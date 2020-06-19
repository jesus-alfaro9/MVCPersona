using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMVC5Persona.Models
{
    public class Persona
    {
        public int ID_PERSONA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOP { get; set; }
        public string APELLIDOM { get; set; }
        public int EDAD { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }

        public string SEXO { get; set; }


    }
}