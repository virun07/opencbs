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
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class EntryFeesView : CollectionView, IEntryFeesView
    {
        private IEntryFeesPresenterCallbacks _presenterCallbacks;

        public EntryFeesView(ITranslator translator)
            : base(translator)
        {
            InitializeComponent();
            MdiParent = Application.OpenForms[0];
            Setup();
        }

        public void Run()
        {
            Show();
        }

        public void Attach(IEntryFeesPresenterCallbacks presenterCallbacks)
        {
            _addButton.Click += (sender, e) => presenterCallbacks.Add();
            _editButton.Click += (sender, e) => presenterCallbacks.Edit();
            _deleteButton.Click += (sender, e) => presenterCallbacks.Delete();
            _entryFeesListView.SelectionChanged += (sender, e) => presenterCallbacks.ChangeSelection();
            _showDeletedCheckBox.CheckedChanged += (sender, e) => presenterCallbacks.Refresh();
            _presenterCallbacks = presenterCallbacks;
        }

        public void ShowEntryFees(IEnumerable<EntryFeeDto> entryFees)
        {
            var selectedObject = _entryFeesListView.SelectedObject;
            _entryFeesListView.SetObjects(entryFees);
            _presenterCallbacks.ChangeSelection();
            _entryFeesListView.SelectedObject = selectedObject;
        }

        public bool AllowAdding
        {
            get { return _addButton.Visible; }
            set { _addButton.Visible = value; }
        }

        public bool AllowEditing
        {
            get { return _addButton.Visible; }
            set { _addButton.Visible = value; }
        }

        public bool AllowDeleting
        {
            get { return _deleteButton.Visible; }
            set { _deleteButton.Visible = value; }
        }

        public bool EditEnabled
        {
            get { return _editButton.Enabled; }
            set { _editButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            get { return _deleteButton.Enabled; }
            set { _deleteButton.Enabled = value; }
        }

        public int? SelectedEntryFeeId
        {
            get
            {
                var entryFeeDto = (EntryFeeDto) _entryFeesListView.SelectedObject;
                if (entryFeeDto == null) return null;
                return entryFeeDto.Id;
            }
        }

        public bool ShowDeleted
        {
            get { return _showDeletedCheckBox.Checked; }
        }

        private void Setup()
        {
            _valueMinColumn.AspectToStringConverter =
            _valueMaxColumn.AspectToStringConverter = v =>
            {
                var value = (decimal) v;
                return string.Format("{0:N2}", value);
            };
            _rateAmountColumn.AspectToStringConverter = v =>
            {
                var rate = (bool) v;
                return rate ? _("Rate") : _("Amount");
            };
        }
    }
}
