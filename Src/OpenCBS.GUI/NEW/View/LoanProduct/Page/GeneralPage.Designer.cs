namespace OpenCBS.GUI.NEW.View.LoanProduct.Page
{
    partial class GeneralPage
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
            this._nameLabel = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._codeTextBox = new System.Windows.Forms.TextBox();
            this._codeLabel = new System.Windows.Forms.Label();
            this._availableForLabel = new System.Windows.Forms.Label();
            this._availableForIndividualCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForSgCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForNsgCheckBox = new System.Windows.Forms.CheckBox();
            this._availableForCompanyCheckBox = new System.Windows.Forms.CheckBox();
            this._currencyLabel = new System.Windows.Forms.Label();
            this._currencyComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(8, 5);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(35, 13);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "Name";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(140, 2);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(200, 20);
            this._nameTextBox.TabIndex = 1;
            this._nameTextBox.Tag = "Name";
            // 
            // _codeTextBox
            // 
            this._codeTextBox.Location = new System.Drawing.Point(140, 28);
            this._codeTextBox.Name = "_codeTextBox";
            this._codeTextBox.Size = new System.Drawing.Size(200, 20);
            this._codeTextBox.TabIndex = 3;
            this._codeTextBox.Tag = "Code";
            // 
            // _codeLabel
            // 
            this._codeLabel.AutoSize = true;
            this._codeLabel.Location = new System.Drawing.Point(8, 31);
            this._codeLabel.Name = "_codeLabel";
            this._codeLabel.Size = new System.Drawing.Size(32, 13);
            this._codeLabel.TabIndex = 2;
            this._codeLabel.Text = "Code";
            // 
            // _availableForLabel
            // 
            this._availableForLabel.AutoSize = true;
            this._availableForLabel.Location = new System.Drawing.Point(8, 58);
            this._availableForLabel.Name = "_availableForLabel";
            this._availableForLabel.Size = new System.Drawing.Size(65, 13);
            this._availableForLabel.TabIndex = 4;
            this._availableForLabel.Text = "Available for";
            // 
            // _availableForIndividualCheckBox
            // 
            this._availableForIndividualCheckBox.AutoSize = true;
            this._availableForIndividualCheckBox.Location = new System.Drawing.Point(140, 57);
            this._availableForIndividualCheckBox.Name = "_availableForIndividualCheckBox";
            this._availableForIndividualCheckBox.Size = new System.Drawing.Size(65, 17);
            this._availableForIndividualCheckBox.TabIndex = 5;
            this._availableForIndividualCheckBox.Text = "Individal";
            this._availableForIndividualCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForSgCheckBox
            // 
            this._availableForSgCheckBox.AutoSize = true;
            this._availableForSgCheckBox.Location = new System.Drawing.Point(140, 76);
            this._availableForSgCheckBox.Name = "_availableForSgCheckBox";
            this._availableForSgCheckBox.Size = new System.Drawing.Size(98, 17);
            this._availableForSgCheckBox.TabIndex = 6;
            this._availableForSgCheckBox.Text = "Solidarity group";
            this._availableForSgCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForNsgCheckBox
            // 
            this._availableForNsgCheckBox.AutoSize = true;
            this._availableForNsgCheckBox.Location = new System.Drawing.Point(140, 95);
            this._availableForNsgCheckBox.Name = "_availableForNsgCheckBox";
            this._availableForNsgCheckBox.Size = new System.Drawing.Size(119, 17);
            this._availableForNsgCheckBox.TabIndex = 7;
            this._availableForNsgCheckBox.Text = "Non-solidarity group";
            this._availableForNsgCheckBox.UseVisualStyleBackColor = true;
            // 
            // _availableForCompanyCheckBox
            // 
            this._availableForCompanyCheckBox.AutoSize = true;
            this._availableForCompanyCheckBox.Location = new System.Drawing.Point(140, 114);
            this._availableForCompanyCheckBox.Name = "_availableForCompanyCheckBox";
            this._availableForCompanyCheckBox.Size = new System.Drawing.Size(70, 17);
            this._availableForCompanyCheckBox.TabIndex = 8;
            this._availableForCompanyCheckBox.Text = "Company";
            this._availableForCompanyCheckBox.UseVisualStyleBackColor = true;
            // 
            // _currencyLabel
            // 
            this._currencyLabel.AutoSize = true;
            this._currencyLabel.Location = new System.Drawing.Point(8, 140);
            this._currencyLabel.Name = "_currencyLabel";
            this._currencyLabel.Size = new System.Drawing.Size(49, 13);
            this._currencyLabel.TabIndex = 9;
            this._currencyLabel.Text = "Currency";
            // 
            // _currencyComboBox
            // 
            this._currencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._currencyComboBox.FormattingEnabled = true;
            this._currencyComboBox.Location = new System.Drawing.Point(138, 137);
            this._currencyComboBox.Name = "_currencyComboBox";
            this._currencyComboBox.Size = new System.Drawing.Size(202, 21);
            this._currencyComboBox.TabIndex = 10;
            // 
            // GeneralPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._currencyComboBox);
            this.Controls.Add(this._currencyLabel);
            this.Controls.Add(this._availableForCompanyCheckBox);
            this.Controls.Add(this._availableForNsgCheckBox);
            this.Controls.Add(this._availableForSgCheckBox);
            this.Controls.Add(this._availableForIndividualCheckBox);
            this.Controls.Add(this._availableForLabel);
            this.Controls.Add(this._codeTextBox);
            this.Controls.Add(this._codeLabel);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._nameLabel);
            this.Name = "GeneralPage";
            this.Size = new System.Drawing.Size(360, 175);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.TextBox _codeTextBox;
        private System.Windows.Forms.Label _codeLabel;
        private System.Windows.Forms.Label _availableForLabel;
        private System.Windows.Forms.CheckBox _availableForIndividualCheckBox;
        private System.Windows.Forms.CheckBox _availableForSgCheckBox;
        private System.Windows.Forms.CheckBox _availableForNsgCheckBox;
        private System.Windows.Forms.CheckBox _availableForCompanyCheckBox;
        private System.Windows.Forms.Label _currencyLabel;
        private System.Windows.Forms.ComboBox _currencyComboBox;
    }
}
