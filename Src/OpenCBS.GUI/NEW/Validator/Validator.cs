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

using OpenCBS.GUI.NEW.Dto;

namespace OpenCBS.GUI.NEW.Validator
{
    public abstract class Validator<T> : IValidator<T> where T : DataTransferObject
    {
        private T _entity;
        public virtual void Validate(T entity)
        {
            _entity = entity;
            _entity.Notification = new Notification();
        }

        protected void Fail(bool condition, string propertyName, string message)
        {
            if (!condition) return;
            _entity.Notification.AddError(new Error { Message = message, PropertyName = propertyName });
        }

        protected void FailIfNullOrEmpty(string propertyName, string message)
        {
            var property = _entity.GetType().GetProperty(propertyName);
            if (property == null) return;
            FailIfNullOrEmpty(property.GetValue(_entity, null), propertyName, message);
        }

        protected void FailIfNullOrEmpty(object property, string propertyName, string message)
        {
            if (property is string)
                Fail(string.IsNullOrEmpty(property as string), propertyName, message);
            else
                Fail(property == null, propertyName, message);
        }
    }
}
