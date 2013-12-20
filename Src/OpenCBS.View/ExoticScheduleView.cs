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
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.View
{
    public partial class ExoticScheduleView : BaseView, IExoticScheduleView
    {
        private IExoticSchedulePresenterCallbacks _presenterCallbacks;

        public ExoticScheduleView(ITranslator translator)
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

        public void FocusItems()
        {
            _itemsListView.Focus();
        }

        public int Id { get; set; }

        public IList<ExoticScheduleItemDto> Items
        {
            get { return (IList<ExoticScheduleItemDto>) _itemsListView.Objects; }
            set
            {
                var selectedObject = _itemsListView.SelectedObject;
                _itemsListView.SetObjects(value);
                _itemsListView.SelectedObject = selectedObject;
                _itemsListView.EnsureModelVisible(selectedObject);
                _presenterCallbacks.ChangeSelectedItem();
            }
        }

        public bool CanMoveUp
        {
            get { return _moveUpButton.Enabled; }
            set { _moveUpButton.Enabled = value; }
        }

        public bool CanMoveDown
        {
            get { return _moveDownButton.Enabled; }
            set { _moveDownButton.Enabled = value; }
        }

        public bool CanDelete
        {
            get { return _deleteButton.Enabled; }
            set { _deleteButton.Enabled = value; }
        }

        public ExoticScheduleItemDto SelectedItem
        {
            get { return (ExoticScheduleItemDto) _itemsListView.SelectedObject;  }
            set
            {
                _itemsListView.SelectedObject = value;
                _itemsListView.EnsureModelVisible(value);
            }
        }

        public string ExoticScheduleName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public void Attach(IExoticSchedulePresenterCallbacks presenterCallbacks)
        {
            _presenterCallbacks = presenterCallbacks;
            FormClosed += (sender, e) => presenterCallbacks.Close();
            _okButton.Click += (sender, e) => presenterCallbacks.Ok();
            _cancelButton.Click += (sender, e) => presenterCallbacks.Cancel();
            _itemsListView.SelectedIndexChanged += (sender, e) => presenterCallbacks.ChangeSelectedItem();
            _moveUpButton.Click += (sender, e) => _presenterCallbacks.MoveUp();
            _moveDownButton.Click += (sender, e) => _presenterCallbacks.MoveDown();
            _addButton.Click += (sender, e) => _presenterCallbacks.Add();
            _deleteButton.Click += (sender, e) => _presenterCallbacks.Delete();
        }
    }
}
