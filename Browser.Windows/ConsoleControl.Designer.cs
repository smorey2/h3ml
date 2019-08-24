namespace Browser.Windows
{
    partial class ConsoleControl
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
            this._splitter = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // _splitter
            // 
            this._splitter.Cursor = System.Windows.Forms.Cursors.HSplit;
            this._splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this._splitter.Location = new System.Drawing.Point(0, 0);
            this._splitter.Name = "_splitter";
            this._splitter.Size = new System.Drawing.Size(150, 3);
            this._splitter.TabIndex = 0;
            this._splitter.TabStop = false;
            this._splitter.SplitterMoving += new System.Windows.Forms.SplitterEventHandler(this.Splitter_SplitterMoving);
            // 
            // ConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._splitter);
            this.Name = "ConsoleControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter _splitter;
    }
}
