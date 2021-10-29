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
                               genero = d.genero,
                               curso = d.curso
                           }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo (AlumnoViewModel model)
        {
            try {
                if (ModelState.IsValid)
                {
                    using (InsecapEntities db = new InsecapEntities())
                    {
                        var oAlumno = new alumno
                        {
                            rut = model.Rut,
                            nombre = model.Nombre,
                            fecha_nacimiento = model.Fecha_Nacimiento,
                            genero = model.Genero,
                            curso = model.Curso
                        };

                        db.alumno.Add(oAlumno);
                        db.SaveChanges();
                    }
                    return Redirect("~/Alumno/");
                }

                return View(model);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Modificar(int id)
        {
            AlumnoViewModel model = new AlumnoViewModel();
            using (InsecapEntities db = new InsecapEntities())
            {
                var oAlumno = db.alumno.Find(id);
                model.Rut = oAlumno.rut;
                model.Nombre = oAlumno.nombre;
                model.Fecha_Nacimiento = oAlumno.fecha_nacimiento;
                model.Genero = oAlumno.genero;
                model.Curso = oAlumno.curso;
                model.ID_Alumno= oAlumno.id_alumno;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(AlumnoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InsecapEntities db = new InsecapEntities())
                    {
                        var oAlumno = db.alumno.Find(model.ID_Alumno);
                        oAlumno.rut = model.Rut;
                        oAlumno.nombre = model.Nombre;
                        oAlumno.fecha_nacimiento = model.Fecha_Nacimiento;
                        oAlumno.genero = model.Genero;
                        oAlumno.curso = model.Curso;

                        db.Entry(oAlumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Alumno/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            AlumnoViewModel model = new AlumnoViewModel();
            using (InsecapEntities db = new InsecapEntities())
            {
                var oAlumno = db.alumno.Find(id);
                db.alumno.Remove(oAlumno);
                db.SaveChanges();
            }
            return Redirect("~/Alumno/");
        }
    }
}