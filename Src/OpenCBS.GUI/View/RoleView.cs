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
using Cyotek.Windows.Forms;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class RoleView : BaseView, IRoleView
    {
        public RoleView(ITranslator translator)
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

        public string RoleName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public void Attach(IRolePresenterCallbacks presenterCallbacks)
        {
            _okButton.Click += (sender, e) => presenterCallbacks.Ok();
            _cancelButton.Click += (sender, e) => presenterCallbacks.Cancel();
        }

        public void ShowPermissions(IList<string> permissions)
        {
            var prefixes = permissions.Select(p => p.Split('.')[0]).Distinct();

            foreach (var prefix in prefixes)
            {
                var temp = prefix;

                var tabListPage = new TabListPage { Text = _(prefix) };

                // Add checkbox for each permission
                var tabPermissions = permissions
                    .Where(p => p.StartsWith(temp));

                var flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown
                };
                foreach (var tabPermission in tabPermissions)
                {
                    var checkBox = new CheckBox
                    {
                        Text = _(tabPermission.Split('.')[1]),
                        AutoSize = true,
                        Tag = tabPermission
                    };
                    flowLayoutPanel.Controls.Add(checkBox);
                }
                tabListPage.Controls.Add(flowLayoutPanel);

                _tabList.TabListPages.Add(tabListPage);
            }
        }

        public IList<string> Permissions
        {
            get
            {
                return GetControls(this)
                    .OfType<CheckBox>().Where(cb => cb.Tag is string && cb.Checked)
                    .Select(cb => cb.Tag.ToString()).ToList().AsReadOnly();
            }

            set
            {
                if (value == null) return;
                var checkBoxes = GetControls(this)
                    .OfType<CheckBox>().Where(cb => cb.Tag is string && value.Contains(cb.Tag.ToString()));
                foreach (var checkBox in checkBoxes)
                    checkBox.Checked = true;
            }
        }
    }
}
