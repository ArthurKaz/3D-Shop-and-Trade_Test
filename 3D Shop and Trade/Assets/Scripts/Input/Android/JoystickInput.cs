using System;
using UnityEngine;

public class JoystickInput : MovementInput
{
    [SerializeField] private Joystick _joystick;

    public override Vector3 GetMovementDirection() => InvertDirection(_joystick.Direction);

    private Vector3 InvertDirection(Vector2 direction2D) => new(direction2D.x, 0, direction2D.y);
}