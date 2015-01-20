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
using System.Collections.Generic;

namespace Epicycle.Physics.Sensors.Simulation
{
    [TestFixture]
    public class PassiveSensorPlayerTest
    {
        private int _initailSample;
        private List<SensorSampleEventArgs<int>> _events;
        private PassiveSensorPlayer<int> _sensor;

        [SetUp]
        public void SetUp()
        {
            _events = new List<SensorSampleEventArgs<int>>();

            for (var sampleId = 1; sampleId <= 4; sampleId++)
            {
                _events.Add(BuildEventArgs(sampleId));
            }

            _initailSample = 123;

            _sensor = new PassiveSensorPlayer<int>(_events, _initailSample);
        }

        private void SensorStartUpdate(int toSampleId)
        {
            _sensor.Start(10);
            _sensor.Update(toSampleId * 100.0 + 30);
        }

        private static SensorSampleEventArgs<int> BuildEventArgs(int sampleId)
        {
            return new SensorSampleEventArgs<int>(sampleId * 100.0, sampleId * 10);
        }
        
        private static void ValidateEvents(List<SensorSampleEventArgs<int>> events, params int[] expectedSampleIds)
        {
            Assert.That(events.Count, Is.EqualTo(expectedSampleIds.Length));

            for (var i = 0; i < expectedSampleIds.Length; i++)
            {
                var expectedEventArgs = BuildEventArgs(expectedSampleIds[i]);

                Assert.That(events[i].Time, Is.EqualTo(expectedEventArgs.Time));
                Assert.That(events[i].Sample, Is.EqualTo(expectedEventArgs.Sample));
            }
        }

        [Test]
        public void LastSample_equals_to_inital_sample_before_updates()
        {
            Assert.That(_sensor.LastSample, Is.EqualTo(_initailSample));
        }

        [Test]
        public void LastSample_equals_to_inital_sample_if_update_didnt_have_relevant_events()
        {
            SensorStartUpdate(0);

            Assert.That(_sensor.LastSample, Is.EqualTo(_initailSample));
        }

        [Test]
        public void LastSample_changes_to_new_value_after_update()
        {
            SensorStartUpdate(2);

            Assert.That(_sensor.LastSample, Is.EqualTo(20));
        }

        [Test]
        public void LastSample_changes_to_last_event_after_all_events_ended()
        {
            SensorStartUpdate(100);

            Assert.That(_sensor.LastSample, Is.EqualTo(40));
        }

        [Test]
        public void OnSample_doesnt_send_events_if_time_before_first_sample()
        {
            var wasEvent = false;

            _sensor.OnSample += (sender, e) => wasEvent = true;
            SensorStartUpdate(0);

            Assert.That(wasEvent, Is.False);
        }

        [Test]
        public void OnSample_update_sends_events_correctly()
        {
            var sentEvents = new List<SensorSampleEventArgs<int>>();

            _sensor.OnSample += (sender, e) => sentEvents.Add(e);

            _sensor.Start(10);
            var result = _sensor.Update(30);
            ValidateEvents(sentEvents);
            Assert.That(result, Is.True);

            result = _sensor.Update(130);
            ValidateEvents(sentEvents, 1);
            Assert.That(result, Is.True);

            sentEvents.Clear();
            result = _sensor.Update(330);
            ValidateEvents(sentEvents, 2, 3);
            Assert.That(result, Is.True);

            sentEvents.Clear();
            result = _sensor.Update(1000);
            ValidateEvents(sentEvents, 4);
            Assert.That(result, Is.False);

            sentEvents.Clear();
            result = _sensor.Update(2000);
            ValidateEvents(sentEvents);
            Assert.That(result, Is.False);

            result = _sensor.Update(3000);
            ValidateEvents(sentEvents);
            Assert.That(result, Is.False);
        }
    }
}
