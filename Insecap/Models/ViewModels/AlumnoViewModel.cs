using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insecap.Models.ViewModels
{
    public class AlumnoViewModel
    {
        public int ID_Alumno { get; set; }
        [Required]
        [StringLength(12)]
        [Display(Name = "Rut")]
        public string Rut { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Género")]
        public string Genero { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public string Curso { get; set; }
    }

    public class AlumnoExisteAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (InsecapEntities db = new InsecapEntities())
            {
                string rut = (string)value;

                if (db.alumno.Where(d => d.rut == rut).Count() > 0)
                {
                    return new ValidationResult("Alumno ya existe.");
                }
            }

            return ValidationResult.Success;
        }
    }
}