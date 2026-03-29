using Godot;
using Snake3D.Misc;

namespace Snake3D.Scene.Game.Script;

public partial class Snake : CharacterBody3D
{
    public const int SPEED = 64;

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

        Vector3 velocity = Velocity;

        if (!IsOnFloor())
            velocity.Y -= 9.8f * (float)delta;

        if (directionSwitch.Equals('u'))
            velocity = -Transform.Basis.Z * SPEED * (float)delta;
        else if (directionSwitch.Equals('d'))
            velocity = Transform.Basis.Z * SPEED * (float)delta;
        else if (directionSwitch.Equals('l'))
            velocity = -Transform.Basis.X * SPEED * (float)delta;
        else if (directionSwitch.Equals('r'))
            velocity = Transform.Basis.X * SPEED * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        DirectionHandler();
        UpdateDirection(delta);

        MoveAndSlide();
        // Position += Transform.Basis.Z * 1.0f * (float)delta;

        GD.Print($"{Position} and {handler.CurrentDirection} and {directionSwitch} SPEED {SPEED}");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
