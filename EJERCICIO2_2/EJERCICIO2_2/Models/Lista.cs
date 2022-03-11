using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace EJERCICIO2_2.Models
{
    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int code { get; set; }

        public String imagenCodigo { get; set; }

        [MaxLength(100)]
        public String nombre { get; set; }

        [MaxLength(100)]
        public String descripcion { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
