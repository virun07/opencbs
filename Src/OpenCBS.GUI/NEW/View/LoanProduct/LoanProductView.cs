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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.GUI.NEW.Dto;
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Presenter;

namespace OpenCBS.GUI.NEW.View.LoanProduct
{
    public partial class LoanProductView : Form, ILoanProductView
    {
        public LoanProductView()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            Setup();
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

        private static void ShowPolicies(ComboBox comboBox, IEnumerable<string> policies)
        {
            var dict = policies.ToDictionary(policy => policy);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = new BindingSource(dict, null);
            comboBox.SelectedIndex = -1;
        }

        private void Setup()
        {
            _nameTextBox.TextChanged += ClearError;
            _codeTextBox.TextChanged += ClearError;
            _currencyComboBox.SelectedIndexChanged += ClearError;
            _schedulePolicyComboBox.SelectedIndexChanged += ClearError;
            _paymentFrequencyPolicyComboBox.SelectedIndexChanged += ClearError;
            _yearPolicyComboBox.SelectedIndexChanged += ClearError;
            _dateShiftPolicyComboBox.SelectedIndexChanged += ClearError;
            _roundingPolicyComboBox.SelectedIndexChanged += ClearError;
            _amountRange.MinMaxChanged += ClearError;
            _interestRateRange.MinMaxChanged += ClearError;
            _maturityRange.MinMaxChanged += ClearError;
            _gracePeriodRange.MinMaxChanged += ClearError;
            _currencyComboBox.SelectedIndexChanged += ClearError;
        }

        private void ClearError(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            _errorProvider.SetError(control, null);
        }

        public void ShowPaymentFrequencyPolicies(IList<string> paymentFrequencyPolicies)
        {
            ShowPolicies(_paymentFrequencyPolicyComboBox, paymentFrequencyPolicies);
        }

        public void ShowSchedulePolicies(IList<string> schedulePolicies)
        {
            ShowPolicies(_schedulePolicyComboBox, schedulePolicies);
        }

        public void ShowYearPolicies(IList<string> yearPolicies)
        {
            ShowPolicies(_yearPolicyComboBox, yearPolicies);
        }

        public void ShowDateShiftPolicies(IList<string> dateShiftPolicies)
        {
            ShowPolicies(_dateShiftPolicyComboBox, dateShiftPolicies);
        }

        public void ShowRoundingPolicies(IList<string> roundingPolicies)
        {
            ShowPolicies(_roundingPolicyComboBox, roundingPolicies);
        }

        public void ShowCurrencies(Dictionary<int, string> currencies)
        {
            _currencyComboBox.DisplayMember = "Value";
            _currencyComboBox.ValueMember = "Key";
            _currencyComboBox.DataSource = new BindingSource(currencies, null);
            _currencyComboBox.SelectedIndex = -1;
        }

        public void ShowNotification(Notification notification)
        {
            this.ShowNotification(notification, _errorProvider);
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

        public string PaymentFrequencyPolicy
        {
            get
            {
                if (_paymentFrequencyPolicyComboBox.SelectedValue == null) return null;
                return _paymentFrequencyPolicyComboBox.SelectedValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _paymentFrequencyPolicyComboBox.SelectedIndex = -1;
                else
                    _paymentFrequencyPolicyComboBox.SelectedValue = value;
            }
        }

        public string SchedulePolicy
        {
            get
            {
                if (_schedulePolicyComboBox.SelectedValue == null) return null;
                return _schedulePolicyComboBox.SelectedValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _schedulePolicyComboBox.SelectedIndex = -1;
                else
                    _schedulePolicyComboBox.SelectedValue = value;
            }
        }

        public string YearPolicy
        {
            get
            {
                if (_yearPolicyComboBox.SelectedValue == null) return null;
                return _yearPolicyComboBox.SelectedValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _yearPolicyComboBox.SelectedIndex = -1;
                else
                    _yearPolicyComboBox.SelectedValue = value;
            }
        }

        public string DateShiftPolicy
        {
            get
            {
                if (_dateShiftPolicyComboBox.SelectedValue == null) return null;
                return _dateShiftPolicyComboBox.SelectedValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _dateShiftPolicyComboBox.SelectedIndex = -1;
                else
                    _dateShiftPolicyComboBox.SelectedValue = value;
            }
        }

        public string RoundingPolicy
        {
            get
            {
                if (_roundingPolicyComboBox.SelectedValue == null) return null;
                return _roundingPolicyComboBox.SelectedValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _roundingPolicyComboBox.SelectedIndex = -1;
                else
                    _roundingPolicyComboBox.SelectedValue = value;
            }
        }

        public decimal? AmountMin
        {
            get { return _amountRange.Min; }
            set { _amountRange.Min = value; }
        }

        public decimal? AmountMax
        {
            get { return _amountRange.Max; }
            set { _amountRange.Max = value; }
        }

        public decimal? InterestRateMin
        {
            get { return _interestRateRange.Min; }
            set { _interestRateRange.Min = value; }
        }

        public decimal? InterestRateMax
        {
            get { return _interestRateRange.Max; }
            set { _interestRateRange.Max = value; }
        }

        public int? MaturityMin
        {
            get { return (int?) _maturityRange.Min; }
            set { _maturityRange.Min = value; }
        }

        public int? MaturityMax
        {
            get { return (int?) _maturityRange.Max; }
            set { _maturityRange.Max = value; }
        }

        public int? GracePeriodMin
        {
            get { return (int?) _gracePeriodRange.Min; }
            set { _gracePeriodRange.Min = value; }
        }

        public int? GracePeriodMax
        {
            get { return (int?) _gracePeriodRange.Max; }
            set { _gracePeriodRange.Max = value; }
        }

        public bool ChargeInterestDuringGracePeriod
        {
            get { return _chargeInterestDuringGracePeriodCheckBox.Checked; }
            set { _chargeInterestDuringGracePeriodCheckBox.Checked = value; }
        }

        public int? CurrencyId
        {
            get
            {
                if (_currencyComboBox.SelectedValue == null) return null;
                return (int?) _currencyComboBox.SelectedValue;
            }
            set
            {
                if (value == null)
                    _currencyComboBox.SelectedIndex = -1;
                else 
                    _currencyComboBox.SelectedValue = value;
            }
        }
    }
}
