using Godot;
using System;

public class AIController : Node
{
    Actor ActorOwner { get { return GetParent() as Actor; } }

    Actor _player;
    Navigation _navigation;
    Vector3[] path = new Vector3[0];
    int path_index;
    public override void _Ready()
    {
        _player = GetNode("/root/Game").FindNode("YellowActor") as Actor;
        _navigation = GetNode<Navigation>("/root/Game/Navigation");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (path_index < path.Length)
        {
            var move_vector = path[path_index] - ActorOwner.GlobalTransform.origin;

            if (move_vector.Length() < 0.1)
            {
                path_index++;
            }
            else
            {
                ActorOwner.Move(move_vector.Normalized(), delta);
            }
        }

    }

    private void MoveToPlayer()
    {
        path = _navigation.GetSimplePath(ActorOwner.GlobalTransform.origin, _player.GlobalTransform.origin);
        path_index = 0;
    }

    public void OnTimer_timeout()
    {
        MoveToPlayer();
    }
}
