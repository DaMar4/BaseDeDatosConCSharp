//using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    class mysql_bd
    {
        const string puente = "datasource=" + "localhost" + ";port=3306;username=root;password=root;database=tienda;";
        MySqlConnection conexion = new MySqlConnection(puente);
        public void conectar()
        {
            try
            {

                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                    Console.WriteLine("Conectado a la base de datos");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos");
            }
        }
        public void desconectar()
        {
            try
            {

                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    Console.WriteLine("Base de datos desconectada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Al desconectar con la base de datos");
            }
        }
        public void Registrar(int id,string nombre, int cantidad)
        {
            string query = "insert into bodega(id,nombre,cantidad) values('" + id + "','" + nombre + "','" + cantidad + "');";
            MySqlCommand agregar_registro = new MySqlCommand(query, conexion);
            //agregar_registro.CommandTimeout = 60;
            agregar_registro.ExecuteReader();
        }
        public void Consulta()
        {
            string query = "select * from bodega";
            MySqlCommand consulta = new MySqlCommand(query, conexion);
            MySqlDataReader reader;
            reader = consulta.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] lista = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
                    foreach (string resultado in lista)
                    {
                        Console.WriteLine(lista[0]+ " "+ lista[1]+" "+ lista[2]);
                        break;
                    }
                }
            }
        }
    }
}
