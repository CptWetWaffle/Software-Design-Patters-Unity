using UnityEngine;

namespace DesignPatterns
{
    public class ScaleCommand : Command
    {
        private readonly float _scaleFactor;
        
        public ScaleCommand(IEntity entity, float scaleFactor) : base(entity)
        {
            _scaleFactor = scaleFactor == 1f ? 1.1f : 0.9f;
        }

        public override void Execute()
        {
            Entity.Transform.localScale *= _scaleFactor;
        }

        public override void Undo()
        {
            Entity.Transform.localScale /= _scaleFactor;
        }
    }
}