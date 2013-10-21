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
using OpenCBS.Engine.Interfaces;
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

        public void ShowSchedulePolicies(IEnumerable<IInstallmentCalculationPolicy> schedulePolicies)
        {
            foreach (var policy in schedulePolicies)
                _schedulePolicyComboBox.Items.Add(policy);
        }

        public void ShowYearPolicies(IEnumerable<IYearPolicy> yearPolicies)
        {
            foreach (var policy in yearPolicies)
                _yearPolicyComboBox.Items.Add(policy);
        }

        public void ShowDateShiftPolicies(IEnumerable<IDateShiftPolicy> dateShiftPolicies)
        {
            foreach (var policy in dateShiftPolicies)
                _dateShiftPolicyComboBox.Items.Add(policy);
        }

        public void ShowRoundingPolicies(IEnumerable<IRoundingPolicy> roundingPolicies)
        {
            foreach (var policy in roundingPolicies)
                _roundingPolicyComboBox.Items.Add(policy);
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

        public IInstallmentCalculationPolicy SchedulePolicy
        {
            get { return (IInstallmentCalculationPolicy) _schedulePolicyComboBox.SelectedItem; }
            set { _schedulePolicyComboBox.SelectedItem = value; }
        }

        public IYearPolicy YearPolicy
        {
            get { return (IYearPolicy) _yearPolicyComboBox.SelectedItem; }
            set { _yearPolicyComboBox.SelectedItem = value; }
        }

        public IDateShiftPolicy DateShiftPolicy
        {
            get { return (IDateShiftPolicy) _dateShiftPolicyComboBox.SelectedItem; }
            set { _dateShiftPolicyComboBox.SelectedItem = value; }
        }

        public IRoundingPolicy RoundingPolicy
        {
            get { return (IRoundingPolicy) _roundingPolicyComboBox.SelectedItem; }
            set { _roundingPolicyComboBox.SelectedItem = value; }
        }
    }
}
