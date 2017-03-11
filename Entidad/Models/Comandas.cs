using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad.Models
{
    public class Comandas : IEntity
    {

        [Key]
        public int comandasId { get; set; }
        //public int userId { get; set; }
        public DateTime fecha { get; set; }
        public float precioTotal { get; set; }
        public string nombreUsuario { get; set; }

        /*  [ForeignKey("userId")]
          public virtual Usuarios user { get; set; }*/

        public virtual ICollection<DetalleComandas> detalleComanda { get; set; }

    }
}
