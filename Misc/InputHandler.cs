using System;
using Godot;

namespace Snake3D.Misc;

public partial class InputHandler : Node
{
    [Signal]
    public delegate void DirectionChangedEventHandler(Direction newDirection);

    private static readonly Lazy<InputHandler> lazyInstance = new Lazy<InputHandler>(() => new());

    public Direction CurrentDirection { get; set; } = Direction.DOWN;

    private InputHandler() { }

    public override void _Ready() { }

    public override void _Process(double delta)
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Handle directional input
        var oldDirection = CurrentDirection;

        if (Input.IsActionPressed("ui_up"))
            CurrentDirection = Direction.UP;
        else if (Input.IsActionPressed("ui_down"))
            CurrentDirection = Direction.DOWN;
        else if (Input.IsActionPressed("ui_left"))
            CurrentDirection = Direction.LEFT;
        else if (Input.IsActionPressed("ui_right"))
            CurrentDirection = Direction.RIGHT;

        // Emit signal if direction changed
        if (oldDirection != CurrentDirection)
        {
            EmitSignal(SignalName.DirectionChanged);
        }
    }

    // Public methods to check input state
    public bool IsDirectionPressed(Direction direction)
    {
        return CurrentDirection == direction;
    }

    public Vector2 GetDirectionVector()
    {
        return CurrentDirection switch
        {
            Direction.UP => Vector2.Up,
            Direction.DOWN => Vector2.Down,
            Direction.LEFT => Vector2.Left,
            Direction.RIGHT => Vector2.Right,
            _ => Vector2.Zero,
        };
    }

    public static InputHandler Instance => lazyInstance.Value;
}
