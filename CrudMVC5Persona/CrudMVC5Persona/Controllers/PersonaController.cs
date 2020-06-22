using CrudMVC5Persona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVC5Persona.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            MantenimientoPersona oPersona = new MantenimientoPersona();

            return View(oPersona.Listar());
        }
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection collection)
        {
            MantenimientoPersona opersona = new MantenimientoPersona();
            Persona oper = new Persona()
            {
                NOMBRES = collection["Nombres"],
                APELLIDOP = collection["ApellidoP"],
                APELLIDOM = collection["ApellidoM"],
                EDAD = int.Parse(collection["Edad"]),
                TELEFONO = collection["Telefono"],
                CORREO= collection["Correo"],
                DIRECCION=collection["Direccion"],
                SEXO=collection["Sexo"]
            };

            opersona.Registrar(oper);
            return RedirectToAction("Index");
        }

        
        public ActionResult Eliminar( int id)
        {
            MantenimientoPersona oPersona = new MantenimientoPersona();
            oPersona.Eliminar(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            MantenimientoPersona oPersona = new MantenimientoPersona();
           Persona oPers = oPersona.TraerPersona(id);
            return View(oPers);

        }
        [HttpPost]
        public ActionResult Actualizar(FormCollection collection)
        {
            MantenimientoPersona opersona = new MantenimientoPersona();
            Persona oper = new Persona()
            {
                ID_PERSONA= int.Parse(collection["IdPersona"]),
                NOMBRES = collection["Nombres"],
                APELLIDOP = collection["ApellidoP"],
                APELLIDOM = collection["ApellidoM"],
                EDAD = int.Parse(collection["Edad"]),
                TELEFONO = collection["Telefono"],
                CORREO = collection["Correo"],
                DIRECCION = collection["Direccion"],
                SEXO = collection["Sexo"]
            };
            opersona.Actualizar(oper);
            return RedirectToAction("Index");
        }

    }
}