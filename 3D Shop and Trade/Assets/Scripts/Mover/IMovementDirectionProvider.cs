using UnityEngine;

namespace Mover
{
    public interface IMovementDirectionProvider
    {
        public Vector3 GetMovementDirection();
    }
}