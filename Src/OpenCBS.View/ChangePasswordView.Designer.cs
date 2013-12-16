namespace OpenCBS.View
{
    partial class ChangePasswordView
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
            this._buttonsPanel = new OpenCBS.Controls.TopEdgePanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this._currentPasswordLabel = new System.Windows.Forms.Label();
            this._newPasswordTextBox = new System.Windows.Forms.TextBox();
            this._newPasswordLabel = new System.Windows.Forms.Label();
            this._newPasswordConfirmationTextBox = new System.Windows.Forms.TextBox();
            this._newPasswordConfirmationLabel = new System.Windows.Forms.Label();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 148);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(448, 61);
            this._buttonsPanel.TabIndex = 101;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Location = new System.Drawing.Point(317, 15);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(117, 32);
            this._cancelButton.TabIndex = 102;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(193, 15);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(117, 32);
            this._okButton.TabIndex = 101;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _currentPasswordTextBox
            // 
            this._currentPasswordTextBox.Location = new System.Drawing.Point(238, 20);
            this._currentPasswordTextBox.Name = "_currentPasswordTextBox";
            this._currentPasswordTextBox.PasswordChar = '*';
            this._currentPasswordTextBox.Size = new System.Drawing.Size(174, 23);
            this._currentPasswordTextBox.TabIndex = 103;
            this._currentPasswordTextBox.Tag = "CurrentPassword";
            // 
            // _currentPasswordLabel
            // 
            this._currentPasswordLabel.AutoSize = true;
            this._currentPasswordLabel.Location = new System.Drawing.Point(12, 23);
            this._currentPasswordLabel.Name = "_currentPasswordLabel";
            this._currentPasswordLabel.Size = new System.Drawing.Size(100, 15);
            this._currentPasswordLabel.TabIndex = 102;
            this._currentPasswordLabel.Text = "Current password";
            // 
            // _newPasswordTextBox
            // 
            this._newPasswordTextBox.Location = new System.Drawing.Point(238, 49);
            this._newPasswordTextBox.Name = "_newPasswordTextBox";
            this._newPasswordTextBox.PasswordChar = '*';
            this._newPasswordTextBox.Size = new System.Drawing.Size(174, 23);
            this._newPasswordTextBox.TabIndex = 105;
            this._newPasswordTextBox.Tag = "NewPassword";
            // 
            // _newPasswordLabel
            // 
            this._newPasswordLabel.AutoSize = true;
            this._newPasswordLabel.Location = new System.Drawing.Point(12, 52);
            this._newPasswordLabel.Name = "_newPasswordLabel";
            this._newPasswordLabel.Size = new System.Drawing.Size(84, 15);
            this._newPasswordLabel.TabIndex = 104;
            this._newPasswordLabel.Text = "New password";
            // 
            // _newPasswordConfirmationTextBox
            // 
            this._newPasswordConfirmationTextBox.Location = new System.Drawing.Point(238, 81);
            this._newPasswordConfirmationTextBox.Name = "_newPasswordConfirmationTextBox";
            this._newPasswordConfirmationTextBox.PasswordChar = '*';
            this._newPasswordConfirmationTextBox.Size = new System.Drawing.Size(174, 23);
            this._newPasswordConfirmationTextBox.TabIndex = 107;
            this._newPasswordConfirmationTextBox.Tag = "NewPasswordConfirmation";
            // 
            // _newPasswordConfirmationLabel
            // 
            this._newPasswordConfirmationLabel.AutoSize = true;
            this._newPasswordConfirmationLabel.Location = new System.Drawing.Point(12, 84);
            this._newPasswordConfirmationLabel.Name = "_newPasswordConfirmationLabel";
            this._newPasswordConfirmationLabel.Size = new System.Drawing.Size(164, 15);
            this._newPasswordConfirmationLabel.TabIndex = 106;
            this._newPasswordConfirmationLabel.Text = "New password (confirmation)";
            // 
            // ChangePasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 209);
            this.Controls.Add(this._newPasswordConfirmationTextBox);
            this.Controls.Add(this._newPasswordConfirmationLabel);
            this.Controls.Add(this._newPasswordTextBox);
            this.Controls.Add(this._newPasswordLabel);
            this.Controls.Add(this._currentPasswordTextBox);
            this.Controls.Add(this._currentPasswordLabel);
            this.Controls.Add(this._buttonsPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change password";
            this._buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TopEdgePanel _buttonsPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TextBox _currentPasswordTextBox;
        private System.Windows.Forms.Label _currentPasswordLabel;
        private System.Windows.Forms.TextBox _newPasswordTextBox;
        private System.Windows.Forms.Label _newPasswordLabel;
        private System.Windows.Forms.TextBox _newPasswordConfirmationTextBox;
        private System.Windows.Forms.Label _newPasswordConfirmationLabel;
    }
}