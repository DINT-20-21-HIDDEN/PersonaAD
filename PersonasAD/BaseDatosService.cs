using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace PersonasAD
{
    //Prueba
    public class BaseDatosService
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;
        public BaseDatosService()
        {
            _conexion = new SqliteConnection("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "personas.db"));
            CrearTablas();
            InsertarDatos();
        }

        private void InsertarDatos()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM personas";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Ana',30)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Pedro',25)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Clara',28)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO personas VALUES ('Juan',19)";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        private void CrearTablas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS personas (
                                    nombre varchar(100) primary key, 
                                    edad integer)";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public ObservableCollection<Persona> ObtenerPersonas()
        {
            ObservableCollection<Persona> resultado = new ObservableCollection<Persona>();

            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM personas";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string nombre = lector.GetString(0);
                    int edad = lector.GetInt32(1);
                    resultado.Add(new Persona(nombre, edad));
                }
            }

            lector.Close();
            _conexion.Close();

            return resultado;

        }

        public void Delete(Persona personaSeleccionada)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM personas WHERE nombre=@nombre";
            _comando.Parameters.Add("@nombre", SqliteType.Text);
            _comando.Parameters["@nombre"].Value = personaSeleccionada.Nombre;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Insertar(Persona personaFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO personas VALUES (@nombre,@edad)";
            _comando.Parameters.Add("@nombre", SqliteType.Text);
            _comando.Parameters.Add("@edad", SqliteType.Integer);
            _comando.Parameters["@nombre"].Value = personaFormulario.Nombre;
            _comando.Parameters["@edad"].Value = personaFormulario.Edad;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void Actualizar(Persona personaFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE personas SET edad=@edad WHERE nombre=@nombre";
            _comando.Parameters.Add("@nombre", SqliteType.Text);
            _comando.Parameters.Add("@edad", SqliteType.Integer);
            _comando.Parameters["@nombre"].Value = personaFormulario.Nombre;
            _comando.Parameters["@edad"].Value = personaFormulario.Edad;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }
    }
}
