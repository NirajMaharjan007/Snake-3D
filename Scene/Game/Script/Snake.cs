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

        // snake = GetNode<Node3D>("Snake");
        // snakeHead = snake.GetNode<MeshInstance3D>("Snake Head");
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
        var velocity = Velocity;

        if (!IsOnFloor())
            velocity.Y -= 9.8f * (float)delta;

        if (handler.CurrentDirection.Equals(Direction.DOWN))
        {
            velocity = Transform.Basis.Z * SPEED * (float)delta;
        }
        else if (handler.CurrentDirection.Equals(Direction.UP))
        {
            velocity = -Transform.Basis.Z * SPEED * (float)delta;
        }
        else if (handler.CurrentDirection.Equals(Direction.LEFT))
        {
            velocity = -Transform.Basis.X * SPEED * (float)delta;
        }
        else if (handler.CurrentDirection.Equals(Direction.RIGHT))
        {
            velocity = Transform.Basis.X * SPEED * (float)delta;
        }

        Velocity = velocity;
        MoveAndSlide();

        GD.Print($"{Position} and {handler.CurrentDirection} and {directionSwitch} SPEED {SPEED}");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        DirectionHandler();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        UpdateDirection(delta);
    }
}
