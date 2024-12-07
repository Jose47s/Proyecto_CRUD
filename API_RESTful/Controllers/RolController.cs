using API_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tranferencia_Datos.Rol_DTOs;


namespace API_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly MyDBcontext _MyDBcontext;

        public RolController(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }



        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        [HttpGet]
        public async Task<Registrados_Rol> Obtener_Todos()
        {
            List<Rol> Lista_Roles = await _MyDBcontext.Roles
                .ToListAsync();

            // DTO a retornar:
            Registrados_Rol registrados = new Registrados_Rol();

            foreach (Rol rol in Lista_Roles)
            {
                registrados.Lista_Roles.Add(new Registrados_Rol.Rol
                {
                    Id = rol.Id,
                    Nombre = rol.Nombre,

                });
            }

            return registrados;
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        [HttpGet("{id}")]
        public async Task<Obtener_PorID> Obtener_PorId(int id)
        {
            Rol? Objeto_Obtenido = await _MyDBcontext.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (Objeto_Obtenido == null)
            {
                return null;
            }

            // DTO a retornar:
            Obtener_PorID rol = new Obtener_PorID
            {
                Id = Objeto_Obtenido.Id,
                Nombre = Objeto_Obtenido.Nombre,
            };

            return rol;
        }




        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        public async Task<int> Crear(Crear_Rol crear_Rol)
        {
            // Objeto a Mapear:
            Rol rol = new Rol
            {
                Nombre = crear_Rol.Nombre,
            };

            _MyDBcontext.Add(rol);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        [HttpPut]
        public async Task<int> Editar(Editar_Rol editar_Rol)
        {
            Rol? Objeto_Obtenido = await _MyDBcontext.Roles
                .FirstOrDefaultAsync(x => x.Id == editar_Rol.Id);

            if (Objeto_Obtenido == null)
            {
                return 0;
            }

            // Modificamos:
            Objeto_Obtenido.Nombre = editar_Rol.Nombre;

            _MyDBcontext.Update(Objeto_Obtenido);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        [HttpDelete("{id}")]
        public async Task<int> Eliminar(int id)
        {
            Rol? Objeto_Obtenido = await _MyDBcontext.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (Objeto_Obtenido == null)
            {
                return 0;
            }

            _MyDBcontext.Remove(Objeto_Obtenido);

            return await _MyDBcontext.SaveChangesAsync();
        }


    }
}
