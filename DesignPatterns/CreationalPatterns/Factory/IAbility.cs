namespace DesignPatterns.Factory
{
    public interface IAbility
    {
        public string Name { get; }
        public void Perform();
    }
}