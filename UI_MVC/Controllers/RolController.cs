using Microsoft.AspNetCore.Mvc;
using Tranferencia_Datos.Rol_DTOs;

namespace UI_MVC.Controllers
{
    public class RolController : Controller
    {
        // Para Hacer Solicitudes Al Servidor:
        private readonly HttpClient _HttpClient;

        public RolController(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient("API_RESTful");
        }


        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        public async Task<IActionResult> Registrados()
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenidos = await _HttpClient.GetAsync("/api/Rol");

            // OBJETO:
            Registrados_Rol Lista_Roles = new Registrados_Rol();

            // True=200-299
            if (JSON_Obtenidos.IsSuccessStatusCode)
            {
                // Deserializamos el Json:
                Lista_Roles = await JSON_Obtenidos.Content.ReadFromJsonAsync<Registrados_Rol>();
            }

            return View(Lista_Roles);
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        public async Task<IActionResult> Detalle(int id)
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("api/Rol/" + id);

            // OBJETO:
            Obtener_PorID Objeto_Obtenido = new Obtener_PorID();

            // Codigo Status:
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<Obtener_PorID>();
            }

            return View(Objeto_Obtenido);
        }


        // NOS MANDA A LA VISTA:
        public ActionResult Crear()
        {
            return View();
        }

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Crear_Rol crear_Rol)
        {
            // Solicitud "POST" al Endpoint:
            HttpResponseMessage Respuesta = await _HttpClient.PostAsJsonAsync("api/Rol", crear_Rol);

            // Codigo Status:
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Registrados", "Rol");
            }

            return View();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MANDA A VISTA
        public async Task<IActionResult> Editar(int id)
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("api/Rol/" + id);

            // OBJETO:
            Obtener_PorID Objeto_Obtenido = new Obtener_PorID();

            // Codigo Status:
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<Obtener_PorID>();
            }

            Editar_Rol Objeto_Editar = new Editar_Rol
            {
                Id = Objeto_Obtenido.Id,
                Nombre = Objeto_Obtenido.Nombre
            };

            return View(Objeto_Editar);
        }

        // RECIBE EL OBJETO MODIFICADO Y LO MODIFICA EN DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Editar_Rol editar_Rol)
        {
            // Solicitud "PUT" al Endpoint:
            HttpResponseMessage Respuesta = await _HttpClient.PutAsJsonAsync("api/Rol", editar_Rol);

            // Codigo Status:
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Registrados", "Rol");
            }

            return View();
        }




        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MANDA A VISTA
        public async Task<IActionResult> Eliminar(int id)
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("api/Rol/" + id);

            // OBJETO:
            Obtener_PorID Objeto_Obtenido = new Obtener_PorID();

            // Codigo Status:
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<Obtener_PorID>();
            }

            return View(Objeto_Obtenido);
        }

        // RECIBE EL OBJETO MODIFICADO Y LO MODIFICA EN DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(Obtener_PorID obtener_PorID)
        {
            // Solicitud "PUT" al Endpoint:
            HttpResponseMessage Respuesta = await _HttpClient.DeleteAsync("api/Rol/" + obtener_PorID.Id);

            // Codigo Status:
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Registrados", "Rol");
            }

            return View();
        }
    }
}
