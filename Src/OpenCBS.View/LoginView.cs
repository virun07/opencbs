// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
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
using OpenCBS.Controls;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class LoginView : OpenCBS.View.BaseView, ILoginView
    {
        private readonly LoaderControl _loader = new LoaderControl();

        public LoginView(ITranslator translator)
            : base(translator)
        {
            InitializeComponent();
            Controls.Add(_loader);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }

        public void StartDatabaseListRefresh()
        {
            Cursor = Cursors.WaitCursor;
            _databaseComboBox.Enabled = false;
            _usernameTextBox.Enabled = false;
            _passwordTextBox.Enabled = false;
            _loginButton.Enabled = false;
            _loader.AttachTo(_databaseComboBox);
            _loader.Start();
        }

        public void StopDatabaseListRefresh()
        {
            _loader.Stop();
            Cursor = Cursors.Arrow;
            _databaseComboBox.Enabled = true;
            _usernameTextBox.Enabled = true;
            _passwordTextBox.Enabled = true;
            _loginButton.Enabled = true;
            _usernameTextBox.Focus();
        }

        public void ShowDatabases(IList<string> databases)
        {
            var dict = databases.ToDictionary(i => i, i => i);
            _databaseComboBox.ValueMember = "Key";
            _databaseComboBox.DisplayMember = "Value";
            _databaseComboBox.DataSource = new BindingSource(dict, null);
        }

        public string Username
        {
            get { return _usernameTextBox.Text; }
            set { _usernameTextBox.Text = value; }
        }

        public string Password
        {
            get { return _passwordTextBox.Text; }
            set { _passwordTextBox.Text = value; }
        }

        public string Database
        {
            get
            {
                if (_databaseComboBox.SelectedValue == null)
                    return null;
                return _databaseComboBox.SelectedValue.ToString();
            }
            set
            {
                if (value == null)
                    _databaseComboBox.SelectedIndex = -1;
                else
                    _databaseComboBox.SelectedValue = value;
            }
        }

        public void Attach(ILoginPresenterCallbacks presenterCallbacks)
        {
            _loginButton.Click += (sender, e) => presenterCallbacks.Ok();
        }
    }
}
