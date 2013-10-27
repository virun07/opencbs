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
using OpenCBS.GUI.NEW.View.LoanProduct.Page;

namespace OpenCBS.GUI.NEW.View.LoanProduct
{
    public partial class LoanProductView : Form, ILoanProductView
    {
        private readonly GeneralPage _generalPage;
        private readonly SchedulePage _schedulePage;
        private readonly EntryFeePage _entryFeePage;
        private readonly LateFeePage _lateFeePage;
        private readonly EarlyFeePage _earlyFeePage;
        private readonly LineOfCreditPage _lineOfCreditPage;

        public LoanProductView()
        {
            Font = SystemFonts.MessageBoxFont;
            _generalPage = new GeneralPage { Dock = DockStyle.Fill, Visible = false };
            _schedulePage = new SchedulePage { Dock = DockStyle.Fill, Visible = false };
            _entryFeePage = new EntryFeePage { Dock = DockStyle.Fill, Visible = false };
            _lateFeePage = new LateFeePage { Dock = DockStyle.Fill, Visible = false };
            _earlyFeePage = new EarlyFeePage { Dock = DockStyle.Fill, Visible = false };
            _lineOfCreditPage = new LineOfCreditPage { Dock = DockStyle.Fill, Visible = false };
            Controls.Add(_generalPage);
            Controls.Add(_schedulePage);
            Controls.Add(_entryFeePage);
            Controls.Add(_lateFeePage);
            Controls.Add(_earlyFeePage);
            Controls.Add(_lineOfCreditPage);
            InitializeComponent();
        }

        public void Run()
        {
            //            _nameTextBox.TextChanged += ClearError;
            //            _codeTextBox.TextChanged += ClearError;
            //            _schedulePolicyComboBox.SelectedIndexChanged += ClearError;
            //            _paymentFrequencyComboBox.SelectedIndexChanged += ClearError;
            //            _yearPolicyComboBox.SelectedIndexChanged += ClearError;
            //            _dateShiftPolicyComboBox.SelectedIndexChanged += ClearError;
            //            _roundingPolicyComboBox.SelectedIndexChanged += ClearError;
            //            _amountRange.MinMaxChanged += ClearError;
            //            _interestRateRange.MinMaxChanged += ClearError;
            //            _maturityRange.MinMaxChanged += ClearError;
            //            _gracePeriodRange.MinMaxChanged += ClearError;
            InitPages();
            ShowDialog();
        }

        private void InitPages()
        {
            var generalNode = new TreeNode("General") { Tag = _generalPage };
            _pageTreeView.Nodes.Add(generalNode);
            var scheduleNode = new TreeNode("Schedule") { Tag = _schedulePage };
            _pageTreeView.Nodes.Add(scheduleNode);
            var entryFeeNode = new TreeNode("Entry fee") { Tag = _entryFeePage };
            _pageTreeView.Nodes.Add(entryFeeNode);
            var lateFeeNode = new TreeNode("Late fee") { Tag = _lateFeePage };
            _pageTreeView.Nodes.Add(lateFeeNode);
            var earlyFeeNode = new TreeNode("Early fee") { Tag = _earlyFeePage };
            _pageTreeView.Nodes.Add(earlyFeeNode);
            var lineOfCreditNode = new TreeNode("Line of Credit") { Tag = _lineOfCreditPage };
            _pageTreeView.Nodes.Add(lineOfCreditNode);
            _pageTreeView.AfterSelect += (sender, e) => ChangePage();
        }

        private void ChangePage()
        {
            _generalPage.Visible = false;
            _schedulePage.Visible = false;
            _entryFeePage.Visible = false;
            _lateFeePage.Visible = false;
            _earlyFeePage.Visible = false;
            _lineOfCreditPage.Visible = false;
            var selectedNode = _pageTreeView.SelectedNode;
            if (selectedNode == null)
            {
                _generalPage.Visible = true;
                return;
            }
            _captionLabel.Text = selectedNode.Text;
            var page = selectedNode.Tag as System.Windows.Forms.UserControl;
            if (page == null)
            {
                _generalPage.Visible = true;
                return;
            }
            page.Visible = true;
        }

