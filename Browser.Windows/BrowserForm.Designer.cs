namespace Browser.Windows
{
    partial class _browser
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
            this._console = new Browser.Windows.ConsoleControl();
            this._toolbar = new Browser.Windows.ToolbarControl();
            this._view = new Browser.Windows.HtmlControl();
            this.SuspendLayout();
            // 
            // _console
            // 
            this._console.BackColor = System.Drawing.SystemColors.ControlLight;
            this._console.Location = new System.Drawing.Point(1, 269);
            this._console.Name = "_console";
            this._console.Size = new System.Drawing.Size(786, 218);
            this._console.TabIndex = 2;
            // 
            // _toolbar
            // 
            this._toolbar.BackColor = System.Drawing.SystemColors.Info;
            this._toolbar.Location = new System.Drawing.Point(0, 0);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Size = new System.Drawing.Size(786, 29);
            this._toolbar.TabIndex = 1;
            // 
            // _view
            // 
            this._view.BackColor = System.Drawing.SystemColors.Control;
            this._view.Location = new System.Drawing.Point(1, 27);
            this._view.Name = "_view";
            this._view.Size = new System.Drawing.Size(786, 245);
            this._view.TabIndex = 0;
            // 
            // _browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 488);
            this.Controls.Add(this._console);
            this.Controls.Add(this._toolbar);
            this.Controls.Add(this._view);
            this.KeyPreview = true;
            this.Name = "_browser";
            this.Text = "Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlControl _view;
        private ToolbarControl _toolbar;
        private ConsoleControl _console;
    }
}

