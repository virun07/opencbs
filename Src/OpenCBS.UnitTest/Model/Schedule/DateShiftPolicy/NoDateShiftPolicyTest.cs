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

using System;
using NUnit.Framework;
using OpenCBS.Model.Schedule.DateShiftPolicy;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Model.Schedule.DateShiftPolicy
{
    [TestFixture]
    public class NoDateShiftPolicyTest
    {
        [Test]
        public void ShiftDate_AnyDate_ReturnsSameDate()
        {
            var policy = new NoDateShiftPolicy();
            var saturday = new DateTime(2013, 6, 8);
            var firstOfJanuary = new DateTime(2013, 1, 1);
            Assert.That(policy.ShiftDate(saturday), Is.EqualTo(saturday));
            Assert.That(policy.ShiftDate(firstOfJanuary), Is.EqualTo(firstOfJanuary));
        }
    }
}
// ReSharper restore InconsistentNaming