        private void ClearError(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            _errorProvider.SetError(control, null);
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

        public void ShowPaymentFrequencyPolicies(IEnumerable<string> paymentFrequencyPolicies)
        {
            //            ShowPolicies(_paymentFrequencyComboBox, paymentFrequencyPolicies);
        }

        public void ShowSchedulePolicies(IEnumerable<string> schedulePolicies)
        {
            //            ShowPolicies(_schedulePolicyComboBox, schedulePolicies);
        }

        public void ShowYearPolicies(IEnumerable<string> yearPolicies)
        {
            //            ShowPolicies(_yearPolicyComboBox, yearPolicies);
        }

        public void ShowDateShiftPolicies(IEnumerable<string> dateShiftPolicies)
        {
            //            ShowPolicies(_dateShiftPolicyComboBox, dateShiftPolicies);
        }

        public void ShowRoundingPolicies(IEnumerable<string> roundingPolicies)
        {
            //            ShowPolicies(_roundingPolicyComboBox, roundingPolicies);
        }

        public void ShowNotification(Notification notification)
        {
            this.ShowNotification(notification, _errorProvider);
        }

        public string LoanProductName
        {
            //            get { return _nameTextBox.Text; }
            //            set { _nameTextBox.Text = value; }
            get;
            set;
        }

        public string Code
        {
            //            get { return _codeTextBox.Text; }
            //            set { _codeTextBox.Text = value; }
            get;
            set;
        }

        public AvailableFor AvailableFor
        {
            //            get
            //            {
            //                var result = AvailableFor.None;
            //                if (_availableForIndividualCheckBox.Checked) result |= AvailableFor.Individual;
            //                if (_availableForSgCheckBox.Checked) result |= AvailableFor.SolidarityGroup;
            //                if (_availableForNsgCheckBox.Checked) result |= AvailableFor.NonSolidarityGroup;
            //                if (_availableForCompanyCheckBox.Checked) result |= AvailableFor.Company;
            //                return result;
            //            }
            //
            //            set
            //            {
            //                _availableForIndividualCheckBox.Checked = (value & AvailableFor.Individual) == AvailableFor.Individual;
            //                _availableForSgCheckBox.Checked = (value & AvailableFor.SolidarityGroup) == AvailableFor.SolidarityGroup;
            //                _availableForNsgCheckBox.Checked = (value & AvailableFor.NonSolidarityGroup) == AvailableFor.NonSolidarityGroup;
            //                _availableForCompanyCheckBox.Checked = (value & AvailableFor.Company) == AvailableFor.Company;
            //            }
            get;
            set;
        }

        public string PaymentFrequencyPolicy
        {
            //            get
            //            {
            //                if (_paymentFrequencyComboBox.SelectedValue == null) return null;
            //                return _paymentFrequencyComboBox.SelectedValue.ToString();
            //            }
            //            set { _paymentFrequencyComboBox.SelectedValue = value; }
            get;
            set;
        }

        public string SchedulePolicy
        {
            //            get
            //            {
            //                if (_schedulePolicyComboBox.SelectedValue == null) return null;
            //                return _schedulePolicyComboBox.SelectedValue.ToString();
            //            }
            //            set { _schedulePolicyComboBox.SelectedValue = value; }
            get;
            set;
        }

        public string YearPolicy
        {
            //            get
            //            {
            //                if (_yearPolicyComboBox.SelectedValue == null) return null;
            //                return _yearPolicyComboBox.SelectedValue.ToString();
            //            }
            //            set { _yearPolicyComboBox.SelectedValue = value; }
            get;
            set;
        }

        public string DateShiftPolicy
        {
            //            get
            //            {
            //                if (_dateShiftPolicyComboBox.SelectedValue == null) return null;
            //                return _dateShiftPolicyComboBox.SelectedValue.ToString();
            //            }
            //            set { _dateShiftPolicyComboBox.SelectedValue = value; }
            get;
            set;
        }

        public string RoundingPolicy
        {
            //            get
            //            {
            //                if (_roundingPolicyComboBox.SelectedValue == null) return null;
            //                return _roundingPolicyComboBox.SelectedValue.ToString();
            //            }
            //            set { _roundingPolicyComboBox.SelectedValue = value; }
            get;
            set;
        }

        public decimal? AmountMin
        {
            //            get { return _amountRange.Min; }
            //            set { _amountRange.Min = value; }
            get;
            set;
        }

        public decimal? AmountMax
        {
            //            get { return _amountRange.Max; }
            //            set { _amountRange.Max = value; }
            get;
            set;
        }

        public decimal? InterestRateMin
        {
            //            get { return _interestRateRange.Min; }
            //            set { _interestRateRange.Min = value; }
            get;
            set;
        }

        public decimal? InterestRateMax
        {
            //            get { return _interestRateRange.Max; }
            //            set { _interestRateRange.Max = value; }
            get;
            set;
        }

        public int? MaturityMin
        {
            //            get { return (int?)_maturityRange.Min; }
            //            set { _maturityRange.Min = value; }
            get;
            set;
        }

        public int? MaturityMax
        {
            //            get { return (int?)_maturityRange.Max; }
            //            set { _maturityRange.Max = value; }
            get;
            set;
        }

        public int? GracePeriodMin
        {
            //            get { return (int?)_gracePeriodRange.Min; }
            //            set { _gracePeriodRange.Min = value; }
            get;
            set;
        }

        public int? GracePeriodMax
        {
            //            get { return (int?) _gracePeriodRange.Max; }
            //            set { _gracePeriodRange.Max = value; }
            get;
            set;
        }
    }
}
