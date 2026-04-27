using System.Windows;
using PacMan.Application;
using PacMan.Domain.Rules;
using PacMan.Presentation.ViewModels;
using PacMan.Presentation.Views;

namespace PacMan.Presentation;

public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Domain
        var rules = new MovementRules();

        // Application
        var engine = new GameEngine(rules);

        // ViewModel
        var vm = new GameViewModel(engine);

        // View
        var window = new MainWindow
        {
            DataContext = vm
        };

        window.Show();
    }
}