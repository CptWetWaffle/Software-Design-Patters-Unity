using UnityEngine;

namespace DesignPatterns
{
    public class MouseMoveCommand : Command
    {
        private readonly Vector3 _destination;
        private Vector3 _previousPosition;

        public MouseMoveCommand(IEntity entity, Vector3 destination) : base(entity)
        {
            _destination = destination;
        }

        public override void Execute()
        {
            _previousPosition = Entity.Transform.position;
            Entity.MoveFromTo(_previousPosition, _destination);
        }

        public override void Undo()
        {
            _previousPosition = _destination;
            Entity.MoveFromTo(_destination, _previousPosition);
        }
    }
}