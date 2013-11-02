using OpenCBS.GUI.NEW.View;

namespace OpenCBS.GUI.View
{
    partial class LoanProductView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._tabList = new Cyotek.Windows.Forms.TabList();
            this._generalTabListPage = new Cyotek.Windows.Forms.TabListPage();
            this._currencyComboBox = new System.Windows.Forms.ComboBox();
            this._currencyLabel = new System.Windows.Forms.Label();
            this._availableForCompanyCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForNsgCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForSgCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForIndividualCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForLabel = new System.Windows.Forms.Label();
            this._codeTextBox = new System.Windows.Forms.TextBox();
            this._codeLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._scheduleTabListPage = new Cyotek.Windows.Forms.TabListPage();
            this._chargeInterestDuringGracePeriodCheckBox = new System.Windows.Forms.CheckBox();
            this._gracePeriodRange = new OpenCBS.Controls.RangeControl();
            this._gracePeriodLabel = new System.Windows.Forms.Label();
            this._maturityRange = new OpenCBS.Controls.RangeControl();
            this._interestRateRange = new OpenCBS.Controls.RangeControl();
            this._amountRange = new OpenCBS.Controls.RangeControl();
            this._maturityLabel = new System.Windows.Forms.Label();
            this._interestRateLabel = new System.Windows.Forms.Label();
            this._amountLabel = new System.Windows.Forms.Label();
            this._roundingPolicyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._dateShiftPolicyComboBox = new System.Windows.Forms.ComboBox();
            this._dateShiftPolicyLabel = new System.Windows.Forms.Label();
            this._yearPolicyComboBox = new System.Windows.Forms.ComboBox();
            this._yearPolicyLabel = new System.Windows.Forms.Label();
            this._paymentFrequencyPolicyComboBox = new System.Windows.Forms.ComboBox();
            this._paymentFrequencyLabel = new System.Windows.Forms.Label();
            this._schedulePolicyComboBox = new System.Windows.Forms.ComboBox();
            this._schedulePolicyLabel = new System.Windows.Forms.Label();
            this._entryFeesTabListPage = new Cyotek.Windows.Forms.TabListPage();
            this._entryFeesListView = new BrightIdeasSoftware.ObjectListView();
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._valueMinColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._valueMaxColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._rateAmountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._entryFeesButtonPanel = new System.Windows.Forms.Panel();
            this._removeEntryFeeButton = new System.Windows.Forms.Button();
            this._addEntryFeeButton = new System.Windows.Forms.Button();
            this._buttonsPanel = new OpenCBS.GUI.NEW.View.TopEdgePanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._tabList.SuspendLayout();
            this._generalTabListPage.SuspendLayout();
            this._scheduleTabListPage.SuspendLayout();
            this._entryFeesTabListPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._entryFeesListView)).BeginInit();
            this._entryFeesButtonPanel.SuspendLayout();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _tabList
            // 
            this._tabList.Controls.Add(this._generalTabListPage);
            this._tabList.Controls.Add(this._scheduleTabListPage);
            this._tabList.Controls.Add(this._entryFeesTabListPage);
            this._tabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabList.Location = new System.Drawing.Point(0, 0);
            this._tabList.Name = "_tabList";
            this._tabList.Size = new System.Drawing.Size(699, 342);
            this._tabList.TabIndex = 5;
            // 
            // _generalTabListPage
            // 
            this._generalTabListPage.Controls.Add(this._currencyComboBox);
            this._generalTabListPage.Controls.Add(this._currencyLabel);
            this._generalTabListPage.Controls.Add(this._availableForCompanyCheckBox);
            this._generalTabListPage.Controls.Add(this._availableForNsgCheckBox);
            this._generalTabListPage.Controls.Add(this._availableForSgCheckBox);
            this._generalTabListPage.Controls.Add(this._availableForIndividualCheckBox);
            this._generalTabListPage.Controls.Add(this._availableForLabel);
            this._generalTabListPage.Controls.Add(this._codeTextBox);
            this._generalTabListPage.Controls.Add(this._codeLabel);
            this._generalTabListPage.Controls.Add(this._nameTextBox);
            this._generalTabListPage.Controls.Add(this._nameLabel);
            this._generalTabListPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._generalTabListPage.Name = "_generalTabListPage";
            this._generalTabListPage.Size = new System.Drawing.Size(541, 334);
            this._generalTabListPage.TabIndex = 0;
            this._generalTabListPage.Text = "General";
            // 
            // _currencyComboBox
            // 
            this._currencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._currencyComboBox.FormattingEnabled = true;
            this._currencyComboBox.Location = new System.Drawing.Point(14, 132);
            this._currencyComboBox.Name = "_currencyComboBox";
            this._currencyComboBox.Size = new System.Drawing.Size(174, 23);
            this._currencyComboBox.TabIndex = 6;
            this._currencyComboBox.Tag = "CurrencyId";
            // 
            // _currencyLabel
            // 
            this._currencyLabel.AutoSize = true;
            this._currencyLabel.Location = new System.Drawing.Point(14, 111);
            this._currencyLabel.Name = "_currencyLabel";
            this._currencyLabel.Size = new System.Drawing.Size(55, 15);
            this._currencyLabel.TabIndex = 5;
            this._currencyLabel.Text = "Currency";
            // 
            // _availableForCompanyCheckBox
            // 
            this._availableForCompanyCheckBox.AutoSize = true;
            this._availableForCompanyCheckBox.Location = new System.Drawing.Point(253, 93);
            this._availableForCompanyCheckBox.Name = "_availableForCompanyCheckBox";
            this._availableForCompanyCheckBox.Size = new System.Drawing.Size(78, 19);
            this._availableForCompanyCheckBox.TabIndex = 11;
            this._availableForCompanyCheckBox.Text = "Company";
            this._availableForCompanyCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForNsgCheckBox
            // 
            this._availableForNsgCheckBox.AutoSize = true;
            this._availableForNsgCheckBox.Location = new System.Drawing.Point(253, 72);
            this._availableForNsgCheckBox.Name = "_availableForNsgCheckBox";
            this._availableForNsgCheckBox.Size = new System.Drawing.Size(137, 19);
            this._availableForNsgCheckBox.TabIndex = 10;
            this._availableForNsgCheckBox.Text = "Non-solidarity group";
            this._availableForNsgCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForSgCheckBox
            // 
            this._availableForSgCheckBox.AutoSize = true;
            this._availableForSgCheckBox.Location = new System.Drawing.Point(253, 50);
            this._availableForSgCheckBox.Name = "_availableForSgCheckBox";
            this._availableForSgCheckBox.Size = new System.Drawing.Size(110, 19);
            this._availableForSgCheckBox.TabIndex = 9;
            this._availableForSgCheckBox.Text = "Solidarity group";
            this._availableForSgCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForIndividualCheckBox
            // 
            this._availableForIndividualCheckBox.AutoSize = true;
            this._availableForIndividualCheckBox.Location = new System.Drawing.Point(253, 28);
            this._availableForIndividualCheckBox.Name = "_availableForIndividualCheckBox";
            this._availableForIndividualCheckBox.Size = new System.Drawing.Size(71, 19);
            this._availableForIndividualCheckBox.TabIndex = 8;
            this._availableForIndividualCheckBox.Text = "Individal";
            this._availableForIndividualCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForLabel
            // 
            this._availableForLabel.AutoSize = true;
            this._availableForLabel.Location = new System.Drawing.Point(250, 7);
            this._availableForLabel.Name = "_availableForLabel";
            this._availableForLabel.Size = new System.Drawing.Size(73, 15);
            this._availableForLabel.TabIndex = 7;
            this._availableForLabel.Text = "Available for";
            // 
            // _codeTextBox
            // 
            this._codeTextBox.Location = new System.Drawing.Point(14, 78);
            this._codeTextBox.Name = "_codeTextBox";
            this._codeTextBox.Size = new System.Drawing.Size(174, 23);
            this._codeTextBox.TabIndex = 4;
            this._codeTextBox.Tag = "Code";
            // 
            // _codeLabel
            // 
            this._codeLabel.AutoSize = true;
            this._codeLabel.Location = new System.Drawing.Point(14, 60);
            this._codeLabel.Name = "_codeLabel";
            this._codeLabel.Size = new System.Drawing.Size(35, 15);
            this._codeLabel.TabIndex = 3;
            this._codeLabel.Text = "Code";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(14, 25);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(174, 23);
            this._nameTextBox.TabIndex = 2;
            this._nameTextBox.Tag = "Name";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(14, 7);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 1;
            this._nameLabel.Text = "Name";
            // 
            // _scheduleTabListPage
            // 
            this._scheduleTabListPage.Controls.Add(this._chargeInterestDuringGracePeriodCheckBox);
            this._scheduleTabListPage.Controls.Add(this._gracePeriodRange);
            this._scheduleTabListPage.Controls.Add(this._gracePeriodLabel);
            this._scheduleTabListPage.Controls.Add(this._maturityRange);
            this._scheduleTabListPage.Controls.Add(this._interestRateRange);
            this._scheduleTabListPage.Controls.Add(this._amountRange);
            this._scheduleTabListPage.Controls.Add(this._maturityLabel);
            this._scheduleTabListPage.Controls.Add(this._interestRateLabel);
            this._scheduleTabListPage.Controls.Add(this._amountLabel);
            this._scheduleTabListPage.Controls.Add(this._roundingPolicyComboBox);
            this._scheduleTabListPage.Controls.Add(this.label1);
            this._scheduleTabListPage.Controls.Add(this._dateShiftPolicyComboBox);
            this._scheduleTabListPage.Controls.Add(this._dateShiftPolicyLabel);
            this._scheduleTabListPage.Controls.Add(this._yearPolicyComboBox);
            this._scheduleTabListPage.Controls.Add(this._yearPolicyLabel);
            this._scheduleTabListPage.Controls.Add(this._paymentFrequencyPolicyComboBox);
            this._scheduleTabListPage.Controls.Add(this._paymentFrequencyLabel);
            this._scheduleTabListPage.Controls.Add(this._schedulePolicyComboBox);
            this._scheduleTabListPage.Controls.Add(this._schedulePolicyLabel);
            this._scheduleTabListPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scheduleTabListPage.Name = "_scheduleTabListPage";
            this._scheduleTabListPage.Size = new System.Drawing.Size(42, 192);
            this._scheduleTabListPage.TabIndex = 1;
            this._scheduleTabListPage.Text = "Schedule";
            // 
            // _chargeInterestDuringGracePeriodCheckBox
            // 
            this._chargeInterestDuringGracePeriodCheckBox.AutoSize = true;
            this._chargeInterestDuringGracePeriodCheckBox.Location = new System.Drawing.Point(253, 212);
            this._chargeInterestDuringGracePeriodCheckBox.Name = "_chargeInterestDuringGracePeriodCheckBox";
            this._chargeInterestDuringGracePeriodCheckBox.Size = new System.Drawing.Size(106, 19);
            this._chargeInterestDuringGracePeriodCheckBox.TabIndex = 48;
            this._chargeInterestDuringGracePeriodCheckBox.Text = "Charge interest";
            this._chargeInterestDuringGracePeriodCheckBox.UseVisualStyleBackColor = true;
            // 
            // _gracePeriodRange
            // 
            this._gracePeriodRange.AllowDecimalSeparator = false;
            this._gracePeriodRange.AutoSize = true;
            this._gracePeriodRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._gracePeriodRange.Location = new System.Drawing.Point(250, 185);
            this._gracePeriodRange.Margin = new System.Windows.Forms.Padding(0);
            this._gracePeriodRange.Max = null;
            this._gracePeriodRange.Min = null;
            this._gracePeriodRange.Name = "_gracePeriodRange";
            this._gracePeriodRange.Size = new System.Drawing.Size(155, 23);
            this._gracePeriodRange.TabIndex = 46;
            this._gracePeriodRange.Tag = "GracePeriod";
            // 
            // _gracePeriodLabel
            // 
            this._gracePeriodLabel.AutoSize = true;
            this._gracePeriodLabel.Location = new System.Drawing.Point(250, 166);
            this._gracePeriodLabel.Name = "_gracePeriodLabel";
            this._gracePeriodLabel.Size = new System.Drawing.Size(74, 15);
            this._gracePeriodLabel.TabIndex = 47;
            this._gracePeriodLabel.Text = "Grace period";
            // 
            // _maturityRange
            // 
            this._maturityRange.AllowDecimalSeparator = false;
            this._maturityRange.AutoSize = true;
            this._maturityRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._maturityRange.Location = new System.Drawing.Point(250, 132);
            this._maturityRange.Margin = new System.Windows.Forms.Padding(0);
            this._maturityRange.Max = null;
            this._maturityRange.Min = null;
            this._maturityRange.Name = "_maturityRange";
            this._maturityRange.Size = new System.Drawing.Size(155, 23);
            this._maturityRange.TabIndex = 44;
            this._maturityRange.Tag = "Maturity";
            // 
            // _interestRateRange
            // 
            this._interestRateRange.AllowDecimalSeparator = true;
            this._interestRateRange.AutoSize = true;
            this._interestRateRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._interestRateRange.Location = new System.Drawing.Point(250, 78);
            this._interestRateRange.Margin = new System.Windows.Forms.Padding(0);
            this._interestRateRange.Max = null;
            this._interestRateRange.Min = null;
            this._interestRateRange.Name = "_interestRateRange";
            this._interestRateRange.Size = new System.Drawing.Size(155, 23);
            this._interestRateRange.TabIndex = 42;
            this._interestRateRange.Tag = "InterestRate";
            // 
            // _amountRange
            // 
            this._amountRange.AllowDecimalSeparator = true;
            this._amountRange.AutoSize = true;
            this._amountRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._amountRange.Location = new System.Drawing.Point(250, 25);
            this._amountRange.Margin = new System.Windows.Forms.Padding(0);
            this._amountRange.Max = null;
            this._amountRange.Min = null;
            this._amountRange.Name = "_amountRange";
            this._amountRange.Size = new System.Drawing.Size(155, 23);
            this._amountRange.TabIndex = 40;
            this._amountRange.Tag = "Amount";
            // 
            // _maturityLabel
            // 
            this._maturityLabel.AutoSize = true;
            this._maturityLabel.Location = new System.Drawing.Point(250, 113);
            this._maturityLabel.Name = "_maturityLabel";
            this._maturityLabel.Size = new System.Drawing.Size(52, 15);
            this._maturityLabel.TabIndex = 45;
            this._maturityLabel.Text = "Maturity";
            // 
            // _interestRateLabel
            // 
            this._interestRateLabel.AutoSize = true;
            this._interestRateLabel.Location = new System.Drawing.Point(250, 60);
            this._interestRateLabel.Name = "_interestRateLabel";
            this._interestRateLabel.Size = new System.Drawing.Size(111, 15);
            this._interestRateLabel.TabIndex = 43;
            this._interestRateLabel.Text = "Interest rate (yearly)";
            // 
            // _amountLabel
            // 
            this._amountLabel.AutoSize = true;
            this._amountLabel.Location = new System.Drawing.Point(250, 7);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(51, 15);
            this._amountLabel.TabIndex = 41;
            this._amountLabel.Text = "Amount";
            // 
            // _roundingPolicyComboBox
            // 
            this._roundingPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._roundingPolicyComboBox.FormattingEnabled = true;
            this._roundingPolicyComboBox.Location = new System.Drawing.Point(14, 238);
            this._roundingPolicyComboBox.Name = "_roundingPolicyComboBox";
            this._roundingPolicyComboBox.Size = new System.Drawing.Size(174, 23);
            this._roundingPolicyComboBox.TabIndex = 39;
            this._roundingPolicyComboBox.Tag = "RoundingPolicy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Rounding";
            // 
            // _dateShiftPolicyComboBox
            // 
            this._dateShiftPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dateShiftPolicyComboBox.FormattingEnabled = true;
            this._dateShiftPolicyComboBox.Location = new System.Drawing.Point(14, 185);
            this._dateShiftPolicyComboBox.Name = "_dateShiftPolicyComboBox";
            this._dateShiftPolicyComboBox.Size = new System.Drawing.Size(174, 23);
            this._dateShiftPolicyComboBox.TabIndex = 37;
            this._dateShiftPolicyComboBox.Tag = "DateShiftPolicy";
            // 
            // _dateShiftPolicyLabel
            // 
            this._dateShiftPolicyLabel.AutoSize = true;
            this._dateShiftPolicyLabel.Location = new System.Drawing.Point(14, 164);
            this._dateShiftPolicyLabel.Name = "_dateShiftPolicyLabel";
            this._dateShiftPolicyLabel.Size = new System.Drawing.Size(57, 15);
            this._dateShiftPolicyLabel.TabIndex = 36;
            this._dateShiftPolicyLabel.Text = "Date shift";
            // 
            // _yearPolicyComboBox
            // 
            this._yearPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearPolicyComboBox.FormattingEnabled = true;
            this._yearPolicyComboBox.Location = new System.Drawing.Point(14, 132);
            this._yearPolicyComboBox.Name = "_yearPolicyComboBox";
            this._yearPolicyComboBox.Size = new System.Drawing.Size(174, 23);
            this._yearPolicyComboBox.TabIndex = 35;
            this._yearPolicyComboBox.Tag = "YearPolicy";
            // 
            // _yearPolicyLabel
            // 
            this._yearPolicyLabel.AutoSize = true;
            this._yearPolicyLabel.Location = new System.Drawing.Point(14, 111);
            this._yearPolicyLabel.Name = "_yearPolicyLabel";
            this._yearPolicyLabel.Size = new System.Drawing.Size(30, 15);
            this._yearPolicyLabel.TabIndex = 34;
            this._yearPolicyLabel.Text = "Year";
            // 
            // _paymentFrequencyPolicyComboBox
            // 
            this._paymentFrequencyPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._paymentFrequencyPolicyComboBox.FormattingEnabled = true;
            this._paymentFrequencyPolicyComboBox.Location = new System.Drawing.Point(14, 78);
            this._paymentFrequencyPolicyComboBox.Name = "_paymentFrequencyPolicyComboBox";
            this._paymentFrequencyPolicyComboBox.Size = new System.Drawing.Size(174, 23);
            this._paymentFrequencyPolicyComboBox.TabIndex = 33;
            this._paymentFrequencyPolicyComboBox.Tag = "PaymentFrequencyPolicy";
            // 
            // _paymentFrequencyLabel
            // 
            this._paymentFrequencyLabel.AutoSize = true;
            this._paymentFrequencyLabel.Location = new System.Drawing.Point(14, 60);
            this._paymentFrequencyLabel.Name = "_paymentFrequencyLabel";
            this._paymentFrequencyLabel.Size = new System.Drawing.Size(110, 15);
            this._paymentFrequencyLabel.TabIndex = 32;
            this._paymentFrequencyLabel.Text = "Payment frequency";
            // 
            // _schedulePolicyComboBox
            // 
            this._schedulePolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._schedulePolicyComboBox.FormattingEnabled = true;
            this._schedulePolicyComboBox.Location = new System.Drawing.Point(14, 25);
            this._schedulePolicyComboBox.Name = "_schedulePolicyComboBox";
            this._schedulePolicyComboBox.Size = new System.Drawing.Size(174, 23);
            this._schedulePolicyComboBox.TabIndex = 31;
            this._schedulePolicyComboBox.Tag = "SchedulePolicy";
            // 
            // _schedulePolicyLabel
            // 
            this._schedulePolicyLabel.AutoSize = true;
            this._schedulePolicyLabel.Location = new System.Drawing.Point(14, 7);
            this._schedulePolicyLabel.Name = "_schedulePolicyLabel";
            this._schedulePolicyLabel.Size = new System.Drawing.Size(81, 15);
            this._schedulePolicyLabel.TabIndex = 30;
            this._schedulePolicyLabel.Text = "Schedule type";
            // 
            // _entryFeesTabListPage
            // 
            this._entryFeesTabListPage.Controls.Add(this._entryFeesListView);
            this._entryFeesTabListPage.Controls.Add(this._entryFeesButtonPanel);
            this._entryFeesTabListPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._entryFeesTabListPage.Name = "_entryFeesTabListPage";
            this._entryFeesTabListPage.Size = new System.Drawing.Size(541, 334);
            this._entryFeesTabListPage.TabIndex = 2;
            this._entryFeesTabListPage.Text = "Entry fees";
            // 
            // _entryFeesListView
            // 
            this._entryFeesListView.AllColumns.Add(this._nameColumn);
            this._entryFeesListView.AllColumns.Add(this._valueMinColumn);
            this._entryFeesListView.AllColumns.Add(this._valueMaxColumn);
            this._entryFeesListView.AllColumns.Add(this._rateAmountColumn);
            this._entryFeesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumn,
            this._valueMinColumn,
            this._valueMaxColumn,
            this._rateAmountColumn});
            this._entryFeesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._entryFeesListView.FullRowSelect = true;
            this._entryFeesListView.GridLines = true;
            this._entryFeesListView.HeaderWordWrap = true;
            this._entryFeesListView.HideSelection = false;
            this._entryFeesListView.Location = new System.Drawing.Point(0, 0);
            this._entryFeesListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._entryFeesListView.MultiSelect = false;
            this._entryFeesListView.Name = "_entryFeesListView";
            this._entryFeesListView.ShowGroups = false;
            this._entryFeesListView.Size = new System.Drawing.Size(541, 287);
            this._entryFeesListView.TabIndex = 4;
            this._entryFeesListView.UseCompatibleStateImageBehavior = false;
            this._entryFeesListView.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "Name";
            this._nameColumn.Text = "Name";
            this._nameColumn.Width = 200;
            // 
            // _valueMinColumn
            // 
            this._valueMinColumn.AspectName = "ValueMin";
            this._valueMinColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMinColumn.Text = "Value (min)";
            this._valueMinColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMinColumn.Width = 100;
            // 
            // _valueMaxColumn
            // 
            this._valueMaxColumn.AspectName = "ValueMax";
            this._valueMaxColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMaxColumn.Text = "Value (max)";
            this._valueMaxColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMaxColumn.Width = 100;
            // 
            // _rateAmountColumn
            // 
            this._rateAmountColumn.AspectName = "Rate";
            this._rateAmountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._rateAmountColumn.Text = "Rate / amount";
            this._rateAmountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._rateAmountColumn.Width = 120;
            // 
            // _entryFeesButtonPanel
            // 
            this._entryFeesButtonPanel.Controls.Add(this._removeEntryFeeButton);
            this._entryFeesButtonPanel.Controls.Add(this._addEntryFeeButton);
            this._entryFeesButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._entryFeesButtonPanel.Location = new System.Drawing.Point(0, 287);
            this._entryFeesButtonPanel.Name = "_entryFeesButtonPanel";
            this._entryFeesButtonPanel.Size = new System.Drawing.Size(541, 47);
            this._entryFeesButtonPanel.TabIndex = 0;
            // 
            // _removeEntryFeeButton
            // 
            this._removeEntryFeeButton.Location = new System.Drawing.Point(106, 12);
            this._removeEntryFeeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._removeEntryFeeButton.Name = "_removeEntryFeeButton";
            this._removeEntryFeeButton.Size = new System.Drawing.Size(100, 28);
            this._removeEntryFeeButton.TabIndex = 3;
            this._removeEntryFeeButton.Text = "Remove";
            this._removeEntryFeeButton.UseVisualStyleBackColor = true;
            // 
            // _addEntryFeeButton
            // 
            this._addEntryFeeButton.Location = new System.Drawing.Point(0, 12);
            this._addEntryFeeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._addEntryFeeButton.Name = "_addEntryFeeButton";
            this._addEntryFeeButton.Size = new System.Drawing.Size(100, 28);
            this._addEntryFeeButton.TabIndex = 2;
            this._addEntryFeeButton.Text = "Add";
            this._addEntryFeeButton.UseVisualStyleBackColor = true;
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 342);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(699, 53);
            this._buttonsPanel.TabIndex = 4;
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(588, 13);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(100, 28);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(481, 13);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(100, 28);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // LoanProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 395);
            this.Controls.Add(this._tabList);
            this.Controls.Add(this._buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan product";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._tabList.ResumeLayout(false);
            this._generalTabListPage.ResumeLayout(false);
            this._generalTabListPage.PerformLayout();
            this._scheduleTabListPage.ResumeLayout(false);
            this._scheduleTabListPage.PerformLayout();
            this._entryFeesTabListPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._entryFeesListView)).EndInit();
            this._entryFeesButtonPanel.ResumeLayout(false);
            this._buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private TopEdgePanel _buttonsPanel;
        private Cyotek.Windows.Forms.TabList _tabList;
        private Cyotek.Windows.Forms.TabListPage _generalTabListPage;
        private Cyotek.Windows.Forms.TabListPage _scheduleTabListPage;
        private System.Windows.Forms.ComboBox _currencyComboBox;
        private System.Windows.Forms.Label _currencyLabel;
        private System.Windows.Forms.CheckBox _availableForCompanyCheckBox;
        private System.Windows.Forms.CheckBox _availableForNsgCheckBox;
        private System.Windows.Forms.CheckBox _availableForSgCheckBox;
        private System.Windows.Forms.CheckBox _availableForIndividualCheckBox;
        private System.Windows.Forms.Label _availableForLabel;
        private System.Windows.Forms.TextBox _codeTextBox;
        private System.Windows.Forms.Label _codeLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.CheckBox _chargeInterestDuringGracePeriodCheckBox;
        private Controls.RangeControl _gracePeriodRange;
        private System.Windows.Forms.Label _gracePeriodLabel;
        private Controls.RangeControl _maturityRange;
        private Controls.RangeControl _interestRateRange;
        private Controls.RangeControl _amountRange;
        private System.Windows.Forms.Label _maturityLabel;
        private System.Windows.Forms.Label _interestRateLabel;
        private System.Windows.Forms.Label _amountLabel;
        private System.Windows.Forms.ComboBox _roundingPolicyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _dateShiftPolicyComboBox;
        private System.Windows.Forms.Label _dateShiftPolicyLabel;
        private System.Windows.Forms.ComboBox _yearPolicyComboBox;
        private System.Windows.Forms.Label _yearPolicyLabel;
        private System.Windows.Forms.ComboBox _paymentFrequencyPolicyComboBox;
        private System.Windows.Forms.Label _paymentFrequencyLabel;
        private System.Windows.Forms.ComboBox _schedulePolicyComboBox;
        private System.Windows.Forms.Label _schedulePolicyLabel;
        private Cyotek.Windows.Forms.TabListPage _entryFeesTabListPage;
        private System.Windows.Forms.Panel _entryFeesButtonPanel;
        private System.Windows.Forms.Button _removeEntryFeeButton;
        private System.Windows.Forms.Button _addEntryFeeButton;
        private BrightIdeasSoftware.ObjectListView _entryFeesListView;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private BrightIdeasSoftware.OLVColumn _valueMinColumn;
        private BrightIdeasSoftware.OLVColumn _valueMaxColumn;
        private BrightIdeasSoftware.OLVColumn _rateAmountColumn;
    }
}