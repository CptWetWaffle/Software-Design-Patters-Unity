using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class CommandProcessor: MonoBehaviour, ICommandProcessor
    {
        public List<Command> Commands { get; set; }
        public int CommandIndex { get; set; }

        public CommandProcessor()
        {
            Commands = new List<Command>();
            CommandIndex = 0;
        }
        
        public void ExecuteCommand(Command command)
        {
            Commands.Add(command);
            command.Execute();
            CommandIndex = Commands.Count - 1;
        }

        public void Undo()
        {
            if (CommandIndex < 0) return;
            
            Commands[CommandIndex].Undo();
            Commands.RemoveAt(CommandIndex);
            CommandIndex--;
        }

        public void Redo()
        {
            Commands[CommandIndex].Execute();
            CommandIndex++;
        }
    }
}