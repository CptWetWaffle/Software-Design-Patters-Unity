using System.Collections.Generic;

namespace DesignPatterns
{
    public interface ICommandProcessor
    {
        List<Command> Commands { get; set; }
        int CommandIndex { get; set; }

        void ExecuteCommand(Command command);
        void Undo();
        void Redo();
    }
}