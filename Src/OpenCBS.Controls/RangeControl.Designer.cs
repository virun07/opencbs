namespace OpenCBS.Controls
{
    partial class RangeControl
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
            this._maxTextBox = new OpenCBS.Controls.AmountTextBox();
            this._minTextBox = new OpenCBS.Controls.AmountTextBox();
            this.SuspendLayout();
            // 
            // _maxTextBox
            // 
            this._maxTextBox.AllowDecimalSeparator = false;
            this._maxTextBox.Location = new System.Drawing.Point(80, 0);
            this._maxTextBox.Margin = new System.Windows.Forms.Padding(0);
            this._maxTextBox.Name = "_maxTextBox";
            this._maxTextBox.Size = new System.Drawing.Size(75, 20);
            this._maxTextBox.TabIndex = 1;
            this._maxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _minTextBox
            // 
            this._minTextBox.AllowDecimalSeparator = false;
            this._minTextBox.Location = new System.Drawing.Point(0, 0);
            this._minTextBox.Margin = new System.Windows.Forms.Padding(0);
            this._minTextBox.Name = "_minTextBox";
            this._minTextBox.Size = new System.Drawing.Size(75, 20);
            this._minTextBox.TabIndex = 0;
            this._minTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RangeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this._maxTextBox);
            this.Controls.Add(this._minTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RangeControl";
            this.Size = new System.Drawing.Size(155, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AmountTextBox _minTextBox;
        private AmountTextBox _maxTextBox;
    }
}
