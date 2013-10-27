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
            this._pageTreeView = new System.Windows.Forms.TreeView();
            this._captionLabel = new System.Windows.Forms.Label();
            this._sidebarPanel = new System.Windows.Forms.Panel();
            this._captionPanel = new System.Windows.Forms.Panel();
            this._buttonsPanel = new OpenCBS.GUI.NEW.View.LoanProduct.TopEdgePanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._sidebarPanel.SuspendLayout();
            this._captionPanel.SuspendLayout();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _pageTreeView
            // 
            this._pageTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pageTreeView.HideSelection = false;
            this._pageTreeView.Location = new System.Drawing.Point(5, 5);
            this._pageTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._pageTreeView.Name = "_pageTreeView";
            this._pageTreeView.Size = new System.Drawing.Size(159, 286);
            this._pageTreeView.TabIndex = 3;
            // 
            // _captionLabel
            // 
            this._captionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this._captionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._captionLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this._captionLabel.Location = new System.Drawing.Point(0, 5);
            this._captionLabel.Name = "_captionLabel";
            this._captionLabel.Padding = new System.Windows.Forms.Padding(5);
            this._captionLabel.Size = new System.Drawing.Size(425, 26);
            this._captionLabel.TabIndex = 5;
            this._captionLabel.Text = "General";
            this._captionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _sidebarPanel
            // 
            this._sidebarPanel.Controls.Add(this._pageTreeView);
            this._sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this._sidebarPanel.Name = "_sidebarPanel";
            this._sidebarPanel.Padding = new System.Windows.Forms.Padding(5);
            this._sidebarPanel.Size = new System.Drawing.Size(169, 296);
            this._sidebarPanel.TabIndex = 6;
            // 
            // _captionPanel
            // 
            this._captionPanel.Controls.Add(this._captionLabel);
            this._captionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._captionPanel.Location = new System.Drawing.Point(169, 0);
            this._captionPanel.Name = "_captionPanel";
            this._captionPanel.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this._captionPanel.Size = new System.Drawing.Size(430, 36);
            this._captionPanel.TabIndex = 7;
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
            this.Controls.Add(this._captionPanel);
            this.Controls.Add(this._sidebarPanel);
            this.Controls.Add(this._buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan product";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._sidebarPanel.ResumeLayout(false);
            this._captionPanel.ResumeLayout(false);
            this._buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.TreeView _pageTreeView;
        private TopEdgePanel _buttonsPanel;
        private System.Windows.Forms.Label _captionLabel;
        private System.Windows.Forms.Panel _sidebarPanel;
        private System.Windows.Forms.Panel _captionPanel;
    }
}