namespace OpenCBS.GUI.NEW.View.LoanProduct.Page
{
    partial class SchedulePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._schedulePolicyComboBox = new System.Windows.Forms.ComboBox();
            this._schedulePolicyLabel = new System.Windows.Forms.Label();
            this._paymentFrequencyPolicyComboBox = new System.Windows.Forms.ComboBox();
            this._paymentFrequencyLabel = new System.Windows.Forms.Label();
            this._yearPolicyComboBox = new System.Windows.Forms.ComboBox();
            this._yearPolicyLabel = new System.Windows.Forms.Label();
            this._dateShiftPolicyComboBox = new System.Windows.Forms.ComboBox();
            this._dateShiftPolicyLabel = new System.Windows.Forms.Label();
            this._roundingPolicyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._amountLabel = new System.Windows.Forms.Label();
            this._interestRateLabel = new System.Windows.Forms.Label();
            this._maturityLabel = new System.Windows.Forms.Label();
            this._maturityRange = new OpenCBS.Controls.RangeControl();
            this._interestRateRange = new OpenCBS.Controls.RangeControl();
            this._amountRange = new OpenCBS.Controls.RangeControl();
            this._gracePeriodRange = new OpenCBS.Controls.RangeControl();
            this._gracePeriodLabel = new System.Windows.Forms.Label();
            this._chargeInterestDuringGracePeriodCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _schedulePolicyComboBox
            // 
            this._schedulePolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._schedulePolicyComboBox.FormattingEnabled = true;
            this._schedulePolicyComboBox.Location = new System.Drawing.Point(8, 21);
            this._schedulePolicyComboBox.Name = "_schedulePolicyComboBox";
            this._schedulePolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._schedulePolicyComboBox.TabIndex = 12;
            this._schedulePolicyComboBox.Tag = "SchedulePolicy";
            // 
            // _schedulePolicyLabel
            // 
            this._schedulePolicyLabel.AutoSize = true;
            this._schedulePolicyLabel.Location = new System.Drawing.Point(8, 5);
            this._schedulePolicyLabel.Name = "_schedulePolicyLabel";
            this._schedulePolicyLabel.Size = new System.Drawing.Size(75, 13);
            this._schedulePolicyLabel.TabIndex = 11;
            this._schedulePolicyLabel.Text = "Schedule type";
            // 
            // _paymentFrequencyPolicyComboBox
            // 
            this._paymentFrequencyPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._paymentFrequencyPolicyComboBox.FormattingEnabled = true;
            this._paymentFrequencyPolicyComboBox.Location = new System.Drawing.Point(8, 67);
            this._paymentFrequencyPolicyComboBox.Name = "_paymentFrequencyPolicyComboBox";
            this._paymentFrequencyPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._paymentFrequencyPolicyComboBox.TabIndex = 14;
            this._paymentFrequencyPolicyComboBox.Tag = "PaymentFrequencyPolicy";
            // 
            // _paymentFrequencyLabel
            // 
            this._paymentFrequencyLabel.AutoSize = true;
            this._paymentFrequencyLabel.Location = new System.Drawing.Point(8, 51);
            this._paymentFrequencyLabel.Name = "_paymentFrequencyLabel";
            this._paymentFrequencyLabel.Size = new System.Drawing.Size(98, 13);
            this._paymentFrequencyLabel.TabIndex = 13;
            this._paymentFrequencyLabel.Text = "Payment frequency";
            // 
            // _yearPolicyComboBox
            // 
            this._yearPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearPolicyComboBox.FormattingEnabled = true;
            this._yearPolicyComboBox.Location = new System.Drawing.Point(8, 113);
            this._yearPolicyComboBox.Name = "_yearPolicyComboBox";
            this._yearPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._yearPolicyComboBox.TabIndex = 16;
            this._yearPolicyComboBox.Tag = "YearPolicy";
            // 
            // _yearPolicyLabel
            // 
            this._yearPolicyLabel.AutoSize = true;
            this._yearPolicyLabel.Location = new System.Drawing.Point(8, 95);
            this._yearPolicyLabel.Name = "_yearPolicyLabel";
            this._yearPolicyLabel.Size = new System.Drawing.Size(29, 13);
            this._yearPolicyLabel.TabIndex = 15;
            this._yearPolicyLabel.Text = "Year";
            // 
            // _dateShiftPolicyComboBox
            // 
            this._dateShiftPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dateShiftPolicyComboBox.FormattingEnabled = true;
            this._dateShiftPolicyComboBox.Location = new System.Drawing.Point(8, 159);
            this._dateShiftPolicyComboBox.Name = "_dateShiftPolicyComboBox";
            this._dateShiftPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._dateShiftPolicyComboBox.TabIndex = 18;
            this._dateShiftPolicyComboBox.Tag = "DateShiftPolicy";
            // 
            // _dateShiftPolicyLabel
            // 
            this._dateShiftPolicyLabel.AutoSize = true;
            this._dateShiftPolicyLabel.Location = new System.Drawing.Point(8, 141);
            this._dateShiftPolicyLabel.Name = "_dateShiftPolicyLabel";
            this._dateShiftPolicyLabel.Size = new System.Drawing.Size(52, 13);
            this._dateShiftPolicyLabel.TabIndex = 17;
            this._dateShiftPolicyLabel.Text = "Date shift";
            // 
            // _roundingPolicyComboBox
            // 
            this._roundingPolicyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._roundingPolicyComboBox.FormattingEnabled = true;
            this._roundingPolicyComboBox.Location = new System.Drawing.Point(8, 205);
            this._roundingPolicyComboBox.Name = "_roundingPolicyComboBox";
            this._roundingPolicyComboBox.Size = new System.Drawing.Size(150, 21);
            this._roundingPolicyComboBox.TabIndex = 20;
            this._roundingPolicyComboBox.Tag = "RoundingPolicy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Rounding";
            // 
            // _amountLabel
            // 
            this._amountLabel.AutoSize = true;
            this._amountLabel.Location = new System.Drawing.Point(210, 5);
            this._amountLabel.Name = "_amountLabel";
            this._amountLabel.Size = new System.Drawing.Size(43, 13);
            this._amountLabel.TabIndex = 22;
            this._amountLabel.Text = "Amount";
            // 
            // _interestRateLabel
            // 
            this._interestRateLabel.AutoSize = true;
            this._interestRateLabel.Location = new System.Drawing.Point(210, 51);
            this._interestRateLabel.Name = "_interestRateLabel";
            this._interestRateLabel.Size = new System.Drawing.Size(63, 13);
            this._interestRateLabel.TabIndex = 24;
            this._interestRateLabel.Text = "Interest rate";
            // 
            // _maturityLabel
            // 
            this._maturityLabel.AutoSize = true;
            this._maturityLabel.Location = new System.Drawing.Point(210, 97);
            this._maturityLabel.Name = "_maturityLabel";
            this._maturityLabel.Size = new System.Drawing.Size(44, 13);
            this._maturityLabel.TabIndex = 26;
            this._maturityLabel.Text = "Maturity";
            // 
            // _maturityRange
            // 
            this._maturityRange.AllowDecimalSeparator = false;
            this._maturityRange.AutoSize = true;
            this._maturityRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._maturityRange.Location = new System.Drawing.Point(210, 113);
            this._maturityRange.Margin = new System.Windows.Forms.Padding(0);
            this._maturityRange.Max = null;
            this._maturityRange.Min = null;
            this._maturityRange.Name = "_maturityRange";
            this._maturityRange.Size = new System.Drawing.Size(155, 20);
            this._maturityRange.TabIndex = 25;
            this._maturityRange.Tag = "Maturity";
            // 
            // _interestRateRange
            // 
            this._interestRateRange.AllowDecimalSeparator = true;
            this._interestRateRange.AutoSize = true;
            this._interestRateRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._interestRateRange.Location = new System.Drawing.Point(210, 67);
            this._interestRateRange.Margin = new System.Windows.Forms.Padding(0);
            this._interestRateRange.Max = null;
            this._interestRateRange.Min = null;
            this._interestRateRange.Name = "_interestRateRange";
            this._interestRateRange.Size = new System.Drawing.Size(155, 20);
            this._interestRateRange.TabIndex = 23;
            this._interestRateRange.Tag = "InterestRate";
            // 
            // _amountRange
            // 
            this._amountRange.AllowDecimalSeparator = true;
            this._amountRange.AutoSize = true;
            this._amountRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._amountRange.Location = new System.Drawing.Point(210, 21);
            this._amountRange.Margin = new System.Windows.Forms.Padding(0);
            this._amountRange.Max = null;
            this._amountRange.Min = null;
            this._amountRange.Name = "_amountRange";
            this._amountRange.Size = new System.Drawing.Size(155, 20);
            this._amountRange.TabIndex = 21;
            this._amountRange.Tag = "Amount";
            // 
            // _gracePeriodRange
            // 
            this._gracePeriodRange.AllowDecimalSeparator = false;
            this._gracePeriodRange.AutoSize = true;
            this._gracePeriodRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._gracePeriodRange.Location = new System.Drawing.Point(210, 159);
            this._gracePeriodRange.Margin = new System.Windows.Forms.Padding(0);
            this._gracePeriodRange.Max = null;
            this._gracePeriodRange.Min = null;
            this._gracePeriodRange.Name = "_gracePeriodRange";
            this._gracePeriodRange.Size = new System.Drawing.Size(155, 20);
            this._gracePeriodRange.TabIndex = 27;
            this._gracePeriodRange.Tag = "GracePeriod";
            // 
            // _gracePeriodLabel
            // 
            this._gracePeriodLabel.AutoSize = true;
            this._gracePeriodLabel.Location = new System.Drawing.Point(210, 143);
            this._gracePeriodLabel.Name = "_gracePeriodLabel";
            this._gracePeriodLabel.Size = new System.Drawing.Size(68, 13);
            this._gracePeriodLabel.TabIndex = 28;
            this._gracePeriodLabel.Text = "Grace period";
            // 
            // _chargeInterestDuringGracePeriodCheckBox
            // 
            this._chargeInterestDuringGracePeriodCheckBox.AutoSize = true;
            this._chargeInterestDuringGracePeriodCheckBox.Location = new System.Drawing.Point(213, 183);
            this._chargeInterestDuringGracePeriodCheckBox.Name = "_chargeInterestDuringGracePeriodCheckBox";
            this._chargeInterestDuringGracePeriodCheckBox.Size = new System.Drawing.Size(97, 17);
            this._chargeInterestDuringGracePeriodCheckBox.TabIndex = 29;
            this._chargeInterestDuringGracePeriodCheckBox.Text = "Charge interest";
            this._chargeInterestDuringGracePeriodCheckBox.UseVisualStyleBackColor = true;
            // 
            // SchedulePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this._chargeInterestDuringGracePeriodCheckBox);
            this.Controls.Add(this._gracePeriodRange);
            this.Controls.Add(this._gracePeriodLabel);
            this.Controls.Add(this._maturityRange);
            this.Controls.Add(this._interestRateRange);
            this.Controls.Add(this._amountRange);
            this.Controls.Add(this._maturityLabel);
            this.Controls.Add(this._interestRateLabel);
            this.Controls.Add(this._amountLabel);
            this.Controls.Add(this._roundingPolicyComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._dateShiftPolicyComboBox);
            this.Controls.Add(this._dateShiftPolicyLabel);
            this.Controls.Add(this._yearPolicyComboBox);
            this.Controls.Add(this._yearPolicyLabel);
            this.Controls.Add(this._paymentFrequencyPolicyComboBox);
            this.Controls.Add(this._paymentFrequencyLabel);
            this.Controls.Add(this._schedulePolicyComboBox);
            this.Controls.Add(this._schedulePolicyLabel);
            this.Name = "SchedulePage";
            this.Size = new System.Drawing.Size(395, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _schedulePolicyComboBox;
        private System.Windows.Forms.Label _schedulePolicyLabel;
        private System.Windows.Forms.ComboBox _paymentFrequencyPolicyComboBox;
        private System.Windows.Forms.Label _paymentFrequencyLabel;
        private System.Windows.Forms.ComboBox _yearPolicyComboBox;
        private System.Windows.Forms.Label _yearPolicyLabel;
        private System.Windows.Forms.ComboBox _dateShiftPolicyComboBox;
        private System.Windows.Forms.Label _dateShiftPolicyLabel;
        private System.Windows.Forms.ComboBox _roundingPolicyComboBox;
        private System.Windows.Forms.Label label1;
        private Controls.RangeControl _amountRange;
        private System.Windows.Forms.Label _amountLabel;
        private System.Windows.Forms.Label _interestRateLabel;
        private Controls.RangeControl _interestRateRange;
        private System.Windows.Forms.Label _maturityLabel;
        private Controls.RangeControl _maturityRange;
        private Controls.RangeControl _gracePeriodRange;
        private System.Windows.Forms.Label _gracePeriodLabel;
        private System.Windows.Forms.CheckBox _chargeInterestDuringGracePeriodCheckBox;
    }
}
