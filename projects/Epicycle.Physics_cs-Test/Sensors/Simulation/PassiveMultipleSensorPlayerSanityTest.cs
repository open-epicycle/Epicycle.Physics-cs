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
    public class PassiveMultipleSensorPlayerSanityTest
    {
        public enum SensorType
        {
            Sensor1,
            Sensor2,
        }

        [Test]
        public void SanityTest()
        {
            var player = new PassiveMultipleSensorPlayer<SensorType>();

            var events1 = new List<SensorSampleEventArgs<int>>();
            var events2 = new List<SensorSampleEventArgs<string>>();
            for (var sampleId = 1; sampleId <= 4; sampleId++)
            {
                events1.Add(new SensorSampleEventArgs<int>(sampleId * 100.0, sampleId * 10));
                events2.Add(new SensorSampleEventArgs<string>(sampleId * 150.0 + 20.0, string.Format("SMP:{0}", sampleId)));
            }

            player.RegisterSensor<int>(SensorType.Sensor1, events1, 123);
            player.RegisterSensor<string>(SensorType.Sensor2, events2, "moo");

            player.Start(5);
            player.Update(130);
            player.Update(310);

            Assert.That(player.GetSensor<int>(SensorType.Sensor1).LastSample, Is.EqualTo(30));
            Assert.That(player.GetSensor<string>(SensorType.Sensor2).LastSample, Is.EqualTo("SMP:1"));
        }
    }
}
