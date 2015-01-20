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
    public sealed class SensorSampleEventArgs<T> : EventArgs
    {
        private readonly double _time;
        private readonly T _sample;

        public SensorSampleEventArgs(double time, T sample)
        {
            _time = time;
            _sample = sample;
        }

        public double Time
        {
            get { return _time; }
        }

        public T Sample
        {
            get { return _sample; }
        }
    }
}
