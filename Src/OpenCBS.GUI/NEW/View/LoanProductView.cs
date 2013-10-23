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
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Presenter;

namespace OpenCBS.GUI.NEW.View
{
    public partial class LoanProductView : Form, ILoanProductView
    {
        public LoanProductView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Attach(ILoanProductPresenterCallbacks presenterCallbacks)
        {
            _okButton.Click += (sender, e) => presenterCallbacks.Ok();
            _cancelButton.Click += (sender, e) => presenterCallbacks.Cancel();
        }

        public void Stop()
        {
            Close();
        }

        public void ShowPaymentFrequencies(IEnumerable<PaymentFrequency> paymentFrequencies)
        {
            foreach (var frequency in paymentFrequencies)
                _paymentFrequencyComboBox.Items.Add(frequency);
        }

        private static void ShowPolicies(ComboBox comboBox, IEnumerable<string> policies)
        {
            var dict = policies.ToDictionary(policy => policy);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = new BindingSource(dict, null);
        }

        public void ShowSchedulePolicies(IEnumerable<string> schedulePolicies)
        {
            ShowPolicies(_schedulePolicyComboBox, schedulePolicies);
        }

        public void ShowYearPolicies(IEnumerable<string> yearPolicies)
        {
            ShowPolicies(_yearPolicyComboBox, yearPolicies);
        }

        public void ShowDateShiftPolicies(IEnumerable<string> dateShiftPolicies)
        {
            ShowPolicies(_dateShiftPolicyComboBox, dateShiftPolicies);
        }

        public void ShowRoundingPolicies(IEnumerable<string> roundingPolicies)
        {
            ShowPolicies(_roundingPolicyComboBox, roundingPolicies);
        }

        public string LoanProductName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public string Code
        {
            get { return _codeTextBox.Text; }
            set { _codeTextBox.Text = value; }
        }

        public PaymentFrequency PaymentFrequency
        {
            get { return (PaymentFrequency)_paymentFrequencyComboBox.SelectedItem; }
            set { _paymentFrequencyComboBox.SelectedItem = value; }
        }

        public AvailableFor AvailableFor
        {
            get
            {
                var result = AvailableFor.None;
                if (_availableForIndividualCheckBox.Checked) result |= AvailableFor.Individual;
                if (_availableForSgCheckBox.Checked) result |= AvailableFor.SolidarityGroup;
                if (_availableForNsgCheckBox.Checked) result |= AvailableFor.NonSolidarityGroup;
                if (_availableForCompanyCheckBox.Checked) result |= AvailableFor.Company;
                return result;
            }

            set
            {
                _availableForIndividualCheckBox.Checked = (value & AvailableFor.Individual) == AvailableFor.Individual;
                _availableForSgCheckBox.Checked = (value & AvailableFor.SolidarityGroup) == AvailableFor.SolidarityGroup;
                _availableForNsgCheckBox.Checked = (value & AvailableFor.NonSolidarityGroup) == AvailableFor.NonSolidarityGroup;
                _availableForCompanyCheckBox.Checked = (value & AvailableFor.Company) == AvailableFor.Company;
            }
        }

        public string SchedulePolicy
        {
            get { return _schedulePolicyComboBox.SelectedValue.ToString(); }
            set { _schedulePolicyComboBox.SelectedValue = value; }
        }

        public string YearPolicy
        {
            get { return _yearPolicyComboBox.SelectedValue.ToString(); }
            set { _yearPolicyComboBox.SelectedValue = value; }
        }

        public string DateShiftPolicy
        {
            get { return _dateShiftPolicyComboBox.SelectedValue.ToString(); }
            set { _dateShiftPolicyComboBox.SelectedValue = value; }
        }

        public string RoundingPolicy
        {
            get { return _roundingPolicyComboBox.SelectedValue.ToString(); }
            set { _roundingPolicyComboBox.SelectedValue = value; }
        }
    }
}
