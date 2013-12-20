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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using NSubstitute;
using NUnit.Framework;
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Validator;
using OpenCBS.Model.Schedule;
using OpenCBS.Service;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Service
{
    [TestFixture]
    public class ExoticScheduleServiceTest
    {
        private IExoticScheduleRepository _repository;
        private IExoticScheduleValidator _validator;
        private ExoticScheduleService _service;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IExoticScheduleRepository>();
            _validator = Substitute.For<IExoticScheduleValidator>();
            _service = new ExoticScheduleService(_repository, _validator);
        }

        [Test]
        public void FindAll_ReturnsAll()
        {
            var schedules = new List<ExoticSchedule>
            {
                new ExoticSchedule(),
                new ExoticSchedule(),
                new ExoticSchedule()
            };
            _repository.FindAll().Returns(schedules);
            var result = _service.FindAll();
            _repository.Received().FindAll();
            Assert.AreEqual(3, result.Count);
            Assert.IsInstanceOf<ReadOnlyCollection<ExoticScheduleDto>>(result);
        }
    }
}
// ReSharper restore InconsistentNaming
