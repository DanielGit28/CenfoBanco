using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cuenta : BaseEntity
    {
        public int Id_Cuenta { get; set; }
        public string Nombre { get; set; }
        public string Moneda { get; set; }
        public float Saldo { get; set; }
        public int Cliente { get; set; }

        public Cuenta()
        {

        }

        public Cuenta(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                
                var entero = 0;
                /*
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Cuenta = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                */
                Nombre = infoArray[0];
                Moneda = infoArray[1];
                Saldo = float.Parse(infoArray[2]);
                if (Int32.TryParse(infoArray[3], out entero))
                    Cliente = entero;
                else
                    throw new Exception("Cliente tiene que ser un número");
            }
            else
            {
                throw new Exception("Todos los valores requeridos[id,nombre,moneda,saldo,cliente]");
            }

        }

    }
}
