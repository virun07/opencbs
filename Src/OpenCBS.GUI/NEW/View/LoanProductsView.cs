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
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Presenter;

namespace OpenCBS.GUI.NEW.View
{
    public partial class LoanProductsView : Form, ILoanProductsView
    {
        private ILoanProductsPresenterCallbacks _presenterCallbacks;

        public LoanProductsView()
        {
            InitializeComponent();
            MdiParent = Application.OpenForms[0];
        }

        public void Attach(ILoanProductsPresenterCallbacks presenterCallbacks)
        {
            _addButton.Click += (sender, e) => presenterCallbacks.Add();
            _editButton.Click += (sender, e) => presenterCallbacks.Edit();
            _deleteButton.Click += (sender, e) => presenterCallbacks.Delete();
            _loanProductsListView.SelectionChanged += (sender, e) => presenterCallbacks.ChangeSelection();
            FormClosed += (sender, e) => presenterCallbacks.Close();
            _presenterCallbacks = presenterCallbacks;
        }

        public void Run()
        {
            Show();
        }

        public void ShowLoanProducts(IEnumerable<LoanProduct> loanProducts)
        {
            var selectedObject = _loanProductsListView.SelectedObject;
            _loanProductsListView.SetObjects(loanProducts);
            _presenterCallbacks.ChangeSelection();
            _loanProductsListView.SelectedObject = selectedObject;
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

        public LoanProduct SelectedLoanProduct
        {
            get { return (LoanProduct)_loanProductsListView.SelectedObject; }
        }
    }
}
