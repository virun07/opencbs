// Copyright © 2013 Open Octopus Ltd.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// 
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using NUnit.Framework;
using OpenCBS.Model.Schedule.RoundingPolicy;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Model.Schedule
{
    [TestFixture]
    public class RoundingPolicyTest
    {
        [Test]
        public void Round_TwoDecimalsRoundingPolicy_RoundsToTwoDecimals()
        {
            var policy = new TwoDecimalsRoundingPolicy();
            Assert.That(policy.Round(100.555m), Is.EqualTo(100.56));
            Assert.That(policy.Round(100.554m), Is.EqualTo(100.55));
        }
        
        [Test]
        public void Round_WholeRoundingPolicy_RoundsToInteger()
        {
            var policy = new WholeRoundingPolicy();
            Assert.That(policy.Round(100.555m), Is.EqualTo(101));
            Assert.That(policy.Round(100.5m), Is.EqualTo(101));
            Assert.That(policy.Round(100.3m), Is.EqualTo(100));
        }
    }
}
// ReSharper restore InconsistentNaming
