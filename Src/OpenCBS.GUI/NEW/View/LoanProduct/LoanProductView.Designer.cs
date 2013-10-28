namespace OpenCBS.GUI.NEW.View.LoanProduct
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
            this._scheduleTabListPage = new Cyotek.Windows.Forms.TabListPage();
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
            this._buttonsPanel = new OpenCBS.GUI.NEW.View.TopEdgePanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._tabList.SuspendLayout();
            this._generalTabListPage.SuspendLayout();
            this._scheduleTabListPage.SuspendLayout();
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
            this._tabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabList.Location = new System.Drawing.Point(0, 0);
            this._tabList.Name = "_tabList";
            this._tabList.Size = new System.Drawing.Size(599, 296);
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
            this._generalTabListPage.Size = new System.Drawing.Size(441, 288);
            this._generalTabListPage.TabIndex = 0;
            this._generalTabListPage.Text = "General";
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
            this._scheduleTabListPage.Size = new System.Drawing.Size(441, 288);
            this._scheduleTabListPage.TabIndex = 1;
            this._scheduleTabListPage.Text = "Schedule";
            // 
            // _currencyComboBox
            // 
            this._currencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._currencyComboBox.FormattingEnabled = true;
            this._currencyComboBox.Location = new System.Drawing.Point(142, 138);
            this._currencyComboBox.Name = "_currencyComboBox";
            this._currencyComboBox.Size = new System.Drawing.Size(202, 21);
            this._currencyComboBox.TabIndex = 21;
            // 
            // _currencyLabel
            // 
            this._currencyLabel.AutoSize = true;
            this._currencyLabel.Location = new System.Drawing.Point(12, 141);
            this._currencyLabel.Name = "_currencyLabel";
            this._currencyLabel.Size = new System.Drawing.Size(49, 13);
            this._currencyLabel.TabIndex = 20;
            this._currencyLabel.Text = "Currency";
            // 
            // _availableForCompanyCheckBox
            // 
            this._availableForCompanyCheckBox.AutoSize = true;
            this._availableForCompanyCheckBox.Location = new System.Drawing.Point(144, 115);
            this._availableForCompanyCheckBox.Name = "_availableForCompanyCheckBox";
            this._availableForCompanyCheckBox.Size = new System.Drawing.Size(70, 17);
            this._availableForCompanyCheckBox.TabIndex = 19;
            this._availableForCompanyCheckBox.Text = "Company";
            this._availableForCompanyCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForNsgCheckBox
            // 
            this._availableForNsgCheckBox.AutoSize = true;
            this._availableForNsgCheckBox.Location = new System.Drawing.Point(144, 96);
            this._availableForNsgCheckBox.Name = "_availableForNsgCheckBox";
            this._availableForNsgCheckBox.Size = new System.Drawing.Size(119, 17);
            this._availableForNsgCheckBox.TabIndex = 18;
            this._availableForNsgCheckBox.Text = "Non-solidarity group";
            this._availableForNsgCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForSgCheckBox
            // 
            this._availableForSgCheckBox.AutoSize = true;
            this._availableForSgCheckBox.Location = new System.Drawing.Point(144, 77);
            this._availableForSgCheckBox.Name = "_availableForSgCheckBox";
            this._availableForSgCheckBox.Size = new System.Drawing.Size(98, 17);
            this._availableForSgCheckBox.TabIndex = 17;
            this._availableForSgCheckBox.Text = "Solidarity group";
            this._availableForSgCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForIndividualCheckBox
            // 
            this._availableForIndividualCheckBox.AutoSize = true;
            this._availableForIndividualCheckBox.Location = new System.Drawing.Point(144, 58);
            this._availableForIndividualCheckBox.Name = "_availableForIndividualCheckBox";
            this._availableForIndividualCheckBox.Size = new System.Drawing.Size(65, 17);
            this._availableForIndividualCheckBox.TabIndex = 16;
            this._availableForIndividualCheckBox.Text = "Individal";
            this._availableForIndividualCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForLabel
            // 
            this._availableForLabel.AutoSize = true;
            this._availableForLabel.Location = new System.Drawing.Point(12, 59);
            this._availableForLabel.Name = "_availableForLabel";
            this._availableForLabel.Size = new System.Drawing.Size(65, 13);
            this._availableForLabel.TabIndex = 15;
            this._availableForLabel.Text = "Available for";
            // 
            // _codeTextBox
            // 
            this._codeTextBox.Location = new System.Drawing.Point(144, 29);
            this._codeTextBox.Name = "_codeTextBox";
            this._codeTextBox.Size = new System.Drawing.Size(200, 20);
            this._codeTextBox.TabIndex = 14;
            this._codeTextBox.Tag = "Code";
            // 
            // _codeLabel
            // 
            this._codeLabel.AutoSize = true;
            this._codeLabel.Location = new System.Drawing.Point(12, 32);
            this._codeLabel.Name = "_codeLabel";
            this._codeLabel.Size = new System.Drawing.Size(32, 13);
            this._codeLabel.TabIndex = 13;
            this._codeLabel.Text = "Code";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(144, 3);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(200, 20);
            this._nameTextBox.TabIndex = 12;
            this._nameTextBox.Tag = "Name";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 6);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(35, 13);
            this._nameLabel.TabIndex = 11;
            this._nameLabel.Text = "Name";
            // 
            // _chargeInterestDuringGracePeriodCheckBox
            // 
            this._chargeInterestDuringGracePeriodCheckBox.AutoSize = true;
            this._chargeInterestDuringGracePeriodCheckBox.Location = new System.Drawing.Point(217, 184);
            this._chargeInterestDuringGracePeriodCheckBox.Name = "_chargeInterestDuringGracePeriodCheckBox";
            this._chargeInterestDuringGracePeriodCheckBox.Size = new System.Drawing.Size(97, 17);
            this._chargeInterestDuringGracePeriodCheckBox.TabIndex = 48;
            this._chargeInterestDuringGracePeriodCheckBox.Text = "Charge interest";
            this._chargeInterestDuringGracePeriodCheckBox.UseVisualStyleBackColor = true;
            // 
            // _gracePeriodRange
            // 
            this._gracePeriodRange.AllowDecimalSeparator = false;
            this._gracePeriodRange.AutoSize = true;
            this._gracePeriodRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._gracePeriodRange.Location = new System.Drawing.Point(214, 160);
            this._gracePeriodRange.Margin = new System.Windows.Forms.Padding(0);
            this._gracePeriodRange.Max = null;
            this._gracePeriodRange.Min = null;
            this._gracePeriodRange.Name = "_gracePeriodRange";
            this._gracePeriodRange.Size = new System.Drawing.Size(155, 20);
            this._gracePeriodRange.TabIndex = 46;
            this._gracePeriodRange.Tag = "GracePeriod";
            // 
            // _gracePeriodLabel
            // 
            this._gracePeriodLabel.AutoSize = true;
            this._gracePeriodLabel.Location = new System.Drawing.Point(214, 144);
            this._gracePeriodLabel.Name = "_gracePeriodLabel";
            this._gracePeriodLabel.Size = new System.Drawing.Size(68, 13);
            this._gracePeriodLabel.TabIndex = 47;
            this._gracePeriodLabel.Text = "Grace period";
            // 
            // _maturityRange
            // 
            this._maturityRange.AllowDecimalSeparator = false;
            this._maturityRange.AutoSize = true;
            this._maturityRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._maturityRange.Location = new System.Drawing.Point(214, 114);
            this._maturityRange.Margin = new System.Windows.Forms.Padding(0);
            this._maturityRange.Max = null;
            this._maturityRange.Min = null;
            this._maturityRange.Name = "_maturityRange";
            this._maturityRange.Size = new System.Drawing.Size(155, 20);
            this._maturityRange.TabIndex = 44;
            this._maturityRange.Tag = "Maturity";
            // 
            // _interestRateRange
            // 
            this._interestRateRange.AllowDecimalSeparator = true;
            this._interestRateRange.AutoSize = true;
            this._interestRateRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._interestRateRange.Location = new System.Drawing.Point(214, 68);
            this._interestRateRange.Margin = new System.Windows.Forms.Padding(0);
            this._interestRateRange.Max = null;
            this._interestRateRange.Min = null;
            this._interestRateRange.Name = "_interestRateRange";
            this._interestRateRange.Size = new System.Drawing.Size(155, 20);
            this._interestRateRange.TabIndex = 42;
            this._interestRateRange.Tag = "InterestRate";
            // 
            // _amountRange
            // 
            this._amountRange.AllowDecimalSeparator = true;
            this._amountRange.AutoSize = true;
            this._amountRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._amountRange.Location = new System.Drawing.Point(214, 22);
            this._amountRange.Margin = new System.Windows.Forms.Padding(0);
            this._amountRange.Max = null;
            this._amountRange.Min = null;
            this._amountRange.Name = "_amountRange";
            this._amountRange.Size = new System.Drawing.Size(155, 20);
            this._amountRange.TabIndex = 40;
            this._amountRange.Tag = "Amount";
            // 
            // _maturityLabel
            // 
            this._maturityLabel.AutoSize = true;
            this._maturityLabel.Location = new System.Drawing.Point(214, 98);
            this._maturityLabel.Name = "_maturityLabel";
            this._maturityLabel.Size = new System.Drawing.Size(44, 13);
            this._maturityLabel.TabIndex = 45;
            this._maturityLabel.Text = "Maturity";
            // 
            // _interestRateLabel
            // 
            this._interestRateLabel.AutoSize = true;
            this._interestRateLabel.Location = new System.Drawing.Point(214, 52);
            this._interestRateLabel.Name = "_interestRateLabel";
            this._interestRateLabel.Size = new System.Drawing.Size(99, 13);
            this._interestRateLabel.TabIndex = 43;
            this._interestRateLabel.Text = "Interest rate (yearly)";
            // 
            // _amountLabel
            // 
            this._amountLabel.AutoSize = true;
            this._amountLabel.Location = new System.Drawing.Point(214, 6);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(43, 13);
            this._amountLabel.TabIndex = 41;
            this._amountLabel.Text = "Amount";
            // 
            // _roundingPolicyComboBox
            // 
            this._roundingPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._roundingPolicyComboBox.FormattingEnabled = true;
            this._roundingPolicyComboBox.Location = new System.Drawing.Point(12, 206);
            this._roundingPolicyComboBox.Name = "_roundingPolicyComboBox";
            this._roundingPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._roundingPolicyComboBox.TabIndex = 39;
            this._roundingPolicyComboBox.Tag = "RoundingPolicy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Rounding";
            // 
            // _dateShiftPolicyComboBox
            // 
            this._dateShiftPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dateShiftPolicyComboBox.FormattingEnabled = true;
            this._dateShiftPolicyComboBox.Location = new System.Drawing.Point(12, 160);
            this._dateShiftPolicyComboBox.Name = "_dateShiftPolicyComboBox";
            this._dateShiftPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._dateShiftPolicyComboBox.TabIndex = 37;
            this._dateShiftPolicyComboBox.Tag = "DateShiftPolicy";
            // 
            // _dateShiftPolicyLabel
            // 
            this._dateShiftPolicyLabel.AutoSize = true;
            this._dateShiftPolicyLabel.Location = new System.Drawing.Point(12, 142);
            this._dateShiftPolicyLabel.Name = "_dateShiftPolicyLabel";
            this._dateShiftPolicyLabel.Size = new System.Drawing.Size(52, 13);
            this._dateShiftPolicyLabel.TabIndex = 36;
            this._dateShiftPolicyLabel.Text = "Date shift";
            // 
            // _yearPolicyComboBox
            // 
            this._yearPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearPolicyComboBox.FormattingEnabled = true;
            this._yearPolicyComboBox.Location = new System.Drawing.Point(12, 114);
            this._yearPolicyComboBox.Name = "_yearPolicyComboBox";
            this._yearPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._yearPolicyComboBox.TabIndex = 35;
            this._yearPolicyComboBox.Tag = "YearPolicy";
            // 
            // _yearPolicyLabel
            // 
            this._yearPolicyLabel.AutoSize = true;
            this._yearPolicyLabel.Location = new System.Drawing.Point(12, 96);
            this._yearPolicyLabel.Name = "_yearPolicyLabel";
            this._yearPolicyLabel.Size = new System.Drawing.Size(29, 13);
            this._yearPolicyLabel.TabIndex = 34;
            this._yearPolicyLabel.Text = "Year";
            // 
            // _paymentFrequencyPolicyComboBox
            // 
            this._paymentFrequencyPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._paymentFrequencyPolicyComboBox.FormattingEnabled = true;
            this._paymentFrequencyPolicyComboBox.Location = new System.Drawing.Point(12, 68);
            this._paymentFrequencyPolicyComboBox.Name = "_paymentFrequencyPolicyComboBox";
            this._paymentFrequencyPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._paymentFrequencyPolicyComboBox.TabIndex = 33;
            this._paymentFrequencyPolicyComboBox.Tag = "PaymentFrequencyPolicy";
            // 
            // _paymentFrequencyLabel
            // 
            this._paymentFrequencyLabel.AutoSize = true;
            this._paymentFrequencyLabel.Location = new System.Drawing.Point(12, 52);
            this._paymentFrequencyLabel.Name = "_paymentFrequencyLabel";
            this._paymentFrequencyLabel.Size = new System.Drawing.Size(98, 13);
            this._paymentFrequencyLabel.TabIndex = 32;
            this._paymentFrequencyLabel.Text = "Payment frequency";
            // 
            // _schedulePolicyComboBox
            // 
            this._schedulePolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._schedulePolicyComboBox.FormattingEnabled = true;
            this._schedulePolicyComboBox.Location = new System.Drawing.Point(12, 22);
            this._schedulePolicyComboBox.Name = "_schedulePolicyComboBox";
            this._schedulePolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._schedulePolicyComboBox.TabIndex = 31;
            this._schedulePolicyComboBox.Tag = "SchedulePolicy";
            // 
            // _schedulePolicyLabel
            // 
            this._schedulePolicyLabel.AutoSize = true;
            this._schedulePolicyLabel.Location = new System.Drawing.Point(12, 6);
            this._schedulePolicyLabel.Name = "_schedulePolicyLabel";
            this._schedulePolicyLabel.Size = new System.Drawing.Size(75, 13);
            this._schedulePolicyLabel.TabIndex = 30;
            this._schedulePolicyLabel.Text = "Schedule type";
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 296);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(599, 46);
            this._buttonsPanel.TabIndex = 4;
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(504, 11);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(86, 24);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(412, 11);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(86, 24);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // LoanProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 342);
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
    }
}