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

        Vector3 movement = Vector3.Zero;

        if (directionSwitch.Equals('u'))
            movement = -Transform.Basis.Z;
        else if (directionSwitch.Equals('d'))
            movement = Transform.Basis.Z;
        else if (directionSwitch.Equals('l'))
            movement = -Transform.Basis.X;
        else if (directionSwitch.Equals('r'))
            movement = Transform.Basis.X;

        Position += movement * SPEED * (float)delta;
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
