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

        public int Cliente { get; set; }

        public Direccion()
        {

        }

        public Direccion(string[] infoArray)
        {
            /*
            if (infoArray == null) 
            {
                Console.WriteLine("Array nulo");
            }
            else if (infoArray != null)
            {
                Console.WriteLine("Array con info");
            }
            Console.WriteLine(infoArray.Length);
            Console.WriteLine(infoArray.ToString());
            */

            //Array.ForEach(infoArray, Console.WriteLine);

            if (infoArray != null && infoArray.Length >= 3)
            {
                /*
                var entero = 0;
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Direccion = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                */
                Provincia = infoArray[0];
                Canton = infoArray[1];
                Distrito = infoArray[2];
                var entero = 0;
                if (Int32.TryParse(infoArray[3], out entero))
                    Cliente = entero;
                else
                    throw new Exception("Id tiene que ser un número");
            }
            else
            {
                throw new Exception("Todos los valores requeridos[provincia,canton,distrito,cliente]");
            }

        }

    }
}
