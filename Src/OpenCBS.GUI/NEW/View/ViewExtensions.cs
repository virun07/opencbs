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
using System.Linq;
using System.Windows.Forms;
using OpenCBS.GUI.NEW.Dto;

namespace OpenCBS.GUI.NEW.View
{
    public static class ViewExtensions
    {
        public static IEnumerable<Control> GetControls(this Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.Concat(controls.SelectMany(x => x.GetControls()));
        }

        public static void ShowNotification(this Form form, Notification notification, ErrorProvider errorProvider)
        {
            foreach (var error in notification.Errors)
            {
                var errorControl = (from c in form.GetControls()
                                   where c.Tag != null && c.Tag.ToString() == error.PropertyName
                                   select c).FirstOrDefault();
                if (errorControl == null) continue;
                errorProvider.SetError(errorControl, error.Message);
            }
        }
    }
}
