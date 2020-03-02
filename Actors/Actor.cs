using Godot;
using System;

public class Actor : KinematicBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void Move(Vector3 move_vector, float delta)
    {
        if (move_vector.Length() == 0) return;

        MoveAndSlide(move_vector * 10);
        var angle = new Vector3(0, Mathf.LerpAngle(GetNode<Spatial>("Body").Rotation.y, new Vector2(move_vector.z, move_vector.x).Angle(), 10 * delta), 0);

        GetNode<Spatial>("Body").Rotation = angle;
        // GetNode<Spatial>("Body").LookAt(GetNode<Spatial>("Body").GlobalTransform.origin + move_vector, Vector3.Up);
    }
}
