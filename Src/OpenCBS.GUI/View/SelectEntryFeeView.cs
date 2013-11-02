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
using System.Windows.Forms;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class SelectEntryFeeView : BaseView, ISelectEntryFeeView
    {
        public SelectEntryFeeView(ITranslator translator)
            : base(translator)
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }

        public void Attach(ISelectEntryFeePresenterCallbacks presenterCallbacks)
        {
            _okButton.Click += (sender, e) => presenterCallbacks.Ok();
            _cancelButton.Click += (sender, e) => presenterCallbacks.Cancel();
            _entryFeeComboBox.SelectedIndexChanged += (sender, e) => presenterCallbacks.ChangeSelection();
        }

        public void ShowEntryFees(Dictionary<int, string> entryFees)
        {
            _entryFeeComboBox.ValueMember = "Key";
            _entryFeeComboBox.DisplayMember = "Value";
            _entryFeeComboBox.DataSource = new BindingSource(entryFees, null);
            _entryFeeComboBox.SelectedIndex = -1;
        }

        public bool CanSelectEntryFee
        {
            get { return _okButton.Enabled; }
            set { _okButton.Enabled = value; }
        }

        public int? SelectedEntryFeeId
        {
            get
            {
                if (_entryFeeComboBox.SelectedValue == null) return null;
                return (int) _entryFeeComboBox.SelectedValue;
            }
        }
    }
}
