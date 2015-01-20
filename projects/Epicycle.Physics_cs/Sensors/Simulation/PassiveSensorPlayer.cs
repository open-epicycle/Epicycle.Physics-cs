// [[[[INFO>
// Copyright 2015 Epicycle (http://epicycle.org, https://github.com/open-epicycle)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// For more information check https://github.com/open-epicycle/Epicycle.Physics-cs
// ]]]]

using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicycle.Physics.Sensors.Simulation
{
    public class PassiveSensorPlayer<T> : ISensor<T>, IPassiveSensorController
    {
        private readonly object _lock = new object();

        private readonly IList<SensorSampleEventArgs<T>> _events;

        private T _lastSample;

        private double _startTime;
        private int _cursor;

        public PassiveSensorPlayer(IEnumerable<SensorSampleEventArgs<T>> events, T intialSample)
        {
            _events = events.ToList();

            _lastSample = intialSample;
        }

        public T LastSample
        {
            get { lock (_lock) { return _lastSample; } }
        }

        public void Start(double time)
        {
            _startTime = time;
            _cursor = 0;
        }

        public bool Update(double time)
        {
            var logTime = time - _startTime;

            for (var i = _cursor; i < _events.Count; i++)
            {
                var curEvent = _events[i];

                if (curEvent.Time < logTime)
                {
                    lock (_lock) { _lastSample = curEvent.Sample; }
                    Dispatch(curEvent);
                }
                else
                {
                    _cursor = i;
                    return true;
                }
            }

            _cursor = _events.Count;
            return false;
        }

        private void Dispatch(SensorSampleEventArgs<T> curEvent)
        {
            if (OnSample != null)
            {
                OnSample(this, curEvent);
            }
        }

        public event EventHandler<SensorSampleEventArgs<T>> OnSample;
    }
}
