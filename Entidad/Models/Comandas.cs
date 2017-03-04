using System;
using System.ComponentModel.DataAnnotations;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class Comandas : IEntity
    {
        //public Comandas()
        //{
        //    detalleComanda = new HashSet<DetalleComandas>();
        //}

        [Key]
        public int comandaId { get; set; }
        public int userId { get; set; }
        //public string IdDetalle { get; set; }
        public DateTime fecha { get; set; }


        public virtual Usuarios user { get; set; }
        //public virtual IEnumerable<DetalleComandas> detalleComanda { get; set; }

    }
}
