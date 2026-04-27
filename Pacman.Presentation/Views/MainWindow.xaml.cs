using System.Windows;
using System.Windows.Input;
using PacMan.Domain.Enums;
using PacMan.Presentation.ViewModels;

namespace PacMan.Presentation.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Loaded += (_, _) => Focus(); // ensure key events work
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (DataContext is not GameViewModel vm)
            return;

        switch (e.Key)
        {
            case Key.Up:
                vm.Move(Direction.Up);
                e.Handled = true;
                break;

            case Key.Down:
                vm.Move(Direction.Down);
                e.Handled = true;
                break;

            case Key.Left:
                vm.Move(Direction.Left);
                e.Handled = true;
                break;

            case Key.Right:
                vm.Move(Direction.Right);
                e.Handled = true;
                break;
        }
    }
}