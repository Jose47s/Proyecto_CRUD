using System;
using System.ComponentModel.DataAnnotations;


namespace Tranferencia_Datos.Rol_DTOs
{
    public class Editar_Rol
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese El Nombre Del Rol.")]
        public string Nombre { get; set; }
    }
}
