using Godot;
using System;

public partial class User : CharacterBody3D
{
    [Export] private float _sensitivity = 0.004f;
    [Export] private float _speed = 3f;
    private bool _mouseCaptured;
    private float _yaw;
    private float _pitch;
    private Quaternion _orientation = Quaternion.Identity;
    public override void _Ready()
    {
        var rot = Rotation;
        _yaw = rot.Y;
        _pitch = rot.X;
        CaptureMouse();
    }
    public void CaptureMouse()
    {
        var input = Input.Singleton;
        input.MouseMode = Input.MouseModeEnum.Captured;
        _mouseCaptured = true;
    }
    public override void _Input(InputEvent e)
    {
        if(e is InputEventMouseMotion mouse && _mouseCaptured)
        {
            _yaw -= mouse.Relative.X * _sensitivity;
            _pitch -= mouse.Relative.Y * _sensitivity;
            _pitch = (float) Math.Clamp(_pitch, -Math.PI / 2, Math.PI / 2);
            var qYaw = new Quaternion(Vector3.Up, _yaw);
            var qPitch =  new Quaternion(Vector3.Right, _pitch);
            _orientation = (qYaw * qPitch).Normalized();
            Rotation = _orientation.GetEuler();
        }
        if(e is InputEventKey key && key.Pressed && key.Keycode == Key.Escape)
        {
            var input = Input.Singleton;
            input.MouseMode = Input.MouseModeEnum.Visible;
            _mouseCaptured = false;
        }
    }
    public override void _PhysicsProcess(double delta)
    {
        var input = Input.Singleton;
        var v = Vector3.Zero;
        if(input.IsActionPressed("user_forward"))
        {
            v.Z -= 1;
        }
        if(input.IsActionPressed("user_backward"))
        {
            v.Z += 1;
        }
        if(input.IsActionPressed("user_left"))
        {
            v.X -= 1;
        }
        if(input.IsActionPressed("user_right"))
        {
            v.X += 1;
        }
        if(input.IsActionPressed("user_up"))
        {
            v.Y += 1;
        }
        if(input.IsActionPressed("user_down"))
        {
            v.Y -= 1;
        }
        Velocity = Velocity.Lerp(_orientation * v.Normalized() * _speed, 5f * (float) delta);
        MoveAndSlide();
    }
}
