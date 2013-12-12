namespace OpenCBS.View
{
    partial class UserView
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
            this._generalTabListPage = new Cyotek.Windows.Forms.TabListPage();
            this._passwordConfirmationTextBox = new System.Windows.Forms.TextBox();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this._usernameTextBox = new System.Windows.Forms.TextBox();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._emailTextBox = new System.Windows.Forms.TextBox();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this._firstNameLabel = new System.Windows.Forms.Label();
            this._passwordConfirmationLabel = new System.Windows.Forms.Label();
            this._lastNameLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._emailLabel = new System.Windows.Forms.Label();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._userTabList = new Cyotek.Windows.Forms.TabList();
            this._buttonsPanel.SuspendLayout();
            this._generalTabListPage.SuspendLayout();
            this._userTabList.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 309);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(634, 53);
            this._buttonsPanel.TabIndex = 100;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Location = new System.Drawing.Point(522, 13);
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
            this._okButton.Location = new System.Drawing.Point(415, 13);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(100, 28);
            this._okButton.TabIndex = 101;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _generalTabListPage
            // 
            this._generalTabListPage.Controls.Add(this._passwordConfirmationTextBox);
            this._generalTabListPage.Controls.Add(this._passwordTextBox);
            this._generalTabListPage.Controls.Add(this._usernameTextBox);
            this._generalTabListPage.Controls.Add(this._firstNameTextBox);
            this._generalTabListPage.Controls.Add(this._emailTextBox);
            this._generalTabListPage.Controls.Add(this._lastNameTextBox);
            this._generalTabListPage.Controls.Add(this._firstNameLabel);
            this._generalTabListPage.Controls.Add(this._passwordConfirmationLabel);
            this._generalTabListPage.Controls.Add(this._lastNameLabel);
            this._generalTabListPage.Controls.Add(this._passwordLabel);
            this._generalTabListPage.Controls.Add(this._emailLabel);
            this._generalTabListPage.Controls.Add(this._usernameLabel);
            this._generalTabListPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._generalTabListPage.Name = "_generalTabListPage";
            this._generalTabListPage.Size = new System.Drawing.Size(476, 301);
            this._generalTabListPage.TabIndex = 0;
            this._generalTabListPage.Text = "General";
            // 
            // _passwordConfirmationTextBox
            // 
            this._passwordConfirmationTextBox.Location = new System.Drawing.Point(250, 131);
            this._passwordConfirmationTextBox.Name = "_passwordConfirmationTextBox";
            this._passwordConfirmationTextBox.PasswordChar = '*';
            this._passwordConfirmationTextBox.Size = new System.Drawing.Size(174, 23);
            this._passwordConfirmationTextBox.TabIndex = 12;
            this._passwordConfirmationTextBox.Tag = "PasswordConfirmation";
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(250, 78);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(174, 23);
            this._passwordTextBox.TabIndex = 10;
            this._passwordTextBox.Tag = "Password";
            // 
            // _usernameTextBox
            // 
            this._usernameTextBox.Location = new System.Drawing.Point(250, 25);
            this._usernameTextBox.Name = "_usernameTextBox";
            this._usernameTextBox.Size = new System.Drawing.Size(174, 23);
            this._usernameTextBox.TabIndex = 8;
            this._usernameTextBox.Tag = "Username";
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(14, 25);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(174, 23);
            this._firstNameTextBox.TabIndex = 2;
            this._firstNameTextBox.Tag = "FirstName";
            // 
            // _emailTextBox
            // 
            this._emailTextBox.Location = new System.Drawing.Point(14, 131);
            this._emailTextBox.Name = "_emailTextBox";
            this._emailTextBox.Size = new System.Drawing.Size(174, 23);
            this._emailTextBox.TabIndex = 6;
            this._emailTextBox.Tag = "Email";
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(14, 78);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(174, 23);
            this._lastNameTextBox.TabIndex = 4;
            this._lastNameTextBox.Tag = "LastName";
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.AutoSize = true;
            this._firstNameLabel.Location = new System.Drawing.Point(14, 7);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(62, 15);
            this._firstNameLabel.TabIndex = 1;
            this._firstNameLabel.Text = "First name";
            // 
            // _passwordConfirmationLabel
            // 
            this._passwordConfirmationLabel.AutoSize = true;
            this._passwordConfirmationLabel.Location = new System.Drawing.Point(250, 113);
            this._passwordConfirmationLabel.Name = "_passwordConfirmationLabel";
            this._passwordConfirmationLabel.Size = new System.Drawing.Size(110, 15);
            this._passwordConfirmationLabel.TabIndex = 11;
            this._passwordConfirmationLabel.Text = "Password (confirm)";
            // 
            // _lastNameLabel
            // 
            this._lastNameLabel.AutoSize = true;
            this._lastNameLabel.Location = new System.Drawing.Point(14, 60);
            this._lastNameLabel.Name = "_lastNameLabel";
            this._lastNameLabel.Size = new System.Drawing.Size(61, 15);
            this._lastNameLabel.TabIndex = 3;
            this._lastNameLabel.Text = "Last name";
            // 
            // _passwordLabel
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(250, 60);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(57, 15);
            this._passwordLabel.TabIndex = 9;
            this._passwordLabel.Text = "Password";
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(14, 113);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(36, 15);
            this._emailLabel.TabIndex = 5;
            this._emailLabel.Text = "Email";
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(250, 7);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(60, 15);
            this._usernameLabel.TabIndex = 7;
            this._usernameLabel.Text = "Username";
            // 
            // _userTabList
            // 
            this._userTabList.Controls.Add(this._generalTabListPage);
            this._userTabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._userTabList.Location = new System.Drawing.Point(0, 0);
            this._userTabList.Name = "_userTabList";
            this._userTabList.Size = new System.Drawing.Size(634, 309);
            this._userTabList.TabIndex = 14;
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 362);
            this.Controls.Add(this._userTabList);
            this.Controls.Add(this._buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this._buttonsPanel.ResumeLayout(false);
            this._generalTabListPage.ResumeLayout(false);
            this._generalTabListPage.PerformLayout();
            this._userTabList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenCBS.Controls.TopEdgePanel _buttonsPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private Cyotek.Windows.Forms.TabListPage _generalTabListPage;
        private System.Windows.Forms.TextBox _passwordConfirmationTextBox;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.TextBox _usernameTextBox;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.TextBox _emailTextBox;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.Label _firstNameLabel;
        private System.Windows.Forms.Label _passwordConfirmationLabel;
        private System.Windows.Forms.Label _lastNameLabel;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.Label _emailLabel;
        private System.Windows.Forms.Label _usernameLabel;
        private Cyotek.Windows.Forms.TabList _userTabList;
    }
}