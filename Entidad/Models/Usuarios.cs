using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class Usuarios : IEntity
    {
        public int userId { get; set; }
        public string userName { get; set; }
    }
}
