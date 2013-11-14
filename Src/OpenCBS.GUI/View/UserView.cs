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
using System.Linq;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class UserView : BaseView, IUserView
    {
        private TabListPage _rolesTabListPage;

        public UserView()
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

        public void ShowRoles(Dictionary<int, string> roles)
        {
            _rolesTabListPage = new TabListPage
            {
                Name = "_rolesTabListPage",
                Text = _("Roles")
            };
            _userTabList.TabListPages.Add(_rolesTabListPage);
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown
            };
            _rolesTabListPage.Controls.Add(panel);

            foreach (var pair in roles)
            {
                var checkBox = new CheckBox
                {
                    Text = pair.Value,
                    Tag = pair.Key,
                    Width = 200
                };
                panel.Controls.Add(checkBox);
            }
        }

        public void DisablePassword()
        {
            var controls = new Control[]
            {
                _passwordLabel,
                _passwordTextBox,
                _passwordConfirmationLabel,
                _passwordConfirmationTextBox
            };
            foreach (var control in controls)
            {
                control.Enabled = control.Visible = false;
            }
        }

        public int Id { get; set; }

        public bool IsSuperuser { get; set; }

        public string Username
        {
            get { return _usernameTextBox.Text; }
            set { _usernameTextBox.Text = value; }
        }

        public string FirstName
        {
            get { return _firstNameTextBox.Text; }
            set { _firstNameTextBox.Text = value; }
        }

        public string LastName
        {
            get { return _lastNameTextBox.Text; }
            set { _lastNameTextBox.Text = value; }
        }

        public string Email
        {
            get { return _emailTextBox.Text; }
            set { _emailTextBox.Text = value; }
        }

        public string Password
        {
            get { return _passwordTextBox.Text; }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmationTextBox.Text; }
        }

        public IList<int> RoleIds
        {
            get
            {
                if (_rolesTabListPage == null)
                    return new List<int>();
                return GetControls(_rolesTabListPage)
                    .OfType<CheckBox>()
                    .Where(c => c.Tag is int && c.Checked)
                    .Select(c => Convert.ToInt32(c.Tag))
                    .ToList().AsReadOnly();
            }
            set
            {
                if (value == null || _rolesTabListPage == null) return;
                var checkBoxes = GetControls(_rolesTabListPage)
                    .OfType<CheckBox>()
                    .Where(c => c.Tag is int && value.Contains(Convert.ToInt32(c.Tag)));
                foreach (var checkBox in checkBoxes)
                    checkBox.Checked = true;
            }
        }

        public void Attach(IUserPresenterCallbacks presenterCallbacks)
        {
            _okButton.Click += (sender, e) => presenterCallbacks.Ok();
            _cancelButton.Click += (sender, e) => presenterCallbacks.Cancel();
            FormClosed += (sender, e) => presenterCallbacks.Close();
        }
    }
}
