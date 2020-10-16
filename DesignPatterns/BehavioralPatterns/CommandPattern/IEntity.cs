using UnityEngine;

namespace DesignPatterns
{
    public interface IEntity
    {
        public Transform Transform { get; }
        public void MoveFromTo(Vector3 startPosition, Vector3 endPosition);
    }
}