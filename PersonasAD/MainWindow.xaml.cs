using System.Windows;
using System.Windows.Input;

namespace PersonasAD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowVM _vm;
        public MainWindow()
        {
            _vm = new MainWindowVM();
            InitializeComponent();
            DataContext = _vm;
        }

        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AñadirPersona();
        }

        private void CommandBinding_Executed_Edit(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.EditarPersona();
        }

        private void CommandBinding_CanExecute_Edit(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HayPersonaSeleccionada();
        }

        private void CommandBinding_Executed_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.EliminarPersona();
        }

        private void CommandBinding_CanExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HayPersonaSeleccionada();
        }

        private void CommandBinding_Executed_Gender(object sender, ExecutedRoutedEventArgs e)
        {
            string genero = _vm.ConsultarGenero();
            MessageBox.Show($"El género estimado de la persona es: {genero}", "Consulta de género", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CommandBinding_CanExecute_Gender(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HayPersonaSeleccionada();
        }
        private void CommandBinding_Executed_Save(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.GuardarCambios();
        }

        private void CommandBinding_CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.FormularioOk();
        }


    }
}
