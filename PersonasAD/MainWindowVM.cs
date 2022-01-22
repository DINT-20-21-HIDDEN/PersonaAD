using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PersonasAD
{
    public enum Modo
    {
        Insertar, Actualizar
    }

    public class MainWindowVM : INotifyPropertyChanged
    {
        public Persona PersonaSeleccionada { get; set; }
        public Persona PersonaFormulario { get; set; }
        public ObservableCollection<Persona> ListaPersonas { get; set; }
        public Modo Accion { get; set; }

        private readonly BaseDatosService _bbdd;
        private readonly ApiRestService _api;

        public MainWindowVM()
        {
            _bbdd = new BaseDatosService();
            _api = new ApiRestService();
            ListaPersonas = _bbdd.ObtenerPersonas();
            PersonaFormulario = new Persona();
            Accion = Modo.Insertar;
        }

        public void AñadirPersona()
        {
            PersonaFormulario = new Persona();
            Accion = Modo.Insertar;
        }

        public void EditarPersona()
        {
            PersonaFormulario = new Persona(PersonaSeleccionada);
            Accion = Modo.Actualizar;
        }

        public bool HayPersonaSeleccionada()
        {
            return PersonaSeleccionada != null;
        }

        public void EliminarPersona()
        {
            _bbdd.Delete(PersonaSeleccionada);
            ListaPersonas = _bbdd.ObtenerPersonas();
        }

        public bool FormularioOk()
        {
            return (PersonaFormulario.Nombre != "" && PersonaFormulario.Edad != null && PersonaFormulario.Edad > 0);
        }

        public string ConsultarGenero()
        {
            return _api.ObtenerGenero(PersonaSeleccionada.Nombre);
        }

        public void GuardarCambios()
        {
            if (Accion == Modo.Insertar)
            {
                _bbdd.Insertar(PersonaFormulario);
                PersonaFormulario = new Persona();
            }
            else
                _bbdd.Actualizar(PersonaFormulario);

            ListaPersonas = _bbdd.ObtenerPersonas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
