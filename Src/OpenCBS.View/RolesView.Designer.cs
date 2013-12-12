namespace OpenCBS.View
{
    partial class RolesView
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
            this._rolesListView = new BrightIdeasSoftware.ObjectListView();
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._addButton = new System.Windows.Forms.Button();
            this._editButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._showDeletedCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._rolesListView)).BeginInit();
            this._buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rolesListView
            // 
            this._rolesListView.AllColumns.Add(this._nameColumn);
            this._rolesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumn});
            this._rolesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rolesListView.FullRowSelect = true;
            this._rolesListView.GridLines = true;
            this._rolesListView.HeaderWordWrap = true;
            this._rolesListView.HideSelection = false;
            this._rolesListView.Location = new System.Drawing.Point(0, 0);
            this._rolesListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._rolesListView.MultiSelect = false;
            this._rolesListView.Name = "_rolesListView";
            this._rolesListView.ShowGroups = false;
            this._rolesListView.Size = new System.Drawing.Size(625, 302);
            this._rolesListView.TabIndex = 4;
            this._rolesListView.UseCompatibleStateImageBehavior = false;
            this._rolesListView.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "Name";
            this._nameColumn.Text = "Name";
            this._nameColumn.Width = 400;
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.Controls.Add(this._addButton);
            this._buttonsPanel.Controls.Add(this._editButton);
            this._buttonsPanel.Controls.Add(this._deleteButton);
            this._buttonsPanel.Controls.Add(this._showDeletedCheckBox);
            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._buttonsPanel.Location = new System.Drawing.Point(625, 0);
            this._buttonsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(171, 302);
            this._buttonsPanel.TabIndex = 5;
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
            // RolesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 302);
            this.Controls.Add(this._rolesListView);
            this.Controls.Add(this._buttonsPanel);
            this.Name = "RolesView";
            this.Text = "Roles";
            ((System.ComponentModel.ISupportInitialize)(this._rolesListView)).EndInit();
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView _rolesListView;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private System.Windows.Forms.FlowLayoutPanel _buttonsPanel;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.CheckBox _showDeletedCheckBox;
    }
}