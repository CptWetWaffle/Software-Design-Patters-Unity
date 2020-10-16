using UnityEngine;

namespace DesignPatterns
{
    public class MoveCommand : Command
    {
        private readonly Vector3 _direction;
        
        public MoveCommand(IEntity entity, Vector3 direction) : base(entity)
        {
            _direction = direction;
        }

        public override void Execute()
        {
            Entity.Transform.position += _direction * 0.1f;
        }

        public override void Undo()
        {
            Entity.Transform.position -= _direction * 0.1f;
        }
    }
}