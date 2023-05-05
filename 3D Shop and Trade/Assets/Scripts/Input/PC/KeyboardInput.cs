using UnityEngine;

public class KeyboardInput : MovementInput
{
    [SerializeField] private KeyCode moveForward = KeyCode.W;
    [SerializeField] private KeyCode moveBack = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode moveRight = KeyCode.D;

    private Vector3 _direction = Vector3.zero;

    private void Update()
    {
        HandleYDown();
        HandleXDown();

    }

    private void HandleYDown()
    {
        if (Input.GetKeyDown(moveForward))
        {
            _direction.z = 1;
        }

        if (Input.GetKeyDown(moveBack))
        {
            _direction.z = -1;
        }

        if (Input.GetKeyUp(moveBack) || Input.GetKeyUp(moveForward))
        {
            _direction.z = 0;
        }
    }

    private void HandleXDown()
    {
        if (Input.GetKeyDown(moveRight))
        {
            _direction.x = 1;
        }

        if (Input.GetKeyDown(moveLeft))
        {
            _direction.x = -1;
        }

        if (Input.GetKeyUp(moveRight) || Input.GetKeyUp(moveLeft))
        {
            _direction.x = 0;
        }
    }

    public override Vector3 GetMovementDirection()
    {
        return _direction;
    }
}