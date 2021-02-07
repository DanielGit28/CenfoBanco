using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        public int Direccion { get; set; }

        public Cliente()
        {

        }

        public Cliente(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 8)
            {
                var entero = 0;
                if (Int32.TryParse(infoArray[0], out entero))
                    Id_Cliente = entero;
                else
                    throw new Exception("Id tiene que ser un número");
                Cedula = infoArray[1];
                Nombre = infoArray[2];
                Apellido = infoArray[3];
                FechaNac = DateTime.Parse(infoArray[4]);
                if (Int32.TryParse(infoArray[5], out entero))
                    Edad = entero;
                else
                    throw new Exception("Edad tiene que ser un número");
                EstadoCivil = infoArray[6];
                Genero = infoArray[7];
                if (Int32.TryParse(infoArray[8], out entero))
                    Direccion = entero;
                else
                    throw new Exception("Direccion tiene que ser un número");
            }
            else
            {
                throw new Exception("Todos los valores requeridos[id,cedula,nombre,apellido.fechaNac,edad,estadoCivil,genero,direccion]");
            }

        }
    }
}
