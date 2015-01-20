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
    public class SensorSampleEventArgsTest
    {
        [Test]
        public void ctor_initializes_all_fileds_correctly()
        {
            var time = 100.0;
            int sample = 123;

            var args = new SensorSampleEventArgs<int>(time, sample);

            Assert.That(args.Time, Is.EqualTo(time));
            Assert.That(args.Sample, Is.EqualTo(sample));
        }
    }
}
