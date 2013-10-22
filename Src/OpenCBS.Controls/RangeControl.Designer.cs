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
            this._minTextBox = new OpenCBS.Controls.AmountTextBox();
            this._maxTextBox = new OpenCBS.Controls.AmountTextBox();
            this.SuspendLayout();
            // 
            // _minTextBox
            // 
            this._minTextBox.Location = new System.Drawing.Point(0, 0);
            this._minTextBox.Name = "_minTextBox";
            this._minTextBox.Size = new System.Drawing.Size(100, 20);
            this._minTextBox.TabIndex = 0;
            this._minTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _maxTextBox
            // 
            this._maxTextBox.Location = new System.Drawing.Point(109, 0);
            this._maxTextBox.Name = "_maxTextBox";
            this._maxTextBox.Size = new System.Drawing.Size(100, 20);
            this._maxTextBox.TabIndex = 1;
            this._maxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this._maxTextBox);
            this.Controls.Add(this._minTextBox);
            this.Name = "RangeControl";
            this.Size = new System.Drawing.Size(212, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AmountTextBox _minTextBox;
        private AmountTextBox _maxTextBox;
    }
}
