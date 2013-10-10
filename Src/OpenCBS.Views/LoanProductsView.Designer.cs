namespace OpenCBS.Views
{
    partial class LoanProductsView
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
            this._buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._editButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._addButton);
            this._buttonsPanel.Controls.Add(this._editButton);
            this._buttonsPanel.Controls.Add(this._deleteButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._buttonsPanel.Location = new System.Drawing.Point(701, 0);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(172, 434);
            this._buttonsPanel.TabIndex = 0;
            // 
            // _addButton
            // 
            this._addButton.AutoSize = true;
            this._addButton.Location = new System.Drawing.Point(3, 3);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(165, 26);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // _editButton
            // 
            this._editButton.AutoSize = true;
            this._editButton.Location = new System.Drawing.Point(3, 35);
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(165, 26);
            this._editButton.TabIndex = 1;
            this._editButton.Text = "Edit";
            this._editButton.UseVisualStyleBackColor = true;
            // 
            // _deleteButton
            // 
            this._deleteButton.AutoSize = true;
            this._deleteButton.Location = new System.Drawing.Point(3, 67);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(165, 26);
            this._deleteButton.TabIndex = 2;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            // 
            // LoanProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 434);
            this.Controls.Add(this._buttonsPanel);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoanProductsView";
            this.Text = "LoanProductsView";
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _buttonsPanel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.Button _deleteButton;

    }
}