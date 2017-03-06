using System.ComponentModel.DataAnnotations;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class DetalleComandas : IEntity
    {
        [Key]
        public int detalleComandaId { get; set; }
        public string comandaId { get; set; }
        public int cantidad { get; set; }

        public virtual Comandas comanda { get; set; }
        public virtual Productos producto { get; set; }
    }
}
