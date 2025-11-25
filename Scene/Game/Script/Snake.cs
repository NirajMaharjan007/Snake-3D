using Godot;

namespace Snake3D.Scene.Game.Script;

public partial class Snake : Node3D
{
    [Export]
    public int SPEED = 1;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        Position += Transform.Basis.Z * 1.0f * (float)delta;

        GD.Print(Position);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
