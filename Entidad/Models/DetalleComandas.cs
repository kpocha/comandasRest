using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class DetalleComandas : IEntity
    {
        [Key]
        public int detalleComandasId { get; set; }
        public string nombreComida { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public int comandasId { get; set; }

        [ForeignKey("comandasId")]
        public virtual Comandas comanda { get; set; }
        
        
    }
}
