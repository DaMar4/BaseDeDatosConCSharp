using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            mysql_bd x = new mysql_bd();
            x.conectar();
            x.Consulta();
            Console.WriteLine("=========================================================");

            x.desconectar();
        }
    }
}
