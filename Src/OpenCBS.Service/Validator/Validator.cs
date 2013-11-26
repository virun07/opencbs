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
using System.Text.RegularExpressions;
using OpenCBS.DataContract;
using OpenCBS.Interface.Validator;

namespace OpenCBS.Service.Validator
{
    public abstract class Validator<T> : IValidator<T> where T : DataTransferObject
    {
        protected const string CannotBeEmpty = "Cannot be empty.";
        protected const string OnlyAlphanumOrUnderscore = "Only latin letters, numbers, and underscores are allowed.";
        protected const string MinValueCannotBeEmpty = "Min value cannot be empty.";
        protected const string MaxValueCannotBeEmpty = "Max value cannot be empty.";

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

        protected void FailIfNullOrEmpty(string propertyName, string message = CannotBeEmpty)
        {
            var property = _entity.GetType().GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException(string.Format("Property '{0}' not found.", propertyName));
            var value = property.GetValue(_entity, null);
            if (propertyName.EndsWith("Min"))
            {
                propertyName = propertyName.Substring(0, propertyName.Length - 3);
                message = MinValueCannotBeEmpty;
            }
            if (propertyName.EndsWith("Max"))
            {
                propertyName = propertyName.Substring(0, propertyName.Length - 3);
                message = MaxValueCannotBeEmpty;
            }
            FailIfNullOrEmpty(value, propertyName, message);
        }

        protected void FailIfNullOrEmpty(object property, string propertyName, string message = CannotBeEmpty)
        {
            if (property is string)
                Fail(string.IsNullOrEmpty(property as string), propertyName, message);
            else
                Fail(property == null, propertyName, message);
        }

        protected void FailIfNotAlphanumOrUnderscore(string propertyName, string message = OnlyAlphanumOrUnderscore)
        {
            var property = _entity.GetType().GetProperty(propertyName);
            if (property.PropertyType != typeof (string))
                throw new ArgumentException(string.Format("Peropty '{0}' should be of type string.", propertyName));
            FailIfNotAlphanumOrUnderscore(property.GetValue(_entity, null), propertyName, message);
        }

        protected void FailIfNotAlphanumOrUnderscore(object property, string propertyName, string message = OnlyAlphanumOrUnderscore)
        {
            var regex = new Regex("^[a-z0-9_]+$", RegexOptions.IgnoreCase);
            var match = regex.Match(property.ToString());
            Fail(!match.Success, propertyName, message);
        }
    }
}
