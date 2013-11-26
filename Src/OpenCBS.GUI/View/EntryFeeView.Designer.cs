namespace OpenCBS.GUI.View
{
    partial class EntryFeeView
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
            this._buttonsPanel = new OpenCBS.GUI.NEW.View.TopEdgePanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._codeTextBox = new System.Windows.Forms.TextBox();
            this._codeLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._valueRange = new OpenCBS.Controls.RangeControl();
            this._valueLabel = new System.Windows.Forms.Label();
            this._rateRadioButton = new System.Windows.Forms.RadioButton();
            this._amountRadioButton = new System.Windows.Forms.RadioButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 169);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(366, 53);
            this._buttonsPanel.TabIndex = 100;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Location = new System.Drawing.Point(254, 13);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(100, 28);
            this._cancelButton.TabIndex = 102;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(147, 13);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(100, 28);
            this._okButton.TabIndex = 101;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _codeTextBox
            // 
            this._codeTextBox.Location = new System.Drawing.Point(114, 37);
            this._codeTextBox.Name = "_codeTextBox";
            this._codeTextBox.Size = new System.Drawing.Size(200, 23);
            this._codeTextBox.TabIndex = 9;
            this._codeTextBox.Tag = "Code";
            // 
            // _codeLabel
            // 
            this._codeLabel.AutoSize = true;
            this._codeLabel.Location = new System.Drawing.Point(12, 40);
            this._codeLabel.Name = "_codeLabel";
            this._codeLabel.Size = new System.Drawing.Size(35, 15);
            this._codeLabel.TabIndex = 8;
            this._codeLabel.Text = "Code";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(114, 8);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(200, 23);
            this._nameTextBox.TabIndex = 7;
            this._nameTextBox.Tag = "Name";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 11);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 6;
            this._nameLabel.Text = "Name";
            // 
            // _valueRange
            // 
            this._valueRange.AllowDecimalSeparator = true;
            this._valueRange.AutoSize = true;
            this._valueRange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._valueRange.Location = new System.Drawing.Point(114, 67);
            this._valueRange.Margin = new System.Windows.Forms.Padding(0);
            this._valueRange.Max = null;
            this._valueRange.Min = null;
            this._valueRange.Name = "_valueRange";
            this._valueRange.Size = new System.Drawing.Size(155, 23);
            this._valueRange.TabIndex = 42;
            this._valueRange.Tag = "Value";
            // 
            // _valueLabel
            // 
            this._valueLabel.AutoSize = true;
            this._valueLabel.Location = new System.Drawing.Point(12, 71);
            this._valueLabel.Name = "_valueLabel";
            this._valueLabel.Size = new System.Drawing.Size(36, 15);
            this._valueLabel.TabIndex = 43;
            this._valueLabel.Tag = "";
            this._valueLabel.Text = "Value";
            // 
            // _rateRadioButton
            // 
            this._rateRadioButton.AutoSize = true;
            this._rateRadioButton.Location = new System.Drawing.Point(114, 102);
            this._rateRadioButton.Name = "_rateRadioButton";
            this._rateRadioButton.Size = new System.Drawing.Size(48, 19);
            this._rateRadioButton.TabIndex = 44;
            this._rateRadioButton.TabStop = true;
            this._rateRadioButton.Text = "Rate";
            this._rateRadioButton.UseVisualStyleBackColor = true;
            // 
            // _amountRadioButton
            // 
            this._amountRadioButton.AutoSize = true;
            this._amountRadioButton.Location = new System.Drawing.Point(114, 127);
            this._amountRadioButton.Name = "_amountRadioButton";
            this._amountRadioButton.Size = new System.Drawing.Size(69, 19);
            this._amountRadioButton.TabIndex = 45;
            this._amountRadioButton.TabStop = true;
            this._amountRadioButton.Text = "Amount";
            this._amountRadioButton.UseVisualStyleBackColor = true;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // EntryFeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 222);
            this.Controls.Add(this._amountRadioButton);
            this.Controls.Add(this._rateRadioButton);
            this.Controls.Add(this._valueRange);
            this.Controls.Add(this._valueLabel);
            this.Controls.Add(this._codeTextBox);
            this.Controls.Add(this._codeLabel);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryFeeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry fee";
            this._buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NEW.View.TopEdgePanel _buttonsPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TextBox _codeTextBox;
        private System.Windows.Forms.Label _codeLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _nameLabel;
        private Controls.RangeControl _valueRange;
        private System.Windows.Forms.Label _valueLabel;
        private System.Windows.Forms.RadioButton _rateRadioButton;
        private System.Windows.Forms.RadioButton _amountRadioButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}