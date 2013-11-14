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
    public partial class RolesView : CollectionView, IRolesView
    {
        private IRolesPresenterCallbacks _presenterCallbacks;

        public RolesView(ITranslator translator)
            : base(translator)
        {
            InitializeComponent();
            MdiParent = Application.OpenForms[0];
        }

        public void Run()
        {
            Show();
        }

        public void ShowRoles(IList<RoleDto> roles)
        {
            var selectedObject = _rolesListView.SelectedObject;
            _rolesListView.SetObjects(roles);
            _presenterCallbacks.ChangeSelection();
            _rolesListView.SelectedObject = selectedObject;
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

        public int? SelectedRoleId
        {
            get
            {
                var roleDto = (RoleDto) _rolesListView.SelectedObject;
                if (roleDto == null) return null;
                return roleDto.Id;
            }
        }

        public bool ShowDeleted
        {
            get { return _showDeletedCheckBox.Checked; }
        }

        public void Attach(IRolesPresenterCallbacks presenterCallbacks)
        {
            _addButton.Click += (sender, e) => presenterCallbacks.Add();
            _editButton.Click += (sender, e) => presenterCallbacks.Edit();
            _deleteButton.Click += (sender, e) => presenterCallbacks.Delete();
            _rolesListView.SelectionChanged += (sender, e) => presenterCallbacks.ChangeSelection();
            _showDeletedCheckBox.CheckedChanged += (sender, e) => presenterCallbacks.Refresh();
            FormClosed += (sender, e) => presenterCallbacks.Close();
            _presenterCallbacks = presenterCallbacks;
        }
    }
}
