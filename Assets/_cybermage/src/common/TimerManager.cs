using System.Collections.Generic;
using System.Linq;
using Cybermage.Core;

namespace Cybermage
{
    public static class TimerManager
    {
        private static List<Timer> _timers = new List<Timer>();
        private static List<Timer> _timersToAppend = new List<Timer>();
        
        public static void StartTimer(Timer timer)
        {
            timer.Start();
            _timersToAppend.Add(timer);
        }

        public static void Update()
        {
            if(_timersToAppend.Any())
                _timers.AddRange(_timersToAppend);
            _timersToAppend.Clear();

            if (!_timers.Any())
                return;

            for (int i = 0; i < _timers.Count; i++)
            {
                _timers[i].Update();
            }

            _timers = _timers.Select(x => x).Where(x => x.Enabled() == true).ToList();
        }
    }
}