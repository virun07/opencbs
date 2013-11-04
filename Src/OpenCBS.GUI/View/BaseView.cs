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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Cyotek.Windows.Forms;
using OpenCBS.Controls;
using OpenCBS.DataContract;
using OpenCBS.Interface;

namespace OpenCBS.GUI.View
{
    public partial class BaseView : Form
    {
        private readonly ITranslator _translator;
        private readonly Dictionary<Component, string> _map = new Dictionary<Component, string>();

        public BaseView()
            : this(null)
        { }

        public BaseView(ITranslator translator)
        {
            _translator = translator;
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        protected void ClearError(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            _errorProvider.SetError(control, null);
        }

        private static IEnumerable<Control> GetControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetControls(x)).Concat(controls);
        }

        public void ShowNotification(Notification notification)
        {
            foreach (var error in notification.Errors)
            {
                var errorControl = (from c in GetControls(this)
                                    where c.Tag != null && c.Tag.ToString() == error.PropertyName
                                    select c).FirstOrDefault();
                if (errorControl == null) continue;
                _errorProvider.SetError(errorControl, _(error.Message));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var validTypes = new[]
            {
                typeof(TextBox),
                typeof(RangeControl),
                typeof(ComboBox)
            };
            foreach (var control in GetControls(this))
            {
                if (control.Tag == null) continue;
                if (!validTypes.Contains(control.GetType())) continue;

                if (control is TextBox)
                    (control as TextBox).TextChanged += ClearError;
                if (control is RangeControl)
                    (control as RangeControl).MinMaxChanged += ClearError;
                if (control is ComboBox)
                    (control as ComboBox).SelectedIndexChanged += ClearError;
            }
            InitControlKeyMap();
            Translate();
        }

        public void Translate()
        {
            if (_translator == null) return;
            foreach (var pair in _map)
            {
                if (pair.Key is Control)
                    (pair.Key as Control).Text = _translator.Translate(pair.Value);
                else if (pair.Key is ColumnHeader)
                    (pair.Key as ColumnHeader).Text = _translator.Translate(pair.Value);
            }
            Invalidate(true);
        }

        public string _(string key)
        {
            if (_translator == null) return key;
            return _translator.Translate(key);
        }

        private void InitControlKeyMap()
        {
            var validTypes = new[]
            {
                typeof (Label),
                typeof (Button),
                typeof (CheckBox),
                typeof (RadioButton),
                typeof (ObjectListView),
                typeof (TabListPage)
            };
            foreach (var control in GetControls(this).Where(c => validTypes.Contains(c.GetType())))
            {
                if (control is ObjectListView)
                {
                    var listView = control as ObjectListView;
                    for (var i = 0; i < listView.Columns.Count; i++)
                    {
                        var column = listView.Columns[i];
                        _map.Add(column, column.Text);
                    }
                }
                else
                {
                    _map.Add(control, control.Text);
                }
            }
            _map.Add(this, Text);
        }
    }
}
