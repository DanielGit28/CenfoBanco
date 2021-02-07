using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class Credito
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
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Credito = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                Monto = float.Parse(infoArray[1]);
                Tasa = float.Parse(infoArray[2]);
                Nombre = infoArray[3];
                Cuota = float.Parse(infoArray[4]);
                FechaInicio = DateTime.Parse(infoArray[5]);
                Estado = infoArray[6];
                SaldoOperacion = float.Parse(infoArray[7]);
                if (Int32.TryParse(infoArray[8], out entero))
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
