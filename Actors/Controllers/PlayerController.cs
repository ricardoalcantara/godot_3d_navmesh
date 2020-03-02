using Godot;
using System;

public class PlayerController : Node
{
    Actor ActorOwner { get { return GetParent() as Actor; }}
    public override void _Ready()
    {
    }

    public override void _PhysicsProcess(float delta)
    {
        var move_vector = new Vector3();
        if (Input.IsActionPressed("move_forward")) move_vector.z -= 1;
        if (Input.IsActionPressed("move_back")) move_vector.z += 1;
        if (Input.IsActionPressed("move_left")) move_vector.x -= 1;
        if (Input.IsActionPressed("move_right")) move_vector.x += 1;

        ActorOwner.Move(move_vector.Normalized(), delta);
    }
}
