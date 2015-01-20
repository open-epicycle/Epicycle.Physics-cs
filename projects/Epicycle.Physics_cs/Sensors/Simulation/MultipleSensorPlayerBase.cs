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

using System.Collections.Generic;

namespace Epicycle.Physics.Sensors.Simulation
{
    // TODO: Test
    public abstract class MultipleSensorPlayerBase<TKey>
    {
        private readonly Dictionary<TKey, object> _sensors;
        private readonly List<IPassiveSensorController> _sensorControllers;

        public MultipleSensorPlayerBase()
        {
            _sensors = new Dictionary<TKey, object>();
            _sensorControllers = new List<IPassiveSensorController>();
        }

        public void RegisterSensor<T>(TKey name, IEnumerable<SensorSampleEventArgs<T>> events, T initalSample)
        {
            var sensorPlayer = new PassiveSensorPlayer<T>(events, initalSample);

            _sensorControllers.Add(sensorPlayer);
            _sensors[name] = sensorPlayer;
        }

        protected virtual void Start(double time)
        {
            _sensorControllers.ForEach(sensor => sensor.Start(time));
        }

        protected virtual bool Update(double time)
        {
            var hasMore = false;

            foreach (var sensor in _sensorControllers)
            {
                hasMore |= sensor.Update(time);
            }

            return hasMore;
        }

        public ISensor<T> GetSensor<T>(TKey name)
        {
            return (ISensor<T>)_sensors[name];
        }
    }
}
