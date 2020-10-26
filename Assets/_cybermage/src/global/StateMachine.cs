using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cybermage
{
    public abstract class State : ICommand
    {
        public string Id { get; private set; }
        
        protected State()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public abstract void Load();
        public abstract void Unload();
        public virtual void StateUpdate() {}
    }

    public static class StateMachine
    {
        private static readonly Queue<State> _stateQueue = new Queue<State>();
        
        public static void Update()
        {
            if (_stateQueue.Count > 0)
                _stateQueue.Peek().StateUpdate();
        }

        public static void QueueState(State state)
        {
            UnloadState();
            _stateQueue.Enqueue(state);
            InitialiseState();
        }
        
        private static void InitialiseState()
        {
            if (_stateQueue.Count > 0)
            {
                Debug.Log($" ▓▓▓▓▓▓▓▓▓▓▓ LOADING {_stateQueue.Peek().GetType().ToString().ToUpper()} ▓▓▓▓▓▓▓▓▓▓▓");
                _stateQueue.Peek().Load();
            }
        }

        private static void UnloadState() 
        {
            if (_stateQueue.Count > 0)
            {
                _stateQueue.Peek().Unload();
                _stateQueue.Dequeue();
            }
        }

        public static int QueueSize()
        {
            return _stateQueue.Count;
        }

        public static State CurrentState()
        {
            return _stateQueue.Peek();
        }

        public static T CurrentState<T>()
        {
            State state = _stateQueue.Peek();

            if (state == null)
                return default(T);

            System.Type templateType = typeof(T);
            System.Type stateType = state.GetType();

            // Types are the same, cast to template type
            if (templateType == stateType)
                return (T)System.Convert.ChangeType(state, templateType);

            // State type implements template type
            if (templateType.IsAssignableFrom(stateType))
                return (T)(object)state;

            return default(T);
        }

        public static void RunMethodOnCurrentState(string method)
        {
            State state = _stateQueue.Peek();

            System.Type stateType = state.GetType();
            System.Reflection.MethodInfo methodInfo = stateType.GetMethod(method);

            if (methodInfo == null)
                return;

            if (methodInfo.GetParameters().Length != 0)
                return;

            methodInfo.Invoke(state, null);
        }
    }
}
