# Pac-Man (WPF, Clean Architecture)

A simple Pac-Man implementation built in **C# / .NET (WPF)** using a clean, layered architecture.

The purpose of this project is to demonstrate:
- Separation of concerns
- Testable domain logic
- Simple and maintainable design (KISS, SOLID)

---

## Features

- Grid-based Pac-Man movement
- Arrow key controls
- Direction-based rotation of Pac-Man
- Screen wrapping (Pac-Man exits one side and appears on the other)
- Transparent sprite rendering

---

## Architecture

The solution is divided into clear layers:
PacMan
│
├── PacMan.Domain # Core business logic
├── PacMan.Application # Use cases
├── PacMan.Presentation # WPF UI (MVVM)
├── PacMan.Tests # Unit tests


### Domain Layer
Contains all core logic:
- `Game`, `Grid`, `Pacman`, `Tile`
- `Position` (value object)
- `MovementRules` (game logic)
No dependencies on UI or frameworks.

### Application Layer
- `GameEngine` orchestrates game ticks
- Delegates behavior to domain rules

### Presentation Layer (WPF)
- MVVM-based structure
- `GameViewModel` handles state updates
- `MainWindow.xaml` renders the grid
- Uses `ItemsControl + UniformGrid`
No business logic here.

### Test Layer

- xUnit + FluentAssertions
- Covers:
  - Movement rules
  - Grid behavior (wrap, eat dot)
  - Game state transitions
  - Engine behavior

## Controls

| Key | Action |
|-----|--------|
| ↑ | Move up |
| ↓ | Move down |
| ← | Move left |
| → | Move right |

Movement is **input-driven**

## Graphics

- Pac-Man uses a PNG with transparent background
- Rotation is handled via `RotateTransform`
- Rendering uses WPF DataTemplates

## Running Tests

Install required packages:
xunit
xunit.runner.visualstudio
FluentAssertions
Microsoft.NET.Test.Sdk


Run tests via:
- Visual Studio Test Explorer
- `dotnet test`

## Build & Run

Requirements:
- .NET 10 (or compatible)
- Windows (WPF)

Run:
dotnet build
dotnet run --project PacMan.Presentation


## Design Decisions

- Movement is deterministic and testable
- Immutable domain objects → easier reasoning & testing
- Clean architecture → UI is decoupled from logic


## Summary

This project focuses on **clarity over complexity**:

Simple code. Clear responsibilities. Easy to test.
