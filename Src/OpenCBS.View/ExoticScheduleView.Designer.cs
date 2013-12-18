namespace OpenCBS.View
{
    partial class ExoticScheduleView
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
            this._propertiesPanel = new System.Windows.Forms.Panel();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._scheduleButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._moveUpButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._itemsListView = new BrightIdeasSoftware.ObjectListView();
            this._numberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._principalPercentageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._interestPercentageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._buttonsPanel.SuspendLayout();
            this._propertiesPanel.SuspendLayout();
            this._scheduleButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._itemsListView)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._cancelButton);
            this._buttonsPanel.Controls.Add(this._okButton);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(0, 290);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(552, 53);
            this._buttonsPanel.TabIndex = 101;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Location = new System.Drawing.Point(440, 13);
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
            this._okButton.Location = new System.Drawing.Point(333, 13);
            this._okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(100, 28);
            this._okButton.TabIndex = 101;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _propertiesPanel
            // 
            this._propertiesPanel.Controls.Add(this._nameTextBox);
            this._propertiesPanel.Controls.Add(this._nameLabel);
            this._propertiesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._propertiesPanel.Location = new System.Drawing.Point(0, 0);
            this._propertiesPanel.Name = "_propertiesPanel";
            this._propertiesPanel.Size = new System.Drawing.Size(552, 44);
            this._propertiesPanel.TabIndex = 102;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(120, 12);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(191, 23);
            this._nameTextBox.TabIndex = 1;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 15);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(39, 15);
            this._nameLabel.TabIndex = 0;
            this._nameLabel.Text = "Name";
            // 
            // _scheduleButtonsPanel
            // 
            this._scheduleButtonsPanel.Controls.Add(this._addButton);
            this._scheduleButtonsPanel.Controls.Add(this._deleteButton);
            this._scheduleButtonsPanel.Controls.Add(this._moveUpButton);
            this._scheduleButtonsPanel.Controls.Add(this.button1);
            this._scheduleButtonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._scheduleButtonsPanel.Location = new System.Drawing.Point(411, 44);
            this._scheduleButtonsPanel.Name = "_scheduleButtonsPanel";
            this._scheduleButtonsPanel.Size = new System.Drawing.Size(141, 246);
            this._scheduleButtonsPanel.TabIndex = 103;
            // 
            // _addButton
            // 
            this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._addButton.Location = new System.Drawing.Point(3, 2);
            this._addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(134, 28);
            this._addButton.TabIndex = 102;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // _deleteButton
            // 
            this._deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._deleteButton.Location = new System.Drawing.Point(3, 34);
            this._deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(134, 28);
            this._deleteButton.TabIndex = 103;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            // 
            // _moveUpButton
            // 
            this._moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._moveUpButton.Location = new System.Drawing.Point(3, 79);
            this._moveUpButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 2);
            this._moveUpButton.Name = "_moveUpButton";
            this._moveUpButton.Size = new System.Drawing.Size(134, 28);
            this._moveUpButton.TabIndex = 104;
            this._moveUpButton.Text = "Move up";
            this._moveUpButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 111);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 28);
            this.button1.TabIndex = 105;
            this.button1.Text = "Move down";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _itemsListView
            // 
            this._itemsListView.AllColumns.Add(this._numberColumn);
            this._itemsListView.AllColumns.Add(this._principalPercentageColumn);
            this._itemsListView.AllColumns.Add(this._interestPercentageColumn);
            this._itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._numberColumn,
            this._principalPercentageColumn,
            this._interestPercentageColumn});
            this._itemsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._itemsListView.FullRowSelect = true;
            this._itemsListView.GridLines = true;
            this._itemsListView.HeaderWordWrap = true;
            this._itemsListView.HideSelection = false;
            this._itemsListView.Location = new System.Drawing.Point(0, 44);
            this._itemsListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._itemsListView.MultiSelect = false;
            this._itemsListView.Name = "_itemsListView";
            this._itemsListView.ShowGroups = false;
            this._itemsListView.Size = new System.Drawing.Size(411, 246);
            this._itemsListView.TabIndex = 104;
            this._itemsListView.UseCompatibleStateImageBehavior = false;
            this._itemsListView.View = System.Windows.Forms.View.Details;
            // 
            // _numberColumn
            // 
            this._numberColumn.AspectName = "Number";
            this._numberColumn.Text = "#";
            this._numberColumn.Width = 50;
            // 
            // _principalPercentageColumn
            // 
            this._principalPercentageColumn.AspectName = "PrincipalPercentage";
            this._principalPercentageColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._principalPercentageColumn.Text = "Principal percentage";
            this._principalPercentageColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._principalPercentageColumn.Width = 140;
            // 
            // _interestPercentageColumn
            // 
            this._interestPercentageColumn.AspectName = "IntereestPercentage";
            this._interestPercentageColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._interestPercentageColumn.Text = "Interest percentage";
            this._interestPercentageColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._interestPercentageColumn.Width = 140;
            // 
            // ExoticScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 343);
            this.Controls.Add(this._itemsListView);
            this.Controls.Add(this._scheduleButtonsPanel);
            this.Controls.Add(this._propertiesPanel);
            this.Controls.Add(this._buttonsPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExoticScheduleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exotic schedule";
            this._buttonsPanel.ResumeLayout(false);
            this._propertiesPanel.ResumeLayout(false);
            this._propertiesPanel.PerformLayout();
            this._scheduleButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._itemsListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TopEdgePanel _buttonsPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Panel _propertiesPanel;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.FlowLayoutPanel _scheduleButtonsPanel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _moveUpButton;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.ObjectListView _itemsListView;
        private BrightIdeasSoftware.OLVColumn _numberColumn;
        private BrightIdeasSoftware.OLVColumn _principalPercentageColumn;
        private BrightIdeasSoftware.OLVColumn _interestPercentageColumn;
    }
}