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
using System.Drawing;
using System.Windows.Forms;
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Dto;
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
            _showDeletedCheckBox.CheckedChanged += (sender, e) => presenterCallbacks.Refresh();
            FormClosed += (sender, e) => presenterCallbacks.Close();
            _presenterCallbacks = presenterCallbacks;

            _loanProductsListView.FormatRow += (sender, e) =>
            {
                var loanProduct = (LoanProductDto) e.Model;
                e.Item.BackColor = loanProduct.Deleted ? Color.FromArgb(255, 92, 92) : Color.Transparent;
            };

            _availableForColumn.AspectToStringConverter += AvailabilityToString;
        }

        public void Run()
        {
            Show();
        }

        public void ShowLoanProducts(IEnumerable<LoanProductDto> loanProducts)
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

        public LoanProductDto SelectedLoanProduct
        {
            get { return (LoanProductDto)_loanProductsListView.SelectedObject; }
        }

        public bool ShowDeleted
        {
            get { return _showDeletedCheckBox.Checked; }
        }

        public string AvailabilityToString(object obj)
        {
            var availableFor = (AvailableFor) obj;
            var items = new List<string>();
            if ((availableFor & AvailableFor.Individual) == AvailableFor.Individual)
                items.Add("Ind");
            if ((availableFor & AvailableFor.SolidarityGroup) == AvailableFor.SolidarityGroup)
                items.Add("SG");
            if ((availableFor & AvailableFor.NonSolidarityGroup) == AvailableFor.NonSolidarityGroup)
                items.Add("NSG");
            if ((availableFor & AvailableFor.Company) == AvailableFor.Company)
                items.Add("Company");
            return string.Join(", ", items.ToArray());
        }
    }
}
