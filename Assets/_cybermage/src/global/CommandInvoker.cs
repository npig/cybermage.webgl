using System.Collections.Generic;

namespace Cybermage
{
    public interface ICommand
    {
        void Load();
        void Unload();
    }
    
    public static class CommandInvoker
    {
        private static Queue<ICommand> _commandBuffer = new Queue<ICommand>();
        private static List<ICommand> _commandHistory = new List<ICommand>();
        private static int _index = 0;
        
        public static void Update()
        {
            if (_commandBuffer.Count > 0)
            {
                ICommand c = _commandBuffer.Dequeue();
                _commandHistory.Add(c);
                c.Load();
                _index++;
            }
        }

        public static void AddCommand(ICommand command)
        {
            while (_commandHistory.Count > _index)
            {
                _commandHistory.RemoveAt(_index);
            }

            _commandBuffer.Enqueue((command));
        }

        public static void Unload()
        {
            if (_index > 0)
            {
                _index--;
                _commandHistory[_index].Unload();
            }
        }

        public static void Reload()
        {
            if (_index < _commandHistory.Count)
            {
                ICommand c = _commandHistory[_index];
                c.Load();
                _index++;
            }
        }
    }
}