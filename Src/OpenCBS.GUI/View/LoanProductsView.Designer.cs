namespace OpenCBS.GUI.View
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
            this._showDeletedCheckBox = new System.Windows.Forms.CheckBox();
            this._loanProductsListView = new BrightIdeasSoftware.ObjectListView();
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._codeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._availableForColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._schedulePolicyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._paymentFrequencyPolicyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._yearPolicyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._dateShiftPolicyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._roundingPolicyColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._loanProductsListView)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._addButton);
            this._buttonsPanel.Controls.Add(this._editButton);
            this._buttonsPanel.Controls.Add(this._deleteButton);
            this._buttonsPanel.Controls.Add(this._showDeletedCheckBox);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._buttonsPanel.Location = new System.Drawing.Point(702, 0);
            this._buttonsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(171, 407);
            this._buttonsPanel.TabIndex = 0;
            // 
            // _addButton
            // 
            this._addButton.AutoSize = true;
            this._addButton.Location = new System.Drawing.Point(3, 2);
            this._addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(164, 27);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // _editButton
            // 
            this._editButton.AutoSize = true;
            this._editButton.Location = new System.Drawing.Point(3, 33);
            this._editButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(164, 27);
            this._editButton.TabIndex = 1;
            this._editButton.Text = "Edit";
            this._editButton.UseVisualStyleBackColor = true;
            // 
            // _deleteButton
            // 
            this._deleteButton.AutoSize = true;
            this._deleteButton.Location = new System.Drawing.Point(3, 64);
            this._deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(164, 27);
            this._deleteButton.TabIndex = 2;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            // 
            // _showDeletedCheckBox
            // 
            this._showDeletedCheckBox.AutoSize = true;
            this._showDeletedCheckBox.Location = new System.Drawing.Point(3, 95);
            this._showDeletedCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._showDeletedCheckBox.Name = "_showDeletedCheckBox";
            this._showDeletedCheckBox.Size = new System.Drawing.Size(97, 19);
            this._showDeletedCheckBox.TabIndex = 3;
            this._showDeletedCheckBox.Text = "Show deleted";
            this._showDeletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _loanProductsListView
            // 
            this._loanProductsListView.AllColumns.Add(this._nameColumn);
            this._loanProductsListView.AllColumns.Add(this._codeColumn);
            this._loanProductsListView.AllColumns.Add(this._availableForColumn);
            this._loanProductsListView.AllColumns.Add(this._schedulePolicyColumn);
            this._loanProductsListView.AllColumns.Add(this._paymentFrequencyPolicyColumn);
            this._loanProductsListView.AllColumns.Add(this._yearPolicyColumn);
            this._loanProductsListView.AllColumns.Add(this._dateShiftPolicyColumn);
            this._loanProductsListView.AllColumns.Add(this._roundingPolicyColumn);
            this._loanProductsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumn,
            this._codeColumn,
            this._availableForColumn,
            this._schedulePolicyColumn,
            this._paymentFrequencyPolicyColumn,
            this._yearPolicyColumn,
            this._dateShiftPolicyColumn,
            this._roundingPolicyColumn});
            this._loanProductsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loanProductsListView.FullRowSelect = true;
            this._loanProductsListView.GridLines = true;
            this._loanProductsListView.HeaderWordWrap = true;
            this._loanProductsListView.HideSelection = false;
            this._loanProductsListView.Location = new System.Drawing.Point(0, 0);
            this._loanProductsListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._loanProductsListView.MultiSelect = false;
            this._loanProductsListView.Name = "_loanProductsListView";
            this._loanProductsListView.ShowGroups = false;
            this._loanProductsListView.Size = new System.Drawing.Size(702, 407);
            this._loanProductsListView.TabIndex = 1;
            this._loanProductsListView.UseCompatibleStateImageBehavior = false;
            this._loanProductsListView.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "Name";
            this._nameColumn.Text = "Name";
            this._nameColumn.Width = 200;
            // 
            // _codeColumn
            // 
            this._codeColumn.AspectName = "Code";
            this._codeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._codeColumn.Text = "Code";
            this._codeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._codeColumn.Width = 80;
            // 
            // _availableForColumn
            // 
            this._availableForColumn.AspectName = "AvailableFor";
            this._availableForColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._availableForColumn.Text = "Available for";
            this._availableForColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._availableForColumn.Width = 150;
            // 
            // _schedulePolicyColumn
            // 
            this._schedulePolicyColumn.AspectName = "SchedulePolicy";
            this._schedulePolicyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._schedulePolicyColumn.Text = "Schedule";
            this._schedulePolicyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._schedulePolicyColumn.Width = 150;
            // 
            // _paymentFrequencyPolicyColumn
            // 
            this._paymentFrequencyPolicyColumn.AspectName = "PaymentFrequencyPolicy";
            this._paymentFrequencyPolicyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._paymentFrequencyPolicyColumn.Text = "Payment frequency";
            this._paymentFrequencyPolicyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._paymentFrequencyPolicyColumn.Width = 150;
            // 
            // _yearPolicyColumn
            // 
            this._yearPolicyColumn.AspectName = "YearPolicy";
            this._yearPolicyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._yearPolicyColumn.Text = "Year";
            this._yearPolicyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._yearPolicyColumn.Width = 100;
            // 
            // _dateShiftPolicyColumn
            // 
            this._dateShiftPolicyColumn.AspectName = "DateShiftPolicy";
            this._dateShiftPolicyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dateShiftPolicyColumn.Text = "Date shift";
            this._dateShiftPolicyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dateShiftPolicyColumn.Width = 100;
            // 
            // _roundingPolicyColumn
            // 
            this._roundingPolicyColumn.AspectName = "RoundingPolicy";
            this._roundingPolicyColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._roundingPolicyColumn.Text = "Rounding";
            this._roundingPolicyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._roundingPolicyColumn.Width = 100;
            // 
            // LoanProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 407);
            this.Controls.Add(this._loanProductsListView);
            this.Controls.Add(this._buttonsPanel);
            this.Name = "LoanProductsView";
            this.Text = "LoanProductsView";
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._loanProductsListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _buttonsPanel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.Button _deleteButton;
        private BrightIdeasSoftware.ObjectListView _loanProductsListView;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private BrightIdeasSoftware.OLVColumn _codeColumn;
        private BrightIdeasSoftware.OLVColumn _paymentFrequencyPolicyColumn;
        private System.Windows.Forms.CheckBox _showDeletedCheckBox;
        private BrightIdeasSoftware.OLVColumn _availableForColumn;
        private BrightIdeasSoftware.OLVColumn _schedulePolicyColumn;
        private BrightIdeasSoftware.OLVColumn _yearPolicyColumn;
        private BrightIdeasSoftware.OLVColumn _dateShiftPolicyColumn;
        private BrightIdeasSoftware.OLVColumn _roundingPolicyColumn;

    }
}