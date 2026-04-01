using Godot;
using Snake3D.Misc;

namespace Snake3D.Scene.Game.Script;

public partial class Snake : Node3D
{
    public const int SPEED = 64;

    private InputHandler handler = InputHandler.Instance;

    private Direction direction = Direction.DOWN;

    private char directionSwitch = 'd';

    private MeshInstance3D snakeHead;

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

    private void UpdateDirection(double delta) { }

    public override void _Process(double delta)
    {
        base._Process(delta);
        DirectionHandler();

        GD.Print($"{Position} and {handler.CurrentDirection} and {directionSwitch} SPEED {SPEED}");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        UpdateDirection(delta);
        GD.PrintRich($"[b]snake-head {snakeHead}[/b]");
    }
}
