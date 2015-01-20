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

using Epicycle.Geodesy;
using NUnit.Framework;

namespace Epicycle.Physics.Sensors.Location
{
    [TestFixture]
    public class LocationSensorSampleTest
    {
        [Test]
        public void ctor_initializes_all_fileds_correctly()
        {
            var provider = LocationProvider.Network;
            var time = 123.0;
            var location = new GeoPoint3(12.0, 23.0, 34.0);
            var geoDatum = GeoDatum.Wgs84;
            var bearing = 123.0;
            var speed = 234.0;
            var accuracy = 345.0;

            var sample = new LocationSensorSample(provider, time, location, geoDatum, bearing, speed, accuracy);

            Assert.That(sample.Provider, Is.EqualTo(provider));
            Assert.That(sample.Time, Is.EqualTo(time));
            Assert.That(sample.Location.Latitude, Is.EqualTo(12.0));
            Assert.That(sample.Location.Longitude, Is.EqualTo(23.0));
            Assert.That(sample.Location.Altitude, Is.EqualTo(34.0));
            Assert.That(sample.GeoDatum, Is.SameAs(GeoDatum.Wgs84));
            Assert.That(sample.Bearing, Is.EqualTo(bearing));
            Assert.That(sample.Speed, Is.EqualTo(speed));
            Assert.That(sample.Accuracy, Is.EqualTo(accuracy));
        }
    }
}
