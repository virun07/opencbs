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
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class UsersView : CollectionView, IUsersView
    {
        private IUsersPresenterCallbacks _presenterCallbacks;

        public UsersView(ITranslator translator)
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

        public void Attach(IUsersPresenterCallbacks presenterCallbacks)
        {
            _addButton.Click += (sender, e) => presenterCallbacks.Add();
            _editButton.Click += (sender, e) => presenterCallbacks.Edit();
            _deleteButton.Click += (sender, e) => presenterCallbacks.Delete();
            _showDeletedCheckBox.CheckedChanged += (sender, e) => presenterCallbacks.Refresh();
            _usersListView.SelectedIndexChanged += (sender, e) => presenterCallbacks.ChangeSelection();
            FormClosing += (sender, e) => presenterCallbacks.Close();
            _presenterCallbacks = presenterCallbacks;
        }

        public void ShowUsers(IList<UserDto> users)
        {
            var selectedObject = _usersListView.SelectedObject;
            _usersListView.SetObjects(users);
            _presenterCallbacks.ChangeSelection();
            _usersListView.SelectedObject = selectedObject;
        }

        public void ProhibitAdding()
        {
            _addButton.Visible = false;
        }

        public void ProhibitEditing()
        {
            _editButton.Visible = false;
        }

        public void ProhibitDeleting()
        {
            _deleteButton.Visible = false;
        }

        public bool CanEdit
        {
            get { return _editButton.Enabled; }
            set { _editButton.Enabled = value; }
        }

        public bool CanDelete
        {
            get { return _deleteButton.Enabled; }
            set { _deleteButton.Enabled = value; }
        }

        public int? SelectedUserId
        {
            get
            {
                var userDto = (UserDto) _usersListView.SelectedObject;
                if (userDto == null) return null;
                return userDto.Id;
            }
        }

        public bool ShowDeleted
        {
            get { return _showDeletedCheckBox.Checked; }
        }

        public IList<RoleDto> Roles { get; set; }

        private void Setup()
        {
            _rolesColumn.AspectToStringConverter = value =>
            {
                var roleIds = (IList<int>) value;
                return string.Join(", ", Roles.Where(r => roleIds.Contains(r.Id)).Select(r => r.Name));
            };
            _isSuperuserColumn.AspectToStringConverter = value =>
            {
                var isSuperuser = (bool) value;
                return isSuperuser ? "*" : string.Empty;
            };
        }
    }
}
