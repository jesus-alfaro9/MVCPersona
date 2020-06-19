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
    }
}