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

using NUnit.Framework;

namespace Epicycle.Physics.Sensors
{
    [TestFixture]
    public class SensorTest
    {
        private Sensor<int> _sensor;

        [SetUp]
        public void SetUp()
        {
            _sensor = new Sensor<int>(123);
        }

        [Test]
        public void LastSample_equals_to_inital_sample_before_updates()
        {
            Assert.That(_sensor.LastSample, Is.EqualTo(123));
        }

        [Test]
        public void LastSample_changes_to_new_value_after_update()
        {
            _sensor.Update(1, 234);

            Assert.That(_sensor.LastSample, Is.EqualTo(234));
        }

        [Test]
        public void OnSample_calling_update_sends_an_evenet()
        {
            SensorSampleEventArgs<int> args = null;

            _sensor.OnSample += (sender, e) => args = e;

            var time = 1.0;
            var sample = 234;

            _sensor.Update(time, sample);

            Assert.That(args, Is.Not.Null);
            Assert.That(args.Time, Is.EqualTo(time));
            Assert.That(args.Sample, Is.EqualTo(sample));
        }
    }
}
