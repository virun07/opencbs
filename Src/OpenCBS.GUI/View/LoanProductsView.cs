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
using OpenCBS.Common;
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class LoanProductsView : CollectionView, ILoanProductsView
    {
        private ILoanProductsPresenterCallbacks _presenterCallbacks;

        public LoanProductsView(ITranslator translator)
            : base(translator)
        {
            InitializeComponent();
            MdiParent = Application.OpenForms[0];
            Setup();
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

        public int? SelectedLoanProductId
        {
            get
            {
                var loanProductDto = (LoanProductDto) _loanProductsListView.SelectedObject;
                if (loanProductDto == null) return null;
                return loanProductDto.Id;
            }
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
                items.Add(_("Ind"));
            if ((availableFor & AvailableFor.SolidarityGroup) == AvailableFor.SolidarityGroup)
                items.Add(_("SG"));
            if ((availableFor & AvailableFor.NonSolidarityGroup) == AvailableFor.NonSolidarityGroup)
                items.Add(_("NSG"));
            if ((availableFor & AvailableFor.Company) == AvailableFor.Company)
                items.Add(_("Company"));
            return string.Join(", ", items.ToArray());
        }

        private void Setup()
        {
            _availableForColumn.AspectToStringConverter += AvailabilityToString;
            _schedulePolicyColumn.AspectToStringConverter =
            _paymentFrequencyPolicyColumn.AspectToStringConverter = 
            _yearPolicyColumn.AspectToStringConverter =
            _dateShiftPolicyColumn.AspectToStringConverter =
            _roundingPolicyColumn.AspectToStringConverter = v =>
            {
                var key = (string) v;
                return _(key);
            };
        }
    }
}
