using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insecap.Models;
using Insecap.Models.ViewModels;

namespace Insecap.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            List<ListAlumnoViewModel> lst;
            using (InsecapEntities db = new InsecapEntities())
            {
                lst = (from d in db.alumno
                           select new ListAlumnoViewModel
                           {
                               id_alumno = d.id_alumno,
                               rut = d.rut,
                               nombre = d.nombre,
                               fecha_nacimiento = d.fecha_nacimiento,
                               genero = d.genero
                           }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo ()
        {
            return View();
        }
    }
}