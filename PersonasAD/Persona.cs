using System.ComponentModel;

namespace PersonasAD
{
    public class Persona : INotifyPropertyChanged
    {
        public string Nombre { get; set; }
        public int? Edad { get; set; }

        public Persona()
        {
            Nombre = "";
            Edad = null;
        }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        public Persona(Persona origen)
        {
            Nombre = origen.Nombre;
            Edad = origen.Edad;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
