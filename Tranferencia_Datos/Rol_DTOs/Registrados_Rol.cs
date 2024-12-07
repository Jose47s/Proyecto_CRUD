using System;


namespace Tranferencia_Datos.Rol_DTOs
{
    public class Registrados_Rol
    {
        public class Rol
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public List<Rol> Lista_Roles { get; set; }

        public Registrados_Rol()
        {
            Lista_Roles = new List<Rol>();
        }
    }
}
