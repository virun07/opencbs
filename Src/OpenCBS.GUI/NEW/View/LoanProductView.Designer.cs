namespace OpenCBS.GUI.NEW.View
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._generalTabPage = new System.Windows.Forms.TabPage();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._nameLabel = new System.Windows.Forms.Label();
            this._codeLabel = new System.Windows.Forms.Label();
            this._paymentFrequencyLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._codeTextBox = new System.Windows.Forms.TextBox();
            this._paymentFrequencyComboBox = new System.Windows.Forms.ComboBox();
            this._tabControl.SuspendLayout();
            this._generalTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._generalTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(757, 371);
            this._tabControl.TabIndex = 0;
            // 
            // _generalTabPage
            // 
            this._generalTabPage.Controls.Add(this._paymentFrequencyComboBox);
            this._generalTabPage.Controls.Add(this._codeTextBox);
            this._generalTabPage.Controls.Add(this._nameTextBox);
            this._generalTabPage.Controls.Add(this._paymentFrequencyLabel);
            this._generalTabPage.Controls.Add(this._codeLabel);
            this._generalTabPage.Controls.Add(this._nameLabel);
            this._generalTabPage.Location = new System.Drawing.Point(4, 25);
            this._generalTabPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._generalTabPage.Name = "_generalTabPage";
            this._generalTabPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._generalTabPage.Size = new System.Drawing.Size(749, 342);
            this._generalTabPage.TabIndex = 0;
            this._generalTabPage.Text = "General";
            this._generalTabPage.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(539, 384);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(100, 26);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(645, 384);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(100, 26);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 18);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(42, 16);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "Name";
            // 
            // _codeLabel
            // 
            this._codeLabel.AutoSize = true;
            this._codeLabel.Location = new System.Drawing.Point(12, 51);
            this._codeLabel.Name = "_codeLabel";
            this._codeLabel.Size = new System.Drawing.Size(38, 16);
            this._codeLabel.TabIndex = 2;
            this._codeLabel.Text = "Code";
            // 
            // _paymentFrequencyLabel
            // 
            this._paymentFrequencyLabel.AutoSize = true;
            this._paymentFrequencyLabel.Location = new System.Drawing.Point(12, 84);
            this._paymentFrequencyLabel.Name = "_paymentFrequencyLabel";
            this._paymentFrequencyLabel.Size = new System.Drawing.Size(120, 16);
            this._paymentFrequencyLabel.TabIndex = 4;
            this._paymentFrequencyLabel.Text = "Payment frequency";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(147, 15);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(209, 22);
            this._nameTextBox.TabIndex = 1;
            // 
            // _codeTextBox
            // 
            this._codeTextBox.Location = new System.Drawing.Point(147, 48);
            this._codeTextBox.Name = "_codeTextBox";
            this._codeTextBox.Size = new System.Drawing.Size(209, 22);
            this._codeTextBox.TabIndex = 3;
            // 
            // _paymentFrequencyComboBox
            // 
            this._paymentFrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._paymentFrequencyComboBox.FormattingEnabled = true;
            this._paymentFrequencyComboBox.Location = new System.Drawing.Point(147, 81);
            this._paymentFrequencyComboBox.Name = "_paymentFrequencyComboBox";
            this._paymentFrequencyComboBox.Size = new System.Drawing.Size(209, 24);
            this._paymentFrequencyComboBox.TabIndex = 5;
            // 
            // LoanProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 422);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._tabControl);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan product";
            this._tabControl.ResumeLayout(false);
            this._generalTabPage.ResumeLayout(false);
            this._generalTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _generalTabPage;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _codeLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _paymentFrequencyLabel;
        private System.Windows.Forms.TextBox _codeTextBox;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.ComboBox _paymentFrequencyComboBox;
    }
}