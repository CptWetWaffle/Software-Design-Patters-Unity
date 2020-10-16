using System.Collections.Generic;

namespace DesignPatterns.Factory
{
    public interface ISimpleFactory<out T>
    {
        public IEnumerable<string> Descriptors { get; }
        public T Get(string descriptor);
    }
}