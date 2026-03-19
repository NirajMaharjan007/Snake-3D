using Godot;

namespace Snake3D.Scene.Game.Script;

public partial class Main : Node3D
{
    Camera3D camera;

    CharacterBody3D snake;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();

        camera = GetNode<Camera3D>("Camera3D");
        snake = GetNode<CharacterBody3D>("Snake");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        base._Process(delta);

        GD.Print($"Snake {snake.GlobalPosition}");
        OutOfBound();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public override void _ExitTree() { }

    private void OutOfBound()
    {
        float x = snake.GlobalPosition.X;
        float y = snake.GlobalPosition.Y;
        float z = snake.GlobalPosition.Z;

        if (x <= -18)
            x = 18;
        else if (x >= 18)
            x = -18;

        if (z >= 14)
            z = -14;
        else if (z <= -14)
            z = 14;

        snake.GlobalPosition = new(x, y, z);
    }
}
