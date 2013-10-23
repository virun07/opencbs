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
using System.Windows.Forms;

namespace OpenCBS.Controls
{
    public partial class RangeControl : UserControl
    {
        public RangeControl()
        {
            InitializeComponent();
        }

        public event EventHandler MinMaxChanged;

        protected override void OnLoad(EventArgs e)
        {
            _minTextBox.SetWatermark("min");
            _maxTextBox.SetWatermark("max");

            _minTextBox.TextChanged += (sender, args) => MinMaxChanged(this, null);
            _maxTextBox.TextChanged += (sender, args) => MinMaxChanged(this, null);

            base.OnLoad(e);
        }

        public decimal? Min
        {
            get
            {
                if (string.IsNullOrEmpty(_minTextBox.Text)) return null;
                return Convert.ToDecimal(_minTextBox.Text);
            }
            set
            {
                _minTextBox.Text = value.HasValue ? Convert.ToString(value.Value) : string.Empty;
            }
        }

        public decimal? Max
        {
            get
            {
                if (string.IsNullOrEmpty(_maxTextBox.Text)) return null;
                return Convert.ToDecimal(_maxTextBox.Text);
            }
            set
            {
                _maxTextBox.Text = value.HasValue ? Convert.ToString(value.Value) : string.Empty;
            }
        }
    }
}
