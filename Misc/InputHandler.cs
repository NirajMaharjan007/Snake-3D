using Godot;

namespace Snake3D.Misc;

public partial class InputHandler : InputEventAction
{
    public Direction Order { get; set; } = Direction.DOWN;

    private InputHandler() { }
}
