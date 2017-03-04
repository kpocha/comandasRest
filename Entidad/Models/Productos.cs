using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class Productos : IEntity
    {
        [Key]
        public int productosId { get; set; }
        public string detalle { get; set; }
        public float precio { get; set; }
        public int categoriaId { get; set; }
        public bool hay { get; set; }
        [ForeignKey("categoriaId")]
        public virtual Categorias categoria { get; set; }
    }
}
