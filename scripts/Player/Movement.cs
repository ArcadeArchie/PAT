using Godot;
using System;

public partial class Movement : CharacterBody3D
{
    private Vector3 _targetVelocity = Vector3.Zero;

    [Export]
    public int Speed { get; set; } = 14;

    [Export]
    public int FallingSpeed { get; set; } = 75;

    public override void _PhysicsProcess(double delta)
    {
        var direction = Vector3.Zero;
        if (Input.IsActionPressed("move_right"))
            direction.X += 1.0f;
        if (Input.IsActionPressed("move_left"))
            direction.X -= 1.0f;
        if (Input.IsActionPressed("move_forward"))
            direction.Z += 1.0f;
        if (Input.IsActionPressed("move_back"))
            direction.Z -= 1.0f;
            

        if (direction != Vector3.Zero)
        {
            direction = direction.Normalized();
            GetNode<Node3D>("Pivot").LookAt(Position + direction, Vector3.Up);
        }

        _targetVelocity.X = direction.X * Speed;
        _targetVelocity.Z = direction.Z * Speed;
        if (!IsOnFloor())
            _targetVelocity.Y -= FallingSpeed * (float)delta;
        Velocity = _targetVelocity;
        MoveAndSlide();
    }
}
