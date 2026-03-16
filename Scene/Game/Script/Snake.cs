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
        // Only change direction if the new direction is not opposite of current
        switch (handler.CurrentDirection)
        {
            case Direction.DOWN when directionSwitch != 'u':
                directionSwitch = 'd';
                break;
            case Direction.UP when directionSwitch != 'd':
                directionSwitch = 'u';
                break;
            case Direction.LEFT when directionSwitch != 'r':
                directionSwitch = 'l';
                break;
            case Direction.RIGHT when directionSwitch != 'l':
                directionSwitch = 'r';
                break;
            // Default - keep current directionSwitch value
        }
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

        // Assuming you have a CurrentDirection property
        if (directionSwitch.Equals('u'))
        {
            position += Transform.Basis.Z * -SPEED * (float)delta;
        }
        else if (directionSwitch.Equals('d'))
        {
            position += Transform.Basis.Z * SPEED * (float)delta;
        }
        else if (directionSwitch.Equals('l'))
        {
            position += Transform.Basis.X * -SPEED * (float)delta;
        }
        else if (directionSwitch.Equals('r'))
        {
            position += Transform.Basis.X * SPEED * (float)delta;
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
