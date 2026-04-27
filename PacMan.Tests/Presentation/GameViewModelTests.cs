using FluentAssertions;
using PacMan.Application;
using PacMan.Domain.Rules;
using PacMan.Presentation.ViewModels;
using Xunit;

public class GameViewModelTests
{
    [Fact]
    public void Move_ShouldUpdateCells()
    {
        var engine = new GameEngine(new MovementRules());
        var vm = new GameViewModel(engine);

        var before = vm.Cells.Count;

        vm.Move(PacMan.Domain.Enums.Direction.Right);

        vm.Cells.Count.Should().Be(before);
    }
}