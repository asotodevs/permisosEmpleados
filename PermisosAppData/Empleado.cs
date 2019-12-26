using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PermisosAppData
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe ingresar un Nombre")]
        [Display(Description ="Nombre Empelado")]
        [StringLength(150,MinimumLength =4,ErrorMessage ="El nombre debe ser mayor que {2} letras y menor que {1}")]       
        public string NombreEmpleado { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Apellido")]
        [Display(Description = "Apellido Empelado")]
        public string ApellidoEmpleado { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Tipo de Permiso")]
        [Display(Description = "Tipo de Permiso")]
        public int TipoPermisoID { get; set; }
        public TipoPermiso TipoPermiso { get; set; }
        [Required(ErrorMessage = "Debe ingresar una  Fecha de Otorgado")]
        [Display(Description = "Fecha de Otorgado")]
        public DateTime FechaPermiso { get; set; }


    }
}