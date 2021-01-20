using System.Windows.Input;

namespace PersonasAD
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Add = new RoutedUICommand(
                "Add", "Add", typeof(CustomCommands),
                new InputGestureCollection { new KeyGesture(Key.A, ModifierKeys.Control) });

        public static readonly RoutedUICommand Edit = new RoutedUICommand(
            "Edit", "Edit", typeof(CustomCommands),
            new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Control) });

        public static readonly RoutedUICommand Delete = new RoutedUICommand(
            "Delete", "Delete", typeof(CustomCommands),
            new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Control) });

        public static readonly RoutedUICommand Save = new RoutedUICommand(
            "Save", "Save", typeof(CustomCommands),
            new InputGestureCollection { new KeyGesture(Key.E, ModifierKeys.Control) });

        public static readonly RoutedUICommand Gender = new RoutedUICommand(
            "Gender", "Gender", typeof(CustomCommands),
            new InputGestureCollection { new KeyGesture(Key.G, ModifierKeys.Control) });

    }
}
