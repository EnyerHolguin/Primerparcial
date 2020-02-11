using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimerParcial.Entidades
{
 
   public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public String Descripcion  { get; set; }
        public decimal Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal Valorinventario { get; set; }

        public Productos()
        {
            
            
        }

        public Productos(int productoId, string descripcion, decimal existencia, decimal costo, decimal valorinventario)
        {
            ProductoId = productoId;
            Descripcion = descripcion;
            Existencia = existencia;
            Costo = costo;
            Valorinventario = valorinventario;
        }
    }
}

