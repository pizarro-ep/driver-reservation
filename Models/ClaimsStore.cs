using System.Security.Claims;

namespace Transport.Models
{
    public class ClaimsStore
    {
        public static List<Claim> GetAllClaims()
        {
            return new List<Claim>(){
            // Inicializar los claims de la aplicación
            new Claim("Crear Rol", "Crear Rol"),
            new Claim("Editar Rol", "Editar Rol"),
            new Claim("Eliminar Rol", "Eliminar Rol")
        };
        }
    }
}
