using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Direccion : BaseEntity
    {
        public int Id_Direccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }


        public Direccion()
        {

        }

        public Direccion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 8)
            {
                var entero = 0;
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Direccion = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                Provincia = infoArray[1];
                Canton = infoArray[2];
                Distrito = infoArray[3];
            }
            else
            {
                throw new Exception("Todos los valores requeridos[id,provincia,canton,distrito]");
            }

        }

    }
}
