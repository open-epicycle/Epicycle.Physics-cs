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

namespace Epicycle.Physics.Sensors
{
    public class Sensor<T> : ISensor<T>
    {
        private T _lastSample;

        public Sensor(T initialSample)
        {
            _lastSample = initialSample;
        }

        public T LastSample
        {
            get { return _lastSample; }
        }

        public event EventHandler<SensorSampleEventArgs<T>> OnSample;

        public void Update(double time, T sample)
        {
            _lastSample = sample;

            if (OnSample != null)
            {
                OnSample(this, new SensorSampleEventArgs<T>(time, sample));
            }
        }
    }
}
