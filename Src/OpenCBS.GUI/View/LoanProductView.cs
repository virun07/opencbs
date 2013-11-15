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
using OpenCBS.Common;
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class LoanProductView : BaseView, ILoanProductView
    {
        private ILoanProductPresenterCallbacks _presenterCallbacks;

        public LoanProductView(ITranslator translator)
            : base(translator)
        {
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
            _addEntryFeeButton.Click += (sender, e) => presenterCallbacks.AddEntryFee();
            _deleteEntryFeeButton.Click += (sender, e) => presenterCallbacks.RemoveEntryFee();
            _entryFeesListView.SelectedIndexChanged += (sender, e) => presenterCallbacks.ChangeSelectedEntryFee();
            FormClosed += (sender, e) => presenterCallbacks.Close();
            _presenterCallbacks = presenterCallbacks;
        }

        public void Stop()
        {
            Close();
        }

        private void ShowPolicies(ComboBox comboBox, IEnumerable<string> policies)
        {
            var dict = policies.ToDictionary(policy => policy, _);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = new BindingSource(dict, null);
            comboBox.SelectedIndex = -1;
        }

        public void ShowPaymentFrequencyPolicies(IList<string> policies)
        {
            ShowPolicies(_paymentFrequencyPolicyComboBox, policies);
        }

        public void ShowSchedulePolicies(IList<string> policies)
        {
            ShowPolicies(_schedulePolicyComboBox, policies);
        }

        public void ShowYearPolicies(IList<string> policies)
        {
            ShowPolicies(_yearPolicyComboBox, policies);
        }

        public void ShowDateShiftPolicies(IList<string> policies)
        {
            ShowPolicies(_dateShiftPolicyComboBox, policies);
        }

        public void ShowRoundingPolicies(IList<string> policies)
        {
            ShowPolicies(_roundingPolicyComboBox, policies);
        }

        public void ShowCurrencies(Dictionary<int, string> currencies)
        {
            _currencyComboBox.DisplayMember = "Value";
            _currencyComboBox.ValueMember = "Key";
            _currencyComboBox.DataSource = new BindingSource(currencies, null);
            _currencyComboBox.SelectedIndex = -1;
        }

        public void ShowLateFeePolicies(IList<string> policies)
        {
            ShowPolicies(_lateFeePolicyComboBox, policies);
        }

        public int Id { get; set; }

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

        public IList<EntryFeeDto> EntryFees
        {
            get { return (IList<EntryFeeDto>) _entryFeesListView.Objects; }
            set
            {
                var selectedObject = _entryFeesListView.SelectedObject;
                _entryFeesListView.SetObjects(value);
                _entryFeesListView.SelectedObject = selectedObject;
                _presenterCallbacks.ChangeSelectedEntryFee();
            }
        }

        private void Setup()
        {
            _rateAmountColumn.AspectToStringConverter = v =>
            {
                var rate = (bool) v;
                return rate ? _("Rate") : _("Amount");
            };
        }

        public bool CanRemoveEntryFee
        {
            get { return _deleteEntryFeeButton.Enabled; }
            set { _deleteEntryFeeButton.Enabled = value; }
        }

        public int? SelectedEntryFeeId
        {
            get
            {
                var entryFee = (EntryFeeDto) _entryFeesListView.SelectedObject;
                return entryFee != null ? entryFee.Id : (int?) null;
            }
        }

        public decimal? LateFeeAmountRateMin
        {
            get { return _lateFeeAmountRateRange.Min; }
            set { _lateFeeAmountRateRange.Min = value; }
        }

        public decimal? LateFeeAmountRateMax
        {
            get { return _lateFeeAmountRateRange.Max; }
            set { _lateFeeAmountRateRange.Max = value; }
        }

        public decimal? LateFeeOlbRateMin
        {
            get { return _lateFeeOlbRateRange.Min; }
            set { _lateFeeOlbRateRange.Min = value; }
        }

        public decimal? LateFeeOlbRateMax
        {
            get { return _lateFeeOlbRateRange.Max; }
            set { _lateFeeOlbRateRange.Max = value; }
        }

        public decimal? LateFeeLatePrincipalRateMin
        {
            get { return _lateFeeLatePrincipalRateRange.Min; }
            set { _lateFeeLatePrincipalRateRange.Min = value; }
        }

        public decimal? LateFeeLatePrincipalRateMax
        {
            get { return _lateFeeLatePrincipalRateRange.Max; }
            set { _lateFeeLatePrincipalRateRange.Max = value; }
        }

        public decimal? LateFeeLateInterestRateMin
        {
            get { return _lateFeeLateInterestRateRange.Min; }
            set { _lateFeeLateInterestRateRange.Min = value; }
        }

        public decimal? LateFeeLateInterestRateMax
        {
            get { return _lateFeeLateInterestRateRange.Max; }
            set { _lateFeeLateInterestRateRange.Max = value; }
        }

        public int? LateFeeGracePeriod
        {
            get { return (int?) _lateFeeGracePeriodTextBox.Amount; }
            set { _lateFeeGracePeriodTextBox.Amount = value; }
        }

        public string LateFeePolicy
        {
            get
            {
                if (_lateFeePolicyComboBox.SelectedValue == null) return null;
                return _lateFeePolicyComboBox.SelectedValue.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _lateFeePolicyComboBox.SelectedIndex = -1;
                else
                    _lateFeePolicyComboBox.SelectedValue = value;
            }
        }
    }
}
