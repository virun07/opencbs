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
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using StructureMap;

namespace OpenCBS.Service.Shell
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;
        private readonly IEventPublisher _eventPublisher;

        public ApplicationController(IContainer container, IEventPublisher eventPublisher)
        {
            _container = container;
            _eventPublisher = eventPublisher;
        }

        public void Execute<T>(T commandData)
        {
            try
            {
                var command = _container.TryGetInstance<ICommand<T>>();
                if (command != null)
                    command.Execute(commandData);
            }
            catch (UnauthorizedAccessException error)
            {
                var presenter = _container.GetInstance<IErrorPresenter>();
                presenter.Run(string.Format("Not authorized: {0}", error.Message));
            }
            catch (Exception error)
            {
                var presenter = _container.GetInstance<IErrorPresenter>();
                presenter.Run(error.Message);
            }
        }

        public void Raise<T>(T eventData)
        {
            _eventPublisher.Publish(eventData);
        }

        public void Unsubscribe(object eventHandlers)
        {
            _eventPublisher.Unsubscribe(eventHandlers);
        }
    }
}
