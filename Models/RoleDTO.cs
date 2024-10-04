using Transport.Models;

namespace Transport.Models
{
    public class RoleDTO
    {
        public IEnumerable<ApplicationRole> Roles { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public RoleDTO()
        {
            Roles = Enumerable.Empty<ApplicationRole>(); // Inicializa Roles con una colección vacía
        }
    }
}