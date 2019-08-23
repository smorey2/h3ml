namespace Browser.Forms
{
    partial class BrowserForm
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
            this._view = new Browser.Forms.HtmlControl();
            this._toolbar = new Browser.Forms.ToolbarControl();
            this._console = new Browser.Forms.ConsoleControl();
            this.SuspendLayout();
            // 
            // _view
            // 
            this._view.BackColor = System.Drawing.SystemColors.Control;
            this._view.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._view.Location = new System.Drawing.Point(1, 45);
            this._view.Name = "_view";
            this._view.Size = new System.Drawing.Size(786, 217);
            this._view.TabIndex = 0;
            // 
            // _toolbar
            // 
            this._toolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._toolbar.Location = new System.Drawing.Point(1, 1);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Size = new System.Drawing.Size(786, 38);
            this._toolbar.TabIndex = 1;
            // 
            // _console
            // 
            this._console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._console.Location = new System.Drawing.Point(1, 269);
            this._console.Name = "_console";
            this._console.Size = new System.Drawing.Size(786, 218);
            this._console.TabIndex = 2;
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 488);
            this.Controls.Add(this._console);
            this.Controls.Add(this._toolbar);
            this.Controls.Add(this._view);
            this.Name = "BrowserForm";
            this.Text = "Browser";
            this.Resize += new System.EventHandler(this.BrowserForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlControl _view;
        private ToolbarControl _toolbar;
        private ConsoleControl _console;
    }
}

