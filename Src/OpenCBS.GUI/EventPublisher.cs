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
using System.Collections.Generic;
using System.Linq;
using OpenCBS.Interfaces;

namespace OpenCBS.GUI
{
    public class EventPublisher : IEventPublisher
    {
        private readonly Dictionary<Type, IList<object>> _handlers;

        public EventPublisher()
        {
            _handlers = new Dictionary<Type, IList<object>>();
        }

        public void Subscribe(object eventHandlers)
        {
            var handlers = eventHandlers.GetType().GetInterfaces();
            var eventHandlerType = typeof(IEventHandler<>);
            foreach (var handler in handlers)
            {
                if (!handler.Name.Equals(eventHandlerType.Name)) continue;

                var eventType = handler.GetGenericArguments()[0];
                AddHandler(eventType, eventHandlers);
            }
        }

        public void Unsubscribe(object eventHandlers)
        {
            var handlers = eventHandlers.GetType().GetInterfaces();
            var eventHandlerType = typeof(IEventHandler<>);
            foreach (var handler in handlers)
            {
                if (!handler.Name.Equals(eventHandlerType.Name)) continue;

                var eventType = handler.GetGenericArguments()[0];
                RemoveHandler(eventType, eventHandlers);
            }
        }

        public void Publish<T>(T eventData)
        {
            Handle(eventData);
        }

        private void AddHandler(Type eventType, object handler)
        {
            if (!_handlers.ContainsKey(eventType))
                _handlers[eventType] = new List<object>();
            _handlers[eventType].Add(handler);
        }

        private void RemoveHandler(Type eventType, object handler)
        {
            if (!_handlers.ContainsKey(eventType)) return;

            _handlers[eventType].Remove(handler);
        }

        private IEnumerable<object> GetEventHandlers<T>()
        {
            var eventType = typeof(T);
            var handlers = new List<object>();
            if (!_handlers.ContainsKey(eventType))
                return handlers;

            handlers.AddRange(_handlers[eventType].Where(handler => handler != null));
            return handlers;
        }

        private void Handle<T>(T eventData)
        {
            var handlers = GetEventHandlers<T>();
            foreach (var eventHandler in handlers.OfType<IEventHandler<T>>())
            {
                eventHandler.Handle(eventData);
            }
        }
    }
}
