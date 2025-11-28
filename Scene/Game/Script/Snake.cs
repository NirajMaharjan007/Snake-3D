using Godot;
using Snake3D.Misc;

namespace Snake3D.Scene.Game.Script;

public partial class Snake : Node3D
{
    [Export]
    public int SPEED = 1;

    private InputHandler handler = InputHandler.Instance;

    private char direction = 'd';

    public override void _Ready()
    {
        base._Ready();

        AddChild(handler);

        switch (direction)
        {
            case 'u':
                handler.CurrentDirection = Direction.UP;
                break;

            case 'd':
                handler.CurrentDirection = Direction.DOWN;
                break;

            case 'l':
                handler.CurrentDirection = Direction.LEFT;
                break;

            case 'r':
                handler.CurrentDirection = Direction.RIGHT;
                break;
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        var position = Position;

        if (handler.CurrentDirection.Equals(Direction.UP))
        {
            position += Transform.Basis.Z * -SPEED * (float)delta;
        }
        else if (handler.CurrentDirection.Equals(Direction.DOWN))
        {
            position += Transform.Basis.Z * SPEED * (float)delta;
        }

        Position = position;

        // Position += Transform.Basis.Z * 1.0f * (float)delta;

        GD.Print($"{Position} and {handler.CurrentDirection}");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
