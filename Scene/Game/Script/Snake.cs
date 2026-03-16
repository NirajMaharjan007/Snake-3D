using Godot;
using Snake3D.Misc;

namespace Snake3D.Scene.Game.Script;

public partial class Snake : CharacterBody3D
{
    [Export]
    public int SPEED = 1;

    private InputHandler handler = InputHandler.Instance;

    private Direction direction = Direction.DOWN;

    private char directionSwitch = 'd';

    public override void _Ready()
    {
        base._Ready();
        AddChild(handler);
    }

    private void DirectionHandler()
    {
        directionSwitch = handler.CurrentDirection switch
        {
            Direction.DOWN => 'd',
            Direction.UP => 'u',
            Direction.RIGHT => 'r',
            Direction.LEFT => 'l',
            _ => 'd',
        };
    }

    private void UpdateDirection(double delta)
    {
        var position = Position;

        /*  if (handler.CurrentDirection.Equals(Direction.UP))
         {
             position += Transform.Basis.Z * -SPEED * (float)delta;
         }
         else if (handler.CurrentDirection.Equals(Direction.DOWN))
         {
             position += Transform.Basis.Z * SPEED * (float)delta;
         }
         else if (handler.CurrentDirection.Equals(Direction.LEFT))
         {
             position += Transform.Basis.X * -SPEED * (float)delta;
         }
         else if (handler.CurrentDirection.Equals(Direction.RIGHT))
         {
             position += Transform.Basis.X * SPEED * (float)delta;
         } */

        switch (directionSwitch)
        {
            case 'u':
                if (directionSwitch != 'd')
                    position += Transform.Basis.Z * -SPEED * (float)delta;
                break;

            case 'd':
                if (directionSwitch != 'u')
                    position += Transform.Basis.Z * SPEED * (float)delta;
                break;
        }

        Position = position;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        DirectionHandler();
        UpdateDirection(delta);

        MoveAndSlide();

        // Position += Transform.Basis.Z * 1.0f * (float)delta;

        GD.Print($"{Position} and {handler.CurrentDirection} and {directionSwitch}");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
