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
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._pageTreeView = new System.Windows.Forms.TreeView();
            this._buttonsPanel = new System.Windows.Forms.Panel();
            this._captionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(538, 2);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(86, 21);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(630, 2);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(86, 21);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _pageTreeView
            // 
            this._pageTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this._pageTreeView.Location = new System.Drawing.Point(0, 0);
            this._pageTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._pageTreeView.Name = "_pageTreeView";
            this._pageTreeView.Size = new System.Drawing.Size(140, 297);
            this._pageTreeView.TabIndex = 3;
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 297);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(729, 46);
            this._buttonsPanel.TabIndex = 4;
            // 
            // _captionLabel
            // 
            this._captionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this._captionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._captionLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this._captionLabel.Location = new System.Drawing.Point(140, 0);
            this._captionLabel.Name = "_captionLabel";
            this._captionLabel.Padding = new System.Windows.Forms.Padding(5);
            this._captionLabel.Size = new System.Drawing.Size(589, 23);
            this._captionLabel.TabIndex = 5;
            this._captionLabel.Text = "General";
            // 
            // LoanProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 343);
            this.Controls.Add(this._captionLabel);
            this.Controls.Add(this._pageTreeView);
            this.Controls.Add(this._buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan product";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.TreeView _pageTreeView;
        private System.Windows.Forms.Panel _buttonsPanel;
        private System.Windows.Forms.Label _captionLabel;
    }
}