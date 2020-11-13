using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cybermage.Core
{
    public class Timer
    {
        public delegate void FinishedDelegate();
        public delegate void UpdateDelegate(float interpolation);

        private float _time;
        private bool _enabled;
        private bool _finished;
        private float _interpolation;
        
        public FinishedDelegate FinishedAction { get; set; }
        public UpdateDelegate UpdateAction { get; set; }
        public float Duration { get; set; }
        
        public Timer(float duration = 0)
        {
            Duration = duration;
            _enabled = false;
            FinishedAction = null;
        }

        public void Update()
        {
            if (_enabled == false)
                return;

            _time -= Time.deltaTime;

            _interpolation = Mathf.Clamp(1.0f - (_time / Duration), 0, 1.0f);

            if (_interpolation > 1)
                _interpolation = 1;

            if (UpdateAction != null)
                UpdateAction(_interpolation);


            if (_time <= 0 && _enabled == true)
            {
                _enabled = false;
                _finished = true;

                if (FinishedAction != null)
                    FinishedAction();
            }
        }

        public bool Enabled()
        {
            return _enabled;
        }

        public bool Finished()
        {
            return _finished;
        }

        public void Start()
        {
            if (Duration <= 0)
            {
                if (FinishedAction != null)
                    FinishedAction();

                return;
            }

            _time = Duration;
            _enabled = true;
            _finished = false;
            _interpolation = 0;
        }

        public void Stop()
        {
            _enabled = false;
            _time = 0;
            _interpolation = 0;
        }
    }
}