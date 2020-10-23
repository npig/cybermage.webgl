using System.Collections.Generic;
using System.Linq;
using Lithodomos.Events;
using UnityEngine;

namespace Lithodomos.Command
{
    public interface ICommand
    {
        string Id { get; set; }
        void Load();
        void Unload();
    }

    public class SystemCommandEvent : IEvent
    {
        public ICommand Command { get; }

        public SystemCommandEvent(ICommand command)
        {
            Command = command;
        }
    }

    public static class CommandInvoker
    {
        private static Queue<ICommand> _commandBuffer;
        private static List<ICommand> _commandHistory;
        private static int _index;
        public static int GetIndex => _index;

        public static void Initialise()
        {
            _commandBuffer = new Queue<ICommand>();
            _commandHistory = new List<ICommand>();
            _index = 0;
        }

        public static void UpdateInvoker()
        {
            if (_commandBuffer.Count > 0)
            {
                ICommand c = _commandBuffer.Dequeue();
                _commandHistory.Add(c);
                EventManager.Instance.Raise(new SystemCommandEvent(c));
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
                EventManager.Instance.Raise(new SystemCommandEvent(c));
                c.Load();

                _index++;
            }
        }

        //Additional Command History interactions 
        public static void BackCommand()
        {
            Unload();

            if (_index > 0)
            {
                _index--;
            }

            Reload();
        }

        public static void LoadCommandByIndex(int index)
        {
            if (_index > 0)
            {
                _index = index - 1;
            }

            Reload();
        }
        
        public static ICommand GetCommand(string id)
        {
            return _commandHistory.Find(x => x.Id == id);
        }
        
        public static bool ContainsCommand(string id)
        {
            return _commandHistory.Exists(x => x.Id == id);
        }

        public static List<ICommand> GetHistory()
        {
            return _commandHistory;
        }

        public static ICommand CurrentCommand()
        {
            return _commandHistory[_index - 1];
        }
    }
}