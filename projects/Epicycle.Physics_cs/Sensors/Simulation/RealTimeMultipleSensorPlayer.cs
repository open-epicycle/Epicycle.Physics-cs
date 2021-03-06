﻿// [[[[INFO>
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

using Epicycle.Commons;
using Epicycle.Commons.Time;

namespace Epicycle.Physics.Sensors.Simulation
{
    // TODO: Test
    public sealed class RealTimeMultipleSensorPlayer<TKey> : MultipleSensorPlayerBase<TKey>
    {
        private readonly IClock _timeProvider;
        private readonly UpdateThread _updateThread;

        public RealTimeMultipleSensorPlayer(IClock timeProvider)
        {
            _timeProvider = timeProvider;
            _updateThread = new UpdateThread(this);
        }

        public void Start()
        {
            base.Start(_timeProvider.Time);
            _updateThread.Start();
        }

        private bool Update()
        {
            return base.Update(_timeProvider.Time);
        }

        internal sealed class UpdateThread : BasePeriodicThread
        {
            private readonly RealTimeMultipleSensorPlayer<TKey> _sensorsLogPlayer;

            public UpdateThread(RealTimeMultipleSensorPlayer<TKey> sensorsLogPlayer)
                : base(10, 5)
            {
                _sensorsLogPlayer = sensorsLogPlayer;
            }

            public new void Start()
            {
                base.Start();
            }

            protected override void Iteration()
            {
                _sensorsLogPlayer.Update();
            }
        }
    }
}
