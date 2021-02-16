using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cliente : BaseEntity
    {
        public int Id_Cliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }

        public Cliente()
        {

        }

        public Cliente(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                var entero = 0;
                /*
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Cliente = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                */
                Cedula = infoArray[0];
                Nombre = infoArray[1];
                Apellido = infoArray[2];
                FechaNac = DateTime.Parse(infoArray[3]);
                if (Int32.TryParse(infoArray[4], out entero))
                    Edad = entero;
                else
                    throw new Exception("Edad tiene que ser un número");
                EstadoCivil = infoArray[5];
                Genero = infoArray[6];
            }
            else
            {
                throw new Exception("Todos los valores requeridos[id,cedula,nombre,apellido.fechaNac,edad,estadoCivil,genero]");
            }

        }

    }
}
