using System;
using System.ComponentModel.DataAnnotations;


namespace Tranferencia_Datos.Rol_DTOs
{
    public class Crear_Rol
    {
        [Required(ErrorMessage = "Ingrese El Nombre Del Rol.")]
        public string Nombre { get; set; }
    }
}
