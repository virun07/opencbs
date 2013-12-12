namespace OpenCBS.View
{
    partial class EntryFeesView
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
            this._entryFeesListView = new BrightIdeasSoftware.ObjectListView();
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._codeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._valueMinColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._valueMaxColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._rateAmountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._editButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._showDeletedCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._entryFeesListView)).BeginInit();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _entryFeesListView
            // 
            this._entryFeesListView.AllColumns.Add(this._nameColumn);
            this._entryFeesListView.AllColumns.Add(this._codeColumn);
            this._entryFeesListView.AllColumns.Add(this._valueMinColumn);
            this._entryFeesListView.AllColumns.Add(this._valueMaxColumn);
            this._entryFeesListView.AllColumns.Add(this._rateAmountColumn);
            this._entryFeesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumn,
            this._codeColumn,
            this._valueMinColumn,
            this._valueMaxColumn,
            this._rateAmountColumn});
            this._entryFeesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._entryFeesListView.FullRowSelect = true;
            this._entryFeesListView.GridLines = true;
            this._entryFeesListView.HeaderWordWrap = true;
            this._entryFeesListView.HideSelection = false;
            this._entryFeesListView.Location = new System.Drawing.Point(0, 0);
            this._entryFeesListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._entryFeesListView.MultiSelect = false;
            this._entryFeesListView.Name = "_entryFeesListView";
            this._entryFeesListView.ShowGroups = false;
            this._entryFeesListView.Size = new System.Drawing.Size(699, 376);
            this._entryFeesListView.TabIndex = 3;
            this._entryFeesListView.UseCompatibleStateImageBehavior = false;
            this._entryFeesListView.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "Name";
            this._nameColumn.Text = "Name";
            this._nameColumn.Width = 250;
            // 
            // _codeColumn
            // 
            this._codeColumn.AspectName = "Code";
            this._codeColumn.Text = "Code";
            this._codeColumn.Width = 150;
            // 
            // _valueMinColumn
            // 
            this._valueMinColumn.AspectName = "ValueMin";
            this._valueMinColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMinColumn.Text = "Value (min)";
            this._valueMinColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMinColumn.Width = 120;
            // 
            // _valueMaxColumn
            // 
            this._valueMaxColumn.AspectName = "ValueMax";
            this._valueMaxColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMaxColumn.Text = "Value (max)";
            this._valueMaxColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._valueMaxColumn.Width = 120;
            // 
            // _rateAmountColumn
            // 
            this._rateAmountColumn.AspectName = "Rate";
            this._rateAmountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._rateAmountColumn.Text = "Rate / amount";
            this._rateAmountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._rateAmountColumn.Width = 120;
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._addButton);
            this._buttonsPanel.Controls.Add(this._editButton);
            this._buttonsPanel.Controls.Add(this._deleteButton);
            this._buttonsPanel.Controls.Add(this._showDeletedCheckBox);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._buttonsPanel.Location = new System.Drawing.Point(699, 0);
            this._buttonsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(171, 376);
            this._buttonsPanel.TabIndex = 2;
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
            // EntryFeesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 376);
            this.Controls.Add(this._entryFeesListView);
            this.Controls.Add(this._buttonsPanel);
            this.Name = "EntryFeesView";
            this.Text = "Entry fees";
            ((System.ComponentModel.ISupportInitialize)(this._entryFeesListView)).EndInit();
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView _entryFeesListView;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private BrightIdeasSoftware.OLVColumn _codeColumn;
        private System.Windows.Forms.FlowLayoutPanel _buttonsPanel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.CheckBox _showDeletedCheckBox;
        private BrightIdeasSoftware.OLVColumn _valueMinColumn;
        private BrightIdeasSoftware.OLVColumn _valueMaxColumn;
        private BrightIdeasSoftware.OLVColumn _rateAmountColumn;
    }
}