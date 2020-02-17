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
            ProductoId = 0;
            Descripcion = string.Empty; 
            Existencia = 0;
            Costo = 0;
            Valorinventario = 0;
        }
    }
}

