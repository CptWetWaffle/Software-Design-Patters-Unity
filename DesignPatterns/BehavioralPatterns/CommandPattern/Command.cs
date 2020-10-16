namespace DesignPatterns
{
    public abstract class Command
    {
        protected IEntity Entity{ get; }

        protected Command(IEntity entity)
        {
            Entity = entity;
        }
        
        public abstract void Execute();
        public abstract void Undo();
    }
}