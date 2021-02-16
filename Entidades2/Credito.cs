using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Credito : BaseEntity
    {
        public int Id_Credito { get; set; }
        public float Monto { get; set; }
        public float Tasa { get; set; }
        public string Nombre { get; set; }
        public float Cuota { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; }
        public float SaldoOperacion { get; set; }
        public int Cliente { get; set; }

        public Credito()
        {

        }

        public Credito(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 8)
            {
                var entero = 0;
                /*
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Credito = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                */
                Monto = float.Parse(infoArray[0]);
                Tasa = float.Parse(infoArray[1]);
                Nombre = infoArray[2];
                Cuota = float.Parse(infoArray[3]);
                FechaInicio = DateTime.Parse(infoArray[4]);
                Estado = infoArray[5];
                SaldoOperacion = float.Parse(infoArray[6]);
                if (Int32.TryParse(infoArray[7], out entero))
                    Cliente = entero;
                else
                    throw new Exception("Cliente tiene que ser un número");
            }
            else
            {
                throw new Exception("Todos los valores requeridos[id,monto,tasa,nombre,cuota,fechaInicio,estado,saldoOperacion,cliente]");
            }

        }

        
    }
}
