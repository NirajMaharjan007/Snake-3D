using Godot;

namespace Snake3D.Scene.Game.Script;

public partial class Main : Node3D
{
    Camera3D camera;

    Node3D snake;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();

        camera = GetNode<Camera3D>("Camera3D");
        snake = GetNode<Node3D>("Snake");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        base._Process(delta);

        GD.Print($"Snake {snake.GlobalPosition}");
        // OutOfBound();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public override void _ExitTree() { }

    private void OutOfBound()
    {
        var min_limit = new Vector3(-10, 5, -10);
        var max_limit = new Vector3(10, 20, 10);

        float x = Mathf.Clamp(GlobalPosition.X, min_limit.X, max_limit.X);
        float y = Mathf.Clamp(GlobalPosition.Y, min_limit.Y, max_limit.Y);
        float z = Mathf.Clamp(GlobalPosition.Z, min_limit.Z, max_limit.Z);

        snake.GlobalPosition = new(x, y, z);
    }
}
