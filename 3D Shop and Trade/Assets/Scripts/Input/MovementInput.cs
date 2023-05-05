using Mover;
using UnityEngine;

public abstract class MovementInput : MonoBehaviour, IMovementDirectionProvider
{
    [SerializeField] private EntityMovement _entityMovement;

    private void Awake()
    {
        _entityMovement.SetDirection(this);
    }

    public abstract Vector3 GetMovementDirection();
}