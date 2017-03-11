using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ComandaModel
    {   
        [Key]
        public int comandaId { get; set; }
        public List<ProductosPedidos> listaPedido {get;set;}
        public string usuarioId;

    }

    public class ProductosPedidos
    {
        [Key]
        public int productoPedidoId { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }

    }
}