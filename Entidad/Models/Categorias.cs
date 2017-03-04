using System.ComponentModel.DataAnnotations;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class Categorias : IEntity
    {
        [Key]
        public int categoriaId { get; set; }
        public string detalle { get; set; }

    }
}
